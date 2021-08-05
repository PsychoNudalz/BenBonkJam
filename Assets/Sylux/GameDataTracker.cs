using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataTracker : MonoBehaviour
{
    public GameDataManager gameDataManager;
    public CardEventManager cardEventManager;

    public bool alien;
    public bool athlete;
    public bool borderAwake;
    public bool dieYoung;
    public bool friendGhost;
    public bool hamDogAdventure;
    public bool hell;
    public bool paradise;
    public bool purgatory;
    public bool reincarnation;
    public bool sick;
    public bool voidEnding;
    public bool wakeUpSim;

    // Start is called before the first frame update
    void Start()
    {
     //   gameDataManager = FindObjectOfType("GameDataManager");

    }

    // Update is called once per frame
    void Update()
    {
        if (cardEventManager.currentCard.CardID == "DEA_000_")
        {
            alien = true;
            Debug.Log("Alien ending triggered");
            alien = GameDataManager.EndingsUnlocked.alien == true;
        }

        if (cardEventManager.currentCard.CardID == "DEA_008_")
        {
            borderAwake = GameDataManager.EndingsUnlocked.borderAwake == true;
        }

        if (cardEventManager.currentCard.CardID == "DEA_009_")
        {
            // Debug.log works, but the other two do not change
            dieYoung = true;
            Debug.Log("die young");
            dieYoung = GameDataManager.EndingsUnlocked.dieYoung == true;
        }

        if (cardEventManager.currentCard.CardID == "DEA_010_")
        {
            friendGhost = GameDataManager.EndingsUnlocked.friendGhost == true;
        }

        if (cardEventManager.currentCard.CardID == "DEA_011_")
        {
            hamDogAdventure = GameDataManager.EndingsUnlocked.hamDogAdventure == true;
        }
        if (cardEventManager.currentCard.CardID == "DEA_012_")
        {
            hell = GameDataManager.EndingsUnlocked.hell == true;
        }
        if (cardEventManager.currentCard.CardID == "DEA_002_")
        {
            paradise = GameDataManager.EndingsUnlocked.paradise == true;
        }
        if (cardEventManager.currentCard.CardID == "DEA_003_")
        {
            purgatory = GameDataManager.EndingsUnlocked.purgatory == true;
        }
        if (cardEventManager.currentCard.CardID == "DEA_004_")
        {
            reincarnation = GameDataManager.EndingsUnlocked.reincarnation == true;
        }
        if (cardEventManager.currentCard.CardID == "DEA_005_")
        {
            sick = GameDataManager.EndingsUnlocked.sick == true;
        }
        if (cardEventManager.currentCard.CardID == "DEA_006_")
        {
            voidEnding = GameDataManager.EndingsUnlocked.voidEnding == true;
        }
        if (cardEventManager.currentCard.CardID == "DEA_007_")
        {
            wakeUpSim = true;
            Debug.Log("Wake up ending triggered");
            wakeUpSim = GameDataManager.EndingsUnlocked.wakeUpSim == true;
        }
    }
}
