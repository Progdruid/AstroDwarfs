using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRenderTrait : Trait
{
    public readonly Sprite Sprite;

    public SimpleRenderTrait(TraitDatas.SimpleRenderData _data, Structure _structure) : base(_structure)
    {
        Sprite = _data.MainSprite;
        Str.gameObject.AddComponent<SpriteRenderer>().sprite = Sprite;
    }
}
