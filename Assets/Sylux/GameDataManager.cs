using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    /*
    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    */

    private void Start()
    {
        Debug.Log("Game Data Manager Started");

        Achievements achievements = new Achievements();
        EndingsUnlocked endingsUnlocked = new EndingsUnlocked();

        string json = JsonUtility.ToJson(achievements);
        string json2 = JsonUtility.ToJson(endingsUnlocked);

        try
        {

            File.WriteAllText(Application.persistentDataPath + "/Save/saveFile.json", json);
            Debug.Log(Application.persistentDataPath);
            Debug.Log(json);
            Debug.Log(json2);
        }
        catch (DirectoryNotFoundException e)
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Save/");
            File.WriteAllText(Application.persistentDataPath + "/Save/saveFile.json", json);

            Debug.LogError("Save file error");
            Debug.LogError(e.StackTrace);
        }

        //  Achievements loadedAchievements = JsonUtility.FromJson<Achievements>(json);
        //  EndingsUnlocked loadedEndingsUnlocked = JsonUtility.FromJson<EndingsUnlocked>(json);


    }
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
    
    public class EndingsUnlocked
    {
        public static bool alien;
        public static bool athlete;
        public static bool borderAwake;
        public static bool dieYoung;
        public static bool friendGhost;
        public static bool hamDogAdventure;
        public static bool hell;
        public static bool paradise;
        public static bool purgatory;
        public static bool reincarnation;
        public static bool sick;
        public static bool voidEnding;
        public static bool wakeUpSim;

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
            EndingsUnlocked.alien = alien;
            EndingsUnlocked.athlete = athlete;
            EndingsUnlocked.borderAwake = borderAwake;
            EndingsUnlocked.dieYoung = dieYoung;
            EndingsUnlocked.friendGhost = friendGhost;
            EndingsUnlocked.hamDogAdventure = hamDogAdventure;
            EndingsUnlocked.hell = hell;
            EndingsUnlocked.paradise = paradise;
            EndingsUnlocked.purgatory = purgatory;
            EndingsUnlocked.reincarnation = reincarnation;
            EndingsUnlocked.sick = sick;
            EndingsUnlocked.voidEnding = voidEnding;
            EndingsUnlocked.wakeUpSim = wakeUpSim;


    }

        public EndingsUnlocked()
        {

            EndingsUnlocked.alien = false;
            EndingsUnlocked.athlete = false;
            EndingsUnlocked.borderAwake = false;
            EndingsUnlocked.dieYoung = false;
            EndingsUnlocked.friendGhost = false;
            EndingsUnlocked.hamDogAdventure = false;
            EndingsUnlocked.hell = false;
            EndingsUnlocked.paradise = false;
            EndingsUnlocked.purgatory = false;
            EndingsUnlocked.reincarnation = false;
            EndingsUnlocked.sick = false;
            EndingsUnlocked.voidEnding = false;
            EndingsUnlocked.wakeUpSim = false;
        }

    }
    
}

