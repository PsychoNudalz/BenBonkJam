using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEventManager : MonoBehaviour
{
    public List<CardOLD> allCards;
    public List<CardOLD> tempCards;
    public List<CardOLD> deathCards;
    [Header("Manager")]
    [SerializeField] CardOLD currentCard;
    [SerializeField] CardOLD previousCard;
    [SerializeField] List<CardOLD> cardBuffer;
    [SerializeField] Player playerScript;
    [SerializeField] int randomPickTry = 100;
    [SerializeField] int cardCounter = 0;
    [SerializeField] int cardPerAge = 5;
    [Header("Transforms")]
    [SerializeField] Transform cardSpawnPoint;
    [SerializeField] Transform previousCardTransform;
    [Header("Button Lock")]
    [SerializeField] float lastPressTime = 10f;
    [SerializeField] float pressCooldown = 1f;
    [Header("Other Components")]
    [SerializeField] UIHandler uIHandler;
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem headsPS;
    [SerializeField] ParticleSystem tailsPS;
    [Header("Debug")]
    [SerializeField] bool runConverter;

    private void Start()
    {
        tempCards =new List<CardOLD>( allCards);
        if (!playerScript)
        {
            playerScript = FindObjectOfType<Player>();
        }
        if (!uIHandler)
        {
            uIHandler = FindObjectOfType<UIHandler>();
        }

        UpdatePlayerStatsUI();
        LoadNewCard();
        currentCard.CardEffectScript.PlaySound(CardSoundEnum.PLAY);
        randomPickTry = allCards.Count * 2;

        if (runConverter)
        {
            RunCardConversion();
        }
    }

    public void LoadNewCard()
    {
        UpdatePlayerStatsUI();
        if (currentCard!= null&& currentCard.ageEnum.Contains(AgeEnum.DEATH))
        {
            FindObjectOfType<GameManagerScript>().setGameOver();
        }
        if (cardCounter >= cardPerAge && cardBuffer.Count == 0)
        {
            AgePlayer();
        }
        CardOLD newCard = null;

        //Death Card
        if (playerScript.age.Equals(AgeEnum.DEATH))
        {
            tempCards = new List<CardOLD>();
            cardBuffer = new List<CardOLD>(deathCards);
        }


        if (cardBuffer.Count > 0)
        {
            newCard = NextBufferCard();
        }
        else if (tempCards.Count == 0 && playerScript.age.Equals(AgeEnum.DEATH))
        {
            FindObjectOfType<GameManagerScript>().setGameOver();
        }
        if (newCard == null)
        {
            newCard = NewRandomCard();
            if (!newCard)
            {
                if (AgePlayer())
                {
                    LoadNewCard();

                }
                return;
            }
            if (playerScript.age.Equals(AgeEnum.DEATH))
            {
                tempCards = new List<CardOLD>();
            }
        }

        SetNewCard(newCard);
        //PlayCardSound(CardSoundEnum.PLAY);
    }


    private bool AgePlayer()
    {
        playerScript.Older();
        cardCounter = 0;
        UpdatePlayerStatsUI();

        return !playerScript.age.Equals(AgeEnum.DEATH);
    }
    private CardOLD NextBufferCard()
    {
        CardOLD newCard = null;
        while (!CanPlay(newCard, playerScript) && cardBuffer.Count > 0)
        {
            newCard = cardBuffer[0];
            cardBuffer.RemoveAt(0);
        }
        if (!CanPlay(newCard, playerScript) && cardBuffer.Count == 0)
        {
            newCard = null;
        }
        return newCard;
    }

    private CardOLD NewRandomCard()
    {
        CardOLD newCard = PickRandomCard();
        if (!newCard)
        {
            Debug.LogError("card deck empty");
            return null;
        }
        int i = randomPickTry;
        while (!CanPlay(newCard, playerScript) && i > 0)
        {
            newCard = PickRandomCard();
            i--;
        }
        if (i <= 0)
        {
            Debug.LogWarning("Failed to pick random card");
            return null;
        }
        cardCounter++;
        return newCard;
    }

    public CardOLD PickRandomCard()
    {
        if (tempCards.Count == 0)
        {
            return null;
        }
        return tempCards[Random.Range(0, tempCards.Count) % tempCards.Count];
    }


    bool CanPlay(CardOLD card, Player playerStats)
    {
        if (card == null)
        {
            return false;
        }
        foreach (StatusEnum s in card.cardStatuses)
        {
            if (!playerScript.status.currentstatus.Contains(s))
            {
                return false;
            }

        }
        if (card.ageEnum.Count == 0)
        {
            return !playerScript.age.Equals(AgeEnum.DEATH);
        }
        if (!card.ageEnum.Contains(playerScript.age))
        {
            return false;
        }
        return true;
    }

    void SetNewCard(CardOLD newCard)
    {
        if (previousCard)
        {
            Destroy(previousCard.gameObject);

        }
        if (currentCard)
        {
            previousCard = currentCard;
            previousCard.transform.parent = previousCardTransform;
            previousCard.transform.position = previousCardTransform.position;
            animator.SetTrigger("Next");
        }

        tempCards.Remove(newCard);
        currentCard = Instantiate(newCard.gameObject, cardSpawnPoint.position, Quaternion.identity, cardSpawnPoint).GetComponent<CardOLD>();

    }

    void PlayCard(float[] values, List<CardOLD> sequence, List<CardOLD> removeSequence, List<StatusEnum> AddStatus, List<StatusEnum> RemoveStatus, List<StatusEnum> requiredStatus)
    {
        foreach (StatusEnum se in requiredStatus)
        {
            if (!playerScript.status.currentstatus.Contains(se))
            {
                return;
            }
        }

        ModifyPlayerStats(values);
        if (sequence.Count > 0)
        {
            WipeBuffer();
            cardBuffer.AddRange(sequence);
        }

        if (removeSequence.Count > 0)
        {
            RemoveFromBuffer(removeSequence);
        }

        if (AddStatus.Count > 0)
        {
            foreach (StatusEnum addS in AddStatus)
            {
                playerScript.AddStatus(addS);
            }
        }
        if (RemoveStatus.Count > 0)
        {
            foreach (StatusEnum remS in RemoveStatus)
            {
                playerScript.RemoveStatus(remS);
            }
        }
        lastPressTime = Time.time;

    }

    private void ModifyPlayerStats(float[] values)
    {
        if (playerScript.heal(values[0]) || playerScript.GainBux(values[1]) || playerScript.GainMood(values[2]))
        {
            //if player death
            playerScript.SetAge((int)AgeEnum.DEATH);
            FindObjectOfType<CameraShake>().PlayShake(.3f, .4f);
        }
        uIHandler.PlayStatsParticles(StatsType.HEALTH, values[0]);
        uIHandler.PlayStatsParticles(StatsType.BUX, values[1]);
        uIHandler.PlayStatsParticles(StatsType.MOOD, values[2]);
    }

    public void Play_Heads()
    {
        if (Time.time < lastPressTime + pressCooldown)
        {
            return;
        }

        PlayCard(currentCard.GetHeadsResults(), currentCard.SequenceCardsHeads, currentCard.RemoveSequenceCardsHeads, currentCard.AddStatusHeads, currentCard.RemoveStatusHeads, currentCard.RequoredStatusHeads);
        PlayCardSound(CardSoundEnum.HEADS);
        headsPS.Stop();
        headsPS.Play();
        UpdatePlayerStatsUI();
        LoadNewCard();
    }
    public void Play_Tails()
    {
        if (Time.time < lastPressTime + pressCooldown)
        {
            return;
        }
        PlayCard(currentCard.GetTailsResults(), currentCard.SequenceCardsTails, currentCard.RemoveSequenceCardsTails, currentCard.AddStatusTails, currentCard.RemoveStatusTails, currentCard.RequoredStatusTails);
        PlayCardSound(CardSoundEnum.TAILS);
        tailsPS.Stop();
        tailsPS.Play();
        UpdatePlayerStatsUI();
        LoadNewCard();
    }
    public void Play_Coin(CoinSide side)
    {
        switch (side)
        {
            case CoinSide.HEADS:
                Play_Heads();
                break;
            case CoinSide.TAILS:
                Play_Tails();
                break;
        }
    }

    void UpdatePlayerStatsUI()
    {
        uIHandler.UpdateStats(playerScript);
    }

    void RemoveFromBuffer(List<CardOLD> cards)
    {
        foreach (CardOLD c in cards)
        {
            if (cardBuffer.Contains(c))
            {
                cardBuffer.Remove(c);
            }
        }
    }

    void WipeBuffer()
    {
        cardBuffer = new List<CardOLD>();
    }

    void PlayCardSound(CardSoundEnum c)
    {
        try
        {
            currentCard.CardEffectScript.PlaySound(c);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to play card sound");
        }
    }


    //CARD CONVERSION
    Card RunCardConversion(CardOLD oldC, Card newC)
    {
        if (newC.PortOldToNew(oldC))
        {
            return newC;
        }
        return null;
    }

    void RunCardConversion()
    {
        bool flag = true;
        List<CardOLD> newTempCards = new List<CardOLD>();
        newTempCards.AddRange(allCards);
        newTempCards.AddRange(deathCards);
        CardOLD currentCard;
        for(int i = 0; i < newTempCards.Count && flag; i++)
        {
            currentCard = newTempCards[i];
            Debug.Log(currentCard.cardDescription);
            if (!currentCard.TryGetComponent(out Card newCom))
            {
                newCom = currentCard.gameObject.AddComponent<Card>();
            }
            flag = (RunCardConversion(currentCard,newCom)) != null;
        }
        if (!flag)
        {
            Debug.LogError("Fail to port");
        }
    }
}