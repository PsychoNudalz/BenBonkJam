using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]

public class GameDataManager : MonoBehaviour
{
    /*
    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    */
    [SerializeField] Achievements achievements = new Achievements();
    [Space(10)]
    [SerializeField] EndingsUnlocked endingsUnlocked = new EndingsUnlocked();
    [SerializeField] List<StatusEffect> statusesGained = new List<StatusEffect>();

    [SerializeField] StatusEffectsUnlocked statusEffectsUnlocked = new StatusEffectsUnlocked();


    public static GameDataManager gameDataManagerInstance;

    public Achievements Achievements1 { get => achievements; set => achievements = value; }
    public EndingsUnlocked EndingsUnlocked1 { get => endingsUnlocked; set => endingsUnlocked = value; }
    public StatusEffectsUnlocked StatusEffectsUnlocked1 { get => statusEffectsUnlocked; set => statusEffectsUnlocked = value; }

    private void Awake()
    {
        //WriteToSave();
        ReadFromSave();
        gameDataManagerInstance = this;
    }

    private void ReadFromSave()
    {
        //Load achievments
        string filePath = $"{Application.persistentDataPath}/Save/achievements.save";
        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);

            string json = (string)formatter.Deserialize(stream);
            achievements = JsonUtility.FromJson<Achievements>(json);

