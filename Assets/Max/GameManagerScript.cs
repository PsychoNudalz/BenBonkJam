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
    public GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI grades;
   
    //if health is 0 -> gameover (Redundant)
    /*public void CheckHealth() {
        if (player.HealthPoints < 0f) {
            gameOver = true;
        } 
    }*/

    public void setGameOver() {
        gameOver = true;
        gameOverScreen.SetActive(true);
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
