using System.Collections.Generic;

public class PropTrait : Trait
{
    private static List<PropTrait> AllProps = new List<PropTrait>();

    private readonly TraitDatas.PropData data;

    public static bool IsInRange (int x, int y)
    {
        foreach (var p in AllProps)
            if (((x - p.Str.x) * (x - p.Str.x) + (y - p.Str.y) * (y - p.Str.y)) <= p.data.Range * p.data.Range)
                return true;
        return false;
    }

    public PropTrait(TraitDatas.PropData _data, Structure _structure) : base(_structure) 
    {
        AllProps.Add(this);

        data = _data;
    }

    public override void OnKill()
    {
        AllProps.Remove(this);
    }
}
