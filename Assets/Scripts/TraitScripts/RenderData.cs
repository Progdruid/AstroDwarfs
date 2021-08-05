using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderData : TraitData
{
    public readonly Sprite[] Sprites;

    public RenderData(Sprite[] _sprites) => Sprites = _sprites;

    public override Trait CreateThisTrait(Structure _structure)
    {
        return new RenderTrait(this, _structure);
    }
}
