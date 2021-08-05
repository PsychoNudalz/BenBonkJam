using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StatsEndingDisplay : MonoBehaviour
{
    public GameDataManager gameDataManager;


    public Button alienEnding;
    public Button athleteEnding;
    public Button borderAwakeEnding;
    public Button dieYoungEnding;
    public Button ghostFriendEnding;
    public Button petAdventureEnding;
    public Button hellEnding;
    public Button paradiseEnding;
    public Button purgatoryEnding;
    public Button reincarnationEnding;
    public Button sickEnding;
    public Button voidEnding;
    public Button wakeUpSimEnding;

    public Sprite alien;
    public Sprite athlete;
    public Sprite borderAwake;
    public Sprite dieYoung;
    public Sprite friendGhost;
    public Sprite hamDogAdventure;
    public Sprite hell;
    public Sprite paradise;
    public Sprite purgatory;
    public Sprite reincarnation;
    public Sprite sick;
    public Sprite voidE;
    public Sprite wakeUpSim;

    public Sprite basic;


    public void Awake()

    {

    }

    public void Update()
    {
        Endings();
        
    }
    public void Endings()
    {
        if (gameDataManager.EndingsUnlocked1.alien == true)
        {
              alienEnding.image.sprite = alien;
            Debug.Log("Alien ending sprite");
        }
        else
        {
            Debug.Log("No alien ending sprite");

            alienEnding.image.sprite = basic;
        }

        if (gameDataManager.EndingsUnlocked1.athlete == true)
        {
            athleteEnding.image.sprite = athlete;
        }
        else
        {
            athleteEnding.image.sprite = basic;
        }

        if (gameDataManager.EndingsUnlocked1.borderAwake == true)
        {
            borderAwakeEnding.image.sprite = borderAwake;
        }
        else
        {
            borderAwakeEnding.image.sprite = basic;
        }

        if (gameDataManager.EndingsUnlocked1.dieYoung == true)
        {
            dieYoungEnding.image.sprite = dieYoung;
        }
        else
        {
            dieYoungEnding.image.sprite = basic;
        }

        if (gameDataManager.EndingsUnlocked1.friendGhost == true)
        {
            ghostFriendEnding.image.sprite = friendGhost;
        }
        else
        {
            ghostFriendEnding.image.sprite = basic;
        }

        if (gameDataManager.EndingsUnlocked1.hamDogAdventure == true)
        {
            petAdventureEnding.image.sprite = hamDogAdventure;
        }
        else
        {
            petAdventureEnding.image.sprite = basic;
        }

        if (gameDataManager.EndingsUnlocked1.hell == true)
        {
            hellEnding.image.sprite = hell;
        }
        else
        {
            hellEnding.image.sprite = basic;
        }

        if (gameDataManager.EndingsUnlocked1.paradise == true)
        {
            paradiseEnding.image.sprite = paradise;
        }
        else
        {
            paradiseEnding.image.sprite = basic;
        }

        if (gameDataManager.EndingsUnlocked1.purgatory == true)
        {
            purgatoryEnding.image.sprite = purgatory;
        }
        else
        {
            purgatoryEnding.image.sprite = basic;
        }

        if (gameDataManager.EndingsUnlocked1.reincarnation == true)
        {
            reincarnationEnding.image.sprite = reincarnation;
        }
        else
        {
            reincarnationEnding.image.sprite = basic;
        }

        if (gameDataManager.EndingsUnlocked1.sick == true)
        {
            sickEnding.image.sprite = sick;
        }
        else
        {
            sickEnding.image.sprite = basic;
        }

        if (gameDataManager.EndingsUnlocked1.voidEnding == true)
        {
            voidEnding.image.sprite = voidE;
        }
        else
        {
            voidEnding.image.sprite = basic;
        }

        if (gameDataManager.EndingsUnlocked1.wakeUpSim == true)
        {
            wakeUpSimEnding.image.sprite = wakeUpSim;
        }
        else
        {
            wakeUpSimEnding.image.sprite = basic;
        }


    }
}
