using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AchievementEnum
{
    gradeSObtained,
    statusEffects10Obtained,
    educationMaxedOut,
    oldAgeObtained, 
    die50Times
}


public class AchievementsManager : PlayerCollectionManager
{
    [Header("Achiements")]
    [SerializeField] List<AchievementCollection> achievementCollections;
    // Start is called before the first frame update
    void Start()
    {
        playerCollections = new List<PlayerCollection>();
        playerCollections.AddRange(achievementCollections);
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

        foreach (AchievementCollection ac in achievementCollections)
        {
            CardIsUnlocked(gameDataManager, ac);

        }

    }

    private static void CardIsUnlocked(GameDataManager gameDataManager, AchievementCollection ac)
    {
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
        }
    }
}
