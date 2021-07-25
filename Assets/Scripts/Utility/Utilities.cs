using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{
    public static bool AreOverlapping (int x, int y, int w, int h, int objx, int objy, int objw, int objh)
    {
        for (int _x = x; _x < x + w; _x++)
            for (int _y = y; _y < y + h; _y++)
                if (objx <= _x && _x < objx + objw && objy <= _y && _y < objy + objh)
                    return true;
        return false;
    }

    public static Sprite LoadSprite (string path, int pixelsPerUnit)
    {
        Texture2D texture = (Texture2D)Resources.Load(path);
        texture.filterMode = FilterMode.Point;
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0f, 0f), pixelsPerUnit);
        
        return sprite;
    }
}
