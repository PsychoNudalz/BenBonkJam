using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

[System.Serializable]
public class CardOptionSave
{
    [XmlAttribute("Stats")]
    public float health;
    public float bux;
    public float mood;
    public int[] requiredStatus;
    [XmlAttribute("Sequence Cards")]
    public string[] sequenceCardsAdd;
    public string[] sequenceCardsRemove;
    [XmlAttribute("Status Effect")]
    public int[] statusAdd;
    public int[] statusRemove;

    public CardOptionSave(CardOption o)
    {
        this.health = o.Health;
        this.bux = o.Bux;
        this.mood = o.Mood;
        List<int> tempInt = new List<int>();
        foreach (StatusEnum se in o.RequiredStatus)
        {
            tempInt.Add((int)se);
        }
        requiredStatus = tempInt.ToArray();
        tempInt = new List<int>();
        foreach (StatusEnum se in o.StatusAdd)
        {
            tempInt.Add((int)se);
        }
        statusAdd = tempInt.ToArray();
        tempInt = new List<int>();
        foreach (StatusEnum se in o.StatusRemove)
        {
            tempInt.Add((int)se);
        }
        statusRemove = tempInt.ToArray();

        List<string> tempString = new List<string>();
        foreach (Card c in o.SequenceCardsAdd)
        {
            tempString.Add(c.CardID);
        }
        sequenceCardsAdd = tempString.ToArray();

        tempString = new List<string>();
        foreach (Card c in o.SequenceCardsRemove)
        {
            tempString.Add(c.CardID);
        }
        sequenceCardsRemove = tempString.ToArray();

    }

    public CardOptionSave(float health, float bux, float mood, int[] requiredStatus, string[] sequenceCardsAdd, string[] sequenceCardsRemove, int[] statusAdd, int[] statusRemove)
    {
        this.health = health;
        this.bux = bux;
        this.mood = mood;
        this.requiredStatus = requiredStatus;
        this.sequenceCardsAdd = sequenceCardsAdd;
        this.sequenceCardsRemove = sequenceCardsRemove;
        this.statusAdd = statusAdd;
        this.statusRemove = statusRemove;
    }

}

[System.Serializable]
public class CardSave
{
    public string cardID;
    public string cardDetails;
    public string cardDes;
    public string headsDes;
    public string tailsDes;
    public CardOptionSave headsOption;
    public CardOptionSave tailsOption;
    public int[] ageNeeded;
    public int[] statusNeeded;
    public string cardSpriteName;

    public CardSave(string cardID, string cardDetails, string cardDes, string headsDes, string tailsDes, CardOptionSave headsOption, CardOptionSave tailsOption, int[] ageNeeded, int[] statusNeeded)
    {
        this.cardID = cardID;
        this.cardDetails = cardDetails;
        this.cardDes = cardDes;
        this.headsDes = headsDes;
        this.tailsDes = tailsDes;
        this.headsOption = headsOption;
        this.tailsOption = tailsOption;
        this.ageNeeded = ageNeeded;
        this.statusNeeded = statusNeeded;
    }

    public CardSave(Card c)
    {
        this.cardID = c.CardID;
        this.cardDes = c.CardDescriptionText;
        this.headsDes = c.HeadsDescriptionText;
        this.tailsDes = c.TailsDescriptionText;
        this.headsOption = new CardOptionSave(c.HeadsOption);
        this.tailsOption = new CardOptionSave(c.TailsOption);

        List<int> tempInt = new List<int>();
        foreach (StatusEnum se in c.AgeNeeded)
        {
            tempInt.Add((int)se);
        }
        ageNeeded = tempInt.ToArray();
        tempInt = new List<int>();
        foreach (StatusEnum se in c.StatusNeeded)
        {
            tempInt.Add((int)se);
        }
        statusNeeded = tempInt.ToArray();
        cardSpriteName = c.CardSprite.sprite.name;
    }

}
[System.Serializable]
public class AllCardsSave
{
    public CardSave[] allCardSave;

    public AllCardsSave(CardSave[] allCardSave)
    {
        this.allCardSave = allCardSave;
    }
}

