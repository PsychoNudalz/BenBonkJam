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
    [Header("SpawnPoint")]
    [SerializeField] Transform cardSpawnPoint;
    [Header("Other Components")]
    [SerializeField] UIHandler uIHandler;

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
        if (cardCounter >= cardPerAge)
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
            Debug.LogError("Failed to pick random card");
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
        return true;
    }

    void SetNewCard(Card newCard)
    {
        if (currentCard)
        {
            previousCard = currentCard;
            Destroy(previousCard.gameObject);
        }
        
        tempCards.Remove(newCard);
        currentCard = Instantiate(newCard.gameObject, cardSpawnPoint.position, Quaternion.identity).GetComponent<Card>();

    }

    void PlayCard(float[] values, List<Card> sequence, List<Card> removeSequence, List<StatusEnum> AddStatus, List<StatusEnum> RemoveStatus)
    {
        playerScript.heal(values[0]);
        playerScript.GainBux(values[1]);
        playerScript.GainMood(values[2]);
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

    public void Play_Heads()
    {
        print("Player Heads");
        PlayCard(currentCard.GetHeadsResults(), currentCard.SequenceCardsHeads, currentCard.RemoveSequenceCardsHeads, currentCard.AddStatusHeads, currentCard.RemoveStatusHeads);
    }
    public void Play_Tails()
    {
        print("Player Tails");
        PlayCard(currentCard.GetTailsResults(), currentCard.SequenceCardsTails, currentCard.RemoveSequenceCardsTails, currentCard.AddStatusTails, currentCard.RemoveStatusTails);
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
}
