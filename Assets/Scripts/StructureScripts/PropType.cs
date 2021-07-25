using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Structures/Prop")]
public class PropType : StructureType
{
    public float Range;

    public override Structure AttachStructure(GameObject go)
    {
        Structure str = go.AddComponent<Prop>();
        str.dataID = IndexTable.GetID(this);
        return str;
    }
}
