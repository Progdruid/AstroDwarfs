using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int Width, Height;
    public List<Structure> Structures;

    public bool IsInsideBounds (int _x, int _y, int _width, int _height)
    {
        return _x >= 0 && _y >= 0 && _x + _width < Width && _y + _height < Height;
    }

    public bool IsEmpty (int _x, int _y, int _width, int _height)
    {
        for (int x = _x; x < _x + _width; x++)
            for (int y = _x; y < _y + _height; y++)
                foreach (Structure str in Structures)
                    if (str.x <= x && x < str.x + str.data.width && str.y <= y && y < str.y + str.data.height)
                        return false;
        return true;
    }

    public void Init (MapConfig config)
    {
        Width = config.width;
        Height = config.height;
        Structures = new List<Structure>();

        for (int i = 0; i < config.structCount; i++)
        {
            IndexTable.GameStructures[config.ids[i]].CreateThisStructure(this, config.xs[i], config.ys[i]);
        }
    }
}
