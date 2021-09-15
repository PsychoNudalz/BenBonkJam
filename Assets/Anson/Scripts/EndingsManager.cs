using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EndingEnum
{
    Alien,
    Athlete,
    BorderAwake,
    DieYoung,
    FriendGhost,
    NewEnding, //Was Pet Adventure.  Replace this with a new Ending
    Hell,
    Paradise,
    Purgatory,
    Reincarnation,
    Sick,
    VoidEnding,
    WakeUpSim,
    Angel
}





public class EndingsManager : PlayerCollectionManager
{
    [Header("Endings")]
    [SerializeField] List<EndingCollection> endingCollections;
    // Start is called before the first frame update
    void Start()
    {
        AutoLoadName();
        playerCollections = new List<PlayerCollection>();
        playerCollections.AddRange(endingCollections);
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

        foreach (EndingCollection ec in endingCollections)
        {
            EndingIsUnlocked(gameDataManager, ec);

        }

    }

    private static void EndingIsUnlocked(GameDataManager gameDataManager, EndingCollection ec)
    {

        ec.IsUnlocked = gameDataManager.EndingsUnlocked1.earnedEndings.Contains(ec.EndingEnum);
        /*
        switch (ec.EndingEnum)
        {
            case EndingEnum.Alien:
                ec.IsUnlocked = gameDataManager.EndingsUnlocked1.alien;
                break;
            case EndingEnum.Athlete:
                ec.IsUnlocked = gameDataManager.EndingsUnlocked1.athlete; ;

                break;
            case EndingEnum.BorderAwake:
                ec.IsUnlocked = gameDataManager.EndingsUnlocked1.borderAwake;
                break;
            case EndingEnum.DieYoung:
                ec.IsUnlocked = gameDataManager.EndingsUnlocked1.dieYoung;
                break;
            case EndingEnum.FriendGhost:
                ec.IsUnlocked = gameDataManager.EndingsUnlocked1.friendGhost;
                break;
            case EndingEnum.NewEnding:
                ec.IsUnlocked = gameDataManager.EndingsUnlocked1.NewEnding;
                break;
            case EndingEnum.Hell:
                ec.IsUnlocked = gameDataManager.EndingsUnlocked1.hell;
                break;
            case EndingEnum.Paradise:
                ec.IsUnlocked = gameDataManager.EndingsUnlocked1.paradise;
                break;
            case EndingEnum.Purgatory:
                ec.IsUnlocked = gameDataManager.EndingsUnlocked1.purgatory;
                break;
            case EndingEnum.Reincarnation:
                ec.IsUnlocked = gameDataManager.EndingsUnlocked1.reincarnation;
                break;
            case EndingEnum.Sick:
                ec.IsUnlocked = gameDataManager.EndingsUnlocked1.sick;
                break;
            case EndingEnum.VoidEnding:
                ec.IsUnlocked = gameDataManager.EndingsUnlocked1.voidEnding;
                break;
            case EndingEnum.WakeUpSim:
                ec.IsUnlocked = gameDataManager.EndingsUnlocked1.wakeUpSim;
                break;
        }
        */
    }

    void AutoLoadName()
    {
        foreach (EndingCollection ec in endingCollections)
        {
            if (ec.CollectionName.Equals(""))
            {
                ec.CollectionName = ec.EndingEnum.ToString();
            }
        }
    }

}
