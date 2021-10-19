using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeinTrait : Trait
{
    public readonly TraitDatas.VeinData data;

    //static
    private static List<VeinTrait> veins = new List<VeinTrait>();
    public static bool TryGetNearestAndNotOccupiedInRange (int _x, int _y, float _range, out VeinTrait _vein)
    {
        _vein = null;
        float prevsqdist = 0f;
        foreach(VeinTrait vein in veins)
        {
            float sqdist = (vein.Str.x - _x) * (vein.Str.x - _x) + (vein.Str.y - _y) * (vein.Str.y - _y);
            if (sqdist > _range * _range)
                continue;
            if (prevsqdist >= sqdist)
                continue;

            _vein = vein;
            prevsqdist = sqdist;
        }

        return _vein != null && !_vein.IsOccupied;
    }


    //public API
    private MinerTrait Miner;

    public bool IsOccupied => Miner != null;
    public void SetMiner (MinerTrait _miner)
    {
        Miner = _miner;
    }


    //Other
    public VeinTrait(TraitDatas.VeinData _data, Structure _structure) : base(_structure)
    {
        veins.Add(this);
        data = _data;
    }

    public override void OnKill()
    {
        veins.Remove(this);
        base.OnKill();
    }
}
