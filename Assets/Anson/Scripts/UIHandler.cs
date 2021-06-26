using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIHandler : MonoBehaviour
{

    [Header("Stats")]
    [SerializeField] Player playerStats;
    [SerializeField] TextMeshProUGUI healthValue;
    [SerializeField] TextMeshProUGUI buxValue;
    [SerializeField] TextMeshProUGUI moodValue;
    [SerializeField] TextMeshProUGUI ageText;
    [SerializeField] TextMeshProUGUI statusText;

    [Header("Card")]
    [SerializeField] Card currentCard;
    [SerializeField] CardEventManager cardEventManager;

    private void Awake()
    {
        if (!cardEventManager)
        {
            cardEventManager = FindObjectOfType<CardEventManager>();
        }
    }
    public void UpdateStats(float h, float b, float m)
    {
        healthValue.text = h.ToString();
        buxValue.text = b.ToString();
        moodValue.text = m.ToString();
    }

    public void UpdateStats(Player p)
    {
        UpdateStats(p.HealthPoints, p.BuxPoint, p.MoodPoint);
        ageText.text = p.age.ToString();
        string tempStatus = "";
        foreach(StatusEnum s in p.status.currentstatus)
        {
            tempStatus += s.ToString() + "\n";
        }
        statusText.text = tempStatus;
    }

    public void Play_Heads()
    {
        cardEventManager.Play_Heads();
    }

    public void Play_Tails()
    {
        cardEventManager.Play_Tails();
    }

}
