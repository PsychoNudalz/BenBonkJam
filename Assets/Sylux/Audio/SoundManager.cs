using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;
using System.IO;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;
    public AudioMixer audioMixer;
    public float musicSliderValueFloat;
    public float SFXsliderValueFloat;

    public Slider musicSlider;
    public Slider sfxSlider;

    [SerializeField] SavedSettings savedSettings;
    public SavedSettings SavedSettings1 { get => savedSettings; set => savedSettings = value; }

    private void Start()
    {
        ReadFromSave();
        musicSlider.value = musicSliderValueFloat;
        sfxSlider.value = SFXsliderValueFloat;

    }

    private void ReadFromSave()
    {
        string json = JsonUtility.ToJson(savedSettings);
        try
        {
            Debug.Log("Loading sound settings");
            json = File.ReadAllText(Application.persistentDataPath + "/Save/savedSettings.json");
        }
        catch (System.Exception)
        {
            Debug.Log("settingsSaved not found");
            Directory.CreateDirectory(Application.persistentDataPath + "/Save/");
            File.WriteAllText(Application.persistentDataPath + "/Save/savedSettings.json", json);

          //  Debug.LogError("Save file error");
            //   Debug.LogError(Exception.StackTrace);

        }

        savedSettings = JsonUtility.FromJson<SavedSettings>(json);
        musicSliderValueFloat = savedSettings.musicSliderValueFloat;
        SFXsliderValueFloat = savedSettings.SFXsliderValueFloat;
        SetMusicLevel(musicSliderValueFloat);
        SetSFXLevel(SFXsliderValueFloat);
    }

    private void WriteToSave()
    {
        savedSettings = new SavedSettings(musicSliderValueFloat, SFXsliderValueFloat);

        Debug.Log("Writing Save");
        string json = JsonUtility.ToJson(savedSettings);

        File.WriteAllText(Application.persistentDataPath + "/Save/savedSettings.json", json);
        Debug.Log(Application.persistentDataPath);
        Debug.Log(json);

        Debug.Log("Saved settings.");

    }

    public void SetMusicLevel(float musicSliderValue)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(musicSliderValue) * 20);
        musicSliderValueFloat = musicSliderValue;
    }

    public void SetSFXLevel(float SFXsliderValue)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(SFXsliderValue) * 20);
        SFXsliderValueFloat = SFXsliderValue;
    }

    public void OnApplicationQuit()
    {
        WriteToSave();
    }
}

public class SavedSettings
{
    public float musicSliderValueFloat;
    public float SFXsliderValueFloat;

    public SavedSettings(float musicSliderValueFloat, float SFXsliderValueFloat)
    {
        this.musicSliderValueFloat = musicSliderValueFloat;
        this.SFXsliderValueFloat = SFXsliderValueFloat;
    }


}
