using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FileLoader
{
    public static Sprite GetCardSprite(string s)
    {
        try
        {
            Sprite CardSprite = Resources.Load<Sprite>($"Sprites/Cards/{s}");
            return CardSprite;

        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to load -" + s);
            Debug.LogError(e);
        }
        return null;
    }

    public static int[] StringSplitToInt(string stringArray, char c)
    {
        string[] tempStringArray = stringArray.Split(c);
        List<int> returnInt = new List<int>();
        string temp;
        foreach (string s in tempStringArray)
        {
            temp = s.Replace(" ", "");
            try
            {
                if (!temp.Equals(""))
                {

                    returnInt.Add(int.Parse(temp));
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
        }
        return returnInt.ToArray();
    }

    public static AgeEnum TextToAge(string s)
    {
        s = s.ToLower();

        foreach(int i in Enum.GetValues(typeof(AgeEnum)))
        {
            if (s.Equals(((AgeEnum)i).ToString().ToLower()))
            {
                return (AgeEnum)i;
            }
        }
        return AgeEnum.OLDAGE;
    }
}
