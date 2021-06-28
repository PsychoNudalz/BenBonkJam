using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public void setGameOver() {
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
        if (s > 200f)
        {
            return "S";
        }
        else if (s > 170f)
        {
            return "A";
        }
        else if (s > 150f)
        {
            return "B";
        }
        else if (s > 130f)
        {
            return "C";
        }
        else if (s > 100f)
        {
            return "D";
        }
        else if (s > 50f)
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
