using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Sprite cardSprite;

    public int cardID;

    public string cardDescription;
    [Header("Heads")]
    public float healthHeads;
    public float moodHeads;
    public float buxHeads;
    [SerializeField] List<Card> sequenceCardsHeads;
    [Header("Tails")]
    public float healthTails;
    public float moodTails;
    public float buxTails;
    [SerializeField] List<Card> sequenceCardsTails;

    [Space]
    public bool heads;
    public bool tails;
    public bool cardMustBePlayed;

    [Header("Condition")]
    public bool useCondition = false;
    public List<AgeEnum> ageEnum;
    public List<cardStatus> cardStatuses;

    public List<Card> SequenceCardsTails { get => sequenceCardsTails;}
    public List<Card> SequenceCardsHeads { get => sequenceCardsHeads;}

    public float[] GetHeadsResults()
    {
        return new float[] {healthHeads, moodHeads, buxHeads};
    }

    public float[] GetTailsResults()
    {
        return new float[] { healthTails, moodTails, buxTails };
    }




}
