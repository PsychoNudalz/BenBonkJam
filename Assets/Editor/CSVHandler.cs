#if (UNITY_EDITOR)

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public static class CSVHandler
{
    static string[] headerFormat = { "Card ID", "Card Details", "Ages Neede", "Status Needed", "Card Sprite Name", "Card Description",
        "Heads Description","Heads Health","Heads Bux","Heads Mood", "Heads Required Status","Heads Sequence Cards Add","Heads Sequence Cards Remove", "Heads Status Add","Heads Status Remove",
        "Tails Description","Tails Health","Tails Bux","Tails Mood", "Tails Required Status","Tails Sequence Cards Add","Tails Sequence Cards Remove", "Tails Status Add","Tails Status Remove",
        "END", "Rules: Age and stats must be in integer.  Set a card detail if description contains special characters"
    };


    public static void FromJSON(CardHandler cardHandler)
    {
        WriteToCSV(cardHandler.LoadAllCardsSave());
    }

    public static void FromExcelToJSON(CardHandler cardHandler)
    {
        cardHandler.SaveCardsToJson(LoadFromCSV());
        Debug.Log("Load from Excel complete");

    }

    public static void WriteToCSV(AllCardsSave allCardsSave)
    {
        try
        {
            File.WriteAllText(Application.dataPath + "/Resources/Data/" + "AllCards.csv", AllCardSaveToString(allCardsSave));
        }
        catch (DirectoryNotFoundException e)
        {
            Directory.CreateDirectory(Application.dataPath + "/Resources/Data/");
            File.WriteAllText(Application.dataPath + "/Resources/Data/" + "AllCards.csv", AllCardSaveToString(allCardsSave));
            return;
        }
        Debug.Log("Write to CSV Successful");
    }

    public static string AllCardSaveToString(AllCardsSave allCardsSave)
    {
        string retString = "";
        foreach (string s in headerFormat)
        {
            retString += s + ",";
        }
        retString += "\n";

        foreach (CardSave cs in allCardsSave.allCardSave)
        {
            retString += cs.ToString() + "END\n";
        }
        //retString += "END";
        return retString;

    }

    public static AllCardsSave LoadFromCSV()
    {
        List<string> loadedArray = LoadFromCSVToString();
        List<CardSave> cardSaves = new List<CardSave>();
        foreach (string s in loadedArray)
        {
            cardSaves.Add(new CardSave(s.Split(',')));
        }

        return new AllCardsSave(cardSaves.ToArray());
    }

    public static List<string> LoadFromCSVToString()
    {
        string loadString = "";
        try
        {
            loadString = File.ReadAllText(Application.dataPath + "/Resources/Data/" + "AllCards.csv");
        }
        catch (FileNotFoundException e)
        {
            Debug.LogWarning("Failed to find AllCards.csv");

            return null;
        }

        List<string> loadedArray = new List<string>(loadString.Split('\n'));
        loadedArray.RemoveAt(0);
        loadedArray.RemoveAt(loadedArray.Count - 1);
        return loadedArray;
    }


    public static string CheckCSVDuplicate(float matchThresshold)
    {
        List<string> loadedArray = LoadFromCSVToString();
        float results;
        string temp;
        string outputString = "";
        Debug.Log("Check Results:\n");
        foreach (string a in loadedArray)
        {
            foreach (string b in loadedArray)
            {
                if (!a.Equals(b))
                {
                    results = CompareRow(a, b);
                    if (results >= matchThresshold)
                    {
                        outputString += $"{a.Split(',')[0]} & {b.Split(',')[0]}: {results}";
                        Debug.Log($"{a.Split(',')[0]} & {b.Split(',')[0]}: {results}");
                    }
                }
            }
        }
        //Debug.Log(outputString);
        return outputString;
    }

    static float CompareRow(string lhs, string rhs)
    {
        string[] leftSplit = lhs.Split(',');
        string[] rightSplit = rhs.Split(',');
        float total = 0;
        int times = 0;
        if (leftSplit.Length.Equals(rightSplit.Length))
        {
            for (int i = 0; i < leftSplit.Length && i < rightSplit.Length; i++)
            {
                if (!leftSplit[i].Equals("") && !rightSplit[i].Equals(""))
                {
                    total += CompareCell(leftSplit[i], rightSplit[i]);
                    times++;
                }

            }
            if (times == 0)
            {
                times = 1;
            }
            //Debug.Log($"{total}  {times}");
            return total / times;
        }
        else
        {
            Debug.LogError($"un equal cell size for:\n{lhs} {leftSplit.Length}\n{rhs} {rightSplit.Length}\n\n");
            return 0;
        }


    }

    static float CompareCell(string lhs, string rhs)
    {
        int counter = 0;
        int maxSize = 1;
        lhs = lhs.ToLower();
        rhs = rhs.ToLower();
        for (int i = 0; i < lhs.Length && i < rhs.Length; i++)
        {
            if (lhs[i].Equals(rhs[i]))
            {
                counter++;
            }
        }
        maxSize = Mathf.Max(lhs.Length, rhs.Length);
        return (float)counter / (float)maxSize;
    }

}
#endif