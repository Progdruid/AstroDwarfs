using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DiggerTrait : Trait
{
    private DiggerData data;
    private float cooldown = 0;

    public DiggerTrait(DiggerData _data, Structure _structure) : base(_structure)
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
        Structure str = Mission.ins.Map.GetNearestStructure((str) => data.AttackTargets.Contains(str.data.Name), Str.x, Str.y, data.Range);
        
        if (str == null)
            return;

        float dist = Mathf.Sqrt((str.x - Str.x) * (str.x - Str.x) + (str.y - Str.y) * (str.y - Str.y));
        if (dist > data.Range)
            return;

        str.Kill();
        Debug.Log("Digged: " + (str.x, str.y));
    }
}
