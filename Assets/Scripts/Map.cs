using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int Width, Height;
    public Structure[] Structures;

    public bool IsInsideBounds (int _x, int _y, int _width, int _height)
    {
        return _x >= 0 && _y >= 0 && _x < _width && _y < _height;
    }

    public bool IsEmpty (int _x, int _y, int _width, int _height)
    {
        foreach (var str in Structures)
            if (str.x >= _x && str.y >= _y && _x + _width < str.data.width && _y + _height < str.data.height) //yeap, it's ok
                return false;

        return true;
    }

    public void Init (MapConfig config)
    {
        Width = config.width;
        Height = config.height;
        Structures = new Structure[config.structures.Length];

        for (int i = 0; i < config.structures.Length; i++)
        {
            (int x, int y, int id) data = config.structures[i];
            int width = IndexTable.GameStructures[data.id].width;
            int height = IndexTable.GameStructures[data.id].height;
            if (!IsInsideBounds(data.x, data.y, width, height))
                continue;
            if (!IsEmpty(data.x, data.y, width, height))
                continue;

            GameObject go = new GameObject($"Building: {data.x}, {data.y}");
            Structure str = IndexTable.GameStructures[data.id].AttachStructure(go);
            Structures[i] = str;


        }
    }
}
