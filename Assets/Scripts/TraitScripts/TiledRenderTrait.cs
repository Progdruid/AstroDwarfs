using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledRenderTrait : Trait
{
    public readonly Sprite[] SpriteSet;

    public TiledRenderTrait(TraitDatas.TiledRenderData _data, Structure _structure) : base(_structure)
    {
        SpriteSet = _data.SpriteSet;
        Str.gameObject.AddComponent<SpriteRenderer>();

        CheckConnection();
        TickNears();
    }

    public override void OnKill()
    {
        TickNears();
    }

    private void TickNears ()
    {
        try { Mission.ins.Map.GetAtPos(Str.x, Str.y + 1).TryFind<TiledRenderTrait>().CheckConnection(); } catch { }
        try { Mission.ins.Map.GetAtPos(Str.x + 1, Str.y).TryFind<TiledRenderTrait>().CheckConnection(); } catch { }
        try { Mission.ins.Map.GetAtPos(Str.x, Str.y - 1).TryFind<TiledRenderTrait>().CheckConnection(); } catch { }
        try { Mission.ins.Map.GetAtPos(Str.x - 1, Str.y).TryFind<TiledRenderTrait>().CheckConnection(); } catch { }
    }

    public void CheckConnection ()
    {
        bool up = true;
        bool right = true;
        bool down = true;
        bool left = true;
        try { up = Mission.ins.Map.GetAtPos(Str.x, Str.y + 1).data.Name != Str.data.Name; } catch { }
        try { right = Mission.ins.Map.GetAtPos(Str.x + 1, Str.y).data.Name != Str.data.Name; } catch { }
        try { down = Mission.ins.Map.GetAtPos(Str.x, Str.y - 1).data.Name != Str.data.Name; } catch { }
        try { left = Mission.ins.Map.GetAtPos(Str.x - 1, Str.y).data.Name != Str.data.Name; } catch { }

        int id = (up ? 1 : 0) + (right ? 1 : 0) * 2 + (down ? 1 : 0) * 4 + (left ? 1 : 0) * 8;
        Str.gameObject.GetComponent<SpriteRenderer>().sprite = SpriteSet[id];
    }
}
