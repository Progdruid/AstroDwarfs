using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerTrait : Trait
{
    private readonly TraitDatas.MinerData data;
    private VeinTrait vein;
    private MissionInfo msInfo = Mission.ins.MissionInfo;

    public MinerTrait(TraitDatas.MinerData _data, Structure _structure) : base(_structure)
    {
        data = _data;

        TryOccupate();
    }

    private bool TryOccupate()
    {
        bool found = VeinTrait.TryGetNearestAndNotOccupiedInRange(Str.x, Str.y, data.Range, out vein);
        if (found)
        {
            vein.SetMiner(this);
            var render = Str.TryFind<StateRenderTrait>();
            render.TryChangeState("Mining");
        }
        return found;
    }

    public override void Tick()
    {
        if (vein == null)
        {
            TryOccupate();
            return;
        }

        msInfo.Resources[vein.data.ResourceName] += (decimal)vein.data.MineRate * (decimal)Mission.ins.tickTime;
    }
}
