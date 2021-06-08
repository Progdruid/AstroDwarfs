using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultStructure", menuName = "Structures/Default Structure")]
public class StructureData : ScriptableObject
{
    public Sprite sprite;
    public int width, height;

    public int GetID () => System.Array.IndexOf( IndexTable.GameStructures, this);

    public virtual Structure AttachStructure (GameObject go)
    {
        Structure str = go.AddComponent<Structure>();
        str.data = this;
        return str;
    }
}
