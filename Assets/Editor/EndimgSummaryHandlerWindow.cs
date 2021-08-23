#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class EndimgSummaryHandlerWindow : EditorWindow
{
    EndingSummary endingSummary { get => FindObjectOfType<EndingSummary>(); }


    [MenuItem("Window/Endimg Summary Handler Window")]

    public static void ShowWindow()
    {
        GetWindow<EndimgSummaryHandlerWindow>("Endimg Summary Handler Window");
    }

    private void OnGUI()
    {

        GUILayout.Label("There must be a Ending Summary in the scene", EditorStyles.boldLabel);
        if (endingSummary)
        {
            GUILayout.Label("Clear", EditorStyles.boldLabel);

        }
        else
        {
            GUILayout.Label("MISSING", EditorStyles.boldLabel);

        }
        GUILayout.Label("Remeber to save ctrl+s", EditorStyles.boldLabel);
        if (GUILayout.Button("Full Save"))
        {
            endingSummary.SaveEndingSummaryConditions();
        }
        GUILayout.Space(10);

        if (GUILayout.Button("Full Load"))
        {
            endingSummary.LoadEndingSummaryConditions();
        }
    }
}
#endif