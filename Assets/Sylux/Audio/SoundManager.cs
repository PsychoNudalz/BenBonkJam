using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using System.IO;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;
    public AudioMixer audioMixer;
    public float musicSliderValueFloat;
    public float SFXsliderValueFloat;

    [SerializeField] SavedSettings savedSettings = new SavedSettings();
    public SavedSettings SavedSettings1 { get => savedSettings; set => savedSettings = value; }

    private void Awake()
    {
        ReadFromSave();
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


    }

    private void WriteToSave()
    {
        Debug.Log("Writing Save");
        string json = JsonUtility.ToJson(savedSettings);

        File.WriteAllText(Application.persistentDataPath + "/Save/savedSettings.json", json);
        Debug.Log(Application.persistentDataPath);
        Debug.Log(json);

        Debug.Log("Saved settings.");


        //  Achievements loadedAchievements = JsonUtility.FromJson<Achievements>(json);
        //  EndingsUnlocked loadedEndingsUnlocked = JsonUtility.FromJson<EndingsUnlocked>(json);
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
}

public class SavedSettings
{
    public float musicSliderValue;

}
