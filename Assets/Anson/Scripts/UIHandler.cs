using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class UIHandler : MonoBehaviour
{

    [Header("Stats")]
    [SerializeField] Player playerStats;
    [SerializeField] Slider healthValue;
    [SerializeField] Slider buxValue;
    [SerializeField] Slider moodValue;
    [SerializeField] TextMeshProUGUI ageText;
    [Header("Status")]
    [SerializeField] GameObject UIStatusEffectGO;
    [SerializeField] GameObject statusDisplay;

    [Header("Card")]
    [SerializeField] Card currentCard;
    [SerializeField] CardEventManager cardEventManager;
    [Header("Game Over")]
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI gradeText;
    [SerializeField] TextMeshProUGUI extraMessage;
    

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
        healthValue.value = h;
        buxValue.value = b;
        moodValue.value = m;
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
        UpdateStatusDisplay(p);
    }

    public void UpdateStatusDisplay(Player p)
    {
        foreach (Transform g in statusDisplay.transform.GetComponentsInChildren<Transform>())
        {
            if (!g.Equals(statusDisplay.transform))
            {
                Destroy(g.gameObject);
            }
        }
        UIStatusEffect currentUI;
        foreach(StatusEnum se in p.status.currentstatus)
        {
            currentUI = Instantiate(UIStatusEffectGO, statusDisplay.transform).GetComponent<UIStatusEffect>();
            currentUI.SetNewStatus(FindObjectOfType<StatusEffectManager>().GetStatusEffectPair(se));
        }


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

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void DisplayGameOver(string grade, string s = "")
    {
        gameOverScreen.SetActive(true);
        gradeText.text = grade;
        extraMessage.text = s;
        statusDisplay.transform.parent = gameOverScreen.transform;
    }
}