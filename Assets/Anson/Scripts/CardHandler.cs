using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandler : MonoBehaviour
{
    [SerializeField] List<Card> allCards;
    [Header("Start Controls")]
    [SerializeField] bool runUpdateCardID;

    private void Start()
    {
        UpdateCardIDs();
    }

    void UpdateCardIDs()
    {
        CardManager.ResetCounters();
        foreach (Card c in allCards)
        {
            c.CardID = CardManager.GetIDValue(c);
        }
    }
}
