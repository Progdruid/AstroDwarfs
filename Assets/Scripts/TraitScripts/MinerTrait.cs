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

        bool found = VeinTrait.TryGetNearestAndNotOccupiedInRange(Str.x, Str.y, data.Range, out resource);
        if (found)
            resource.SetMiner(this);
    }

    public override void Tick()
    {
        if (resource == null)
            return;

        //mining resources
    }
}
