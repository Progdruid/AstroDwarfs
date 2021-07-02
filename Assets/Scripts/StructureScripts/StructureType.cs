using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultStructure", menuName = "Structures/Default Structure")]
public class StructureType : ScriptableObject
{
    public string Name;
    public Sprite Sprite;
    public int Width, Height;

    public int GetID () => System.Array.IndexOf( IndexTable.GameStructures, this);

    public virtual Structure CreateThisStructure (Map map, int x, int y)
    {
        if(!map.IsInsideBounds(x, y, Width, Height))
            throw new System.Exception($"Area: {x}->{x + Width}, {y}->{y + Height} is out of bounds");
        if (!map.IsEmpty(x, y, Width, Height))
            throw new System.Exception($"Area: {x}->{x + Width}, {y}->{y + Height} is not empty");

        GameObject go = new GameObject($"{Name}: {x}, {y}");
        go.transform.position = new Vector3(x, y, 0);
        go.AddComponent<SpriteRenderer>().sprite = Sprite;
        Structure str = go.AddComponent<Structure>();
        str.x = x; str.y = y;
        str.data = this;
        map.Structures.Add(str);

        return str;
    }

    public virtual Structure AttachStructure (GameObject go)
    {
        Structure str = go.AddComponent<Structure>();
        str.data = this;
        return str;
    }
}
