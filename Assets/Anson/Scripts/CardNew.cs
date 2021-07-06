using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public struct CardOption
{
    [Header("Stats")]
    [SerializeField] float health;
    [SerializeField] float bux;
    [SerializeField] float mood;
    [SerializeField] List<StatusEnum> requiredStatus;
    [Header("Sequence Cards")]
    [SerializeField] List<Card> sequenceCardsAdd;
    [SerializeField] List<Card> sequenceCardsRemove;
    [Header("Status Effect")]
    [SerializeField] List<StatusEnum> statusAdd;
    [SerializeField] List<StatusEnum> statusRemove;

    public float Health { get => health; set => health = value; }
    public float Bux { get => bux; set => bux = value; }
    public float Mood { get => mood; set => mood = value; }
    public List<StatusEnum> RequiredStatus { get => requiredStatus; set => requiredStatus = value; }
    public List<Card> SequenceCardsAdd { get => sequenceCardsAdd; set => sequenceCardsAdd = value; }
    public List<Card> SequenceCardsRemove { get => sequenceCardsRemove; set => sequenceCardsRemove = value; }
    public List<StatusEnum> StatusAdd { get => statusAdd; set => statusAdd = value; }
    public List<StatusEnum> StatusRemove { get => statusRemove; set => statusRemove = value; }

    public float[] GetStatsResults()
    {
        return new float[] { health, bux, mood };
    }

    public void Init(float health, float bux, float mood, List<StatusEnum> requiredStatus, List<Card> sequenceCardsAdd, List<Card> sequenceCardsRemove, List<StatusEnum> statusAdd, List<StatusEnum> statusRemove)
    {
        this.health = health;
        this.bux = bux;
        this.mood = mood;
        this.requiredStatus = requiredStatus;
        this.sequenceCardsAdd = sequenceCardsAdd;
        this.sequenceCardsRemove = sequenceCardsRemove;
        this.statusAdd = statusAdd;
        this.statusRemove = statusRemove;
    }
}


public class CardNew : MonoBehaviour
{
    [Header("Card Info")]
    [SerializeField] string cardID;
    [SerializeField] string cardDescription;
    [SerializeField] string cardDescriptionText;
    [Header("Heads")] 
    [SerializeField] string headsDescriptionText;
    [SerializeField] CardOption headsOption;
    [Header("Tails")]
    [SerializeField] string tailsDescriptionText;
    [SerializeField] CardOption tailsOption;
    [Header("Condition")]
    [SerializeField] List<AgeEnum> ageNeeded;
    [SerializeField] List<StatusEnum> statusNeeded;
    [Header("Card Components")]
    [SerializeField] TextMeshPro cardDescriptionTMPro;
    [SerializeField] TextMeshPro headsDescriptionTMPro;
    [SerializeField] TextMeshPro tailsDescriptionTMPro;
    [Header("Other Components")]
    [SerializeField] CardEffectScript cardEffectScript;
    // Start is called before the first frame update

    public bool PortOldToNew(Card old)
    {
        try
        {
            cardID = old.cardID.ToString();
            cardDescription = old.cardDescription;
            headsOption.Init(old.healthHeads, old.buxHeads, old.moodHeads, old.RequoredStatusHeads, old.SequenceCardsHeads, old.RemoveSequenceCardsHeads, old.AddStatusHeads, old.RemoveStatusHeads);
            tailsOption.Init(old.healthTails, old.buxTails, old.moodTails, old.RequoredStatusTails, old.SequenceCardsTails, old.RemoveSequenceCardsTails, old.AddStatusTails, old.RemoveStatusTails);
            ageNeeded = new List<AgeEnum>(old.ageEnum);
            statusNeeded = new List<StatusEnum>(old.cardStatuses);
        }
        catch(System.Exception e)
        {
            Debug.LogError("Card Port failed on: " + old.cardDescription);
            print(e.StackTrace);
            return false;
        }
        return true;
    }

    void UpdateSavedDescriptions()
    {

    }

    private void Start()
    {
        if (!cardEffectScript)
        {
            cardEffectScript = GetComponent<CardEffectScript>();
        }
    }

    public float[] GetHeadsResults()
    {
        return headsOption.GetStatsResults();
    }

    public float[] GetTailsResults()
    {
        return tailsOption.GetStatsResults();
    }


}

