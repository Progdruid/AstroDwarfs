using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expander : Structure
{
    public override void Tick()
    {
        base.Tick();

        if (y + data.Height + 1 <= Mission.Map.Height)
        {
            Structure up = Mission.Map.GetAtPos(x, y + 1);
            if(!(up is Expander) && !Prop.IsInArea(x, y + 1))
            {
                if (up == null)
                    ;
                if (up != null)
                    up.Kill();
                data.CreateThisStructure(x, y + 1);
            }
        }
        if (x + data.Width + 1 <= Mission.Map.Width)
        {
            Structure right = Mission.Map.GetAtPos(x + 1, y);
            if (!(right is Expander) && !Prop.IsInArea(x + 1, y))
            {
                if (right != null)
                    right.Kill();
                data.CreateThisStructure(x + 1, y);
            }
        }
        if (y - 1 >= 0)
        {
            Structure down = Mission.Map.GetAtPos(x, y - 1);
            if (!(down is Expander) && !Prop.IsInArea(x, y - 1))
            {
                if (down != null)
                    down.Kill();
                data.CreateThisStructure(x, y - 1);
            }
        }
        if (x - 1 >= 0)
        {
            Structure left = Mission.Map.GetAtPos(x - 1, y);
            if (!(left is Expander) && !Prop.IsInArea(x - 1, y))
            {
                if (left != null)
                    left.Kill();
                data.CreateThisStructure(x - 1, y);
            }
        }
    }
}
