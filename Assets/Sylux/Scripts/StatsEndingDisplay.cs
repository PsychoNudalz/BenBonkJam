using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;

public class StatsEndingDisplay : MonoBehaviour
{
    #region references

    public Text timesDiedText;


    public GameDataManager gameDataManager;

    public Canvas achievementsPage1Canvas;
    public Canvas achievementsPage2Canvas;
    public Canvas achievementsPage3Canvas;

    public Canvas endingsPage1StatsCanvas;
    public Canvas endingsPage2StatsCanvas;
    public Canvas endingsPage3StatsCanvas;
    public Canvas endingsStatsCanvas;

    public Canvas statisticsCanvas;

    // endings
    public Canvas alienCanvas;
    public Canvas athleteCanvas;
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

    public Button endingsButton;
    public Button achievementsButton;
    public Button statisticsButton;

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

    // achievements
    public Button die50TimesButton;
    public Button gradeSObtainedButton;
    public Button statusEffects10ObtainedButton;
    public Button educationMaxedOutObtainedButton;
    public Button oldAgeObtainedButton;

    public Canvas die50TimesCanvas;

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

    // achievement Sprites


    public Sprite basic;

    #endregion

    public void Start()
    {
        Statistics();
        StartCoroutine(LateStart());

        die50TimesCanvas.enabled = false;

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

        endingsButton.interactable = true;
        achievementsButton.interactable = true;
    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(1);
        Achievements();
        Endings();
    }

    public void Statistics()
    {
        timesDiedText.text = gameDataManager.Achievements1.timesDied.ToString();
        if (gameDataManager.Achievements1.timesDied >= 50 && gameDataManager.Achievements1.die50Times == false)
        {
            gameDataManager.Achievements1.die50Times = true;
            gameDataManager.SaveGame();
        }
        else
        {
            return;
        }
    }
    public void Update()
    {
        ColorBlock cb = endingsButton.colors;
        ColorBlock cb2 = achievementsButton.colors;
        ColorBlock cb3 = statisticsButton.colors;

        if (endingsPage1StatsCanvas.enabled == true || endingsPage2StatsCanvas.enabled == true || endingsPage3StatsCanvas.enabled == true)
        {
            cb.selectedColor = new Color(0.0f, 0.75f, 1f, 1f);
            cb.normalColor = new Color(0.0f, 0.75f, 1f, 1f);
            endingsButton.interactable = false;
            cb.disabledColor = new Color (0.0f, 0.75f, 1f, 1f); 
            endingsButton.colors = cb;
        }
        else
        {
            cb.selectedColor = new Color(255, 255, 255, 255);
            cb.normalColor = new Color(255, 255, 255, 255);
            endingsButton.interactable = true;
            endingsButton.colors = cb;
        }

        // achievements
        if (achievementsPage1Canvas.enabled == true || achievementsPage2Canvas.enabled == true || achievementsPage3Canvas.enabled == true)
        {
            cb2.selectedColor = new Color(0.0f, 0.75f, 1f, 1f);
            cb2.normalColor = new Color(0.0f, 0.75f, 1f, 1f);
            achievementsButton.interactable = false;
            cb2.disabledColor = new Color(0.0f, 0.75f, 1f, 1f);
            achievementsButton.colors = cb2;
        }
        else
        {
            cb2.selectedColor = new Color(255, 255, 255, 255);
            cb2.normalColor = new Color(255, 255, 255, 255);
            achievementsButton.interactable = true;
            achievementsButton.colors = cb2;
        }

        if (statisticsCanvas.enabled == true)
        {
            cb3.selectedColor = new Color(0.0f, 0.75f, 1f, 1f);
            cb3.normalColor = new Color(0.0f, 0.75f, 1f, 1f);
            statisticsButton.interactable = false;
            cb3.disabledColor = new Color(0.0f, 0.75f, 1f, 1f);
            statisticsButton.colors = cb3;
        }
        else
        {
            cb3.selectedColor = new Color(255, 255, 255, 255);
            cb3.normalColor = new Color(255, 255, 255, 255);
            statisticsButton.interactable = true;
            statisticsButton.colors = cb3;
        }

    }

