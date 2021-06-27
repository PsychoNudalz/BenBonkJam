using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEventManager : MonoBehaviour
{
    public List<Card> allCards;
    public List<Card> tempCards;
    [Header("Manager")]
    [SerializeField] Card currentCard;
    [SerializeField] Card previousCard;
    [SerializeField] List<Card> cardBuffer;
    [SerializeField] Player playerScript;
    [SerializeField] int randomPickTry = 50;
    [SerializeField] int cardCounter = 0;
    [SerializeField] int cardPerAge = 5;
    [Header("Transforms")]
    [SerializeField] Transform cardSpawnPoint;
    [SerializeField] Transform previousCardTransform;
    [Header("Other Components")]
    [SerializeField] UIHandler uIHandler;
    [SerializeField] Animator animator;

    private void Start()
    {
        tempCards = allCards;
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
    }

    public void LoadNewCard()
    {
        UpdatePlayerStatsUI();
        if (cardCounter >= cardPerAge&& cardBuffer.Count == 0)
        {
            AgePlayer();
        }
        Card newCard = null;
        
        if (cardBuffer.Count > 0)
        {
            newCard = NextBufferCard();
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
        }

        SetNewCard(newCard);
        PlayCardSound(CardSoundEnum.PLAY);
    }


    private bool AgePlayer()
    {
        playerScript.Older();
        cardCounter = 0;
        return !playerScript.age.Equals(AgeEnum.DEATH);
    }
    private Card NextBufferCard()
    {
        Card newCard = null;
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

    private Card NewRandomCard()
    {
        Card newCard = PickRandomCard();
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

    public Card PickRandomCard()
    {
        if (tempCards.Count == 0)
        {
            return null;
        }
        return tempCards[Random.Range(0, tempCards.Count) % tempCards.Count];
    }


    bool CanPlay(Card card, Player playerStats)
    {
        if (card == null)
        {
            return false;
        }
        if (!card.ageEnum.Contains(playerScript.age))
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
        return true;
    }

    void SetNewCard(Card newCard)
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
        currentCard = Instantiate(newCard.gameObject, cardSpawnPoint.position, Quaternion.identity,cardSpawnPoint).GetComponent<Card>();

    }

    void PlayCard(float[] values, List<Card> sequence, List<Card> removeSequence, List<StatusEnum> AddStatus, List<StatusEnum> RemoveStatus, List<StatusEnum> requiredStatus)
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
        UpdatePlayerStatsUI();
        LoadNewCard();

    }

    private void ModifyPlayerStats(float[] values)
    {
        playerScript.heal(values[0]);
        playerScript.GainBux(values[1]);
        playerScript.GainMood(values[2]);
        uIHandler.PlayStatsParticles(StatsType.HEALTH, values[0]);
        uIHandler.PlayStatsParticles(StatsType.BUX, values[1]);
        uIHandler.PlayStatsParticles(StatsType.MOOD, values[2]);
    }

    public void Play_Heads()
    {
        PlayCard(currentCard.GetHeadsResults(), currentCard.SequenceCardsHeads, currentCard.RemoveSequenceCardsHeads, currentCard.AddStatusHeads, currentCard.RemoveStatusHeads,currentCard.RequoredStatusHeads);
        PlayCardSound(CardSoundEnum.HEADS);
    }
    public void Play_Tails()
    {
        PlayCard(currentCard.GetTailsResults(), currentCard.SequenceCardsTails, currentCard.RemoveSequenceCardsTails, currentCard.AddStatusTails, currentCard.RemoveStatusTails, currentCard.RequoredStatusTails);
        PlayCardSound(CardSoundEnum.TAILS);
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

    void RemoveFromBuffer(List<Card> cards)
    {
        foreach (Card c in cards)
        {
            if (cardBuffer.Contains(c))
            {
                cardBuffer.Remove(c);
            }
        }
    }

    void WipeBuffer()
    {
        cardBuffer = new List<Card>();
    }
    
    void PlayCardSound(CardSoundEnum c)
    {
        try
        {
            currentCard.CardEffectScript.PlaySound(c);
        }catch(System.Exception e)
        {
            Debug.LogError("Failed to play card sound");
        }
    }
}