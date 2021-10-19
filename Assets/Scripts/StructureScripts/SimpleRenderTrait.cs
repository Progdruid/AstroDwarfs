using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRenderTrait : Trait
{
    public SimpleRenderTrait(TraitDatas.SimpleRenderData _data, Structure _structure) : base(_structure)
    {
        Str.gameObject.AddComponent<SpriteRenderer>().sprite = _data.MainSprite;
    }
}
