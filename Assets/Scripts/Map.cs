using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public int Width { get; private set; }
    public int Height { get; private set; }

    private Transform parent;

    public Map(Transform _parent, MapConfig _config)
    {
        parent = _parent;

        Width = _config.width;
        Height = _config.height;
        structs = new List<Structure>();
        matrix = new Structure[Width, Height];

        for (int i = 0; i < _config.structCount; i++)
            CreateStructure(_config.xs[i], _config.ys[i], _config.ids[i]);
        
    }

    #region Structures API

    private List<Structure> structs;
    private Structure[,] matrix;

    public int StrCount => structs.Count;

    public void AddStructure (Structure str)
    {
        structs.Add(str);

        for (int x = str.x; x < str.x + str.data.Width; x++)
            for (int y = str.y; y < str.y + str.data.Height; y++)
                matrix[x, y] = str;
    }
    public void RemoveStructure (Structure str)
    {
        structs.Remove(str);

        for (int x = str.x; x < str.x + str.data.Width; x++)
            for (int y = str.y; y < str.y + str.data.Height; y++)
                matrix[x, y] = null;
    }
    public Structure GetAtPos(int _x, int _y) => matrix[_x, _y];
    public Structure GetAtIndex(int _i) => structs[_i];
    public bool IsInsideBounds(int _x, int _y, int _width, int _height)
    {
        return _x >= 0 && _y >= 0 && _x + _width <= Width && _y + _height <= Height;
    }
    public bool IsEmpty(int _x, int _y, int _width, int _height)
    {
        foreach (var str in structs)
            if (Utilities.AreOverlapping(_x, _y, _width, _height, str.x, str.y, str.data.Width, str.data.Height))
                return false;
        return true;
    }

    #endregion

    public Structure CreateStructure (int x, int y, int id)
    {
        StructureType data = IndexTable.GameStructures[id];

        if (!IsInsideBounds(x, y, data.Width, data.Height))
            throw new System.Exception($"Area: {x}->{x + data.Width}, {y}->{y + data.Height} is out of bounds");
        if (!IsEmpty(x, y, data.Width, data.Height))
            throw new System.Exception($"Area: {x}->{x + data.Width}, {y}->{y + data.Height} is not empty");

        GameObject go = new GameObject($"{data.Name}: {x}, {y}");
        go.transform.position = new Vector3(x, y, 0);
        go.AddComponent<SpriteRenderer>().sprite = data.Sprite;

        Structure str = data.AttachStructure(go);

        str.x = x; str.y = y;

        AddStructure(str);
        str.OnCreate();

        return str;
    }
}
