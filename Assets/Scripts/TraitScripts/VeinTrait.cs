using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeinTrait : Trait
{
    //static
    private static List<VeinTrait> resources = new List<VeinTrait>();
    public static bool TryGetNearestAndNotOccupiedInRange (int _x, int _y, float _range, out VeinTrait _resource)
    {
        _resource = null;
        float prevsqdist = 0f;
        foreach(VeinTrait resource in resources)
        {
            float sqdist = (resource.Str.x - _x) * (resource.Str.x - _x) + (resource.Str.y - _y) * (resource.Str.y - _y);
            if (sqdist > _range * _range)
                continue;
            if (prevsqdist >= sqdist)
                continue;

            _resource = resource;
            prevsqdist = sqdist;
        }

        return _resource != null && !_resource.IsOccupied;
    }


    //public API
    private MinerTrait Miner;

    public bool IsOccupied => Miner != null;
    public void SetMiner (MinerTrait _miner)
    {
        Miner = _miner;
    }


    //Other
    public VeinTrait(Structure _structure) : base(_structure)
    {
        resources.Add(this);
    }

    public override void OnKill()
    {
        resources.Remove(this);
        base.OnKill();
    }
}
