using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

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

    [Header("Mixer")]
    [SerializeField] AudioMixerGroup audioMixerGroup;

    [Header("Effects")]
    [SerializeField] bool autoFindParticles;
    [SerializeField] UnityEvent headsEffect;
    [SerializeField] UnityEvent tailsEffect;

    public AudioSource PlayCardSound { get => playCardSound; }
    public AudioSource HeadsSound { get => headsSound; }
    public AudioSource TailsSound { get => tailsSound; }

    private void Awake()
    {
        if (audioMixerGroup!= null)
        {
            playCardSound.outputAudioMixerGroup = audioMixerGroup;
            headsSound.outputAudioMixerGroup = audioMixerGroup;
            tailsSound.outputAudioMixerGroup = audioMixerGroup;
        }
        if (autoFindParticles|| (headsEffect.GetPersistentEventCount()==0&& headsEffect.GetPersistentEventCount() == 0))
        {
            AutoAddEffects();
        }
    }

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

    public void PlayHeads()
    {
        headsEffect.Invoke();
        PlaySound(CardSoundEnum.HEADS);
    }

    public void PlayTails()
    {
        tailsEffect.Invoke();
        PlaySound(CardSoundEnum.TAILS);

    }

    
    [ContextMenu("Auto find and add particles")]
    public void AutoAddEffects()
    {
        AutoAddEffectsToUE(headsEffect, "head");
        AutoAddEffectsToUE(tailsEffect, "tail");
    }

    void AutoAddEffectsToUE(UnityEvent ue, string name)
    {
        //ue.RemoveAllListeners();
        foreach (ParticleSystem ps in GetComponentsInChildren<ParticleSystem>())
        {
            if (ps.name.ToLower().Contains(name.ToLower()))
            {
                ue.AddListener(ps.Play);
            }
        }
    }
}