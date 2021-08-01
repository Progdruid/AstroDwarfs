using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpanderData : TraitData
{
    public ExpanderData(string _name) : base(_name)
    {

    }

    public override Trait CreateThisTrait(Structure _structure)
    {
        return new ExpanderTrait(this, _structure);
    }
}
