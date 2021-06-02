using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingTransform tf;
    public Sprite Sprite;

    public virtual void OnCreate() { }
    public virtual void OnBuildingDestroy ()
    {
        Destroy(gameObject);
        Destroy(this);
    }
}
