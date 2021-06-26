using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEventManager : MonoBehaviour
{
    public List<Card> allCards;
    [Header("Manager")]
    [SerializeField] Card currentCard;
    //[SerializeField] List<Card> cardBuffer;
    [SerializeField] Player playerScript;




    bool CanPlay(Card card, Player playerStats)
    {
        if (!card.ageEnum.Equals(AgeEnum.BABY))
        {
            return false;
        }
        return true;
    }
}
