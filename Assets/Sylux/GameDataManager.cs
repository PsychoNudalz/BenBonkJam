using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private Achievements Achievements1 { get => achievements; set => achievements = value; }
    public EndingsUnlocked EndingsUnlocked1 { get => endingsUnlocked; set => endingsUnlocked = value; }

    private void Start()
    {
        //WriteToSave();
        ReadFromSave();
    }

    private void ReadFromSave()
    {

    }

    private void WriteToSave()
    {
        Debug.Log("Game Data Manager Started");
        string json = JsonUtility.ToJson(achievements);
        string json2 = JsonUtility.ToJson(endingsUnlocked);

        try
        {

            File.WriteAllText(Application.persistentDataPath + "/Save/achievements.json", json);
            Debug.Log(Application.persistentDataPath);
            Debug.Log(json);
        }
        catch (DirectoryNotFoundException e)
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Save/");
            File.WriteAllText(Application.persistentDataPath + "/Save/achievements.json", json);

            Debug.LogError("Save file error");
            Debug.LogError(e.StackTrace);
        }

        Debug.Log("Saved Ach.");

        try
        {

            File.WriteAllText(Application.persistentDataPath + "/Save/saveEndings.json", json2);
            Debug.Log(Application.persistentDataPath);
            Debug.Log(json2);
        }
        catch (DirectoryNotFoundException e)
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Save/");
            File.WriteAllText(Application.persistentDataPath + "/Save/saveEndings.json", json2);

            Debug.LogError("Save file error");
            Debug.LogError(e.StackTrace);
        }

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

    private class Achievements
    {
        public int gamesPlayed;
        public int easterEggsFound;
        public int endingsFound;
        public int uniqueCardsDiscovered;

        public Achievements(int gamesPlayed, int easterEggsFound, int endingsFound, int uniqueCardsDiscovered)
        {
            this.gamesPlayed = gamesPlayed;
            this.easterEggsFound = easterEggsFound;
            this.endingsFound = endingsFound;
            this.uniqueCardsDiscovered = uniqueCardsDiscovered;
        }

        public Achievements()
        {
            this.gamesPlayed = 0;
            this.easterEggsFound = 0;
            this.endingsFound = 0;
            this.uniqueCardsDiscovered = 0;
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

