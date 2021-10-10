using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerTrait : Trait
{
    private readonly TraitDatas.MinerData data;

    private VeinTrait resource;

    public MinerTrait(TraitDatas.MinerData _data, Structure _structure) : base(_structure)
    {
        data = _data;

        TryOccupate();
    }

    private bool TryOccupate()
    {
        bool found = VeinTrait.TryGetNearestAndNotOccupiedInRange(Str.x, Str.y, data.Range, out resource);
        if (found)
            resource.SetMiner(this);
        return found;
    }

    public override void Tick()
    {
        if (resource == null)
        {
            TryOccupate();
            return;
        }

        Debug.Log("mining resources");
    }
}
