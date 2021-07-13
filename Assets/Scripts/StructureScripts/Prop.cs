using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : Structure
{
    protected static List<Prop> AllProps;

    public static bool IsInArea (int x, int y)
    {
        foreach (Prop prop in AllProps)
        {
            float dist = Mathf.Sqrt((prop.x - x) * (prop.x - x) + (prop.y - y) * (prop.y - y));
            if (dist <= ((PropType)prop.data).Range)
                return true;
        }

        return false;
    }
    
    public override void OnCreate()
    {
        base.OnCreate();

        if (AllProps == null)
            AllProps = new List<Prop>();

        AllProps.Add(this);
    }

    public override void Kill()
    {
        AllProps.Remove(this);

        base.Kill();
    }
}
