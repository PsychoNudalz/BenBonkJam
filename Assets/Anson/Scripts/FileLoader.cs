using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FileLoader
{
    public static Sprite GetCardSprite(string s)
    {
        try
        {
            Debug.Log($"Sprites/Cards/{s}");
        var CardSprite = Resources.Load<Sprite>($"Sprites/Cards/{s}");
        Debug.Log((CardSprite as Sprite).name);
        return CardSprite as Sprite;

        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to load -" + s);
            Debug.LogError(e);
        }
        return null;
    }
}
