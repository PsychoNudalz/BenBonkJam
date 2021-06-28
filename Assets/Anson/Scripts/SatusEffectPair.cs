using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatusEffectPair 
{
    public StatusEnum status;
    public Sprite icon;

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
}


