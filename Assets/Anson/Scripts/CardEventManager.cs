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
        Card newCard;
        if (cardBuffer.Count > 0)
        {
            newCard = cardBuffer[0];
            cardBuffer.RemoveAt(0);
        }
        else
        {
        newCard= NewRandomCard();

        }
        SetNewCard(newCard);

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
        return newCard;
    }

    public Card PickRandomCard()
    {
        if (tempCards.Count == 0)
        {
            return null;
        }
        return tempCards[Random.Range(0, tempCards.Count)% tempCards.Count];
    }


    bool CanPlay(Card card, Player playerStats)
    {
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
        currentCard = Instantiate(newCard.gameObject,cardSpawnPoint.position,Quaternion.identity).GetComponent<Card>();

    }

    void PlayCard(float[] values, List<Card> sequence)
    {
        playerScript.heal(values[0]);
        playerScript.GainBux(values[1]);
        playerScript.GainMood(values[2]);
        if (sequence.Count > 0)
        {
            WipeBuffer();
            cardBuffer.AddRange(sequence);
        }
        UpdatePlayerStatsUI();
        LoadNewCard();

    }

    public void Play_Heads()
    {
        print("Player Heads");
        PlayCard(currentCard.GetHeadsResults(), currentCard.SequenceCardsHeads);
    }
    public void Play_Tails()
    {
        print("Player Tails");
        PlayCard(currentCard.GetTailsResults(), currentCard.SequenceCardsTails);
    }

    void UpdatePlayerStatsUI()
    {
        uIHandler.UpdateStats(playerScript.HealthPoints, playerScript.BuxPoint, playerScript.MoodPoint);
    }

    void RemoveFromBuffer(List<Card> cards)
    {
        foreach(Card c in cards)
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
