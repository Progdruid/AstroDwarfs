using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[CreateAssetMenu(fileName = "IndexTable", menuName = "Index Table")]
public class IndexTable : ScriptableObject
{
    public static StructureType[] GameStructures;

    public StructureType[] gameStructures;

    private void Awake()
    {
        OnValidate();
    }

    private void OnValidate()
    {
        GameStructures = gameStructures;
    }
}
