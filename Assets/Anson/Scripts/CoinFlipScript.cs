using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFlipScript : MonoBehaviour
{
    [Header("Coin")]
    [SerializeField] GameObject coinGO;
    [SerializeField] Rigidbody2D coinRB;
    [SerializeField] CoinScript coinScript;
    [Header("Launch Stuff")]
    [SerializeField] Vector2 launchForce = new Vector2(10f, 100f);
    [SerializeField] Vector2 launchTorque = new Vector2(10f, 100f);
    [SerializeField] Transform lauchPoint;

    private void Start()
    {
        if (!coinRB)
        {
            if (!coinGO)
            {
                Debug.LogError("no Coin assigned");
                return;
            }
            coinRB = coinGO.GetComponent<Rigidbody2D>();
        }
        if (!coinScript)
        {
            coinGO.GetComponent<CoinScript>();
        }
    }
    public void LaunchCoin(float charge)
    {
        if (!coinRB)
        {
            if (!coinGO)
            {
                Debug.LogError("no Coin assigned");
                return;
            }
            coinRB = coinGO.GetComponent<Rigidbody2D>();
        }
        ResetCoinPosition();
        coinRB.bodyType = RigidbodyType2D.Dynamic;
        coinRB.AddForce(coinRB.mass* transform.up * (launchForce.x + charge * (launchForce.y-launchForce.x)));
        coinRB.AddTorque(coinRB.mass * launchTorque.x + charge * (launchTorque.y- launchTorque.x));
    }

    public void ResetCoinPosition()
    {
        coinGO.transform.position = lauchPoint.position;
        coinRB.bodyType = RigidbodyType2D.Kinematic;

    }


}
