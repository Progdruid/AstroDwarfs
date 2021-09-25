using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureData
{
    public readonly string Name;
    public readonly int Width, Height;

    public readonly TraitDatas.TraitData[] TraitDatas;

    public StructureData (string _name, int _width, int _height, TraitDatas.TraitData[] _traitDatas)
    {
        Name = _name;
        Width = _width;
        Height = _height;
        TraitDatas = _traitDatas;
    }
}
