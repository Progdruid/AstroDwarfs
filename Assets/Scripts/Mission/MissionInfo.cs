using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//A class, which contains all info about player state, resources, enemy state, etc.
public class MissionInfo
{
    private Dictionary<string, decimal> Resources;


    public Dictionary<string, decimal>.KeyCollection GetResKeys() => Resources.Keys;
    public decimal GetResByKey(string _key) => Resources[_key];
    public void SetResByKey(string _key, decimal _value)
    {
        if (InfoUpdateEvent != null)
            InfoUpdateEvent();
        Resources[_key] = _value;
    }
    public void IncreaseResByKey(string _key, decimal _value)
    {
        if (InfoUpdateEvent != null)
            InfoUpdateEvent();
        Resources[_key] += _value;
    }
    public void MultResByKey(string _key, decimal _mult)
    {
        if (InfoUpdateEvent != null)
            InfoUpdateEvent();
        Resources[_key] *= _mult;
    }
    public void AddRes(string _key, decimal _value)
    {
        if (InfoUpdateEvent != null)
            InfoUpdateEvent();
        Resources.Add(_key, _value);
    }


    public delegate void InfoUpdateHandler();
    public event InfoUpdateHandler InfoUpdateEvent;


    public MissionInfo ()
    {
        Resources = new Dictionary<string, decimal>();

        Resources.Add("Cobalt", 0);
    }
}
