using System.Collections.Generic;

[System.Serializable]
public struct StructureConfig
{
    public string Name;
    public int Width, Height;
    public (string traitName, Dictionary<string, object> args)[] Traits;
}
