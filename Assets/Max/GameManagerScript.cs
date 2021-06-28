using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class StatusToScore
{
    public static float GetScore(StatusEnum s)
    {
        float score = 10f;
        switch (s)
        {
            case StatusEnum.DemonicKinship:
                score = 20f;
                break;
            case StatusEnum.Married:
                score = 20f;
                break;
            case StatusEnum.AngelicBoon:
                score = 30f;
                break;
            case StatusEnum.PetDog:
                break;
            case StatusEnum.Criminal:
                break;
            case StatusEnum.Gambler:
                break;
            case StatusEnum.Addict:
                break;
            case StatusEnum.Spiritual:
                break;
            case StatusEnum.Sick:
                break;
            case StatusEnum.Paranormal:
                score = 15f;
                break;
            case StatusEnum.EducatedI:
                break;
            case StatusEnum.EducatedII:
                score = 20f;
                break;
            case StatusEnum.Trained:
                score = 15f;
                break;
            case StatusEnum.ParentHood:
                score = 15f;
                break;
            case StatusEnum.Divorced:
                score = 20f;
                break;
            case StatusEnum.Employed:
                break;
            case StatusEnum.Unemployed:
                score = 15f;
                break;
            case StatusEnum.SportsTalent:
                score = 20f;
                break;
            case StatusEnum.Driver:
                break;
            case StatusEnum.PetHamster:
                break;
            case StatusEnum.Soulmate:
                break;
            case StatusEnum.Haunted:
                break;
            case StatusEnum.DieYoung:
                score = 20f;
                break;
        }
        return score;
    }
}

public class GameManagerScript : MonoBehaviour
{
    public bool gameOver;
    public Player player;
    [Header("Game Over")]
    public UIHandler uIHandler;

    //if health is 0 -> gameover (Redundant)
    /*public void CheckHealth() {
        if (player.HealthPoints < 0f) {
            gameOver = true;
        } 
    }*/

    public void setGameOver()
    {
        gameOver = true;
        if (!uIHandler)
        {
            uIHandler = FindObjectOfType<UIHandler>();
        }
        uIHandler.DisplayGameOver(GetGrade());
    }

    public string GetGrade()
    {
        float s = player.GetTotalStats();

        foreach(StatusEnum se in player.status.currentstatus)
        {
            s += StatusToScore.GetScore(se);
        }

        if (s > 250f)
        {
            return "S";
        }
        else if (s > 250f)
        {
            return "A";
        }
        else if (s > 200f)
        {
            return "B";
        }
        else if (s > 160f)
        {
            return "C";
        }
        else if (s > 100f)
        {
            return "D";
        }
        else if (s > 70f)
        {
            return "E";
        }
        else
        {
            return "F";
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
