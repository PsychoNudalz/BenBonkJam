using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [Header("Stats Bar")]
    [SerializeField] GameOver_StatsBar health;
    [SerializeField] GameOver_StatsBar bux;
    [SerializeField] GameOver_StatsBar mood;

    [Header("Status Effect")]
    [SerializeField] GameOver_StatusDisplay statusDisplay;

    [Header("Grade")]
    [SerializeField] TextMeshProUGUI gradeText;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialise(Player player)
    {
        //Stats Bar
        health.Initialise(player.HealthPoints);
        bux.Initialise(player.BuxPoint);
        mood.Initialise(player.MoodPoint);

        //Status Display
        statusDisplay.Initialise(player.allCurrentStatusEffects.ToArray());
    }

    private void OnEnable()
    {
        
    }

}
