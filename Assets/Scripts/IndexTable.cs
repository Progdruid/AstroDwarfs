using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IndexTable", menuName = "Index Table")]
public class IndexTable : ScriptableObject
{
    public static StructureData[] GameStructures;

    public StructureData[] gameStructures;

    private void OnValidate()
    {
        GameStructures = gameStructures;
    }
}
