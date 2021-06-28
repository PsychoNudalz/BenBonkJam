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

    // credits objects

    public GameObject mainCredits;
    public GameObject sfxCredits1;
    public GameObject sfxCredits2;
    public GameObject sfxCredits3;

    void Start()
    {
        mainCanvas.enabled = true;
        helpCanvas.enabled = false;
        creditsCanvas.enabled = false;

    }

    public void Play()
    {
        Debug.Log("Loading Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Help()
    {
        mainCanvas.enabled = false;
        helpCanvas.enabled = true;
        creditsCanvas.enabled = false;
    }

    // credits
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

    public void CreditsTwo()
    {
        sfxCredits1.SetActive(false);
        sfxCredits2.SetActive(true);
        sfxCredits3.SetActive(false);
    }

    public void backToMain()
    {
        mainCanvas.enabled = true;
        helpCanvas.enabled = false;
        creditsCanvas.enabled = false;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("QUITTING GAME");
    }
}
