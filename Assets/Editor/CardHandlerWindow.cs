#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class CardHandlerWindow : EditorWindow
{
    Vector2 scrollPos;
    CardHandler cardHandler { get => FindObjectOfType<CardHandler>(); }

    [MenuItem("Window/Card Handler")]
    public static void ShowWindow()
    {
        GetWindow<CardHandlerWindow>("Card Handler Window");
    }

    private void OnGUI()
    {
        GUILayout.BeginVertical();
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
        GUILayout.Label("There must be a card handler in the scene", EditorStyles.boldLabel);
        if (cardHandler)
        {
            GUILayout.Label("Card Handler Present", EditorStyles.boldLabel);

        }
        else
        {
            GUILayout.Label("Card Handler MISSING", EditorStyles.boldLabel);

        }

        GUILayout.Label("Remember to save ctrl+s", EditorStyles.boldLabel);
        GUILayout.Label("And also Uncheck and Check the card handler and apply the prefab", EditorStyles.boldLabel);
        GUILayout.Label("And apply the prefab", EditorStyles.boldLabel);
        GUILayout.Space(10);
        GUILayout.Label("Adding Cards", EditorStyles.boldLabel);
        GUILayout.Label("1.	Go to the card handler scene.\n2.Create a new prefab of the card.\n3.Add the new card to the card handler." +
    "\n4.Sort the cards in the Card Handler Window.\n5.Set card ID.\n6.Full save to CSV.", EditorStyles.boldLabel);
        GUILayout.Space(10);
        GUILayout.Label("Deleting Cards", EditorStyles.boldLabel);
        GUILayout.Label("1.	Go to the card handler scene.\n2.Delete the prefab of the card in the assets folder.\n3.Remove the ‘missing’ card array in the CardHandler." +
            "\n4.Sort the cards in the Card Handler Window.\n5.Set card ID.\n6.Full save to CSV.", EditorStyles.boldLabel);
        GUILayout.Space(10);
        GUILayout.Label("Card Handler", EditorStyles.boldLabel);
        if (GUILayout.Button("Sort Cards"))
        {
            MarkDirty();
            cardHandler.SortCards();
        }

        if (GUILayout.Button("Set Card ID"))
        {
            MarkDirty();
            cardHandler.UpdateCardIDs();
        }

        if (GUILayout.Button("Check CSV duplicate"))
        {
            MarkDirty();
            CSVHandler.CheckCSVDuplicate(cardHandler.DupFlagRange);
        }

        if (GUILayout.Button("Check Illegal Character"))
        {
            MarkDirty();
            if (!CSVHandler.CheckIllegalCharacter())
            {
                Debug.Log("No Issues found");
            }

        }

        if (GUILayout.Button("Find All Cards"))
        {
            MarkDirty();
            cardHandler.FindAllCards();
        }
        if (cardHandler && cardHandler.TempAutoFoundCards.Count > 0)
        {
            if (GUILayout.Button("Apply Found Cards"))
            {
                MarkDirty();
                cardHandler.ApplyFoundCards();
            }

            if (GUILayout.Button("Clear Found Cards"))
            {
                MarkDirty();
                cardHandler.ClearFoundCards();
            }
        }

        GUILayout.Space(10);

        GUILayout.Label("Save/ Load controls", EditorStyles.boldLabel);

        if (GUILayout.Button("Full Add New Cards From Excel"))
        {
            MarkDirty();
            try
            {
                if (CSVHandler.CheckIllegalCharacter())
                {
                    Debug.LogError("Check failed, terminating.  Please Fix the csv first for commas and illegal character.  Might need to open the csv in Notepad to check FULLY");
                    throw new System.Exception("Check failed");
                }
                else
                {
                    CSVHandler.FromExcelToJSON(cardHandler);
                    cardHandler.GenerateCardsFromJson();
                    cardHandler.LoadCardsFromJson();
                    cardHandler.SaveCardsToJson();
                    CSVHandler.FromJSON(cardHandler);
                    Debug.Log("Operation Successful");
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("WARNING! failed to complete");
                Debug.LogError(e.Message);
                Debug.LogError(e.StackTrace);

            }

        }
        GUILayout.Space(10);

        if (GUILayout.Button("Full Save To CSV"))
        {
            MarkDirty();
            try
            {
                cardHandler.SaveCardsToJson();
                CSVHandler.FromJSON(cardHandler);
                Debug.Log("Operation Successful");

            }
            catch (System.Exception e)
            {
                Debug.LogError("WARNING! failed to complete");
                Debug.LogError(e.Message);
                Debug.LogError(e.StackTrace);
            }
        }
        GUILayout.Space(10);

        if (GUILayout.Button("Full Load From CSV"))
        {
            MarkDirty();
            try
            {
                if (CSVHandler.CheckIllegalCharacter())
                {
                    Debug.LogError("Check failed, terminating.  Please Fix the csv first for commas and illegal character.  Might need to open the csv in Notepad to check FULLY");
                    throw new System.Exception("Check failed");
                }
                else
                {
                    CSVHandler.FromExcelToJSON(cardHandler);
                    cardHandler.LoadCardsFromJson();
                    cardHandler.SaveCardsToJson();
                    CSVHandler.FromJSON(cardHandler);
                    Debug.Log("Operation Successful");

                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("WARNING! failed to complete");
                Debug.LogError(e.Message);
                Debug.LogError(e.StackTrace);

            }
        }

        GUILayout.Space(20);
        GUILayout.Label("Singular controls", EditorStyles.boldLabel);

        GUILayout.Label("Save/ Load Buttons", EditorStyles.boldLabel);

        if (GUILayout.Button("Save Cards to JSON"))
        {
            cardHandler.SaveCardsToJson();
        }
        if (GUILayout.Button("Load Cards from JSON"))
        {
            cardHandler.LoadCardsFromJson();
        }
        GUILayout.Space(10);

        if (GUILayout.Button("Generate Cards from JSON"))
        {
            cardHandler.GenerateCardsFromJson();
        }

        GUILayout.Space(10);
        GUILayout.Label("Excel Handling", EditorStyles.boldLabel);

        if (GUILayout.Button("Save JSON to EXCEL"))
        {
            CSVHandler.FromJSON(cardHandler);
        }
        if (GUILayout.Button("Load EXCEL to JSON"))
        {
            CSVHandler.FromExcelToJSON(cardHandler);
        }


        GUILayout.EndScrollView();

    }


    private void MarkDirty()
    {
        EditorUtility.SetDirty(cardHandler);
        EditorSceneManager.MarkSceneDirty(cardHandler.gameObject.scene);
        foreach (Card c in cardHandler.AllCards)
        {
            if (c)
            {
            EditorUtility.SetDirty(c.gameObject);
            }

        }
    }



}

public static class CardHandlerStatic
{
    public static void MarkDirty(GameObject p)
    {
        EditorUtility.SetDirty(p);
        EditorSceneManager.MarkSceneDirty(p.gameObject.scene);
    }
}

public class CardHandlerWindowInspector : Editor
{
    public override void OnInspectorGUI()
    {
        if (GUI.changed)
        {
            EditorUtility.SetDirty(FindObjectOfType<CardHandler>());
            EditorSceneManager.MarkSceneDirty(FindObjectOfType<CardHandler>().gameObject.scene);
        }
    }
}
#endif