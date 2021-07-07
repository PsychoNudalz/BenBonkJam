using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class CardHandler : MonoBehaviour
{
    [SerializeField] List<Card> allCards;
    [Header("Start Controls")]
    [SerializeField] bool runUpdateCardID;
    
    private void Awake()
    {
        //EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
    }
    
    private void Start()
    {
        UpdateCardIDs();
        SaveCardsToJson();
    }

    void UpdateCardIDs()
    {
        CardManager.ResetCounters();

        foreach (Card c in allCards)
        {
            c.CardID = CardManager.GetIDValue(c);
            c.gameObject.SetActive(false);
            c.gameObject.SetActive(true);
        }
    }

    public void SaveCardsToJson()
    {
        string saveString = "";
        List<CardSave> cardSaves = new List<CardSave>();
        foreach (Card c in allCards)
        {
            cardSaves.Add(new CardSave(c));
        }
        AllCardsSave allCardsSave = new AllCardsSave(cardSaves.ToArray());
        saveString = JsonUtility.ToJson(allCardsSave);
        print("Saving all cards");
        print(saveString);
        try
        {
            File.WriteAllText(Application.dataPath + "/Resource/" + "SavedCardsJSON.json", saveString);
        }
        catch(DirectoryNotFoundException e)
        {
            Directory.CreateDirectory(Application.dataPath + "/Resource/");
            File.WriteAllText(Application.dataPath + "/Resource/" + "SavedCardsJSON.json", saveString);

        }
    }

    public string SaveCardToCSV()
    {
        return "";
    }
}
