using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Structure : MonoBehaviour, ITickable
{
    public int x, y;
    public StructureType data;

    public virtual void Tick ()
    {
        //Debug.Log($"Ticked: {data.Name} ({x}, {y})");
    }

    public virtual void OnCreate() 
    {
        Mission.Map.AddStructure(this);
    }

    public virtual void Kill()
    {
        Mission.Map.RemoveStructure(this);

        Destroy(gameObject);
        Destroy(this);
    }
}