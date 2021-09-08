using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEventManager : MonoBehaviour
{
    public List<Card> allCards;
    public List<Card> tempCards;
    public List<Card> deathCards;
    [Header("Manager")]
    [SerializeField] public Card currentCard;
    [SerializeField] Card previousCard;
    [SerializeField] List<Card> cardBuffer;
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
    //[SerializeField] ParticleSystem headsPS;
    //[SerializeField] ParticleSystem tailsPS;
    [Header("Private")]
    [SerializeField] bool isDeathStage = false;

    [Header("Debug")]
    [SerializeField] bool runConverter;

    private void Start()
    {
        tempCards = new List<Card>(allCards);
        if (!playerScript)
        {
            playerScript = FindObjectOfType<Player>();
        }
        if (!uIHandler)
        {
            uIHandler = FindObjectOfType<UIHandler>();
        }

        UpdatePlayerStatsUI();
        if (randomPickTry == 0)
        {
            randomPickTry = allCards.Count * 2;
        }
        LoadNewCard();
        currentCard.CardEffectScript.PlaySound(CardSoundEnum.PLAY);

        AgeChangeAnimationHandler.current.PlayAnimation(playerScript.age);

        //Running conversion from old to new Card System
        if (runConverter)
        {
            RunCardConversion();
        }
        BackgroundMusicBlender.current.PlayAgeMusic(playerScript.age);
    }

    public void LoadNewCard()
    {
        UpdatePlayerStatsUI();

        Card newCard = null;

        if (currentCard && currentCard.IsEnding)
        {
            CallGameOver();
            return;
        }


        isDeathStage = isDeathStage || playerScript.age.Equals(AgeEnum.DEAD);

        if (cardBuffer.Count == 0 && (cardCounter >= cardPerAge || isDeathStage))
        {
            if (AgePlayer() && !isDeathStage)
            {
                Debug.LogError("Tried to age player but reach maximum age");
                CallGameOver();
                return;
            }
            else
            {
                print($"Age player: {playerScript.age}");
                if (isDeathStage)
                {
                    newCard = LoadGameOverCard();
                    SetNewCard(newCard);
                    return;
                }
                else
                {
                    LoadNewCard();
                    return;
                }
            }
        }


        //Sequence Cards
        if (cardBuffer.Count > 0)
        {
            newCard = NextBufferCard();
        }


        //
        if (newCard == null)
        {
            newCard = NewRandomCard();

            //fail safe if it can't play any new cards
            if (!newCard)
            {
                if (!playerScript.age.Equals(AgeEnum.DEAD))
                {
                    cardCounter = cardPerAge + 1;
                    LoadNewCard();
                    return;
                }
            }
        }

        SetNewCard(newCard);
    }


    Card LoadGameOverCard()
    {
        tempCards = new List<Card>();
        cardBuffer = new List<Card>(deathCards);
        Card returnCard = NextBufferCard();
        cardBuffer = new List<Card>();
        return returnCard;
    }

    private void CallGameOver()
    {
        GameDataTracker.current.PostGame();

        FindObjectOfType<GameManagerScript>().setGameOver(currentCard.CardID);
    }

    private bool AgePlayer()
    {
        bool maxedAge = playerScript.Older();
        AgeChangeAnimationHandler.current.PlayAnimation(playerScript.age);
        cardCounter = 0;
        UpdatePlayerStatsUI();
        BackgroundMusicBlender.current.PlayAgeMusic(playerScript.age);

        return maxedAge;
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
        foreach (StatusEnum s in card.StatusNeeded)
        {
            if (!playerScript.status.currentstatus.Contains(s))
            {
                return false;
            }

        }
        if (card.AgeNeeded.Count == 0)
        {
            return !playerScript.age.Equals(AgeEnum.DEAD);
        }
        if (!card.AgeNeeded.Contains(playerScript.age))
        {
            return false;
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
        if (!newCard)
        {
            Debug.LogError("New card is Null");
        }
        else
        {
            tempCards.Remove(newCard);
            currentCard = Instantiate(newCard.gameObject, cardSpawnPoint.position, Quaternion.identity, cardSpawnPoint).GetComponent<Card>();
            //currentCard.CardEffectScript.PlaySound(CardSoundEnum.PLAY);

            Debug.Log($"New Card: {currentCard.CardID}");
        }


    }


    //void PlayCard(float[] values, List<Card> sequence, List<Card> removeSequence, List<StatusEnum> AddStatus, List<StatusEnum> RemoveStatus, List<StatusEnum> requiredStatus)
    //{
    //    foreach (StatusEnum se in requiredStatus)
    //    {
    //        if (!playerScript.status.currentstatus.Contains(se))
    //        {
    //            return;
    //        }
    //    }

    //    ModifyPlayerStats(values);
    //    if (sequence.Count > 0)
    //    {
    //        WipeBuffer();
    //        cardBuffer.AddRange(sequence);
    //    }

    //    if (removeSequence.Count > 0)
    //    {
    //        RemoveFromBuffer(removeSequence);
    //    }

    //    if (AddStatus.Count > 0)
    //    {
    //        foreach (StatusEnum addS in AddStatus)
    //        {
    //            playerScript.AddStatus(addS);
    //        }
    //    }
    //    if (RemoveStatus.Count > 0)
    //    {
    //        foreach (StatusEnum remS in RemoveStatus)
    //        {
    //            playerScript.RemoveStatus(remS);
    //        }
    //    }
    //    lastPressTime = Time.time;

    //}


    /// <summary>
    /// plays the card option
    /// true if player dies
    /// </summary>
    /// <param name="cardOption"></param>
    /// <returns>true if player dies</returns>
    bool PlayCard(CardOption cardOption)
    {
        float[] values = cardOption.GetStatsResults();
        List<Card> sequence = cardOption.SequenceCardsAdd;
        List<Card> removeSequence = cardOption.SequenceCardsRemove;
        List<StatusEnum> AddStatus = cardOption.StatusAdd;
        List<StatusEnum> RemoveStatus = cardOption.StatusRemove;
        List<StatusEnum> requiredStatus = cardOption.RequiredStatus;

        GameDataTracker.current.CheckIsDeathCard();
        GameDataTracker.current.CheckIsAchievementPerTurn();

        foreach (StatusEnum se in requiredStatus)
        {
            if (!playerScript.status.currentstatus.Contains(se))
            {
                return false;
            }
        }

        isDeathStage = ModifyPlayerStats(values);
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

        return true;
    }

    /// <summary>
    /// Modify the player stats
    /// return true if the player dies
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    private bool ModifyPlayerStats(float[] values)
    {
        //print("Modify Stats");
        uIHandler.PlayStatsParticles(StatsType.HEALTH, values[0]);
        uIHandler.PlayStatsParticles(StatsType.BUX, values[1]);
        uIHandler.PlayStatsParticles(StatsType.MOOD, values[2]);

        if (playerScript.GainHealth(values[0]) || playerScript.GainBux(values[1]) || playerScript.GainMood(values[2]))
        {
            //if player DEAD
            playerScript.SetAge((int)AgeEnum.DEAD);
            FindObjectOfType<CameraShake>().PlayShake(.3f, .4f);
            return true;
        }
        PlayerPassiveGain();
        return false;
    }

    void PlayerPassiveGain()
    {
        //print("Passive Gain");
        float[] passiveArray = playerScript.PassiveGain();
        uIHandler.PlayStatsParticles(StatsType.HEALTH, passiveArray[0]);
        uIHandler.PlayStatsParticles(StatsType.BUX, passiveArray[1]);
        uIHandler.PlayStatsParticles(StatsType.MOOD, passiveArray[2]);
    }


    public void Play_Heads()
    {
        if (Time.time < lastPressTime + pressCooldown)
        {
            return;
        }

        //PlayCard(currentCard.GetHeadsResults(), currentCard.SequenceCardsHeads, currentCard.RemoveSequenceCardsHeads, currentCard.AddStatusHeads, currentCard.RemoveStatusHeads, currentCard.RequoredStatusHeads);
        PlayCard(currentCard.HeadsOption);
        //PlayCardSound(CardSoundEnum.HEADS);
        currentCard.CardEffectScript.PlayHeads();
        UpdatePlayerStatsUI();
        LoadNewCard();
    }
    public void Play_Tails()
    {
        if (Time.time < lastPressTime + pressCooldown)
        {
            return;
        }
        //PlayCard(currentCard.GetTailsResults(), currentCard.SequenceCardsTails, currentCard.RemoveSequenceCardsTails, currentCard.AddStatusTails, currentCard.RemoveStatusTails, currentCard.RequoredStatusTails);
        PlayCard(currentCard.TailsOption);
        //PlayCardSound(CardSoundEnum.TAILS);
        currentCard.CardEffectScript.PlayTails();
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
        List<Card> newTempCards = new List<Card>();
        newTempCards.AddRange(allCards);
        newTempCards.AddRange(deathCards);
        CardOLD currentCard;
        for (int i = 0; i < newTempCards.Count && flag; i++)
        {
            currentCard = newTempCards[i].GetComponent<CardOLD>();
            Debug.Log(currentCard.cardDescription);
            if (!currentCard.TryGetComponent(out Card newCom))
            {
                newCom = currentCard.gameObject.AddComponent<Card>();
            }
            flag = (RunCardConversion(currentCard, newCom)) != null;
        }
        if (!flag)
        {
            Debug.LogError("Fail to port");
        }
    }

    public void Animation_PlaySound()
    {
        currentCard.CardEffectScript.PlaySound(CardSoundEnum.PLAY);
    }
}