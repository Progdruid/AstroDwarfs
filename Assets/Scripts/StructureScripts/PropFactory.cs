using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropFactory : StructureFactory
{
    public override Structure AttachStructure(GameObject _go)
    {
        return _go.AddComponent<Prop>();
    }
}
