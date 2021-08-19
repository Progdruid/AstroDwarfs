using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillerTrait : Trait
{
    private DrillerData data;
    private float cooldown = 0;

    public DrillerTrait(DrillerData _data, Structure _structure) : base(_structure)
    {
        data = _data;
    }

    public override void Tick()
    {
        if (cooldown > 0)
        {
            cooldown -= Mission.ins.TickTime;
            return;
        }

        TryDig();
        cooldown = 1f / data.DiggingSpeed;
    }

    public void TryDig ()
    {
        Structure str = Mission.ins.Map.TryGetNearest(data.AttackTargets, Str.x, Str.y);
        if (str == null)
            return;

        float dist = Mathf.Sqrt((str.x - Str.x) * (str.x - Str.x) + (str.y - Str.y) * (str.y - Str.y));
        if (dist > data.Range)
            return;

        str.Kill();
        Debug.Log("Digged: " + (str.x, str.y));
    }
}
