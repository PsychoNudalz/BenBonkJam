using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataTracker : MonoBehaviour
{
    public static GameDataTracker current;

    public GameDataManager gameDataManager;
    public CardEventManager cardEventManager;
    // Start is called before the first frame update
    void Start()
    {
        //   gameDataManager = FindObjectOfType("GameDataManager");
        current = this;
    }

    // Update is called once per frame
    void Update()
    {
        //CheckIsDeathCard();
    }

    public void CheckIsDeathCard()
    {
        if (cardEventManager.currentCard.CardID == "DEA_000_")
        {
            Debug.Log("Alien ending triggered");
            gameDataManager.EndingsUnlocked1.alien = true;
            gameDataManager.SaveGame();
        }

        if (cardEventManager.currentCard.CardID == "DEA_008_")
        {
            gameDataManager.EndingsUnlocked1.borderAwake =true;
            gameDataManager.SaveGame();

        }

        if (cardEventManager.currentCard.CardID == "DEA_009_")
        {
            // Debug.log works, but the other two do not change
            //Debug.Log("die young");
            gameDataManager.EndingsUnlocked1.dieYoung = true;
            gameDataManager.SaveGame();

        }

        if (cardEventManager.currentCard.CardID == "DEA_010_")
        {
            gameDataManager.EndingsUnlocked1.friendGhost = true;
            gameDataManager.SaveGame();

        }

        if (cardEventManager.currentCard.CardID == "DEA_011_")
        {
            gameDataManager.EndingsUnlocked1.hamDogAdventure = true;
            gameDataManager.SaveGame();

        }
        if (cardEventManager.currentCard.CardID == "DEA_012_")
        {
            gameDataManager.EndingsUnlocked1.hell = true;
            gameDataManager.SaveGame();

        }
        if (cardEventManager.currentCard.CardID == "DEA_002_")
        {
            gameDataManager.EndingsUnlocked1.paradise = true;
            gameDataManager.SaveGame();

        }
        if (cardEventManager.currentCard.CardID == "DEA_003_")
        {
            gameDataManager.EndingsUnlocked1.purgatory =true;
            gameDataManager.SaveGame();

        }
        if (cardEventManager.currentCard.CardID == "DEA_004_")
        {
           gameDataManager.EndingsUnlocked1.reincarnation = true;
            gameDataManager.SaveGame();

        }
        if (cardEventManager.currentCard.CardID == "DEA_005_")
        {
            gameDataManager.EndingsUnlocked1.sick = true;
            gameDataManager.SaveGame();

        }
        if (cardEventManager.currentCard.CardID == "DEA_006_")
        {
            gameDataManager.EndingsUnlocked1.voidEnding = true;
            gameDataManager.SaveGame();

        }
        if (cardEventManager.currentCard.CardID == "DEA_007_")
        {
            gameDataManager.EndingsUnlocked1.wakeUpSim = true;
            gameDataManager.SaveGame();

        }
    }
}
