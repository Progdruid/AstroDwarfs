using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilarTrait : Trait
{
    public static List<PilarTrait> Pilars = new List<PilarTrait>();
    private static List<PilarTrait> GetPilarsInRange(int _x, int _y, PilarTrait _thisPilar)
    {
        List<PilarTrait> nearest = new List<PilarTrait>();

        foreach (var pilar in Pilars)
        {
            if (pilar == _thisPilar)
                continue;

            float dist = Mathf.Sqrt((_x - pilar.Str.x) * (_x - pilar.Str.x) + (_y - pilar.Str.y) * (_y - pilar.Str.y));
            if (dist <= data.Range)
                nearest.Add(pilar);
        }

        return nearest;
    }
    public static bool CheckConnectionToNetwork (int _x, int _y)
    {
        return Pilars.Exists(p => Mathf.Sqrt((_x - p.Str.x) * (_x - p.Str.x) + (_y - p.Str.y) * (_y - p.Str.y)) <= data.Range && p.Active);
    }

    private static TraitDatas.PilarData data;

    public bool Active;
    public List<PilarTrait> Connections = new List<PilarTrait>();

    public PilarTrait(TraitDatas.PilarData _data, Structure _structure) : base(_structure)
    {
        if (Pilars.Count == 0)
            data = _data;
        
        Active = Pilars.Count == 0;
        Pilars.Add(this);

        UpdateConnections();
        foreach (var pilar in Connections)
            pilar.UpdateConnections();
    }

    public void UpdateConnections ()
    {
        Connections = GetPilarsInRange(Str.x, Str.y, this);
        if (!Active)
            Active = Connections.Exists(x => x.Active);
    }



    public override void OnKill()
    {
        Pilars.Remove(this);
        UpdateConnections();
        foreach (var pilar in Connections)
            pilar.UpdateConnections();
        base.OnKill();
    }
}
