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

    void Start()
    {
        mainCanvas.enabled = true;
        helpCanvas.enabled = false;
        creditsCanvas.enabled = false;

    }

    public void Play()
    {
        Debug.Log("Loading Game");
     //   SceneManager.LoadScene("Scene 01"); 
    }

    public void Help()
    {
        mainCanvas.enabled = false;
        helpCanvas.enabled = true;
        creditsCanvas.enabled = false;
    }

    public void Credits()
    {
        mainCanvas.enabled = false;
        creditsCanvas.enabled = true;
        helpCanvas.enabled = false;
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
