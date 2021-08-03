using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpanderData : TraitData
{
    public override Trait CreateThisTrait(Structure _structure)
    {
        return new ExpanderTrait(this, _structure);
    }
}
