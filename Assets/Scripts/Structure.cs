using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Structure : MonoBehaviour
{
    public int x, y;
    public StructureData data;

    public virtual void OnCreate() { }

    public virtual void OnKill()
    {
        Destroy(gameObject);
        Destroy(this);
    }
}