    public void Achievements()
    {
        if (gameDataManager.Achievements1.die50Times == true)
        {
            die50TimesButton.image.sprite = dieYoung;
            die50TimesButton.interactable = true;
        }
        else
        {
            die50TimesButton.image.sprite = basic;
            die50TimesButton.interactable = false;
        }

        if (gameDataManager.Achievements1.gradeSObtained == true)
        {
            gradeSObtainedButton.image.sprite = dieYoung;
            gradeSObtainedButton.interactable = true;
        }
        else
        {
            gradeSObtainedButton.image.sprite = basic;
            gradeSObtainedButton.interactable = false;
        }

        if (gameDataManager.Achievements1.statusEffects10Obtained == true)
        {
            statusEffects10ObtainedButton.image.sprite = dieYoung;
            statusEffects10ObtainedButton.interactable = true;
        }
        else
        {
            statusEffects10ObtainedButton.image.sprite = basic;
            statusEffects10ObtainedButton.interactable = false;
        }

        if (gameDataManager.Achievements1.educationMaxedOut == true)
        {
            educationMaxedOutObtainedButton.image.sprite = dieYoung;
            educationMaxedOutObtainedButton.interactable = true;
        }
        else
        {
            educationMaxedOutObtainedButton.image.sprite = basic;
            educationMaxedOutObtainedButton.interactable = false;
        }

        if (gameDataManager.Achievements1.oldAgeObtained == true)
        {
            oldAgeObtainedButton.image.sprite = dieYoung;
            oldAgeObtainedButton.interactable = true;
        }
        else
        {
            oldAgeObtainedButton.image.sprite = basic;
            oldAgeObtainedButton.interactable = false;
        }
    }
    public void die50Times()
    {
        die50TimesCanvas.enabled = true;
        achievementsPage1Canvas.enabled = false;
        achievementsPage2Canvas.enabled = false;
        achievementsPage3Canvas.enabled = false;
        endingsStatsCanvas.enabled = false;
    }

    public void BackToAchievements1()
    {
        endingsStatsCanvas.enabled = true;

        achievementsPage1Canvas.enabled = true;

        die50TimesCanvas.enabled = false;

    }

    public void BackToAchievements2()
    {

    }

    public void BackToAchievements3()
    {

    }

