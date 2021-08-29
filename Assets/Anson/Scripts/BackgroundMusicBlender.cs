using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicBlender : MonoBehaviour
{

    [SerializeField] List<AudioSource> musics;
    [SerializeField] AudioSource currentMusic;
    [SerializeField] AudioSource previousMusic;
    [SerializeField] float blendSpeed = 1f;
    [SerializeField] bool playFirstMusic;

    public static BackgroundMusicBlender current;
    // Start is called before the first frame update
    void Awake()
    {
        current = this;
        currentMusic = musics[0];
        //previousMusic = musics[0];
        foreach (AudioSource bgm in musics)
        {
            bgm.volume = 0;
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
        if (currentMusic && currentMusic.volume < 1f)
        {
            currentMusic.volume += Time.deltaTime * blendSpeed;
        }
        if (previousMusic && previousMusic.volume > 0f)
        {
            previousMusic.volume -= Time.deltaTime * blendSpeed;
        }
    }

    public void PlayAgeMusic(AgeEnum ageEnum)
    {
        if (previousMusic)
        {
            previousMusic.Stop();
        }
        Debug.Log("Music change");
        previousMusic = currentMusic;
        try
        {
            currentMusic = musics[(int)ageEnum];
            if (currentMusic.Equals(previousMusic))
            {
                previousMusic = null;
            }
            currentMusic.Play();

        }
        catch (System.IndexOutOfRangeException e)
        {
            Debug.LogError($"Age {ageEnum.ToString()} not in range of music size");
        }
    }

    public void PlayAgeMusic(int musicIndex)
    {
        if (previousMusic)
        {
            previousMusic.Stop();
        }
        Debug.Log("Music change");
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
