using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Structure : MonoBehaviour
{
    public int x, y;
    public StructureType data;

    public virtual void Tick ()
    {
        Debug.Log($"Ticked: {data.Name} ({x}, {y})");
    }

    public virtual void OnCreate() { }

    public virtual void OnKill()
    {
        Destroy(gameObject);
        Destroy(this);
    }
}