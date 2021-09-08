using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private GameObject buttons;
    [SerializeField] private GameObject coinText;

    private PlayerControlScript playerControl;
    private UIHandler uiHandler;

    void Start()
    {
        playerControl = FindObjectOfType<PlayerControlScript>();
        uiHandler = FindObjectOfType<UIHandler>();
    }

    void OnFlipKeyboard()
    {
        if (playerControl.ControlLock)
        {
            buttons.SetActive(false);
            playerControl.SetControlLock(false);
            coinText.SetActive(true);
            playerControl.SetCharge(true);
        }
        else
        {
            playerControl.SetCharge(false);
        }
    }

    void OnHeads()
    {
        uiHandler.Play_Heads();
    }

    void OnTails()
    {
        uiHandler.Play_Tails();
    }
}
