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

    [Header("Particle Effects")]
    [SerializeField] ParticleSystem health_Gain;
    [SerializeField] ParticleSystem health_Lose;
    [SerializeField] ParticleSystem bux_Gain;
    [SerializeField] ParticleSystem bux_Lose;
    [SerializeField] ParticleSystem mood_Gain;
    [SerializeField] ParticleSystem mood_Lose;

    public ParticleSystem Health_Gain { get => health_Gain; set => health_Gain = value; }
    public ParticleSystem Health_Lose { get => health_Lose; set => health_Lose = value; }
    public ParticleSystem Bux_Gain { get => bux_Gain; set => bux_Gain = value; }
    public ParticleSystem Bux_Lose { get => bux_Lose; set => bux_Lose = value; }
    public ParticleSystem Mood_Gain { get => mood_Gain; set => mood_Gain = value; }
    public ParticleSystem Mood_Lose { get => mood_Lose; set => mood_Lose = value; }

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
        foreach (StatusEnum s in p.status.currentstatus)
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
    public void PlayStatsParticles(StatsType statsType, float value)
    {
        if (value > 0f)
        {

            switch (statsType)
            {
                case StatsType.HEALTH:
                    health_Gain.Stop();
                    health_Gain.Play();
                    break;
                case StatsType.BUX:
                    bux_Gain.Stop();
                    bux_Gain.Play();
                    break;
                case StatsType.MOOD:
                    mood_Gain.Stop();
                    mood_Gain.Play();
                    break;
            }
        }
        else if (value < 0f)
        {
            switch (statsType)
            {
                case StatsType.HEALTH:
                    health_Lose.Stop();
                    health_Lose.Play();
                    break;
                case StatsType.BUX:
                    bux_Lose.Stop();
                    bux_Lose.Play();
                    break;
                case StatsType.MOOD:
                    mood_Lose.Stop();
                    mood_Lose.Play();
                    break;
            }
        }

    }
}