using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public int Width, Height;
    public List<Structure> Structures;

    //maybe i might make it async
    public void TickAll ()
    {
        for (int i = 0; i < Structures.Count; i++)
            Structures[i].Tick();
    }

    public bool IsInsideBounds (int _x, int _y, int _width, int _height)
    {
        return _x >= 0 && _y >= 0 && _x + _width < Width && _y + _height < Height;
    }

    public bool IsEmpty (int _x, int _y, int _width, int _height)
    {
        foreach (var str in Structures)
            if (Utilities.AreOverlapping(_x, _y, _width, _height, str.x, str.y, str.data.Width, str.data.Height))
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
