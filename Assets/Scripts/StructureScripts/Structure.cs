using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Structure : MonoBehaviour, ITickable
{
    public int x, y;
    public int dataID;

    public virtual void Tick ()
    {

    }

    public virtual void OnCreate() 
    {
        Mission.SubscribeTickable(this);
    }

    public virtual void Kill()
    {
        Mission.Map.RemoveStructure(this);
        Mission.UnsubscribeTickable(this);

        Destroy(gameObject);
        Destroy(this);
    }
}