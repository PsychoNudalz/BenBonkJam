using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [Header("Pause Menu Buttons")]
    [SerializeField] private Button mainMenu;
    [SerializeField] private Button resume;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;

    [Header("Game Objects")]
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject areYouSureCanvas;
    [SerializeField] private GameObject mainPauseCanvas;

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
        
        if(SceneTransition.Instance != null)
        {
            SceneTransition.Instance.FadeToScene(0);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
