using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropData : StructureData
{
    public readonly float Range;

    public PropData(string _name, int _width, int _height, Sprite _sprite, float _range, int _id) : base(_name, _width, _height, _sprite, _id)
    {
        Range = _range;
    }
}
