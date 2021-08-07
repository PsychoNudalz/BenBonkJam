using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StatsEndingDisplay : MonoBehaviour
{
    public GameDataManager gameDataManager;

    public Canvas alienCanvas;
    public Canvas athleteCanvas;
    public Canvas endingsStatsCanvas;
    public Canvas borderAwakeCanvas;
    public Canvas dieYoungCanvas;
    public Canvas ghostFriendCanvas;
    public Canvas petAdventureCanvas;
    public Canvas hellCanvas;
    public Canvas paradiseCanvas;
    public Canvas purgatoryCanvas;
    public Canvas reincarnationCanvas;
    public Canvas sickCanvas;
    public Canvas voidCanvas;
    public Canvas wakeUpSimCanvas;

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


    public void Start()
    {
        StartCoroutine(LateStart());

        alienCanvas.enabled = false;
        athleteCanvas.enabled = false;
        borderAwakeCanvas.enabled = false;
        dieYoungCanvas.enabled = false;
        ghostFriendCanvas.enabled = false;
        petAdventureCanvas.enabled = false;
        hellCanvas.enabled = false;
        paradiseCanvas.enabled = false;
        purgatoryCanvas.enabled = false;
        reincarnationCanvas.enabled = false;
        sickCanvas.enabled = false;
        voidCanvas.enabled = false;
        wakeUpSimCanvas.enabled = false;

    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(1);
        Endings();
    }

    public void Endings()
    {
        if (gameDataManager.EndingsUnlocked1.alien == true)
        {
            alienEnding.image.sprite = alien;
            alienEnding.interactable = true;

        }
        else
        {
            alienEnding.image.sprite = basic;
            alienEnding.interactable = false;
        }

        if (gameDataManager.EndingsUnlocked1.athlete == true)
        {
            athleteEnding.image.sprite = athlete;
            athleteEnding.interactable = true;
        }
        else
        {
            athleteEnding.image.sprite = basic;
            athleteEnding.interactable = false;
        }

        if (gameDataManager.EndingsUnlocked1.borderAwake == true)
        {
            borderAwakeEnding.image.sprite = borderAwake;
            borderAwakeEnding.interactable = true;
        }
        else
        {
            borderAwakeEnding.image.sprite = basic;
            borderAwakeEnding.interactable = false;
        }

        if (gameDataManager.EndingsUnlocked1.dieYoung == true)
        {
            dieYoungEnding.image.sprite = dieYoung;
            dieYoungEnding.interactable = true;

        }
        else
        {
            dieYoungEnding.image.sprite = basic;
            dieYoungEnding.interactable = false;

        }

        if (gameDataManager.EndingsUnlocked1.friendGhost == true)
        {
            ghostFriendEnding.image.sprite = friendGhost;
            ghostFriendEnding.interactable = true;
        }
        else
        {
            ghostFriendEnding.image.sprite = basic;
            ghostFriendEnding.interactable = false;        }

        if (gameDataManager.EndingsUnlocked1.hamDogAdventure == true)
        {
            petAdventureEnding.image.sprite = hamDogAdventure;
            petAdventureEnding.interactable = true;
        }
        else
        {
            petAdventureEnding.image.sprite = basic;
            petAdventureEnding.interactable = false;        }

        if (gameDataManager.EndingsUnlocked1.hell == true)
        {
            hellEnding.image.sprite = hell;
            hellEnding.interactable = true;
        }
        else
        {
            hellEnding.image.sprite = basic;
            hellEnding.interactable = false;        }

        if (gameDataManager.EndingsUnlocked1.paradise == true)
        {
            paradiseEnding.image.sprite = paradise;
            paradiseEnding.interactable = true;
        }
        else
        {
            paradiseEnding.image.sprite = basic;
            paradiseEnding.interactable = false;        }

        if (gameDataManager.EndingsUnlocked1.purgatory == true)
        {
            purgatoryEnding.image.sprite = purgatory;
            purgatoryEnding.interactable = true;
        }
        else
        {
            purgatoryEnding.image.sprite = basic;
            purgatoryEnding.interactable = false;        }

        if (gameDataManager.EndingsUnlocked1.reincarnation == true)
        {
            reincarnationEnding.image.sprite = reincarnation;
            reincarnationEnding.interactable = true;
        }
        else
        {
            reincarnationEnding.image.sprite = basic;
            reincarnationEnding.interactable = false;        }

        if (gameDataManager.EndingsUnlocked1.sick == true)
        {
            sickEnding.image.sprite = sick;
            sickEnding.interactable = true;
        }
        else
        {
            sickEnding.image.sprite = basic;
            sickEnding.interactable = false;        }

        if (gameDataManager.EndingsUnlocked1.voidEnding == true)
        {
            voidEnding.image.sprite = voidE;
            voidEnding.interactable = true;
        }
        else
        {
            voidEnding.image.sprite = basic;
            voidEnding.interactable = false;        }

        if (gameDataManager.EndingsUnlocked1.wakeUpSim == true)
        {
            wakeUpSimEnding.image.sprite = wakeUpSim;
            wakeUpSimEnding.interactable = true;
        }
        else
        {
            wakeUpSimEnding.image.sprite = basic;
            wakeUpSimEnding.interactable = false;        }


    }

    public void AthleteButton()
    {
        athleteCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;
    }

    public void AlienButton()
    {
        alienCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;

    }
    public void BorderAwakeButton()
    {
        borderAwakeCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;
        
    }

    public void DieYoungButton()
    {
        dieYoungCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;
    }

    public void GhostFriendButton()
    {
        ghostFriendCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;

    }

    public void PetAdventureButton()
    {
        petAdventureCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;
    }

    public void HellButton()
    {
        hellCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;

    }

    public void ParadiseButton()
    {
        paradiseCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;
    }

    public void PurgatoryButton()
    {
        purgatoryCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;

    }

    public void ReincarnationButton()
    {
        reincarnationCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;
    }

    public void SickButton()
    {
        sickCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;
    }

    public void VoidEButton()
    {
        voidCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;
    }

    public void WakeUpSimButton()
    {
        wakeUpSimCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;
    }

    public void Back()
    {
        athleteCanvas.enabled = false;
        endingsStatsCanvas.enabled = true;
        alienCanvas.enabled = false;
        borderAwakeCanvas.enabled = false;
        dieYoungCanvas.enabled = false;
        ghostFriendCanvas.enabled = false;
        petAdventureCanvas.enabled = false;
        hellCanvas.enabled = false;
        paradiseCanvas.enabled = false;
        purgatoryCanvas.enabled = false;
        reincarnationCanvas.enabled = false;
        sickCanvas.enabled = false;
        voidCanvas.enabled = false;
        wakeUpSimCanvas.enabled = false;
        endingsStatsCanvas.enabled = true;
    }

    public void BackPage2()
    {
        athleteCanvas.enabled = false;
        endingsStatsCanvas.enabled = true;
        alienCanvas.enabled = false;
        borderAwakeCanvas.enabled = false;
        dieYoungCanvas.enabled = false;
        ghostFriendCanvas.enabled = false;
        petAdventureCanvas.enabled = false;
        hellCanvas.enabled = false;
        paradiseCanvas.enabled = false;
        purgatoryCanvas.enabled = false;
        reincarnationCanvas.enabled = false;
        sickCanvas.enabled = false;
        voidCanvas.enabled = false;
        wakeUpSimCanvas.enabled = false;
        endingsStatsCanvas.enabled = true;
    }

    public void BackPage3()
    {
        athleteCanvas.enabled = false;
        endingsStatsCanvas.enabled = true;
        alienCanvas.enabled = false;
        borderAwakeCanvas.enabled = false;
        dieYoungCanvas.enabled = false;
        ghostFriendCanvas.enabled = false;
        petAdventureCanvas.enabled = false;
        hellCanvas.enabled = false;
        paradiseCanvas.enabled = false;
        purgatoryCanvas.enabled = false;
        reincarnationCanvas.enabled = false;
        sickCanvas.enabled = false;
        voidCanvas.enabled = false;
        wakeUpSimCanvas.enabled = false;
        endingsStatsCanvas.enabled = true;
    }
}
