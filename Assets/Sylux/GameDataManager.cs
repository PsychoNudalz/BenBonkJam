using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;

public class GameDataManager : MonoBehaviour
{

    private void Start()
    {
        Debug.Log("Game Data Manager Started");

        Achievements achievements = new Achievements();
        EndingsUnlocked endingsUnlocked = new EndingsUnlocked();

        string json = JsonUtility.ToJson(achievements);
        string json2 = JsonUtility.ToJson(endingsUnlocked);

        Achievements loadedAchievements = JsonUtility.FromJson<Achievements>(json);

        Debug.Log(json);
        Debug.Log(json2);

    }




    private class Achievements
    {
        public int gamesPlayed;
        public int easterEggsFound;
        public int endingsFound;
        public int uniqueCardsDiscovered;
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

    }
}
