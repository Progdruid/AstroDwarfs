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

    public Structure CreateThisStructure (int x, int y)
    {
        if(!Mission.Map.IsInsideBounds(x, y, Width, Height))
            throw new System.Exception($"Area: {x}->{x + Width}, {y}->{y + Height} is out of bounds");
        if (!Mission.Map.IsEmpty(x, y, Width, Height))
            throw new System.Exception($"Area: {x}->{x + Width}, {y}->{y + Height} is not empty");

        GameObject go = new GameObject($"{Name}: {x}, {y}");
        go.transform.position = new Vector3(x, y, 0);
        go.AddComponent<SpriteRenderer>().sprite = Sprite;

        Structure str = AttachStructure(go);

        str.x = x; str.y = y;

        str.OnCreate();

        return str;
    }

    public virtual Structure AttachStructure (GameObject go)
    {
        Structure str = go.AddComponent<Structure>();
        str.dataID = IndexTable.GetID(this);
        return str;
    }
}
