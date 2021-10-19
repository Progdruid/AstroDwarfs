using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A class, which contains all info about player state, resources, enemy state, etc.
public class MissionInfo
{
    public Dictionary<string, decimal> Resources;

    public MissionInfo ()
    {
        Resources = new Dictionary<string, decimal>();

        Resources.Add("Cobalt", 0);
    }
}
