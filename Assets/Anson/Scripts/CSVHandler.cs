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
        foreach(string s in headerFormat)
        {
            retString += s + ",";
        }
        retString += "\n";

        foreach(CardSave cs in allCardsSave.allCardSave)
        {
            retString += cs.ToString() + "END\n";
        }
        //retString += "END";
        return retString;

    }

    public static AllCardsSave LoadFromCSV()
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

        List<string> loadedArray = new List<string>( loadString.Split('\n'));
        loadedArray.RemoveAt(0);
        loadedArray.RemoveAt(loadedArray.Count - 1);
        
        List<CardSave> cardSaves = new List<CardSave>();
        foreach(string s in loadedArray)
        {
            cardSaves.Add(new CardSave(s.Split(',')));
        }

        return new AllCardsSave(cardSaves.ToArray());
    }

}
