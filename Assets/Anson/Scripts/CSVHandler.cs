using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class CSVHandler
{
    static string[] headerFormat = { "Card ID", "Card Details", "Ages Neede", "Status Needed", "Card Sprite Name", "Card Description",
        "Heads Description","Heads Health","Heads Bux","Heads Mood", "Heads Required Status","Heads Sequence Cards Add","Heads Sequence Cards Remove", "Heads Status Add","Heads Status Remove",
        "Tails Description","Tails Health","Tails Bux","Tails Mood", "Tails Required Status","Tails Sequence Cards Add","Tails Sequence Cards Remove", "Tails Status Add","Tails Status Remove",
    };

    public static void FromJSON(CardHandler cardHandler)
    {
        WriteToCSV(cardHandler.LoadAllCardsSave());
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
            retString += cs.ToString() + "\n";
        }

        return retString;

    }

}
