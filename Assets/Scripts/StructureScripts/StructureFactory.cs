using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureFactory
{
    public virtual Structure AttachStructure (GameObject _go)
    {
        return _go.AddComponent<Structure>();
    }
}
