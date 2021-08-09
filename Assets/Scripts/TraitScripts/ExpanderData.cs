using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpanderData : TraitData
{
    public readonly float Cooldown;

    public ExpanderData(float _cooldown)
    {
        Cooldown = _cooldown;
    }

    public override Trait CreateThisTrait(Structure _structure)
    {
        return new ExpanderTrait(this, _structure);
    }
}
