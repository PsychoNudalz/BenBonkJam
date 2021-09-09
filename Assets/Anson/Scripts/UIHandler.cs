using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.InputSystem;

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
    [SerializeField] CardOLD currentCard;
    [SerializeField] CardEventManager cardEventManager;
    [Header("Game Over")]
    [SerializeField] GameOverController gameOverController;

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


    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

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
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
        if (!playerStats)
        {
            playerStats = FindObjectOfType<Player>();
        }

        gameOverController.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        //Set up the new Pointer Event
        m_PointerEventData = new PointerEventData(m_EventSystem);
        //Set the Pointer Event Position to that of the mouse position
        m_PointerEventData.position = Mouse.current.position.ReadValue();

        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        m_Raycaster.Raycast(m_PointerEventData, results);
        
        //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.CompareTag("Status Effect Icon"))
            {
                Tooltip.ShowTooltip_Static(result.gameObject.GetComponentInParent<UIStatusEffect>().status);
                SummaryTooltip.HideTooltip_Static();
            }
            else
            {
                Tooltip.HideTooltip_Static();
                if(result.gameObject.CompareTag("HP Bar"))
                {
                    SummaryTooltip.ShowTooltip_Static(SummaryType.HP);
                }
                else if(result.gameObject.CompareTag("Bux Bar"))
                {
                    SummaryTooltip.ShowTooltip_Static(SummaryType.Bux);
                }
                else if(result.gameObject.CompareTag("Mood Bar"))
                {
                    SummaryTooltip.ShowTooltip_Static(SummaryType.Mood);
                }
                else
                {
                    SummaryTooltip.HideTooltip_Static();
                }
            }
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
            currentUI.SetNewStatus(FindObjectOfType<StatusEffectManager>().GetStatusEffect(se));
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
        if(SceneTransition.Instance != null)
        {
            SceneTransition.Instance.FadeToScene(0);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void DisplayGameOver(string grade, float score, string s = "")
    {
        gameOverScreen.SetActive(true);
        gradeText.text = grade;
        //extraMessage.text = s;
        //statusDisplay.transform.parent = gameOverScreen.transform;
        gameOverController.Initialise(playerStats,grade,score);
    }
}