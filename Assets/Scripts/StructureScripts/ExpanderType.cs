using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//only 1x1
[CreateAssetMenu(fileName = "", menuName = "Structures/Expander")]
public class ExpanderType : StructureType
{
    public override Structure AttachStructure(GameObject go)
    {
        Structure str = go.AddComponent<Expander>();
        str.data = this;
        return str;
    }
}
