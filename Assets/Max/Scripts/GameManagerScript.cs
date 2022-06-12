using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

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
    public static GameManagerScript current;

    public bool gameOver;
    public Player player;
    [SerializeField] System.Tuple<string, float> score;
    
    [Header("Game Over")]
    public UIHandler uIHandler;

    public Tuple<string, float> Score { get => score; set => score = value; }

    //if health is 0 -> gameover (Redundant)
    /*public void CheckHealth() {
        if (player.HealthPoints < 0f) {
            gameOver = true;
        } 
    }*/

    public void setGameOver(string deathCardID)
    {
        gameOver = true;
        if (!uIHandler)
        {
            uIHandler = FindObjectOfType<UIHandler>();
        }
        uIHandler.DisplayGameOver(GetGrade().Item1,GetGrade().Item2);
    }

    public System.Tuple<string, float> GetGrade()
    {
        float s = player.GetTotalStats();

        foreach (StatusEnum se in player.status.currentstatus)
        {
            s += StatusToScore.GetScore(se);
        }
        System.Tuple<string, float> returnTuple = new System.Tuple<string, float>("", s);

        if (s > 250f)
        {
            returnTuple = new System.Tuple<string, float>("S", s);
        }
        else if (s > 250f)
        {
            returnTuple = new System.Tuple<string, float>("A", s);

        }
        else if (s > 200f)
        {
            returnTuple = new System.Tuple<string, float>("B", s);

        }
        else if (s > 160f)
        {
            returnTuple = new System.Tuple<string, float>("C", s);
        }
        else if (s > 100f)
        {
            returnTuple = new System.Tuple<string, float>("D", s);
        }
        else if (s > 70f)
        {
            returnTuple = new System.Tuple<string, float>("E", s);
        }
        else
        {
            returnTuple = new System.Tuple<string, float>("F", s);
        }
        score = returnTuple;
        return returnTuple;
    }

    // Start is called before the first frame update
    void Start()
    {
        current = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
