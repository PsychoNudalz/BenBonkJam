using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatsLoader : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timesDied;
    [SerializeField] TextMeshProUGUI achievements;
    [SerializeField] TextMeshProUGUI endings;
    [SerializeField] TextMeshProUGUI uniqueCardsDiscovered;


    private void UpdateText()
    {
        if (GameDataManager.gameDataManagerInstance)
        {
            timesDied.text = GameDataManager.gameDataManagerInstance.Achievements1.timesDied.ToString();
            achievements.text = GameDataManager.gameDataManagerInstance.Achievements1.earnedAchievements.Count.ToString();
            endings.text = GameDataManager.gameDataManagerInstance.EndingsUnlocked1.earnedEndings.Count.ToString();
        }
    }

    private void OnEnable()
    {
        UpdateText();
    }
}
