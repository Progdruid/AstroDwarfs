using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
using System.Text.RegularExpressions;

public abstract class TraitData
{
    public readonly string Name;

    public int GetID() => Mission.Registry.GetTraitDataID(this);

    public abstract Trait CreateThisTrait(Structure _structure);

    public TraitData (string _name)
    {
        Name = _name;
    }
}
