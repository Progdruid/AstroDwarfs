using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[CreateAssetMenu(fileName = "IndexTable", menuName = "Index Table")]
public class IndexTable : ScriptableObject
{
    private static StructureType[] GameStructures;

    public StructureType[] gameStructures;

    private void OnValidate()
    {
        GameStructures = gameStructures;
    }

    public static int GetID(StructureType type) => System.Array.IndexOf(GameStructures, type);
    public static StructureType GetStr(int id) => GameStructures[id];
    public static int strCount => GameStructures.Length;
}
