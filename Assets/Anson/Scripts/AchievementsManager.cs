using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AchievementEnum
{

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
        LoadButtons();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
