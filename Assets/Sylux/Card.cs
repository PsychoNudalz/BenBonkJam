using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Sprite cardSprite;

    public int cardID;

    public string cardDescription;
    [Header("Heads")]
    public float healthHeads;
    public float moodHeads;
    public float buxHeads;
    [SerializeField] List<StatusEnum> requoredStatusHeads;

    [SerializeField] List<Card> sequenceCardsHeads;
    [SerializeField] List<Card> removeSequenceCardsHeads;
    [SerializeField] List<StatusEnum> addStatusHeads;
    [SerializeField] List<StatusEnum> removeStatusHeads;
    [Header("Tails")]
    public float healthTails;
    public float moodTails;
    public float buxTails;
    [SerializeField] List<StatusEnum> requoredStatusTails;

    [SerializeField] List<Card> sequenceCardsTails;
    [SerializeField] List<Card> removeSequenceCardsTails;
    [SerializeField] List<StatusEnum> addStatusTails;
    [SerializeField] List<StatusEnum> removeStatusTails;

    [Space]
    public bool heads;
    public bool tails;
    public bool cardMustBePlayed;

    [Header("Condition")]
    public bool useCondition = false;
    public List<AgeEnum> ageEnum;
    public List<StatusEnum> cardStatuses;

    public List<Card> SequenceCardsTails { get => sequenceCardsTails;}
    public List<Card> SequenceCardsHeads { get => sequenceCardsHeads;}
    public List<StatusEnum> AddStatusHeads { get => addStatusHeads; }
    public List<StatusEnum> RemoveStatusHeads { get => removeStatusHeads;}
    public List<StatusEnum> AddStatusTails { get => addStatusTails; }
    public List<StatusEnum> RemoveStatusTails { get => removeStatusTails;}
    public List<Card> RemoveSequenceCardsHeads { get => removeSequenceCardsHeads; }
    public List<Card> RemoveSequenceCardsTails { get => removeSequenceCardsTails; }
    public List<StatusEnum> RequoredStatusHeads { get => requoredStatusHeads; set => requoredStatusHeads = value; }
    public List<StatusEnum> RequoredStatusTails { get => requoredStatusTails; set => requoredStatusTails = value; }

    public float[] GetHeadsResults()
    {
        return new float[] {healthHeads, moodHeads, buxHeads};
    }

    public float[] GetTailsResults()
    {
        return new float[] { healthTails, moodTails, buxTails };
    }




}
