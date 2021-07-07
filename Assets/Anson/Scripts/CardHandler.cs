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

    public List<Card> AllCards { get => allCards;}

    private void Awake()
    {
        //EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
    }
    
    private void Start()
    {
        UpdateCardIDs();
        SaveCardsToJson();
    }

    public void UpdateCardIDs()
    {
        CardManager.ResetCounters();

        foreach (Card c in allCards)
        {
            c.CardID = CardManager.GetIDValue(c);
            c.gameObject.SetActive(false);
            c.gameObject.SetActive(true);
            //Destroy(Instantiate(c.gameObject), 0.1f);
            print("ResetID: " + c.name);
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

    public void LoadCardsFromJson()
    {
        string loadString = "";
        try
        {
            loadString = File.ReadAllText(Application.dataPath + "/Resource/" + "SavedCardsJSON.json");
        }
        catch (FileNotFoundException e)
        {
            Debug.LogWarning("Failed to find save file, loading default save");

            return;
        }
        CardSave[] allCardsSaves = JsonUtility.FromJson<AllCardsSave>(loadString).allCardSave;
        Card currentCard;        
        foreach(CardSave cs in allCardsSaves)
        {
            currentCard = GetCardByID(cs.cardID);
            if (currentCard != null)
            {
                Debug.Log("Updating card: " + cs.cardID);
            currentCard.UpdateCard(cs);

            }
            else
            {
                Debug.LogError("Failed to get card: " + cs.cardID + " " + cs.cardDes);
            }
        }
    }

    public string SaveCardToCSV()
    {
        return "";
    }

    public Card GetCardByID(string id)
    {
        Card temp = null;
        foreach(Card c in allCards)
        {
            if (c.Equals(id))
            {
                return c;
            }
        }

        return temp;
    }
}
