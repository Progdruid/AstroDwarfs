using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureData
{
    public readonly string Name;
    public readonly int Width, Height;
    public readonly Sprite Sprite;

    public readonly int factoryID;

    public StructureData (string _name, int _width, int _height, Sprite _sprite, int _factoryID)
    {
        Name = _name;
        Width = _width;
        Height = _height;
        Sprite = _sprite;
        factoryID = _factoryID;
    }
}
