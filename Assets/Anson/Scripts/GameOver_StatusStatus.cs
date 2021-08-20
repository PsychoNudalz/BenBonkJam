using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOver_StatusStatus : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI statsText;
    [SerializeField] TextMeshProUGUI score;


    
    public void Initialise(StatusEffect se) 
    {
        image.sprite = se.icon;
        statsText.text = se.status.ToString();
        score.text = StatusToScore.GetScore(se.status).ToString();
    }
}
