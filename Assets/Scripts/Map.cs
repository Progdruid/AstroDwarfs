using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Map
{
    public int Width { get; private set; }
    public int Height { get; private set; }

    private Transform parent;

    public Map(Transform _parent)
    {
        parent = _parent;
    }

    #region Structures

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

    #endregion

    #region Secondary functions

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
    public Structure GetNearestStructure(System.Func<Structure, bool> _condition, int _x, int _y, float _range)
    {
        for (float curRange = 1f; curRange < _range; curRange += 1f)
        {
            decimal curAngleDelta = 1m / (decimal)(curRange + 1);
            for (decimal angle = 0; angle < (decimal)Mathf.PI * 2; angle += curAngleDelta)
            {
                int x = _x + Mathf.RoundToInt(curRange * Mathf.Cos((float)angle));
                int y = _y + Mathf.RoundToInt(curRange * Mathf.Sin((float)angle));

                if (x < 0 || y < 0 || x >= Width || y >= Height)
                    continue;

                Structure str = GetAtPos(x, y);
                if (str != null)
                    if (_condition(str))
                        return str;
            }

            if (_range - curRange < 1)
                curRange = _range;
        }

        return null;
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

        Structure str = go.AddComponent<Structure>();

        str.x = _x; str.y = _y;
        str.data = _data;
        AddStructure(str);

        str.OnCreate();

        return str;
    }

    public void Init (MapConfig _config)
    {
        Width = _config.width;
        Height = _config.height;
        structs = new List<Structure>();
        matrix = new Structure[Width, Height];

        for (int i = 0; i < _config.structCount; i++)
            CreateStructure(_config.xs[i], _config.ys[i], Mission.ins.Registry.GetData(_config.ids[i]));
    }
}
