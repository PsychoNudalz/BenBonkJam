using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum StatsType
{
    HEALTH,
    BUX,
    MOOD
}
public class Player : MonoBehaviour
{

    [Header("Base States")]
    public Status status;
    public float StartingHealth = 100.0f;
    public float StartingBux = 20f;
    public float StartingMood = 50f;
    //Init age
    public AgeEnum age;

    [Header("Modifiers (In percentage)")]
    [SerializeField] int healthModPos = 0;
    [SerializeField] int buxModPos = 0;
    [SerializeField] int moodModPos = 0;
    [SerializeField] int healthModNeg = 0;
    [SerializeField] int buxModNeg = 0;
    [SerializeField] int moodModNeg = 0;

    [Header("Passive Gain/ Lost")]
    [SerializeField] float healthPassive = 0;
    [SerializeField] float buxPassive = 0;
    [SerializeField] float moodPassive = 0;


    public void Older()
    {
        int temp = (int)age;
        temp++;
        age = (AgeEnum)temp;
        if ((int)age > 5)
        {
            age = (AgeEnum)5;
        }
        else
        {
            age = (AgeEnum)temp;
        }
    }

    public void Younger()
    {
        int temp = (int)age;
        temp--;
        if ((int)age < 0)
        {
            age = (AgeEnum)0;
        }
        else
        {
            age = (AgeEnum)temp;
        }
    }

    public void SetAge(int num)
    {
        int temp = num;
        age = (AgeEnum)temp;
    }

    //Init health
    private float _HealthPoints = 100f;
    public float HealthPoints
    {
        get { return _HealthPoints; }
        set
        {
            // Make the HP in the range 0f to 100f
            _HealthPoints = Mathf.Clamp(value, 0f, 100f);
            if (HealthPoints <= 0f)
            {
                //dead
            }
        }
    }

    public bool GainHealth(float Amount)
    {
        if (Amount > 0)
        {
            HealthPoints += Amount * (1 + (healthModPos / 100f));
        }
        else
        {
            HealthPoints += Amount * (1 + (healthModNeg / 100f));
        }
        return HealthPoints <= 0;
    }

    //Init Bux
    public float BuxPoint
    {
        get { return _Bux; }
        set
        {
            // Make the cash in the range 0f to 100f
            _Bux = Mathf.Clamp(value, 0f, 100f);
            if (BuxPoint <= 0f)
            {
                //No more money!
            }
        }
    }
    private float _Bux = 1000f;

    public bool GainBux(float Amount)
    {
        if (Amount > 0)
        {
        BuxPoint += Amount * (1 + (buxModPos / 100f));
        }
        else
        {
            BuxPoint += Amount * (1 + (buxModNeg / 100f));

        }
        return BuxPoint <= 0;

    }

    public void LoseBux(float Amount)
    {
        BuxPoint -= Amount;
    }

    //Init Mood
    public float MoodPoint
    {
        get { return _Mood; }
        set
        {
            // Make Mood in the range 0f to 100f
            _Mood = Mathf.Clamp(value, 0f, 100f);
            if (MoodPoint <= 0f)
            {
                //No mood
            }
        }
    }
    private float _Mood = 100f;

    public bool GainMood(float Amount)
    {
        if (Amount > 0)
        {
        MoodPoint += Amount * (1 + (moodModPos / 100f));
        }
        else
        {
            MoodPoint += Amount * (1 + (moodModNeg / 100f));

        }
        return BuxPoint <= 0;

    }

    public void LoseMood(float Amount)
    {
        MoodPoint -= Amount;
    }

    public void AddStatus(StatusEnum statusEnum)
    {
        Vector3 cardPos = Mouse.current.position.ReadValue();
        StatusEffect se = FindObjectOfType<StatusEffectManager>().GetStatusEffect(statusEnum);
        FindObjectOfType<StatusEffectIconSpawner>().SpawnStatusEffectIcon(se);
        AddStatus(StatusEffectManager.current.GetStatusEffect(statusEnum));
    }


    public void AddStatus(StatusEffect statusEffect)
    {
        status.AddStatus(statusEffect.status);
        healthModPos += statusEffect.HealthPos;
        buxModPos += statusEffect.BuxPos;
        moodModPos += statusEffect.MoodPos;
        healthModNeg += statusEffect.HealthNeg;
        buxModNeg += statusEffect.BuxNeg;
        moodModNeg += statusEffect.MoodNeg;
        healthPassive += statusEffect.HealthPassive;
        buxPassive += statusEffect.BuxPassive;
        moodPassive += statusEffect.MoodPassive;
    }

    public void RemoveStatus(StatusEnum statusEnum)
    {
        RemoveStatus(StatusEffectManager.current.GetStatusEffect(statusEnum));
    }

    public void RemoveStatus(StatusEffect statusEffect)
    {
        status.RemoveStatus(statusEffect.status);
        healthModPos -= statusEffect.HealthPos;
        buxModPos -= statusEffect.BuxPos;
        moodModPos -= statusEffect.MoodPos;
        healthModNeg -= statusEffect.HealthNeg;
        buxModNeg -= statusEffect.BuxNeg;
        moodModNeg -= statusEffect.MoodNeg;
        healthPassive -= statusEffect.HealthPassive;
        buxPassive -= statusEffect.BuxPassive;
        moodPassive -= statusEffect.MoodPassive;
    }

    public bool HasSatus(StatusEnum statusEnum)
    {
        return status.HasSatus(statusEnum);
    }

    public bool HasSatus(StatusEffect statusEffect)
    {
        return status.HasSatus(statusEffect.status);
    }

    public bool IsGameOver()
    {
        return HealthPoints <= 0 || MoodPoint <= 0 || BuxPoint <= 0;
    }
    // Start is called before the first frame update
    void Awake()
    {
        HealthPoints = StartingHealth;
        BuxPoint = StartingBux;
        MoodPoint = StartingMood;
        //SetAge(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float GetTotalStats()
    {
        return HealthPoints + BuxPoint + MoodPoint;
    }


    public float[] PassiveGain()
    {
        GainHealth(healthPassive);
        GainBux(buxPassive);
        GainMood(moodPassive);
        float[] returnArray = new float[] { healthPassive, buxPassive, moodPassive };
        return returnArray;
    }


}
