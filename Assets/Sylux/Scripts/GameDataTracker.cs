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

    public void CheckIsAchievement()
    {
        /*
        //S rank, max out education card, 10 status effects at once, old age card
        if (StatusEnum.Equals(StatusEnum.EducatedIII))
        {
            // do stuff
        }
        */
        //Grade S
        if (GameManagerScript.current.Score.Item1.Equals("S"))
        {
            //gameDataManager.Achievements1.gradeSObtained = true;
        }


    }

    public void PostGame()
    {
        gameDataManager.Achievements1.timesDied++;
        gameDataManager.SaveGame();
        //CheckIsDeathCard();
    }

    public void CheckIsDeathCard()
    {
        if (cardEventManager.currentCard.CardID == "DEA_000_")
        {
            Debug.Log("Alien ending triggered");
            gameDataManager.EndingsUnlocked1.alien = true;
            
        }

        if (cardEventManager.currentCard.CardID == "DEA_008_")
        {
            gameDataManager.EndingsUnlocked1.borderAwake = true;
        }

        if (cardEventManager.currentCard.CardID == "DEA_009_")
        {
            gameDataManager.EndingsUnlocked1.dieYoung = true;

        }

        if (cardEventManager.currentCard.CardID == "DEA_010_")
        {
            gameDataManager.EndingsUnlocked1.friendGhost = true;

        }

        if (cardEventManager.currentCard.CardID == "DEA_011_")
        {
            gameDataManager.EndingsUnlocked1.hamDogAdventure = true;
        }

        if (cardEventManager.currentCard.CardID == "DEA_012_")
        {
            gameDataManager.EndingsUnlocked1.hell = true;
        }
        if (cardEventManager.currentCard.CardID == "DEA_002_")
        {
            gameDataManager.EndingsUnlocked1.paradise = true;
        }
        if (cardEventManager.currentCard.CardID == "DEA_003_")
        {
            gameDataManager.EndingsUnlocked1.purgatory = true;
        }
        if (cardEventManager.currentCard.CardID == "DEA_004_")
        {
            gameDataManager.EndingsUnlocked1.reincarnation = true;
        }
        if (cardEventManager.currentCard.CardID == "DEA_005_")
        {
            gameDataManager.EndingsUnlocked1.sick = true;
        }
        if (cardEventManager.currentCard.CardID == "DEA_006_")
        {
            gameDataManager.EndingsUnlocked1.voidEnding = true;
        }
        if (cardEventManager.currentCard.CardID == "DEA_007_")
        {
            gameDataManager.EndingsUnlocked1.wakeUpSim = true;
        }
    }
}
