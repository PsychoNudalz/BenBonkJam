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

    public void Play_Heads()
    {
        cardEventManager.Play_Heads();
    }

    public void Play_Tails()
    {
        cardEventManager.Play_Tails();
    }

}
