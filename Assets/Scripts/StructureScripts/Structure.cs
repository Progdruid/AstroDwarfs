using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Structure : MonoBehaviour, ITickable
{
    public int x, y;
    public StructureData data;

    private List<Trait> traits;

    #region Traits API

    public int traitCount => traits.Count;
    public Trait GetTrait(int _id) => traits[_id];
    public void AddTrait (TraitData _data) => traits.Add(_data.CreateThisTrait(this));
    public void RemoveTrait(Trait _trait) => traits.Remove(_trait);
    public T TryFind<T> () where T : Trait
    {
        foreach (Trait trait in traits)
            if (trait is T)
                return (T)trait;
        return null;
    }
    public bool Contains<T> () where T : Trait
    {
        foreach (Trait trait in traits)
            if (trait is T)
                return true;
        return false;
    }

    #endregion

    public virtual void Tick () 
    {
        foreach (var trait in traits)
            trait.Tick();
    }

    public virtual void OnCreate(int _x, int _y, StructureData _data) 
    {
        x = _x;
        y = _y;
        data = _data;

        traits = new List<Trait>();

        foreach (var traitData in data.traitDatas)
            AddTrait(traitData);

        Mission.ins.SubscribeTickable(this);
    }

    public virtual void Kill()
    {
        Mission.ins.Map.RemoveStructure(this);
        Mission.ins.UnsubscribeTickable(this);

        foreach (var trait in traits)
            trait.OnKill();

        Destroy(gameObject);
        Destroy(this);
    }
}