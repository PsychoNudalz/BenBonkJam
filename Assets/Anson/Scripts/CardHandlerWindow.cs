using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CardHandlerWindow : EditorWindow
{
    CardHandler cardHandler { get => FindObjectOfType<CardHandler>(); }

    [MenuItem("Window/Card Handler")]
    public static void ShowWindow()
    {
        GetWindow<CardHandlerWindow>("Card Handler Window");
    }

    private void OnGUI()
    {
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

        GUILayout.Label("Card Handler", EditorStyles.boldLabel);
        if (GUILayout.Button("Sort Cards"))
        {
            cardHandler.SortCards();
        }

        if (GUILayout.Button("Set Card ID"))
        {
            cardHandler.UpdateCardIDs();
        }

        if (GUILayout.Button("Full Add New Cards From Excel"))
        {
            CSVHandler.FromExcelToJSON(cardHandler);
            cardHandler.GenerateCardsFromJson();
            cardHandler.SaveCardsToJson();
            cardHandler.LoadCardsFromJson();
            cardHandler.SaveCardsToJson();
            CSVHandler.FromJSON(cardHandler);

        }

        if (GUILayout.Button("Full Save"))
        {
            cardHandler.SaveCardsToJson();
            CSVHandler.FromJSON(cardHandler);

        }

        if (GUILayout.Button("Full Load"))
        {
            CSVHandler.FromExcelToJSON(cardHandler);
            cardHandler.LoadCardsFromJson();
            cardHandler.SaveCardsToJson();
            CSVHandler.FromJSON(cardHandler);

        }

        GUILayout.Space(20);
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

    }




}
