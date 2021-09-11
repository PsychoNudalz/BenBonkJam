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
    private bool controlsLocked = false;

    public bool ControlsLocked
    {
        get => controlsLocked;
        set => controlsLocked = value;
    }

    void Start()
    {
        playerControl = FindObjectOfType<PlayerControlScript>();
        uiHandler = FindObjectOfType<UIHandler>();
    }

    void OnFlipKeyboard()
    {
        if(controlsLocked){return;}
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
        if(controlsLocked){return;}

        uiHandler.Play_Heads();
    }

    void OnTails()
    {
        if(controlsLocked){return;}

        uiHandler.Play_Tails();
    }

    [ContextMenu("Lock Controls")]
    public void LockControls()
    {
        controlsLocked = true;
    }
    
    [ContextMenu("Unlock Controls")]
    public void UnlockControls()
    {
        controlsLocked = false;
    }
}
