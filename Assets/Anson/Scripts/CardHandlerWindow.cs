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

        GUILayout.Label("Remeber to save ctrl+s",EditorStyles.boldLabel);
        

        if (GUILayout.Button("Set Card ID"))
        {
            cardHandler.UpdateCardIDs();
        }
        if (GUILayout.Button("Save Cards to JSON"))
        {
            cardHandler.SaveCardsToJson();
        }
        if (GUILayout.Button("Load Cards from JSON"))
        {
            cardHandler.LoadCardsFromJson();
        }
        if (GUILayout.Button("Generate Cards from JSON"))
        {
            cardHandler.GenerateCardsFromJson();
        }
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
