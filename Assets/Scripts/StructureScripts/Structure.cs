using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Structure : MonoBehaviour, ITickable
{
    public int x, y;
    public int dataID;

    public virtual void Tick ()
    {
        //Debug.Log($"Ticked: {data.Name} ({x}, {y})");
    }

    public virtual void OnCreate() 
    {
        Mission.TickEvent += Tick;
    }

    public virtual void Kill()
    {
        Mission.Map.RemoveStructure(this);
        Mission.TickEvent -= Tick;

        Destroy(gameObject);
        Destroy(this);
    }
}