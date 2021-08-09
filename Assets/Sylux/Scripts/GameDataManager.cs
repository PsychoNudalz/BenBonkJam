using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    [SerializeField] EndingsUnlocked endingsUnlocked = new EndingsUnlocked();
    public static GameDataManager gameDataManagerInstance;

    public Achievements Achievements1 { get => achievements; set => achievements = value; }
    public EndingsUnlocked EndingsUnlocked1 { get => endingsUnlocked; set => endingsUnlocked = value; }

    private void Awake()
    {
        //WriteToSave();
        ReadFromSave();
    }

    private void ReadFromSave()
    {
        string json = JsonUtility.ToJson(achievements);
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


    }

    private void WriteToSave()
    {
        Debug.Log("Writing Save");
        string json = JsonUtility.ToJson(achievements);
        string json2 = JsonUtility.ToJson(endingsUnlocked);

        File.WriteAllText(Application.persistentDataPath + "/Save/achievements.json", json);
        Debug.Log(Application.persistentDataPath);
        Debug.Log(json);
        


        Debug.Log("Saved Ach.");

        File.WriteAllText(Application.persistentDataPath + "/Save/saveEndings.json", json2);
        Debug.Log(Application.persistentDataPath);
        Debug.Log(json2);
        

        Debug.Log("Saved End.");


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
        public bool die50Times;
        public bool gradeSObtained;
        public bool statusEffects10Obtained;
        public bool educationMaxedOut;
        public bool oldAgeObtained;

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
            this.gradeSObtained = gradeSObtained;
            this.statusEffects10Obtained = statusEffects10Obtained;
            this.educationMaxedOut = educationMaxedOut;
            this.oldAgeObtained = oldAgeObtained;
            this.die50Times = die50Times;
        }

        public Achievements()
        {
            this.timesDied = 0;
            this.easterEggsFound = 0;
            this.endingsFound = 0;
            this.uniqueCardsDiscovered = 0;
            this.gradeSObtained = false;
            this.statusEffects10Obtained = false;
            this.educationMaxedOut = false;
            this.oldAgeObtained = false;
            this.die50Times = false;
        }
    }

    [System.Serializable]

    public class EndingsUnlocked
    {
        public  bool alien;
        public  bool athlete;
        public  bool borderAwake;
        public  bool dieYoung;
        public  bool friendGhost;
        public  bool hamDogAdventure;
        public  bool hell;
        public  bool paradise;
        public  bool purgatory;
        public  bool reincarnation;
        public  bool sick;
        public  bool voidEnding;
        public  bool wakeUpSim;

        public void Update()
        {
            if (dieYoung == true)
            {
                Debug.Log("DIED YOUNG");
            }
        }

        public EndingsUnlocked(bool alien, bool athlete, bool borderAwake, bool dieYoung, bool friendGhost, bool hamDogAdventure,
                bool hell, bool paradise, bool purgatory, bool reincarnation, bool sick, bool voidEnding, bool wakeUpSim)
        {
            this.alien = alien;
            this.athlete = athlete;
            this.borderAwake = borderAwake;
            this.dieYoung = dieYoung;
            this.friendGhost = friendGhost;
            this.hamDogAdventure = hamDogAdventure;
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
            hamDogAdventure = false;
            hell = false;
            paradise = false;
            purgatory = false;
            reincarnation = false;
            sick = false;
            voidEnding = false;
            wakeUpSim = false;
            
        }

    }

}

