using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public enum CoinSide
{
    Heads,
    Tails
}
public class CoinScript : MonoBehaviour
{
    [SerializeField] CoinSide coinSide;
    [Header("Other Components")]
    [SerializeField] PlayerControlScript playerControlScript;
    [SerializeField] TextMeshPro coinSideText;
    // Start is called before the first frame update
    void Start()
    {
        if (!playerControlScript)
        {
            playerControlScript = FindObjectOfType<PlayerControlScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Angle(transform.up, Vector2.up)<90)
        {
            coinSideText.text = CoinSide.Heads.ToString();
        }
        else
        {
            coinSideText.text = CoinSide.Tails.ToString();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!playerControlScript)
        {
            playerControlScript = FindObjectOfType<PlayerControlScript>();
        }
        playerControlScript.SetControlLock(false);
    }
}
