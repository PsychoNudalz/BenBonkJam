using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;
    public AudioMixer audioMixer;
    public float sFXVolume;
    public float musicVolume;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetMusicLevel(float sliderValue)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(sliderValue) * 20);
    }

    public void SetSFXLevel(float sliderValue)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(sliderValue) * 20);
    }
}