            stream.Close();
        }
        else
        {
            Debug.LogWarning($"Achievments File not found");
            achievements = new Achievements();
        }

        //Load endings
        filePath = $"{Application.persistentDataPath}/Save/endings.save";
        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);

            string json2 = (string)formatter.Deserialize(stream);
            endingsUnlocked = JsonUtility.FromJson<EndingsUnlocked>(json2);
            stream.Close();
            //Debug.Log("Load player Save clear");
        }
        else
        {
            Debug.LogWarning($"Endings save file not found!");
            endingsUnlocked = new EndingsUnlocked();
        }

        // load Status Effects
        
        filePath = $"{Application.persistentDataPath}/Save/statusEffects.save";
        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);

            string json3 = (string)formatter.Deserialize(stream);
            statusEffectsUnlocked = JsonUtility.FromJson<StatusEffectsUnlocked>(json3);
            stream.Close();
            //Debug.Log("Load player Save clear");
        }
        else
        {
            Debug.LogWarning($"Status Effects save file not found!");
            statusEffectsUnlocked = new StatusEffectsUnlocked();
        }

        
        /* string json = JsonUtility.ToJson(achievements);
         string json2 = JsonUtility.ToJson(endingsUnlocked);
         try
         {
             Debug.Log("Loading save progress");
             json = File.ReadAllText(Application.persistentDataPath + "/Save/achievements.json");
         }
         catch (System.Exception)
         {
             Debug.Log("Whoops");
             Directory.CreateDirectory(Application.persistentDataPath + "/Save/");
             File.WriteAllText(Application.persistentDataPath + "/Save/achievements.json", json);

             Debug.LogError("Save file error");
          //   Debug.LogError(Exception.StackTrace);

         }

         try
         {
             Debug.Log("Loading endings progress");
             json2 = File.ReadAllText(Application.persistentDataPath + "/Save/saveEndings.json");
         }
         catch (System.Exception)
         {

             Directory.CreateDirectory(Application.persistentDataPath + "/Save/");
             File.WriteAllText(Application.persistentDataPath + "/Save/saveEndings.json", json2);
             json2 = JsonUtility.ToJson(endingsUnlocked);

             Debug.LogError("Save file error");
           //  Debug.LogError(e.StackTrace);
         }

         achievements = JsonUtility.FromJson<Achievements>(json);
         endingsUnlocked = JsonUtility.FromJson<EndingsUnlocked>(json2);

         */
    }

    private void WriteToSave()
    {
        Debug.Log("Writing Player Save");

        // achievements
        BinaryFormatter formatter = new BinaryFormatter();
        /*CreateSaveDirectoryPaths();*/
        string filePath = $"{Application.persistentDataPath}/Save/achievements.save";
        FileStream stream = new FileStream(filePath, FileMode.Create);
        string json = JsonUtility.ToJson(achievements);
        formatter.Serialize(stream, json);
        stream.Close();
        Debug.Log("Saved Ach.");

        // endings
        filePath = $"{Application.persistentDataPath}/Save/endings.save";
        stream = new FileStream(filePath, FileMode.Create);
        string json2 = JsonUtility.ToJson(endingsUnlocked);
        formatter.Serialize(stream, json2);
        stream.Close();
        Debug.Log("Saved End.");

        filePath = $"{Application.persistentDataPath}/Save/statusEffects.save";
        stream = new FileStream(filePath, FileMode.Create);
        string json3 = JsonUtility.ToJson(statusEffectsUnlocked);
        formatter.Serialize(stream, json3);
        stream.Close();
        Debug.Log("Saved StatusEffects.");

        /*Debug.Log("Writing Save");

        File.WriteAllText(Application.persistentDataPath + "/Save/achievements.json", json);
        Debug.Log(Application.persistentDataPath);
        Debug.Log(json);
        


        Debug.Log("Saved Ach.");

        File.WriteAllText(Application.persistentDataPath + "/Save/saveEndings.json", json2);
        Debug.Log(Application.persistentDataPath);
        Debug.Log(json2);
        

        Debug.Log("Saved End.");*/


        //  Achievements loadedAchievements = JsonUtility.FromJson<Achievements>(json);
        //  EndingsUnlocked loadedEndingsUnlocked = JsonUtility.FromJson<EndingsUnlocked>(json);
    }

    public void SaveGame()
    {
        WriteToSave();
        Debug.Log("Save complete");
    }

    [System.Serializable]

    // achievements class contains BOTH, the statistics information and the achievements information
    public class Achievements
    {
        // achievements
        /*
        public bool die50Times = false;
        public bool gradeSObtained = false;
        public bool statusEffects10Obtained = false;
        public bool educationMaxedOut = false;
        public bool oldAgeObtained = false;
        public bool adoptAllPossibleAnimals = false;
        public bool dieAsABaby = false;
        public bool dieAtOldAgeWith100Mood = false;
        public bool dieAtOldAgeWith100Bux = false;
        public bool haveChildren = false;
        public bool getScammed = false;

        */

        public List<AchievementEnum> earnedAchievements = new List<AchievementEnum>();

        // stats
        public int timesDied;
        public int easterEggsFound;
        public int endingsFound;
        public int uniqueCardsDiscovered;

        public Achievements(int timesDied, int easterEggsFound, int endingsFound, int uniqueCardsDiscovered,
            bool gradeSObtained, bool statusEffects10Obtained, bool educationMaxedOut, bool oldAgeObtained, bool die50Times)
        {
            this.timesDied = timesDied;
            this.easterEggsFound = easterEggsFound;
            this.endingsFound = endingsFound;
            this.uniqueCardsDiscovered = uniqueCardsDiscovered;
            /*
            this.gradeSObtained = gradeSObtained;
            this.statusEffects10Obtained = statusEffects10Obtained;
            this.educationMaxedOut = educationMaxedOut;
            this.oldAgeObtained = oldAgeObtained;
            this.die50Times = die50Times;
            */
        }

        public Achievements()
        {
            this.timesDied = 0;
            this.easterEggsFound = 0;
            this.endingsFound = 0;
            this.uniqueCardsDiscovered = 0;
            /*
            this.gradeSObtained = false;
            this.statusEffects10Obtained = false;
            this.educationMaxedOut = false;
            this.oldAgeObtained = false;
            this.die50Times = false;
            */
        }

        public void AddAchievement(AchievementEnum ae)
        {
            if (!earnedAchievements.Contains(ae))
            {
                earnedAchievements.Add(ae);
            }
        }
    }

    [System.Serializable]

    public class EndingsUnlocked
    {
        public List<EndingEnum> earnedEndings = new List<EndingEnum>();
        

        public void AddEnding(EndingEnum ee)
        {
            if (!earnedEndings.Contains(ee))
            {
                earnedEndings.Add(ee);
            }
        }
        
        /*
        public bool alien;
        public bool athlete;
        public bool borderAwake;
        public bool dieYoung;
        public bool friendGhost;
        public bool NewEnding;
        public bool hell;
        public bool paradise;
        public bool purgatory;
        public bool reincarnation;
        public bool sick;
        public bool voidEnding;
        public bool wakeUpSim;

        
        public EndingsUnlocked(bool alien, bool athlete, bool borderAwake, bool dieYoung, bool friendGhost, bool hamDogAdventure,
                bool hell, bool paradise, bool purgatory, bool reincarnation, bool sick, bool voidEnding, bool wakeUpSim)
        {
            this.alien = alien;
            this.athlete = athlete;
            this.borderAwake = borderAwake;
            this.dieYoung = dieYoung;
            this.friendGhost = friendGhost;
            this.NewEnding = hamDogAdventure;
            this.hell = hell;
            this.paradise = paradise;
            this.purgatory = purgatory;
            this.reincarnation = reincarnation;
            this.sick = sick;
            this.voidEnding = voidEnding;
            this.wakeUpSim = wakeUpSim;
        }
        public EndingsUnlocked()
        {
            alien = false;
            athlete = false;
            borderAwake = false;
            dieYoung = false;
            friendGhost = false;
            NewEnding = false;
            hell = false;
            paradise = false;
            purgatory = false;
            reincarnation = false;
            sick = false;
            voidEnding = false;
            wakeUpSim = false;
        }
        */
    }

    [System.Serializable]
    public class StatusEffectsUnlocked
    {
        // achievements
        /*
        public bool die50Times = false;
        public bool gradeSObtained = false;
        public bool statusEffects10Obtained = false;
        public bool educationMaxedOut = false;
        public bool oldAgeObtained = false;
        public bool adoptAllPossibleAnimals = false;
        public bool dieAsABaby = false;
        public bool dieAtOldAgeWith100Mood = false;
        public bool dieAtOldAgeWith100Bux = false;
        public bool haveChildren = false;
        public bool getScammed = false;

        */

        public List<StatusEffectsEnum> earnedStatusEffects = new List<StatusEffectsEnum>();

        // stats
        public bool hamster;

        public StatusEffectsUnlocked(bool hamster)
        {
            this.hamster = hamster;

            /*
            this.gradeSObtained = gradeSObtained;
            this.statusEffects10Obtained = statusEffects10Obtained;
            this.educationMaxedOut = educationMaxedOut;
            this.oldAgeObtained = oldAgeObtained;
            this.die50Times = die50Times;
            */
        }

        public StatusEffectsUnlocked()
        {
            this.hamster = false;

            /*
            this.gradeSObtained = false;
            this.statusEffects10Obtained = false;
            this.educationMaxedOut = false;
            this.oldAgeObtained = false;
            this.die50Times = false;
            */
        }

        public void AddStatusEffect(StatusEffectsEnum se)
        {
            if (!earnedStatusEffects.Contains(se))
            {
                earnedStatusEffects.Add(se);
            }
        }
    }


}

