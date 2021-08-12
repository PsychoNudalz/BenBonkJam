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

    public GameObject pauseCanvas;
    public GameObject areYouSureCanvas;
    public GameObject mainPauseCanvas;

    void Start()
    {
        pauseCanvas.SetActive(false);
        areYouSureCanvas.SetActive(false);

        
    }

    public void PauseButton()
    {
        pauseCanvas.SetActive(true);
        mainPauseCanvas.SetActive(true);
    }

    public void ResumeButton()
    {
        pauseCanvas.SetActive(false);
    }

    public void MainMenuButton()
    {
        mainPauseCanvas.SetActive(false);
        areYouSureCanvas.SetActive(true);
    }

    public void NoButton()
    {
        mainPauseCanvas.SetActive(true);
        areYouSureCanvas.SetActive(false);
    }

    public void YesButton()
    {
        pauseCanvas.SetActive(false);
        areYouSureCanvas.SetActive(false);
        SceneManager.LoadScene("MainMenu");

    }
}
