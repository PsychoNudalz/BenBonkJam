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
    [Header("Animation")]
    [Range(0f, 1f)]
    [SerializeField] float rangeValue;
    [SerializeField] bool playAnimation;
    [SerializeField] float animationTime = 1f;


    public void Initialise(StatusEffect se)
    {
        image.sprite = se.icon;
        statsText.text = se.status.ToString();
        score.text = StatusToScore.GetScore(se.status).ToString();
    }

    private void Update()
    {
        PlayAnimation();
    }

    private void PlayAnimation()
    {
        if (playAnimation)
        {
            image.color = ScaleColour(image.color);
            statsText.color = ScaleColour(statsText.color);
            score.color = ScaleColour(score.color);
            rangeValue += animationTime * Time.deltaTime;
            if (rangeValue >= 1f)
            {
                playAnimation = false;
            }
        }
    }

    Color ScaleColour(Color color)
    {
        return new Vector4(color.r, color.g, color.b, rangeValue);
    }

    public void StartAnimation()
    {
        playAnimation = true;
    }


}
