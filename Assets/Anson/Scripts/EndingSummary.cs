using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.IO;
using TMPro;

[System.Serializable]
public class EndingSummaryConditions
{
    [Header("Condition")]
    [Tooltip("Range value be between 0 - Max Value, Inclusive")]
    public Vector2 healthRange = new Vector2(0, 100f);
    [Tooltip("Range value be between 0 - Max Value, Inclusive")]
    public Vector2 buxRange = new Vector2(0, 100f);
    [Tooltip("Range value be between 0 - Max Value, Inclusive")]
    public Vector2 moodRange = new Vector2(0, 100f);
    [Space(10f)]
    [Header("Summary")]
    [TextArea]
    public string summaryText = "";

    public EndingSummaryConditions(Vector2 healthRange, Vector2 buxRange, Vector2 moodRange, string summaryText)
    {
        this.healthRange = healthRange;
        this.buxRange = buxRange;
        this.moodRange = moodRange;
        this.summaryText = summaryText;
    }

    public EndingSummaryConditions()
    {
        this.healthRange = new Vector2(0, 100f);
        this.buxRange = new Vector2(0, 100f);
        this.moodRange = new Vector2(0, 100f);
        this.summaryText = "";
    }

    public bool IsMatched(Player player)
    {
        if (IsMatchValueRange(player.HealthPoints,healthRange)&& IsMatchValueRange(player.BuxPoint, buxRange)&& IsMatchValueRange(player.MoodPoint, moodRange))
        {
            return true;
        }
        return false;
    }

    bool IsMatchValueRange(float value, Vector2 range)
    {
        return (value >= range.x&& value <= range.y);
    }

}

public class EndingSummary : MonoBehaviour
{
    [Header("Endings")]
    [SerializeField] List<EndingSummaryConditions> endingSummaries;
    [Space(10)]
    [Header("Connected Components")]
    [SerializeField] TextMeshProUGUI summaryText;
    
    class EndingSummaryList
    {
        public EndingSummaryConditions[] endingSummaries;
        //public EndingSummaryConditions[] EndingSummaries { get => endingSummaries; }

        public EndingSummaryList(List<EndingSummaryConditions> endingSummaries)
        {
            this.endingSummaries = endingSummaries.ToArray();
        }
        public EndingSummaryList(EndingSummaryConditions[] endingSummaries)
        {
            this.endingSummaries = endingSummaries;
        }

    }


    public List<EndingSummaryConditions> EndingSummaries { get => endingSummaries; set => endingSummaries = value; }

    
    public void SaveEndingSummaryConditions()
    {
        print(endingSummaries.Count);
        FileLoader.SaveToFile(Application.dataPath + "/Resources/Data/","EndingSummaries.json",new EndingSummaryList( endingSummaries));
    }

    public void LoadEndingSummaryConditions()
    {
        endingSummaries = new List<EndingSummaryConditions>( FileLoader.LoadFromFile< EndingSummaryList > (Application.dataPath + "/Resources/Data/EndingSummaries.json").endingSummaries);
    }

    public void UpdateSummaryText()
    {
        if (!summaryText)
        {
            return;
        }

        summaryText.text = GetEndingSummary().summaryText;
    }

    EndingSummaryConditions GetEndingSummary()
    {
        EndingSummaryConditions returnEnding = null;

        foreach(EndingSummaryConditions esc in endingSummaries)
        {
            return esc;
        }


        return returnEnding;
    }
}
