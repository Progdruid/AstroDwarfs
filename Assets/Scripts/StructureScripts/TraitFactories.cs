using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class TraitFactories    
{
    public abstract class TraitFactory
    {
        public abstract TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _args);
    }
    
    public class HealthFactory : TraitFactory
    {
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _args)
        {
            object health = _args["Health"];

            return new TraitDatas.HealthData(Convert.ToInt32(health));
        }
    }

    public class PilarFactory : TraitFactory
    {
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _args)
        {
            object range = _args["Range"];
            return new TraitDatas.PilarData((float)(double)range);
        }
    }

    public class PropFactory : TraitFactory
    {
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _args)
        {
            object range = _args["Range"];
            return new TraitDatas.PropData((float)(double)range);
        }
    }

    #region Render
    
    public class SimpleRenderFactory : TraitFactory
    {
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _args)
        {
            object path = _args["Path"];
            object ppu = _args["PixelsPerUnit"];
            return new TraitDatas.SimpleRenderData( Utilities.LoadSprite((string)path, Convert.ToInt32(ppu)) );
        }
    }

    public class TiledRenderFactory : TraitFactory
    {
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _args)
        {
            object path = _args["Path"];
            object ppu = _args["PixelsPerUnit"];
            return new TraitDatas.TiledRenderData(Utilities.LoadSlicedSet((string)path, Convert.ToInt32(ppu)));
        }
    }

    public class StateRenderFactory : TraitFactory
    {
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _args)
        {
            object ppuobj = _args["PixelsPerUnit"];
            int ppu = Convert.ToInt32(ppuobj);
            
            object objdict = _args["SpriteStates"];
            object[] objarr = (objdict as IEnumerable<object>).ToArray();

            Dictionary<string, Sprite> dict = new Dictionary<string, Sprite>(); 
            foreach (object kvp in objarr)
            {
                string str = kvp.ToString();
                string[] arr = str.Split(':');
                arr[0] = arr[0].Trim(new char[] { '"' } );
                arr[1] = arr[1].Trim(new char[] { '"', ' ' });
                dict.Add(arr[0], Utilities.LoadSprite(arr[1], ppu));
            }
            return new TraitDatas.StateRenderData(dict);
        }
    }

    #endregion

    public class ExpanderFactory : TraitFactory
    {
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _args)
        {
            object cooldown = _args["Cooldown"];
            return new TraitDatas.ExpanderData((float)(double)cooldown);
        }
    }

    public class DiggerFactory : TraitFactory
    {
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _args)
        {
            object targets = _args["Targets"];
            object diggingSpeed =_args["DiggingSpeed"];
            object range = _args["Range"];
            List<string> _targets = new List<string>();
            foreach(object objTarget in targets as IEnumerable<object>)
            {
                string strTarget = objTarget.ToString();
                _targets.Add(strTarget);
            }

            return new TraitDatas.DiggerData(_targets.ToArray(), Convert.ToInt32(diggingSpeed), (float)(double)range);
        }
    }

    public class VeinFactory : TraitFactory
    {
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _args)
        {
            object _name = _args["ResourceName"];
            object _mineRate = _args["MineRate"];
            return new TraitDatas.VeinData(_name.ToString(), (double)_mineRate);
        }
    }

    public class MinerFactory : TraitFactory
    {
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _args)
        {
            object _range = _args["Range"];
            return new TraitDatas.MinerData((float)(double)_range);
        }
    }
}