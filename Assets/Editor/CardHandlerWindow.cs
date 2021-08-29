#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
            GUILayout.Label("Clear", EditorStyles.boldLabel);

        }
        else
        {
            GUILayout.Label("MISSING", EditorStyles.boldLabel);

        }

        GUILayout.Label("Remeber to save ctrl+s", EditorStyles.boldLabel);
        GUILayout.Space(10);

        GUILayout.Label("Card Handler", EditorStyles.boldLabel);
        if (GUILayout.Button("Sort Cards"))
        {
            cardHandler.SortCards();
        }

        if (GUILayout.Button("Set Card ID"))
        {
            cardHandler.UpdateCardIDs();
        }

        if (GUILayout.Button("Check CSV duplicate"))
        {
            CSVHandler.CheckCSVDuplicate(cardHandler.DupFlagRange);
        }

        if (GUILayout.Button("Find All Cards"))
        {
            cardHandler.FindAllCards();
        }
        if (cardHandler.TempAutoFoundCards.Count > 0)
        {
            if (GUILayout.Button("Apply Found Cards"))
            {
                cardHandler.ApplyFoundCards();
            }

            if (GUILayout.Button("Clear Found Cards"))
            {
                cardHandler.ClearFoundCards();
            }
        }

        GUILayout.Space(10);

        GUILayout.Label("Save/ Load controls", EditorStyles.boldLabel);

        if (GUILayout.Button("Full Add New Cards From Excel"))
        {
            try
            {
                CSVHandler.FromExcelToJSON(cardHandler);
                cardHandler.GenerateCardsFromJson();
                cardHandler.SaveCardsToJson();
                cardHandler.LoadCardsFromJson();
                cardHandler.SaveCardsToJson();
                CSVHandler.FromJSON(cardHandler);
            }
            catch (System.Exception e)
            {
                Debug.LogError("WARNING! failed to complete");
                Debug.LogError(e.Message);
                Debug.LogError(e.StackTrace);

            }

        }
        GUILayout.Space(10);

        if (GUILayout.Button("Full Save"))
        {
            try
            {
                cardHandler.SaveCardsToJson();
                CSVHandler.FromJSON(cardHandler);
            }
            catch (System.Exception e)
            {
                Debug.LogError("WARNING! failed to complete");
                Debug.LogError(e.Message);
                Debug.LogError(e.StackTrace);
            }
        }
        GUILayout.Space(10);

        if (GUILayout.Button("Full Load"))
        {
            try
            {
                CSVHandler.FromExcelToJSON(cardHandler);
                cardHandler.LoadCardsFromJson();
                cardHandler.SaveCardsToJson();
                CSVHandler.FromJSON(cardHandler);
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




}
#endif