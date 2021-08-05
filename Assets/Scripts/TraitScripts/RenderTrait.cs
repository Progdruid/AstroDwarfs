using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTrait : Trait
{
    public readonly Sprite[] Sprites;

    public RenderTrait(RenderData _data, Structure _structure) : base(_structure)
    {
        Sprites = _data.Sprites;
        Str.gameObject.AddComponent<SpriteRenderer>().sprite = Sprites[0];
    }
}
