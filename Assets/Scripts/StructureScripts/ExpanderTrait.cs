using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1x1 only
public class ExpanderTrait : Trait
{
    public ExpanderTrait(TraitData _data, Structure _structure) : base(_data, _structure) { }

    public override void Tick ()
    {
        if (Str.y + 1 + Str.data.Height <= Mission.Map.Height)
            TryExpand(Str.x, Str.y + 1, Str.data);
        if (Str.x + 1 + Str.data.Width <= Mission.Map.Width)
            TryExpand(Str.x + 1, Str.y, Str.data);
        if (Str.y - 1 >= 0)
            TryExpand(Str.x, Str.y - 1, Str.data);
        if (Str.x - 1 >= 0)
            TryExpand(Str.x - 1, Str.y, Str.data);
    }

    private void TryExpand (int _x, int _y, StructureData _data)
    {
        if (PropTrait.IsInRange(_x, _y))
            return;

        Structure str = Mission.Map.GetAtPos(_x, _y);

        if (str == null)
        {
            Mission.Map.CreateStructure(_x, _y, _data);
            return;
        }
        if (str.Contains<ExpanderTrait>())
                return;
        else
        {
            str.Kill();
            Mission.Map.CreateStructure(_x, _y, _data);
        }
    }
}
