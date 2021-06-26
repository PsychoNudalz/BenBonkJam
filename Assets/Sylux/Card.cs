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
    [Header("Tails")]
    public float healthTails;
    public float moodTails;
    public float buxTails;

    [Space]
    public bool heads;
    public bool tails;
    public bool cardMustBePlayed;

    public enum cardStatus
    {
        DemonicKinship,
        Married,
        AngelicBoon,
        Pet,
        Criminal,
        Gambler,
        Addict,
        Spiritual,
        Sick,
        Paranormal,
        EducatedI,
        EducatedII,
        Trained,
        Parenthood,
        Divorced,
    }

    public enum cardType
    {
        Baby,
        Childhood,
        Adolescence,
        Adult,
        OldAge,
        Death,
    }

    float[] GetHeadsResults()
    {
        return new float[] {healthHeads, moodHeads, buxHeads};
    }

    float[] GetTailsResults()
    {
        return new float[] { healthTails, moodTails, buxTails };
    }

}
