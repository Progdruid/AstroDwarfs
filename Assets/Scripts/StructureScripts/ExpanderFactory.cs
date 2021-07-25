using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpanderFactory : StructureFactory
{
    public override Structure AttachStructure(GameObject _go)
    {
        return _go.AddComponent<Expander>();
    }
}
