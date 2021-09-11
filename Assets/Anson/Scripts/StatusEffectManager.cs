using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



public class StatusEffectManager : MonoBehaviour
{
    static string headerFormat = "Status Effect,Heath Gain,Bux Gain,Mood Gain,Health Lost,Bux Lost,Mood Lost,Health Passive,Bux Passive,Mood Passive";

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
                allSatusEffect.Add(new StatusEffect(e, 0, 0, 0, 0, 0, 0, 0, 0, 0, null, ""));
            }
        }


        //if (updateCSV)
        //{
        //    SaveModificationToCSV();
        //}
        //else
        //{
        //    LoadModifiersFromCSV();
        //}
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

    [ContextMenu("Load Modifiers from CSV")]
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
        loadedArray.RemoveAt(0);
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
                    getSE.HealthPos = int.Parse(stringSplit[1]);
                    getSE.BuxPos = int.Parse(stringSplit[2]);
                    getSE.MoodPos = int.Parse(stringSplit[3]);
                    getSE.HealthNeg = int.Parse(stringSplit[4]);
                    getSE.BuxNeg = int.Parse(stringSplit[5]);
                    getSE.MoodNeg = int.Parse(stringSplit[6]);
                    getSE.HealthPassive = float.Parse(stringSplit[7]);
                    getSE.BuxPassive = float.Parse(stringSplit[8]);
                    getSE.MoodPassive = float.Parse(stringSplit[9]);
                    //getSE.description = stringSplit[10];
                }
            }

        }

        return;
    }

    [ContextMenu("Save Modifiers from CSV")]

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
        string temp = headerFormat + "\n";
        foreach (StatusEffect se in allSatusEffect)
        {
            temp += se.ToString() + "\n";
        }

        return temp;
    }

}
