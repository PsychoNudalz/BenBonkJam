using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerCollection
{
    [SerializeField] string collectionName;
    [SerializeField] Sprite sprite;
    [TextArea]
    [SerializeField] string details;
    [SerializeField] bool isUnlocked;

    public string CollectionName { get => collectionName; set => collectionName = value; }
    public Sprite Sprite { get => sprite; set => sprite = value; }
    public string Details { get => details; set => details = value; }
    public bool IsUnlocked { get => isUnlocked; set => isUnlocked = value; }
    // Start is called before the first frame update

}

[System.Serializable]

public class AchievementCollection : PlayerCollection
{
    [Header("Achievement")]
    [SerializeField] AchievementEnum achievementEnum;

    public AchievementEnum AchievementEnum { get => achievementEnum; set => achievementEnum = value; }
}

[System.Serializable]

public class EndingCollection : PlayerCollection
{
    [Header("Ending")]
    [SerializeField] EndingEnum endingEnum;

    public EndingEnum EndingEnum { get => endingEnum; set => endingEnum = value; }
}
