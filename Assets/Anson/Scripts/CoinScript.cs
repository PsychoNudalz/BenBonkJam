using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public enum CoinSide
{
    HEADS,
    TAILS
}
public class CoinScript : MonoBehaviour
{
    [SerializeField] CoinSide coinSide;
    [SerializeField] bool launchCoin;
    [Space]
    [SerializeField] UnityEvent OnCollisionEvent;
    [SerializeField] AudioSource collisionSound;
    [Header("Coin Display")]
    [SerializeField] SpriteRenderer coinRender;
    [SerializeField] Sprite headsSprite;
    [SerializeField] Sprite tailsSprite;
    [Header("Other Components")]
    [SerializeField] PlayerControlScript playerControlScript;
    [SerializeField] TextMeshPro coinSideText;
    [SerializeField] CardEventManager cardEventManager;


    public bool LaunchCoin { get => launchCoin; set => launchCoin = value; }

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
        coinSideText.text = GetCoinSide().ToString();
        switch (GetCoinSide())
        {
            case CoinSide.HEADS:
                coinRender.sprite = headsSprite;
                break;
            case CoinSide.TAILS:
                coinRender.sprite = tailsSprite;
                break;
        }
    }

    CoinSide GetCoinSide()
    {
        if (Vector2.Angle(transform.up, Vector2.up) < 90)
        {
            return CoinSide.HEADS;
        }
        else
        {
            return CoinSide.TAILS;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!launchCoin)
        {
            return;
        }
        else
        {
            if (collisionSound)
            {
                collisionSound.Stop();
                collisionSound.Play();
            }
            OnCollisionEvent.Invoke();
        }
        if (!playerControlScript)
        {
            playerControlScript = FindObjectOfType<PlayerControlScript>();
        }
        if (!cardEventManager)
        {
            cardEventManager = FindObjectOfType<CardEventManager>();
        }


        cardEventManager.Play_Coin(GetCoinSide());
        launchCoin = false;

    }
    public void OnLand()
    {

    }
}
