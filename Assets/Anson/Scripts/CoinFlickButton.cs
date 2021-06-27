using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinFlickButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] PlayerControlScript playerControlScript;

    private void Start()
    {
        if (!playerControlScript)
        {
            playerControlScript = FindObjectOfType<PlayerControlScript>();
        }
        button.onClick.AddListener( ChargeCoin);
        button.onClick.AddListener( LaunchCoin);
    }

    void ChargeCoin()
    {
        print("Charge");
        playerControlScript.SetCharge(true);
    }
void LaunchCoin()
    {
        playerControlScript.SetCharge(true);
    }
}
