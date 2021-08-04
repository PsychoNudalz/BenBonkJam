using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



public class StatusEffectManager : MonoBehaviour
{
    [SerializeField] List<StatusEffect> allSatusEffect;

    public static StatusEffectManager current;

    [Header("Debug")]
    [SerializeField] bool updateCSV;

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        foreach (StatusEnum e in System.Enum.GetValues(typeof(StatusEnum)))
        {
            if (!AllSEContains(e))
            {
                allSatusEffect.Add(new StatusEffect(e, 0, 0, 0, null, ""));
            }
        }

        if (updateCSV)
        {
            SaveModificationToCSV();
        }
        else
        {
            LoadModifiersFromCSV();
        }
    }

    public StatusEffect GetStatusEffect(StatusEnum e)
    {
        foreach (StatusEffect sep in allSatusEffect)
        {
            if (sep.Equals(e))
            {
                return sep;
            }
        }
        return null;
    }

    bool AllSEContains(StatusEnum e)
    {
        foreach (StatusEffect se in allSatusEffect)
        {
            if (se.Equals(e))
            {
                return true;
            }
        }
        return false;
    }

    StatusEffect GetSEFromString(string s)
    {
        foreach (StatusEffect se in allSatusEffect)
        {
            if (se.status.ToString().Equals(s))
            {
                return se;
            }
        }
        return null;
    }

    void LoadModifiersFromCSV()
    {
        string loadString = "";
        try
        {
            loadString = File.ReadAllText(Application.dataPath + "/Resources/Data/" + "StatusEffect.csv");
        }
        catch (FileNotFoundException e)
        {
            Debug.LogWarning("Failed to find StatusEffect.csv");

            return;
        }

        List<string> loadedArray = new List<string>(loadString.Split('\n'));
        //loadedArray.RemoveAt(0);
        //loadedArray.RemoveAt(loadedArray.Count - 1);

        List<CardSave> cardSaves = new List<CardSave>();
        string[] stringSplit;
        StatusEffect getSE;
        foreach (string s in loadedArray)
        {
            stringSplit = s.Split(',');
            if (stringSplit.Length > 0)
            {

                getSE = GetSEFromString(stringSplit[0]);
                if (getSE != null)
                {
                    getSE.Health = int.Parse(stringSplit[1]);
                    getSE.Bux = int.Parse(stringSplit[2]);
                    getSE.Mood = int.Parse(stringSplit[3]);
                }
            }

        }

        return;
    }

    void SaveModificationToCSV()
    {
        try
        {
            File.WriteAllText(Application.dataPath + "/Resources/Data/" + "StatusEffect.csv", ToString());
        }
        catch (DirectoryNotFoundException e)
        {
            Directory.CreateDirectory(Application.dataPath + "/Resources/Data/");
            File.WriteAllText(Application.dataPath + "/Resources/Data/" + "StatusEffect.csv", ToString());
            return;
        }
        Debug.Log("Write to CSV Successful");
    }


    public override string ToString()
    {
        string temp = "";
        foreach (StatusEffect se in allSatusEffect)
        {
            temp += se.ToString()+"\n";
        }

        return temp;
    }

}
