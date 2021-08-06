using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledRenderData : RenderData
{
    public TiledRenderData(Sprite[] _sprites) : base(_sprites) {}

    public override Trait CreateThisTrait(Structure _structure)
    {
        return new TiledRenderTrait(this, _structure);
    }
}
