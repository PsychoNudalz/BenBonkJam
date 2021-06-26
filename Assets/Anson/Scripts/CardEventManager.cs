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
    //[SerializeField] List<Card> cardBuffer;
    [SerializeField] Player playerScript;
    [SerializeField] int randomPickTry = 50;
    [Header("SpawnPoint")]
    [SerializeField] Transform cardSpawnPoint;

    private void Start()
    {
        tempCards = allCards;
    }

    public void LoadNewCard()
    {
        Card newCard  = PickRandomCard();
        if (!newCard)
        {
            Debug.LogError("card deck empty");
            return;
        }
        int i = randomPickTry;
        while (!CanPlay(newCard, playerScript)&& i>0)
        {
            newCard = PickRandomCard();
            i--;
        }
        if (i <= 0)
        {
            Debug.LogError("Failed to pick random card");
            return;
        }
        SetNewCard(newCard);
        

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
        if (!card.ageEnum.Contains(playerScript.ageEnum))
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
}
