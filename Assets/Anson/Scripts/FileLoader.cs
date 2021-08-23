using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class FileLoader
{

    public static void SaveToFile<T>(string path,string filename, T objectToBeSaved)
    {
        string saveString = JsonUtility.ToJson(objectToBeSaved);
        Debug.Log("Saving all cards");
        Debug.Log(saveString);
        try
        {
            File.WriteAllText(path+filename, saveString);
        }
        catch (DirectoryNotFoundException e)
        {
            Directory.CreateDirectory(path);
            File.WriteAllText(path + filename, saveString);

        }
        Debug.Log("Save complete");
    }

    public static T LoadFromFile<T>(string pathWithName)
    {
        string loadString = "";
        try
        {
            loadString = File.ReadAllText(pathWithName);
        }
        catch (FileNotFoundException e)
        {
            Debug.LogWarning("Failed to find save file, loading default save");

            return default(T);
        }
        return JsonUtility.FromJson<T>(loadString);
    }


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
        return AgeEnum.OLD;
    }


    public static object EmptyDataCheck(string s, object defaultValue)
    {
        if (s.Equals(""))
        {
            return defaultValue;
        }
        else
        {
            return s;
        }

    }
    public static string EmptyDataCheckString(string s, string i)
    {
        if (s.Equals(""))
        {
            return i;
        }
        else
        {
            return s;
        }

    }
}
