using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas mainCanvas;
    public Canvas helpCanvas;
    public Canvas creditsCanvas;
    public Canvas statsCanvas;

    // credits objects
    public GameObject mainCredits;
    public GameObject sfxCredits1;
    public GameObject sfxCredits2;
    public GameObject sfxCredits3;

    //stats objects
    public Canvas statisticsCanvas;
    public Canvas achievementsCanvas;
    public Canvas endingsCanvas;

    //achievements Canvas
    public Canvas achievementsCanvas2;
    public Canvas achievementsCanvas3;

    // endings Canvas
    public Canvas endingsCanvas2;
    public Canvas endingCanvas3;

    void Start()
    {
        endingsCanvas2.enabled = false;
        endingCanvas3.enabled = false;
        achievementsCanvas2.enabled = false;
        achievementsCanvas3.enabled = false;
        mainCanvas.enabled = true;
        statsCanvas.enabled = false;
        helpCanvas.enabled = false;
        creditsCanvas.enabled = false;
        statisticsCanvas.enabled = false;
        achievementsCanvas.enabled = false;
        endingsCanvas.enabled = false;
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
        mainCanvas.enabled = false;
        helpCanvas.enabled = false;
        creditsCanvas.enabled = false;
        statsCanvas.enabled = true;
        achievementsCanvas.enabled = true;
        endingsCanvas.enabled = false;
        endingsCanvas2.enabled = false;
        endingCanvas3.enabled = false;
    }

    public void Help()
    {
        mainCanvas.enabled = false;
        helpCanvas.enabled = true;
        creditsCanvas.enabled = false;
    }

    //statisticsMenu
    #region statistics
    public void Endings()
    {
        achievementsCanvas.enabled = false;
        statisticsCanvas.enabled = false;
        endingsCanvas.enabled = true;
        endingsCanvas2.enabled = false;
        endingCanvas3.enabled = false;
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
        mainCanvas.enabled = false;
        creditsCanvas.enabled = true;
        helpCanvas.enabled = false;
        mainCredits.SetActive(true);
        sfxCredits1.SetActive(false);
        sfxCredits2.SetActive(false);
        sfxCredits3.SetActive(false);
    }

    public void SFXCreditsOne()
    {
        mainCredits.SetActive(false);
        sfxCredits1.SetActive(true);
        sfxCredits2.SetActive(false);
        sfxCredits3.SetActive(false);
    }

    public void SFXCreditsTwo()
    {
        mainCredits.SetActive(false);
        sfxCredits1.SetActive(false);
        sfxCredits2.SetActive(true);
        sfxCredits3.SetActive(false);
    }

    public void SFXCreditsThree()
    {
        mainCredits.SetActive(false);
        sfxCredits1.SetActive(false);
        sfxCredits2.SetActive(false);
        sfxCredits3.SetActive(true);
    }
    #endregion
    public void backToMain()
    {
        mainCanvas.enabled = true;
        helpCanvas.enabled = false;
        creditsCanvas.enabled = false;
        statsCanvas.enabled = false;
        achievementsCanvas.enabled = false;
        statisticsCanvas.enabled = false;
        endingsCanvas.enabled = false;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("QUITTING GAME");
    }
}
