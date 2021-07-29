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

    public CardOptionSave(string[] s)
    {
        try
        {
        this.health = int.Parse(s[0]);
        this.bux = int.Parse(s[1]);
        this.mood = int.Parse(s[2]);
        this.requiredStatus = FileLoader.StringSplitToInt(s[3], '/');
        this.sequenceCardsAdd = s[4].Split('/');
        this.sequenceCardsRemove = s[5].Split('/');
        this.statusAdd = FileLoader.StringSplitToInt(s[6], '/');
        this.statusRemove = FileLoader.StringSplitToInt(s[7], '/');
        }catch(System.FormatException e)
        {
            Debug.LogError($"card option save parse error {s[0]}");
            foreach(string x in s)
            {

            Debug.LogWarning(x);
            }
            Debug.LogError(e.StackTrace);
        }

    }

    public override string ToString()
    {
        string retString = "";
        retString += health + ",";
        retString += bux + ",";
        retString += mood + ",";
        foreach (int i in requiredStatus)
        {
            retString += i + "/";
        }
        retString += ",";
        foreach (string i in sequenceCardsAdd)
        {
            retString += i + "/";
        }
        retString += ",";
        foreach (string i in sequenceCardsRemove)
        {
            retString += i + "/";
        }
        retString += ",";
        foreach (int i in statusAdd)
        {
            retString += i + "/";
        }
        retString += ",";
        foreach (int i in statusRemove)
        {
            retString += i + "/";
        }
        retString += ",";
        return retString;
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
    public CardSave()
    {
        this.cardID = "Empty";
        this.cardDetails = "Empty";
        this.cardDes = "Empty";
        this.headsDes = "Empty";
        this.tailsDes = "Empty";
        this.headsOption = null;
        this.tailsOption = null;
        this.ageNeeded = null;
        this.statusNeeded = null;
    }

    public CardSave(Card c)
    {
        this.cardID = c.CardID;
        this.cardDetails = c.CardDetails;
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
        try
        {
            cardSpriteName = c.CardSprite.sprite.name;
        }
        catch (System.NullReferenceException e)
        {
            Debug.LogError($"{cardID} missing sprite");
        }
    }

    public CardSave(string[] s)
    {
        if (s.Length < 20)
        {
            
            return;
        }
        string loadString = "";
        foreach(string x in s)
        {
            loadString += x + ",";
        }
        //Debug.Log("loading string: "+loadString);


        this.cardID = s[0];
        Debug.Log("Loading Card: "+cardID);

        this.cardDetails = s[1];
        this.ageNeeded = FileLoader.StringSplitToInt(s[2], '/');
        this.statusNeeded = FileLoader.StringSplitToInt(s[3], '/');
        this.cardSpriteName = s[4];
        this.cardDes = s[5];

        //Debug.Log("Loading Head");
        this.headsDes = s[6];
        List<string> subArray = new List<string>(s);
        this.headsOption = new CardOptionSave(subArray.GetRange(7, 8).ToArray());// 7,14

        //Debug.Log("Loading Tails");
        this.tailsDes = s[15];
        this.tailsOption = new CardOptionSave(subArray.GetRange(16, 8).ToArray());
    }

    public override string ToString()
    {
        string retString = "";
        retString += cardID + ",";
        retString += cardDetails + ",";
        foreach (int i in ageNeeded)
        {
            retString += i + "/";
        }
        retString += ",";
        foreach (int i in statusNeeded)
        {
            retString += i + "/";
        }
        retString += ",";
        retString += cardSpriteName + ",";


        retString += cardDes.Replace("\n", " ").Replace("\r", " ").Replace(",", " ") + ",";
        retString += headsDes.Replace("\n", " ").Replace("\r", " ").Replace(",", " ") + ",";
        retString += headsOption.ToString();
        retString += tailsDes.Replace("\n", " ").Replace("\r", " ").Replace(",", " ") + ",";
        retString += tailsOption.ToString();
        retString = retString.Replace("\n", " ").Replace("\r", " ");
        if (retString.Contains("\n"))
        {
            Debug.LogError($"Found paragraph in to string: {cardID}");
        }
        return retString;
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

