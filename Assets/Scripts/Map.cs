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

        for (int x = str.x; x < str.x + Mission.Registry.GetData(str.dataID).Width; x++)
            for (int y = str.y; y < str.y + Mission.Registry.GetData(str.dataID).Height; y++)
                matrix[x, y] = str;
    }
    public void RemoveStructure (Structure str)
    {
        structs.Remove(str);

        for (int x = str.x; x < str.x + Mission.Registry.GetData(str.dataID).Width; x++)
            for (int y = str.y; y < str.y + Mission.Registry.GetData(str.dataID).Height; y++)
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
            if (Utilities.AreOverlapping(_x, _y, _width, _height, str.x, str.y, Mission.Registry.GetData(str.dataID).Width, Mission.Registry.GetData(str.dataID).Height))
                return false;
        return true;
    }

    #endregion

    public Structure CreateStructure (int _x, int _y, int _dataID)
    {
        //StructureType data = IndexTable.GetStr(id);
        StructureData data = Mission.Registry.GetData(_dataID);
        StructureFactory factory = Mission.Registry.GetFactory(data.factoryID);

        if (!IsInsideBounds(_x, _y, data.Width, data.Height))
            throw new System.Exception($"Area: {_x}->{_x + data.Width}, {_y}->{_y + data.Height} is out of bounds");
        if (!IsEmpty(_x, _y, data.Width, data.Height))
            throw new System.Exception($"Area: {_x}->{_x + data.Width}, {_y}->{_y + data.Height} is not empty");

        GameObject go = new GameObject($"{data.Name}: {_x}, {_y}");
        go.transform.position = new Vector3(_x, _y, 0);
        go.transform.parent = parent;
        go.AddComponent<SpriteRenderer>().sprite = data.Sprite;

        Structure str = factory.AttachStructure(go);

        str.dataID = _dataID;
        str.x = _x; str.y = _y;

        AddStructure(str);
        str.OnCreate();

        return str;
    }
}
