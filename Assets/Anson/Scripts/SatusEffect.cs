using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatusEffect 
{
    public StatusEnum status;
    [Header("Stats Modification")]
    [SerializeField] int healthPos;
    [SerializeField] int buxPos;
    [SerializeField] int moodPos;
    [SerializeField] int healthNeg;
    [SerializeField] int buxNeg;
    [SerializeField] int moodNeg;
    [Header("Passive")]
    [SerializeField] float healthPassive;
    [SerializeField] float buxPassive;
    [SerializeField] float moodPassive;
    [Header("UI Display")]
    public Sprite icon;
    public string description;

    public int HealthPos { get => healthPos; set => healthPos = value; }
    public int BuxPos { get => buxPos; set => buxPos = value; }
    public int MoodPos { get => moodPos; set => moodPos = value; }
    public int HealthNeg { get => healthNeg; set => healthNeg = value; }
    public int BuxNeg { get => buxNeg; set => buxNeg = value; }
    public int MoodNeg { get => moodNeg; set => moodNeg = value; }
    public float HealthPassive { get => healthPassive; set => healthPassive = value; }
    public float BuxPassive { get => buxPassive; set => buxPassive = value; }
    public float MoodPassive { get => moodPassive; set => moodPassive = value; }



    public StatusEffect(StatusEnum status, int healthPos, int buxPos, int moodPos, int healthNeg, int buxNeg, int moodNeg, float healthPassive, float buxPassive, float moodPassive, Sprite icon, string description)
    {
        this.status = status;
        this.healthPos = healthPos;
        this.buxPos = buxPos;
        this.moodPos = moodPos;
        this.healthNeg = healthNeg;
        this.buxNeg = buxNeg;
        this.moodNeg = moodNeg;
        this.healthPassive = healthPassive;
        this.buxPassive = buxPassive;
        this.moodPassive = moodPassive;
        this.icon = icon;
        this.description = description;
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        else if (obj is StatusEnum)
        {
            if (status.Equals((StatusEnum)obj))
            {
                return true;
            }
            return false;
        }
        return base.Equals(obj);
    }


    public override int GetHashCode()
    {
        int hashCode = -1467767241;
        hashCode = hashCode * -1521134295 + status.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<Sprite>.Default.GetHashCode(icon);
        return hashCode;
    }

    public override string ToString()
    {
        return ($"{status.ToString()},{healthPos},{buxPos},{moodPos},{HealthNeg},{buxNeg},{MoodNeg},{healthPassive},{BuxPassive},{MoodPassive} {description}");
    }
}


