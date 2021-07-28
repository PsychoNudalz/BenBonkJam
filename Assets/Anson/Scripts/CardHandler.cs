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
    [SerializeField] GameObject baseCard;
    [SerializeField] List<Card> allCards;
    [Header("Start Controls")]
    [SerializeField] bool runUpdateCardID;

    public List<Card> AllCards { get => allCards; }

    private void Awake()
    {
        //EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
    }

    private void Start()
    {
        //UpdateCardIDs();
        //SaveCardsToJson();
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
            File.WriteAllText(Application.dataPath + "/Resources/" + "SavedCardsJSON.json", saveString);
        }
        catch (DirectoryNotFoundException e)
        {
            Directory.CreateDirectory(Application.dataPath + "/Resources/");
            File.WriteAllText(Application.dataPath + "/Resources/" + "SavedCardsJSON.json", saveString);

        }
    }

    public void LoadCardsFromJson()
    {
        CardManager.ResetCounters();
        CardSave[] allCardsSaves = LoadAllCardsSaves();
        if (allCardsSaves == null)
        {
            return;
        }
        Card currentCard;
        foreach (CardSave cs in allCardsSaves)
        {
            currentCard = GetCardByID(cs.cardID);
            if (currentCard != null)
            {
                Debug.Log("Updating card: " + cs.cardID);
                currentCard.UpdateCard(cs);
                CardManager.UpdateCounter(cs.cardID);
            }
            else
            {
                Debug.LogError("Failed to get card: " + cs.cardID + " " + cs.cardDes);
            }
        }
        print("Card Manager Counter: " + CardManager.GetCounterString());
        CardManager.RefreshCounter(allCardsSaves);
        CardManager.RefreshCounter(allCards.ToArray());
    }

    public void GenerateCardsFromJson()
    {
        CardSave[] allCardsSaves = LoadAllCardsSaves();
        CardManager.RefreshCounter(allCardsSaves);
        if (allCardsSaves == null)
        {
            return;
        }
        Card currentCard;
        foreach (CardSave cs in allCardsSaves)
        {
            currentCard = GetCardByID(cs.cardID);
            if (currentCard == null)
            {
                Card newCard = CreateNewCard(cs).GetComponent<Card>();
                allCards.Add(newCard);
                Debug.Log("Successfully generated: " + newCard.CardID + "  " + newCard.CardDescriptionText);
            }
        }
    }

    public CardSave[] LoadAllCardsSaves()
    {
        string loadString = "";
        try
        {
            loadString = File.ReadAllText(Application.dataPath + "/Resources/" + "SavedCardsJSON.json");
        }
        catch (FileNotFoundException e)
        {
            Debug.LogWarning("Failed to find save file, loading default save");

            return null;
        }
        return JsonUtility.FromJson<AllCardsSave>(loadString).allCardSave;
    }

    public string SaveCardToCSV()
    {
        return "";
    }

    public Card GetCardByID(string id)
    {
        Card temp = null;
        foreach (Card c in allCards)
        {
            if (c != null && c.Equals(id))
            {
                return c;
            }
        }
        Debug.LogError("Failed to get card: " + id);
        return temp;
    }

    public GameObject CreateNewCard(CardSave sc, string cardName = null)
    {
        GameObject instanceRoot = (GameObject)PrefabUtility.InstantiatePrefab(baseCard);
        Card newCard = instanceRoot.GetComponent<Card>();
        newCard.UpdateCard(sc);
        newCard.CardID = CardManager.GetIDValue(newCard);
        if (cardName == null)
        {
            instanceRoot.name = "Card_" + newCard.CardDescriptionText;
        }
        else
        {
            instanceRoot.name = "Card_" + cardName;
        }
        GameObject pVariant = PrefabUtility.SaveAsPrefabAsset(instanceRoot, "Assets/Cards_New/" + CardManager.GetAgeFolderString((int)sc.ageNeeded[0]) + "/" + instanceRoot.name + ".prefab");
        DestroyImmediate(instanceRoot);
        return pVariant;
    }
}
