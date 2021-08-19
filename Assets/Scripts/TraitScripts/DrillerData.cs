using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillerData : TraitData
{
    public readonly string[] AttackTargets;
    public readonly int DiggingSpeed;
    public readonly float Range;

    public DrillerData(string[] _targets, int _diggingSpeed, float _range)
    {
        AttackTargets = _targets;
        DiggingSpeed = _diggingSpeed;
        Range = _range;
    }

    public override Trait CreateThisTrait(Structure _structure)
    {
        return new DrillerTrait(this, _structure);
    }
}
