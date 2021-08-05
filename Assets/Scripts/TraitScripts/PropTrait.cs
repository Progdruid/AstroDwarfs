using System.Collections.Generic;

public class PropTrait : Trait
{
    private static List<PropTrait> AllProps;

    private readonly PropData data;

    public static bool IsInRange (int x, int y)
    {
        foreach (var p in AllProps)
            if (((x - p.Str.x) * (x - p.Str.x) + (y - p.Str.y) * (y - p.Str.y)) <= p.data.Range * p.data.Range)
                return true;
        return false;
    }

    public PropTrait(PropData _data, Structure _structure) : base(_structure) 
    {
        if (AllProps == null)
            AllProps = new List<PropTrait>();
        AllProps.Add(this);

        data = _data;
    }

    public override void OnKill()
    {
        AllProps.Remove(this);
    }
}
