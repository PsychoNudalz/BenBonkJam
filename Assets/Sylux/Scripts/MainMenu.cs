using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Canvases")]
    [SerializeField] private Canvas mainCanvas;
    [SerializeField] private Canvas creditsCanvas;
    [SerializeField] private Canvas optionsCanvas;
    [SerializeField] private Canvas statsCanvas;

    [Header("Help Canvases")]
    [SerializeField] private GameObject helpCanvas;
    [SerializeField] private GameObject helpCanvasPage1;
    [SerializeField] private GameObject helpCanvasPage2;
    [SerializeField] private GameObject helpCanvasPage3;

    [Header("Credits Objects")]
    [SerializeField] private GameObject mainCredits;
    [SerializeField] private GameObject sfxCredits1;
    [SerializeField] private GameObject sfxCredits2;
    [SerializeField] private GameObject sfxCredits3;

    [Header("Stats Objects")]
    [SerializeField] private Canvas statisticsCanvas;
    [SerializeField] private GameObject achievementsAndEndingsObject;

    [Header("Achievements Canvas")]
    [SerializeField] private Canvas achievementsCanvas;
    [SerializeField] private Canvas achievementsCanvas2;
    [SerializeField] private Canvas achievementsCanvas3;

    [Header("Ending Canvas")]
    [SerializeField] private Canvas endingsCanvas;
    [SerializeField] private Canvas endingsCanvas2;
    [SerializeField] private Canvas endingCanvas3;

    [Header("Status Effects Canvas")]
    [SerializeField] private Canvas statusEffectsCanvasMain;
    [SerializeField] private Canvas statusEffectsCanvas;
    [SerializeField] private Canvas statusEffectsCanvas2;
    [SerializeField] private Canvas statusEffectsCanvas3;


    void Start()
    {
        DisableAllUI();
        mainCanvas.enabled = true;
    }

    public void DisableAllUI()
    {
        endingsCanvas2.enabled = false;
        endingCanvas3.enabled = false;
        achievementsCanvas2.enabled = false;
        achievementsCanvas3.enabled = false;
        mainCanvas.enabled = false;
        statsCanvas.enabled = false;
        helpCanvas.SetActive(false);
        creditsCanvas.enabled = false;
        statisticsCanvas.enabled = false;
        achievementsCanvas.enabled = false;
        endingsCanvas.enabled = false;
        optionsCanvas.enabled = false;

        statusEffectsCanvas.enabled = false;
        statusEffectsCanvas2.enabled = false;
        statusEffectsCanvas3.enabled = false;
        achievementsAndEndingsObject.SetActive(false);
    }

    public void Play()
    {
        if(SceneTransition.Instance != null)
        {
            SceneTransition.Instance.FadeToScene(1);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    public void Stats()
    {
        DisableAllUI();
        statsCanvas.enabled = true;
        achievementsCanvas.enabled = true;
        achievementsAndEndingsObject.SetActive(true);
    }

    public void Options()
    {
        optionsCanvas.enabled = true;
        mainCanvas.enabled = false;
    }

    public void OptionsBack()
    {
        optionsCanvas.enabled = false;
        mainCanvas.enabled = true;
    }

    public void Help()
    {
        mainCanvas.enabled = false;
        DisableHelp();
        helpCanvas.SetActive(true);
        helpCanvasPage1.SetActive(true);
        creditsCanvas.enabled = false;
    }

    #region Help

    public void DisableHelp()
    {
        helpCanvasPage1.SetActive(false);
        helpCanvasPage2.SetActive(false);
        helpCanvasPage3.SetActive(false);
    }

    public void Help2()
    {
        DisableHelp();
        helpCanvasPage2.SetActive(true);
    }

    public void Help3()
    {
        DisableHelp();
        helpCanvasPage3.SetActive(true);

    }
    #endregion

    //statisticsMenu
    #region statistics
    public void Endings()
    {
        achievementsCanvas.enabled = false;
        statisticsCanvas.enabled = false;
        endingsCanvas.enabled = true;
        endingsCanvas2.enabled = false;
        endingCanvas3.enabled = false;
        statusEffectsCanvas.enabled = false;
        statusEffectsCanvas2.enabled = false;
        statusEffectsCanvas3.enabled = false;
        statusEffectsCanvasMain.enabled = false;
    }

    public void Endings2()
    {
        endingsCanvas2.enabled = true;
        endingCanvas3.enabled = false;
        endingsCanvas.enabled = false;
    }

    public void Endings3()
    {
        endingsCanvas2.enabled = false;
        endingCanvas3.enabled = true;
        endingsCanvas.enabled = false;
    }

    public void Achievements()
    {
        achievementsCanvas.enabled = true;
        statisticsCanvas.enabled = false;
        endingsCanvas.enabled = false;
        endingsCanvas2.enabled = false;
        endingCanvas3.enabled = false;
        achievementsCanvas2.enabled = false;
        achievementsCanvas3.enabled = false;
        statusEffectsCanvas.enabled = false;
        statusEffectsCanvas2.enabled = false;
        statusEffectsCanvas3.enabled = false;
        statusEffectsCanvasMain.enabled = false;
    }

    public void Achievements2()
    {
        achievementsCanvas2.enabled = true;
        achievementsCanvas3.enabled = false;
        achievementsCanvas.enabled = false;
    }

    public void Achievements3()
    {
        achievementsCanvas2.enabled = false;
        achievementsCanvas3.enabled = true;
        achievementsCanvas.enabled = false;
    }

    public void StatusEffects()
    {
        statusEffectsCanvas.enabled = true;
        statusEffectsCanvas2.enabled = false;
        statusEffectsCanvas3.enabled = false;
        statusEffectsCanvasMain.enabled = true;
    }

    public void StatusEffects2()
    {
        statusEffectsCanvas.enabled = false;
        statusEffectsCanvas2.enabled = true;
        statusEffectsCanvas3.enabled = false;
    }

    public void StatusEffects3()
    {
        statusEffectsCanvas.enabled = false;
        statusEffectsCanvas2.enabled = false;
        statusEffectsCanvas3.enabled = true;
    }

    public void Statistics()
    {
        achievementsCanvas.enabled = false;
        statisticsCanvas.enabled = true;
        endingsCanvas.enabled = false;
    }
    #endregion

    // credits
    #region Credits
    public void Credits()
    {
        DisableAllCredits();
        creditsCanvas.enabled = true;
        mainCredits.SetActive(true);
    }

    public void DisableAllCredits()
    {
        mainCanvas.enabled = false;
        helpCanvas.SetActive(false);
        mainCredits.SetActive(false);
        sfxCredits1.SetActive(false);
        sfxCredits2.SetActive(false);
        sfxCredits3.SetActive(false);
    }

    public void SFXCreditsOne()
    {
        DisableAllCredits();
        sfxCredits1.SetActive(true);
    }

    public void SFXCreditsTwo()
    {
        DisableAllCredits();
        sfxCredits2.SetActive(true);
    }

    public void SFXCreditsThree()
    {
        DisableAllCredits();
        sfxCredits3.SetActive(true);
    }
    #endregion
    public void backToMain()
    {
        DisableAllUI();
        mainCanvas.enabled = true;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("QUITTING GAME");
    }
}
