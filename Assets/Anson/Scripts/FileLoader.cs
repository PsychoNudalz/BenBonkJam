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
}
