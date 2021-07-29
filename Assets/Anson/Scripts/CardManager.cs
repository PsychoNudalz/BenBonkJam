using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardManager
{
    //card id
    //all card counter
    private static int[] counters = { 0, 0, 0, 0, 0, 0, 0 };

    public static int[] Counters { get => counters; }

    public static void ResetCounters()
    {
        Debug.LogWarning("Reseting: " + GetCounterString());
        counters = new int[] { 0, 0, 0, 0, 0, 0, 0 };
    }

    public static string GetIDValue(Card c)
    {
        string temp = "";
        if (c.AgeNeeded.Count > 0)
        {
            temp += GetAgeShortString((int)c.AgeNeeded[0]) + "_";
            temp += counters[(int)c.AgeNeeded[0]].ToString() + "_";
            counters[(int)c.AgeNeeded[0]]++;
        }
        else
        {
            temp += GetAgeShortString(7) + "_";
            temp += counters[6].ToString() + "_";
            counters[6]++;
        }

        return temp;
    }

    public static string GetAgeShortString(int ageInt)
    {
        if (ageInt < 6)
        {
            AgeEnum ageEnum = (AgeEnum)ageInt;
            return ageEnum.ToString().Substring(0, 3).ToUpper();
        }
        else
        {
            return "GEN";
        }
    }

    public static string GetAgeFolderString(int ageInt)
    {
        if (ageInt < 6)
        {
            AgeEnum ageEnum = (AgeEnum)ageInt;
            switch (ageEnum)
            {
                case AgeEnum.INFANCY:
                    return "Infancy";
                case AgeEnum.CHILDHOOD:
                    return "Childhood";

                case AgeEnum.ADOLESENCE:
                    return "Adolescence";

                case AgeEnum.ADULT:
                    return "Adult";

                case AgeEnum.OLDAGE:
                    return "OldAge";

                case AgeEnum.DEATH:
                    return "Death";
                default:
                    return "General";
            }
        }

        else
        {
            return "General";
        }
    }

    public static void RefreshCounter(Card[] cards)
    {
        ResetCounters();
        foreach (Card c in cards)
        {
            UpdateCounter(c.CardID);
        }
    }

    public static void RefreshCounter(CardSave[] cards)
    {
        ResetCounters();
        foreach (CardSave c in cards)
        {
            UpdateCounter(c.cardID);
        }
        Debug.Log("Card Manager Counter: " + CardManager.GetCounterString());

    }

    public static void UpdateCounter(string cardID)
    {
        string temp = cardID;
        string[] seperators = { "_" };
        string[] cardSplit;
        try
        {
            if (!cardID.Equals(""))
            {

                cardSplit = temp.Split(seperators, 2, System.StringSplitOptions.RemoveEmptyEntries);
                cardSplit[1] = cardSplit[1].Replace("_", "");
                //Debug.Log(cardSplit[0]);
                //Debug.Log(cardSplit[1]);
                for (int i = 0; i < 7; i++)
                {
                    if (GetAgeShortString(i).Equals(cardSplit[0]))
                    {
                        if (counters[i] <= int.Parse(cardSplit[1]))
                        {
                            counters[i] = int.Parse(cardSplit[1]) + 1;
                        }
                    }
                }
            }
            else
            {
                Debug.LogWarning("Empty Card ID");
            }

        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to split: " + cardID);
            Debug.LogError(e);
            return;
        }
        //Debug.Log("Counter: " + GetCounterString());
    }

    public static string GetCounterString()
    {
        string temp = "[";
        foreach (int i in counters)
        {
            temp += " " + i + ",";
        }
        temp += "]";
        return temp;
    }

}