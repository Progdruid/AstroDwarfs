using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trait : ITickable
{
    public readonly TraitData Data;
    public readonly Structure Str;

    public virtual void Tick() { }
    public virtual void OnKill() { }


    public Trait (TraitData _data, Structure _structure)
    {
        Data = _data;
        Str = _structure;
    }
}
