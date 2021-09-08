using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class BackgroundMusic
{
    public AudioSource music;
    public AnimationCurve fadeIn;
    public AnimationCurve fadeOut;
    //public float volume { get => music.volume; set => music.volume = value; }

    public void Play()
    {
        if (music)
        {
            music.Play();
        }
    }

    public void Stop()
    {
        if (music)
        {
            music.Stop();
        }
    }


}


public class BackgroundMusicBlender : MonoBehaviour
{

    [SerializeField] List<BackgroundMusic> musics;
    [SerializeField] BackgroundMusic currentMusic;
    [SerializeField] BackgroundMusic previousMusic;
    [SerializeField] float blendSpeed = 1f;
    [SerializeField] bool playFirstMusic;

    [SerializeField] float fadeInValue = 0;
    [SerializeField] float fadeOutValue = 0;

    public static BackgroundMusicBlender current;
    // Start is called before the first frame update
    void Start()
    {
        current = this;
        currentMusic = musics[0];
        //previousMusic = musics[0];
        foreach (BackgroundMusic bgm in musics)
        {
            bgm.music.volume = 0;
        }
        if (playFirstMusic)
        {
            currentMusic.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMusic();
    }

    void UpdateMusic()
    {
        if (currentMusic.music != null && (currentMusic.music.volume < 1f || fadeInValue < 1f))
        {
            fadeInValue += Time.deltaTime * blendSpeed;
            currentMusic.music.volume = currentMusic.fadeIn.Evaluate(fadeInValue);
        }
        try
        {

            if (previousMusic.music != null && (previousMusic.music.volume > 0f || fadeOutValue < 1f))
            {
                fadeOutValue += Time.deltaTime * blendSpeed;
                previousMusic.music.volume = previousMusic.fadeOut.Evaluate(fadeOutValue);

            }
        }
        catch (System.NullReferenceException e)
        {

        }
    }

    public void PlayAgeMusic(AgeEnum ageEnum)
    {
        PlayAgeMusic((int)ageEnum);
    }

    public void PlayAgeMusic(int musicIndex)
    {
        fadeInValue = 0;
        fadeOutValue = 0;
        if (previousMusic != null && previousMusic.music != null)
        {
            previousMusic.Stop();
        }
        //Debug.Log("Music change");
        previousMusic = currentMusic;
        try
        {
            currentMusic = musics[musicIndex];
            if (currentMusic.Equals(previousMusic))
            {
                previousMusic = null;
            }
            currentMusic.Play();

        }
        catch (System.IndexOutOfRangeException e)
        {
            Debug.LogError($"music index {musicIndex} is out of range");
        }
    }
}
