using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatusEffect 
{
    public StatusEnum status;
    [Header("Stats Modification")]
    [SerializeField] int health;
    [SerializeField] int bux;
    [SerializeField] int mood;

    [Header("UI Display")]
    public Sprite icon;
    public string description;


    public int Health { get => health; set => health = value; }
    public int Bux { get => bux; set => bux = value; }
    public int Mood { get => mood; set => mood = value; }

    public StatusEffect(StatusEnum status, int health, int bux, int mood, Sprite icon, string description)
    {
        this.status = status;
        this.health = health;
        this.bux = bux;
        this.mood = mood;
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
        return ($"{status.ToString()},{health},{bux},{mood},{description}");
    }
}


