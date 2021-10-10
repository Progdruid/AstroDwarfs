using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateRenderTrait : Trait
{
    public readonly TraitDatas.StateRenderData data;
    public (string State, Sprite Sprite) CurrentState { get; private set; }

    public StateRenderTrait (TraitDatas.StateRenderData _data, Structure _str) : base(_str)
    {
        data = _data;
        Str.gameObject.AddComponent<SpriteRenderer>();
        TryChangeState(data.DefaultState);
    }

    public bool TryChangeState (string _state)
    {
        bool found = data.SpriteStates.TryGetValue(_state, out Sprite sprite);
        if (found)
        {
            CurrentState = (_state, sprite);
            Str.gameObject.GetComponent<SpriteRenderer>().sprite = sprite; 
        }
        return found;
    }
}
