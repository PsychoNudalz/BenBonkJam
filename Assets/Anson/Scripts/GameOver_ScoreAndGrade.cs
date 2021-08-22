using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver_ScoreAndGrade : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] float score;

    [Header("Components")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gradeText;

    [Header("Animation")]
    [Range(0f, 1f)]
    [SerializeField] float scoreRangeValue = 0f;
    [SerializeField] bool playScoreAnimation = false;
    //[SerializeField] float scoreAnimationSpeed = 1f;
    [Range(0f, 1f)]
    [SerializeField] float gradeRangeValue = 0f;
    [SerializeField] bool playGradeAnimation = false;





    private void Update()
    {
        if (playScoreAnimation)
        {
            PlayScoreAnimation();
        }
        if (playGradeAnimation)
        {
            PlayGradeAnimation();
        }

    }

    public void Initialise(string grade, float totalScore)
    {
        score = totalScore;
        gradeText.text = grade;
    }

    private void PlayScoreAnimation()
    {

        //gradeText.color = ScaleColour(gradeText.color);
        scoreText.text = (scoreRangeValue * score).ToString();
        //scoreRangeValue += scoreAnimationSpeed * Time.deltaTime;
        if (scoreRangeValue >= 1f)
        {
            playScoreAnimation = false;
        }
    }

    private void PlayGradeAnimation()
    {

        gradeText.color = ScaleColour(gradeText.color,gradeRangeValue);
        if (gradeRangeValue >= 1f)
        {
            playGradeAnimation = false;
        }
    }
    Color ScaleColour(Color color, float range)
    {
        return new Vector4(color.r, color.g, color.b, range);
    }
}
