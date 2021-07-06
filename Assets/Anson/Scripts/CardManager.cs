using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardManager
{
    //card id
    //all card counter
    private static int[] counters = { 0, 0, 0, 0, 0, 0, 0 };


    public static void ResetCounters()
    {
        counters = new int[] { 0, 0, 0, 0, 0, 0, 0 };
    }

    public static string GetIDValue(Card c)
    {
        string temp = "";
        if (c.AgeNeeded.Count > 0)
        {
            temp += c.AgeNeeded[0].ToString().Substring(0,3).ToUpper() + "_";
            temp += counters[(int) c.AgeNeeded[0]].ToString() + "_";
            counters[(int)c.AgeNeeded[0]]++;
        }
        else
        {
            temp += "GEN_";
            temp += counters[6].ToString() + "_";
            counters[6]++;
        }

        return temp;
    }
}
