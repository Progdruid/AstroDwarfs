using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapConfig
{
    public int width, height;

    public (int x, int y, int id)[] structures;

    public int SpawningStructureIndex;
}
