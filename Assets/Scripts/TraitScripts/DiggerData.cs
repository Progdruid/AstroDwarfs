using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiggerData : TraitData
{
    public readonly string[] AttackTargets;
    public readonly int DiggingSpeed;
    public readonly float Range;

    public DiggerData(string[] _targets, int _diggingSpeed, float _range)
    {
        AttackTargets = _targets;
        DiggingSpeed = _diggingSpeed;
        Range = _range;
    }

    public override Trait CreateThisTrait(Structure _structure)
    {
        return new DiggerTrait(this, _structure);
    }
}
