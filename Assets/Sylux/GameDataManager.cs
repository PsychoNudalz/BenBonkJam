using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{

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
    
    private class EndingsUnlocked
    {
        public bool alien;
        public bool athlete;
        public bool borderAwake;
        public bool dieYoung;
        public bool friendGhost;
        public bool hamDogAdventure;
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

            this.alien = false;
            this.athlete = false;
            this.borderAwake = false;
            this.dieYoung = false;
            this.friendGhost = false;
            this.hamDogAdventure = false;
            this.hell = false;
            this.paradise = false;
            this.purgatory = false;
            this.reincarnation = false;
            this.sick = false;
            this.voidEnding = false;
            this.wakeUpSim = false;
        }

    }
    
}

