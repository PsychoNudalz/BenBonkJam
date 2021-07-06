using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Obsolete("Use new Card class",false)]
public class CardOLD : MonoBehaviour
{
    public Sprite cardSprite;

    public int cardID;

    public string cardDescription;
    [Header("Heads")]
    public float healthHeads;
    public float buxHeads;
    public float moodHeads;
    [SerializeField] List<StatusEnum> requoredStatusHeads;

    [SerializeField] List<CardOLD> sequenceCardsHeads;
    [SerializeField] List<CardOLD> removeSequenceCardsHeads;
    [SerializeField] List<StatusEnum> addStatusHeads;
    [SerializeField] List<StatusEnum> removeStatusHeads;
    [Header("Tails")]
    public float healthTails;
    public float buxTails;
    public float moodTails;
    [SerializeField] List<StatusEnum> requoredStatusTails;

    [SerializeField] List<CardOLD> sequenceCardsTails;
    [SerializeField] List<CardOLD> removeSequenceCardsTails;
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


    [Header("Other Components")]
    [SerializeField] CardEffectScript cardEffectScript;

    public List<CardOLD> SequenceCardsTails { get => sequenceCardsTails;}
    public List<CardOLD> SequenceCardsHeads { get => sequenceCardsHeads;}
    public List<StatusEnum> AddStatusHeads { get => addStatusHeads; }
    public List<StatusEnum> RemoveStatusHeads { get => removeStatusHeads;}
    public List<StatusEnum> AddStatusTails { get => addStatusTails; }
    public List<StatusEnum> RemoveStatusTails { get => removeStatusTails;}
    public List<CardOLD> RemoveSequenceCardsHeads { get => removeSequenceCardsHeads; }
    public List<CardOLD> RemoveSequenceCardsTails { get => removeSequenceCardsTails; }
    public List<StatusEnum> RequoredStatusHeads { get => requoredStatusHeads; set => requoredStatusHeads = value; }
    public List<StatusEnum> RequoredStatusTails { get => requoredStatusTails; set => requoredStatusTails = value; }
    public CardEffectScript CardEffectScript { get => cardEffectScript; set => cardEffectScript = value; }

    private void Start()
    {
        if (!cardEffectScript)
        {
            cardEffectScript = GetComponent<CardEffectScript>();
        }
    }

    public float[] GetHeadsResults()
    {
        return new float[] {healthHeads, buxHeads, moodHeads};
    }

    public float[] GetTailsResults()
    {
        return new float[] { healthTails, buxTails, moodTails };
    }




}
