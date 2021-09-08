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

    public void CheckIsAchievementPostGame()
    {
        /*
        //S rank, max out education card, 10 status effects at once, old age card
        if (StatusEnum.Equals(StatusEnum.EducatedIII))
        {
            // do stuff
        }
        */
        //Grade S
        GameManagerScript.current.GetGrade();
        if (GameManagerScript.current.Score.Item1.Equals("S"))
        {
            //gameDataManager.Achievements1.gradeSObtained = true;
            AddAchievement(AchievementEnum.gradeSObtained);
        }

        //StatusEffects10Obtained
        if (Player.current.status.currentstatus.Count >= 10)
        {
            AddAchievement(AchievementEnum.statusEffects10Obtained);
        }

        //Education Maxed Out
        if (Player.current.status.HasSatus(StatusEnum.EducatedIII))
        {
            AddAchievement(AchievementEnum.educationMaxedOut);
        }


        //die 50 Times
        if (gameDataManager.Achievements1.timesDied >= 50)
        {
            AddAchievement(AchievementEnum.die50Times);
        }

        //adopt All possible Animals
        if (Player.current.status.HasSatus(StatusEnum.PetCat) && Player.current.status.HasSatus(StatusEnum.PetDog) && Player.current.status.HasSatus(StatusEnum.PetDragon) && (Player.current.status.HasSatus(StatusEnum.PetDragon) || Player.current.status.HasSatus(StatusEnum.BlueDragonPet) || Player.current.status.HasSatus(StatusEnum.RedDragonPet)))
        {
            AddAchievement(AchievementEnum.adoptAllPossibleAnimals);
        }

        //die as a baby
        if (Player.current.HasSatus(StatusEnum.DieYoung))
        {
            AddAchievement(AchievementEnum.dieAsABaby);
        }

        //die at old age with 100 Mood
        if (!Player.current.IsGameOver() && Player.current.MoodPoint >= 100)
        {
            AddAchievement(AchievementEnum.dieAtOldAgeWith100Mood);
        }

        //die at old age with 100 Bux
        if (!Player.current.IsGameOver() && Player.current.BuxPoint >= 100)
        {
            AddAchievement(AchievementEnum.dieAtOldAgeWith100Bux);
        }

        //Have children
        if (Player.current.HasSatus(StatusEnum.ParentHood))
        {
            AddAchievement(AchievementEnum.haveChildren);
        }

        
    }

    public void CheckIsAchievementPerTurn()
    {
        //Old Age
        if (Player.current.age.Equals(AgeEnum.OLD))
        {
            AddAchievement(AchievementEnum.oldAgeObtained);
        }
    }

    void AddAchievement(AchievementEnum ae)
    {
        gameDataManager.Achievements1.AddAchievement(ae);
    }

    public void PostGame()
    {
        gameDataManager.Achievements1.timesDied++;
        CheckIsAchievementPostGame();
        gameDataManager.SaveGame();
        //CheckIsDeathCard();
    }

    public void CheckIsDeathCard()
    {
        //if (cardEventManager.currentCard.CardID == "DEA_000_")
        //{
        //    Debug.Log("Alien ending triggered");
        //    gameDataManager.EndingsUnlocked1.alien = true;
            
        //}

        //if (cardEventManager.currentCard.CardID == "DEA_008_")
        //{
        //    gameDataManager.EndingsUnlocked1.borderAwake = true;
        //}

        //if (cardEventManager.currentCard.CardID == "DEA_009_")
        //{
        //    gameDataManager.EndingsUnlocked1.dieYoung = true;

        //}

        //if (cardEventManager.currentCard.CardID == "DEA_010_")
        //{
        //    gameDataManager.EndingsUnlocked1.friendGhost = true;

        //}


        ////if (cardEventManager.currentCard.CardID == "DEA_011_")
        ////{
        ////    gameDataManager.EndingsUnlocked1.NewEnding = true;
        ////}

        //if (cardEventManager.currentCard.CardID == "DEA_012_")
        //{
        //    gameDataManager.EndingsUnlocked1.hell = true;
        //}
        //if (cardEventManager.currentCard.CardID == "DEA_002_")
        //{
        //    gameDataManager.EndingsUnlocked1.paradise = true;
        //}
        //if (cardEventManager.currentCard.CardID == "DEA_003_")
        //{
        //    gameDataManager.EndingsUnlocked1.purgatory = true;
        //}
        //if (cardEventManager.currentCard.CardID == "DEA_004_")
        //{
        //    gameDataManager.EndingsUnlocked1.reincarnation = true;
        //}
        //if (cardEventManager.currentCard.CardID == "DEA_005_")
        //{
        //    gameDataManager.EndingsUnlocked1.sick = true;
        //}
        //if (cardEventManager.currentCard.CardID == "DEA_006_")
        //{
        //    gameDataManager.EndingsUnlocked1.voidEnding = true;
        //}
        //if (cardEventManager.currentCard.CardID == "DEA_007_")
        //{
        //    gameDataManager.EndingsUnlocked1.wakeUpSim = true;
        //}
    }
}
