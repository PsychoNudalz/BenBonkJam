using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEventManager : MonoBehaviour
{
    public List<Card> allCards;
    [Header("Manager")]
    [SerializeField] Card currentCard;
    [SerializeField] List<Card> cardBuffer;
    [SerializeField] Player playerScript;
}
