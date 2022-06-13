using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusEffectsEnum
{
    PetHamster
}

// this is part of the achievements menu in the main menu
public class StatusEffectsMenuManager : PlayerCollectionManager
{
    [Header("Achiements")]
    [SerializeField] StatusEffectsCollecton[] statusEffectsCollectons;
    // Start is called before the first frame update
    void Start()
    {
        playerCollections = new List<PlayerCollection>();
        playerCollections.AddRange(statusEffectsCollectons);
        LoadIsUnlocked();
        LoadButtons();

    }

    // Update is called once per frame
    void Update()
    {

    }


    void AutoGenerateAchievements()
    {

    }

    protected override void LoadIsUnlocked()
    {
        base.LoadIsUnlocked();

        GameDataManager gameDataManager = GameDataManager.gameDataManagerInstance;
        if (!gameDataManager)
        {
            Debug.LogError("Failed to load achievements from save");
            return;
        }

        foreach (StatusEffectsCollecton se in statusEffectsCollectons)
        {
            CardIsUnlocked(gameDataManager, se);

        }

    }

    private static void CardIsUnlocked(GameDataManager gameDataManager, StatusEffectsCollecton se)
    {

        if (gameDataManager.StatusEffectsUnlocked1.earnedStatusEffects.Contains(se.StatusEffectsEnum))
        {
            se.IsUnlocked = true;
        }

        /*
        switch (ac.AchievementEnum)
        {
            case AchievementEnum.gradeSObtained:
                ac.IsUnlocked = gameDataManager.Achievements1.gradeSObtained;
                break;
            case AchievementEnum.statusEffects10Obtained:
                ac.IsUnlocked = gameDataManager.Achievements1.statusEffects10Obtained;

                break;
            case AchievementEnum.educationMaxedOut:
                ac.IsUnlocked = gameDataManager.Achievements1.educationMaxedOut;

                break;
            case AchievementEnum.oldAgeObtained:
                ac.IsUnlocked = gameDataManager.Achievements1.oldAgeObtained;

                break;
            case AchievementEnum.die50Times:
                ac.IsUnlocked = gameDataManager.Achievements1.die50Times;

                break;
            case AchievementEnum.adoptAllPossibleAnimals:
                ac.IsUnlocked = gameDataManager.Achievements1.adoptAllPossibleAnimals;

                break;
            case AchievementEnum.dieAsABaby:
                ac.IsUnlocked = gameDataManager.Achievements1.dieAsABaby;
                break;
            case AchievementEnum.dieAtOldAgeWith100Mood:
                ac.IsUnlocked = gameDataManager.Achievements1.dieAtOldAgeWith100Mood;
                break;
            case AchievementEnum.dieAtOldAgeWith100Bux:
                ac.IsUnlocked = gameDataManager.Achievements1.dieAtOldAgeWith100Bux;
                break;
            case AchievementEnum.haveChildren:
                ac.IsUnlocked = gameDataManager.Achievements1.haveChildren;
                break;
            case AchievementEnum.getScammed:
                ac.IsUnlocked = gameDataManager.Achievements1.getScammed;
                break;
        }
        */
    }
}
