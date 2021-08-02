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
            CreateStructure(_config.xs[i], _config.ys[i], Mission.ins.Registry.GetData(_config.ids[i]));
        
    }

    #region Structures API

    private List<Structure> structs;
    private Structure[,] matrix;

    public int StrCount => structs.Count;

    public void AddStructure (Structure _str)
    {
        structs.Add(_str);

        for (int x = _str.x; x < _str.x + _str.data.Width; x++)
            for (int y = _str.y; y < _str.y + _str.data.Height; y++)
                matrix[x, y] = _str;
    }
    public void RemoveStructure (Structure _str)
    {
        structs.Remove(_str);

        for (int x = _str.x; x < _str.x + _str.data.Width; x++)
            for (int y = _str.y; y < _str.y + _str.data.Height; y++)
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

    public Structure CreateStructure (int _x, int _y, StructureData _data)
    {
        if (!IsInsideBounds(_x, _y, _data.Width, _data.Height))
            throw new System.Exception($"Area: {_x}->{_x + _data.Width}, {_y}->{_y + _data.Height} is out of bounds");
        if (!IsEmpty(_x, _y, _data.Width, _data.Height))
            throw new System.Exception($"Area: {_x}->{_x + _data.Width}, {_y}->{_y + _data.Height} is not empty");

        GameObject go = new GameObject($"{_data.Name}: {_x}, {_y}");
        go.transform.position = new Vector3(_x, _y, 0);
        go.transform.parent = parent;
        go.AddComponent<SpriteRenderer>().sprite = _data.Sprite;

        Structure str = go.AddComponent<Structure>();

        str.OnCreate(_x, _y, _data);
        AddStructure(str);

        return str;
    }
}