    #region EndingsMenu
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
            ghostFriendEnding.interactable = false;
        }

        if (gameDataManager.EndingsUnlocked1.hamDogAdventure == true)
        {
            petAdventureEnding.image.sprite = hamDogAdventure;
            petAdventureEnding.interactable = true;
        }
        else
        {
            petAdventureEnding.image.sprite = basic;
            petAdventureEnding.interactable = false;
        }

        if (gameDataManager.EndingsUnlocked1.hell == true)
        {
            hellEnding.image.sprite = hell;
            hellEnding.interactable = true;
        }
        else
        {
            hellEnding.image.sprite = basic;
            hellEnding.interactable = false;
        }

        if (gameDataManager.EndingsUnlocked1.paradise == true)
        {
            paradiseEnding.image.sprite = paradise;
            paradiseEnding.interactable = true;
        }
        else
        {
            paradiseEnding.image.sprite = basic;
            paradiseEnding.interactable = false;
        }

        if (gameDataManager.EndingsUnlocked1.purgatory == true)
        {
            purgatoryEnding.image.sprite = purgatory;
            purgatoryEnding.interactable = true;
        }
        else
        {
            purgatoryEnding.image.sprite = basic;
            purgatoryEnding.interactable = false;
        }

        if (gameDataManager.EndingsUnlocked1.reincarnation == true)
        {
            reincarnationEnding.image.sprite = reincarnation;
            reincarnationEnding.interactable = true;
        }
        else
        {
            reincarnationEnding.image.sprite = basic;
            reincarnationEnding.interactable = false;
        }

        if (gameDataManager.EndingsUnlocked1.sick == true)
        {
            sickEnding.image.sprite = sick;
            sickEnding.interactable = true;
        }
        else
        {
            sickEnding.image.sprite = basic;
            sickEnding.interactable = false;
        }

        if (gameDataManager.EndingsUnlocked1.voidEnding == true)
        {
            voidEnding.image.sprite = voidE;
            voidEnding.interactable = true;
        }
        else
        {
            voidEnding.image.sprite = basic;
            voidEnding.interactable = false;
        }

        if (gameDataManager.EndingsUnlocked1.wakeUpSim == true)
        {
            wakeUpSimEnding.image.sprite = wakeUpSim;
            wakeUpSimEnding.interactable = true;
        }
        else
        {
            wakeUpSimEnding.image.sprite = basic;
            wakeUpSimEnding.interactable = false;
        }


    }

    public void AthleteButton()
    {
        athleteCanvas.enabled = true;
        endingsPage1StatsCanvas.enabled = false;
        endingsPage2StatsCanvas.enabled = false;
        endingsPage3StatsCanvas.enabled = false;
        endingsStatsCanvas.enabled = false;
    }

    public void AlienButton()
    {
        alienCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;
        endingsPage1StatsCanvas.enabled = false;
        endingsPage2StatsCanvas.enabled = false;
        endingsPage3StatsCanvas.enabled = false;

    }
    public void BorderAwakeButton()
    {
        borderAwakeCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;
        endingsPage1StatsCanvas.enabled = false;
        endingsPage2StatsCanvas.enabled = false;
        endingsPage3StatsCanvas.enabled = false;

    }

    public void DieYoungButton()
    {
        dieYoungCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;
        endingsPage1StatsCanvas.enabled = false;
        endingsPage2StatsCanvas.enabled = false;
        endingsPage3StatsCanvas.enabled = false;
    }

    public void GhostFriendButton()
    {
        ghostFriendCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;
        endingsPage1StatsCanvas.enabled = false;
        endingsPage2StatsCanvas.enabled = false;
        endingsPage3StatsCanvas.enabled = false;

    }

    public void PetAdventureButton()
    {
        petAdventureCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;
        endingsPage1StatsCanvas.enabled = false;
        endingsPage2StatsCanvas.enabled = false;
        endingsPage3StatsCanvas.enabled = false;
    }

    public void HellButton()
    {
        hellCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;
        endingsPage1StatsCanvas.enabled = false;
        endingsPage2StatsCanvas.enabled = false;
        endingsPage3StatsCanvas.enabled = false;
    }

    public void ParadiseButton()
    {
        paradiseCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;
        endingsPage1StatsCanvas.enabled = false;
        endingsPage2StatsCanvas.enabled = false;
        endingsPage3StatsCanvas.enabled = false;
    }

    public void PurgatoryButton()
    {
        purgatoryCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;
        endingsPage1StatsCanvas.enabled = false;
        endingsPage2StatsCanvas.enabled = false;
        endingsPage3StatsCanvas.enabled = false;

    }

    public void ReincarnationButton()
    {
        reincarnationCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;
        endingsPage1StatsCanvas.enabled = false;
        endingsPage2StatsCanvas.enabled = false;
        endingsPage3StatsCanvas.enabled = false;
    }

    public void SickButton()
    {
        sickCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;
        endingsPage1StatsCanvas.enabled = false;
        endingsPage2StatsCanvas.enabled = false;
        endingsPage3StatsCanvas.enabled = false;
    }

    public void VoidEButton()
    {
        voidCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;
        endingsPage1StatsCanvas.enabled = false;
        endingsPage2StatsCanvas.enabled = false;
        endingsPage3StatsCanvas.enabled = false;
    }

    public void WakeUpSimButton()
    {
        wakeUpSimCanvas.enabled = true;
        endingsStatsCanvas.enabled = false;
        endingsPage1StatsCanvas.enabled = false;
        endingsPage2StatsCanvas.enabled = false;
        endingsPage3StatsCanvas.enabled = false;
    }

    public void EndingBackPage1()
    {
        endingsPage1StatsCanvas.enabled = true;

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

    public void EndingBackPage2()
    {
        endingsPage2StatsCanvas.enabled = true;

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

    public void EndingsBackPage3()
    {
        endingsPage3StatsCanvas.enabled = true;

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
    #endregion
}
