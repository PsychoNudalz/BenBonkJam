using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardSoundEnum
{
    PLAY,
    HEADS,
    TAILS
}
public class CardEffectScript : MonoBehaviour
{

    [Header("Sound")]

    [SerializeField] AudioSource playCardSound;
    [SerializeField] AudioSource headsSound;
    [SerializeField] AudioSource tailsSound;

    public AudioSource PlayCardSound { get => playCardSound; }
    public AudioSource HeadsSound { get => headsSound; }
    public AudioSource TailsSound { get => tailsSound; }

    public void PlaySound(CardSoundEnum c)
    {
        try
        {
            switch (c)
            {
                case CardSoundEnum.PLAY:
                    playCardSound.Play();
                    break;
                case CardSoundEnum.HEADS:
                    headsSound.Play();
                    break;
                case CardSoundEnum.TAILS:
                    tailsSound.Play();
                    break;
            }
        }
        catch (System.Exception e)
        {

        }
    }
}