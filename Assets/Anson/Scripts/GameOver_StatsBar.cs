using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver_StatsBar : MonoBehaviour
{

    [Header("Stats")]
    [SerializeField] float statsValue;

    [Header("Components")]
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI text;
    //[SerializeField] 

    [Header("Animation")]
    [Range(0f, 1f)]
    [SerializeField] float rangeValue;



    private void Awake()
    {
        if (!slider)
        {
            slider = GetComponentInChildren<Slider>();
        }
        if (!text)
        {
            text = GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    public void Initialise(float statsValue)
    {
        this.statsValue = statsValue;
    }

    private void Update()
    {
        UpdateSliderAndScore();
    }
    public void UpdateSliderAndScore()
    {

        slider.value = statsValue*rangeValue;
        text.text = (Mathf.RoundToInt(statsValue* rangeValue)).ToString();
    }
}
