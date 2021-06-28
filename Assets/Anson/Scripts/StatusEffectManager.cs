using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public  class StatusEffectManager:MonoBehaviour
{
    [SerializeField] List<StatusEffectPair> allSatusEffectPair;

    public StatusEffectPair GetStatusEffectPair(StatusEnum e)
    {
        foreach(StatusEffectPair sep in allSatusEffectPair)
        {
            if (sep.Equals(e))
            {
                return sep;
            }
        }
        return null;
    }
}
