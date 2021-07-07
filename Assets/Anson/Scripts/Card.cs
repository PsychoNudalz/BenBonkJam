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

    public void Init(float health, float bux, float mood, List<StatusEnum> requiredStatus, List<CardOLD> sequenceCardsAdd, List<CardOLD> sequenceCardsRemove, List<StatusEnum> statusAdd, List<StatusEnum> statusRemove)
    {
        this.health = health;
        this.bux = bux;
        this.mood = mood;
        this.requiredStatus = requiredStatus;
        //this.sequenceCardsAdd = sequenceCardsAdd;
        //this.sequenceCardsRemove = sequenceCardsRemove;
        this.statusAdd = statusAdd;
        this.statusRemove = statusRemove;
        this.sequenceCardsAdd = new List<Card>();
        this.sequenceCardsRemove = new List<Card>();
        foreach (CardOLD old in sequenceCardsAdd)
        {
            if (old != null)
            {

                if (old.gameObject.TryGetComponent(out Card newCard))
                {
                    this.sequenceCardsAdd.Add(newCard);

                }
                else
                {
                    Debug.LogError("Failed to get new card class");
                }
            }
        }
        foreach (CardOLD old in sequenceCardsRemove)
        {
            if (old != null)
            {
                if (old.gameObject.TryGetComponent(out Card newCard))
                {
                    this.sequenceCardsRemove.Add(newCard);

                }
                else
                {
                    Debug.LogError("Failed to get new card class");

                }
            }
        }
    }

    public CardOption(CardOptionSave cos)
    {
        health = cos.health;
        bux = cos.bux;
        mood = cos.mood;
        requiredStatus = new List<StatusEnum>();
        foreach (int i in cos.requiredStatus)
        {
            requiredStatus.Add((StatusEnum)i);
        }
        statusAdd = new List<StatusEnum>();
        foreach(int i in cos.statusAdd)
        {
            statusAdd.Add((StatusEnum)i);
        }
        statusRemove = new List<StatusEnum>();
        foreach (int i in cos.statusRemove)
        {
            statusRemove.Add((StatusEnum)i);
        }

        Card tempCard;
        sequenceCardsAdd = new List<Card>();
        foreach(string s in cos.sequenceCardsAdd)
        {
            tempCard = UnityEditor.MonoScript.FindObjectOfType<CardHandler>().GetCardByID(s);
            if (tempCard != null)
            {
            sequenceCardsAdd.Add(tempCard);
            }
        }

        sequenceCardsRemove = new List<Card>();
        foreach (string s in cos.sequenceCardsRemove)
        {
            tempCard = UnityEditor.MonoScript.FindObjectOfType<CardHandler>().GetCardByID(s);
            if (tempCard != null)
            {
                sequenceCardsRemove.Add(tempCard);
            }
        }
    }
}


public class Card : MonoBehaviour
{
    [Header("Card Info")]
    [SerializeField] string cardID;
    //[SerializeField] string cardDescription;
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

    public CardEffectScript CardEffectScript { get => cardEffectScript; set => cardEffectScript = value; }
    public List<AgeEnum> AgeNeeded { get => ageNeeded; set => ageNeeded = value; }
    public List<StatusEnum> StatusNeeded { get => statusNeeded; set => statusNeeded = value; }
    public CardOption HeadsOption { get => headsOption; set => headsOption = value; }
    public CardOption TailsOption { get => tailsOption; set => tailsOption = value; }
    public string CardID { get => cardID; set => cardID = value; }
    public string CardID1 { get => cardID; set => cardID = value; }
    public string CardDescriptionText { get => cardDescriptionText; set => cardDescriptionText = value; }
    public string HeadsDescriptionText { get => headsDescriptionText; set => headsDescriptionText = value; }
    public string TailsDescriptionText { get => tailsDescriptionText; set => tailsDescriptionText = value; }

    // Start is called before the first frame update

    public bool PortOldToNew(CardOLD old)
    {
        try
        {
            cardID = old.cardID.ToString();
            //cardDescription = old.cardDescription;
            headsOption.Init(old.healthHeads, old.buxHeads, old.moodHeads, old.RequoredStatusHeads, old.SequenceCardsHeads, old.RemoveSequenceCardsHeads, old.AddStatusHeads, old.RemoveStatusHeads);
            tailsOption.Init(old.healthTails, old.buxTails, old.moodTails, old.RequoredStatusTails, old.SequenceCardsTails, old.RemoveSequenceCardsTails, old.AddStatusTails, old.RemoveStatusTails);
            ageNeeded = new List<AgeEnum>(old.ageEnum);
            statusNeeded = new List<StatusEnum>(old.cardStatuses);
            UpdateSavedDescriptions();
        }
        catch (System.Exception e)
        {
            Debug.LogError("Card Port failed on: " + old.cardDescription);
            print(e.StackTrace);
            return false;
        }
        return true;
    }

    void UpdateSavedDescriptions()
    {
        cardDescriptionText = cardDescriptionTMPro.text;
        headsDescriptionText = headsDescriptionTMPro.text;
        tailsDescriptionText = tailsDescriptionTMPro.text;
    }

    void UpdateCardDescriptions()
    {
        cardDescriptionTMPro.text = cardDescriptionText;
        headsDescriptionTMPro.text = headsDescriptionText;
        tailsDescriptionTMPro.text = tailsDescriptionText;
    }

    public bool LoadFromSave(CardSave cs, bool forceOverride = false)
    {
        return false;
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

    public bool IsCardSave(CardSave cs)
    {
        return CardID.Equals(cs.cardID);
    }
    public override bool Equals(object other)
    {
        if (other is CardSave)
        {
            return IsCardSave(other as CardSave);
        }
        if (other is string)
        {
            return CardID.Equals(other as string);
        }

        return base.Equals(other);
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public bool UpdateCard(CardSave cs)
    {
        try
        {
            cardDescriptionText = cs.cardDes;
            headsDescriptionText = cs.headsDes;
            tailsDescriptionText = cs.tailsDes;
            headsOption = new CardOption(cs.headsOption);
            tailsOption = new CardOption(cs.tailsOption);
            ageNeeded = new List<AgeEnum>();
            foreach ( int i in cs.ageNeeded)
            {
                ageNeeded.Add((AgeEnum)i);
            }
            statusNeeded = new List<StatusEnum>();
            foreach(int i in cs.statusNeeded)
            {
                statusNeeded.Add((StatusEnum)i);
            }
            UpdateCardDescriptions();
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.StackTrace);
        }

        return false;
    }

}

