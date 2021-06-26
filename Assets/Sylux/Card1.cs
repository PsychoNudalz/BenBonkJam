using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Sprite cardSprite;

    public string cardDescription;

    public float healthHeads;
    public float moodHeads;
    public float buxHeads;
    public float healthTails;
    public float moodTails;
    public float buxTails;

    public bool heads;
    public bool tails;
    public bool cardMustBePlayed;
    

    public enum cardType
    {
        Baby,
        Childhood,
        Adolescence,
        Adult,
        OldAge,
        Death,
    }

    public int cardID;


    float[] GetHeadsResults()
    {
        return new float[] {healthHeads, moodHeads, buxHeads};
    }

    float[] GetTailsResults()
    {
        return new float[] { healthTails, moodTails, buxTails };
    }

}
