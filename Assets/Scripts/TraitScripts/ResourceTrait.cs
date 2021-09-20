using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTrait : Trait
{
    private Structure Miner;
    public Structure GetMiner() => Miner;
    public void SetMiner(Structure _miner) => Miner = _miner;

    public ResourceTrait(Structure _structure) : base(_structure)
    {}

}
