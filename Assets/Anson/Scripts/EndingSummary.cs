using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.IO;
using TMPro;

[System.Serializable]
public class EndingSummaryConditions
{
    [Header("Condition")]
    [Tooltip("Set Overall Score Range")]
    public Vector2 scoreRange = new Vector2(0, float.MaxValue);
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

    public bool IsMatched(Player player, float score)
    {
        if (IsMatchValueRange(score, scoreRange) && IsMatchValueRange(player.HealthPoints, healthRange) && IsMatchValueRange(player.BuxPoint, buxRange) && IsMatchValueRange(player.MoodPoint, moodRange))
        {
            return true;
        }
        return false;
    }

    bool IsMatchValueRange(float value, Vector2 range)
    {
        return (value >= range.x && value <= range.y);
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

    [ContextMenu("Save Summaries to CSV")]

    public void SaveEndingSummaryConditions()
    {
        print(endingSummaries.Count);
        FileLoader.SaveToFile(Application.dataPath + "/Resources/Data/", "EndingSummaries.json", new EndingSummaryList(endingSummaries));
    }

    [ContextMenu("Load Summaries from CSV")]

    public void LoadEndingSummaryConditions()
    {
        endingSummaries = new List<EndingSummaryConditions>(FileLoader.LoadFromFile<EndingSummaryList>(Application.dataPath + "/Resources/Data/EndingSummaries.json").endingSummaries);
    }

    public void UpdateSummaryText(float score)
    {
        if (!summaryText)
        {
            return;
        }

        summaryText.text = GetEndingSummary(score).summaryText;
    }

    EndingSummaryConditions GetEndingSummary(float score)
    {
        EndingSummaryConditions returnEnding = endingSummaries[endingSummaries.Count-1];

        foreach (EndingSummaryConditions esc in endingSummaries)
        {
            if (esc.IsMatched(Player.current,score))
            {
                return esc;

            }
        }


        return returnEnding;
    }
}
