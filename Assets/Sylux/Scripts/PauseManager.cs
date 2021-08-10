using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public Button mainMenu;
    public Button resume;
    public Button yesButton;
    public Button noButton;

    public Canvas pauseCanvas;
    public Canvas areYouSureCanvas;
    public Canvas mainPauseCanvas;

    void Start()
    {
        pauseCanvas.enabled = false;
        areYouSureCanvas.enabled = false;
    }

    public void PauseButton()
    {
        pauseCanvas.enabled = true;
        mainPauseCanvas.enabled = true;
    }

    public void ResumeButton()
    {
        pauseCanvas.enabled = false;
    }

    public void MainMenuButton()
    {
        mainPauseCanvas.enabled = false;
        areYouSureCanvas.enabled = true;
    }

    public void NoButton()
    {
        mainPauseCanvas.enabled = true;
        areYouSureCanvas.enabled = false;
    }

    public void YesButton()
    {
        pauseCanvas.enabled = false;
        areYouSureCanvas.enabled = false;
        SceneManager.LoadScene("MainMenu");

    }
}
