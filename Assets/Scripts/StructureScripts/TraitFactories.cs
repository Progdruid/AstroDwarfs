using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class TraitFactories    
{
    public abstract class TraitFactory
    {
        public abstract TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _params);
    }
    
    public class HealthFactory : TraitFactory
    {
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _params)
        {
            object health = _params["Health"];

            return new TraitDatas.HealthData(Convert.ToInt32(health));
        }
    }

    public class PropFactory : TraitFactory
    {
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _params)
        {
            object range = _params["Range"];
            return new TraitDatas.PropData((float)(double)range);
        }
    }

    #region Render
    
    public class SimpleRenderFactory : TraitFactory
    {
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _params)
        {
            object path = _params["Path"];
            object ppu = _params["PixelsPerUnit"];
            return new TraitDatas.SimpleRenderData( Utilities.LoadSprite((string)path, Convert.ToInt32(ppu)) );
        }
    }

    public class TiledRenderFactory : TraitFactory
    {
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _params)
        {
            object path = _params["Path"];
            object ppu = _params["PixelsPerUnit"];
            return new TraitDatas.TiledRenderData(Utilities.LoadSlicedSet((string)path, Convert.ToInt32(ppu)));
        }
    }

    public class StateRenderFactory : TraitFactory
    {
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _params)
        {
            object ppuobj = _params["PixelsPerUnit"];
            int ppu = Convert.ToInt32(ppuobj);
            
            object objdict = _params["SpriteStates"];
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
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _params)
        {
            object cooldown = _params["Cooldown"];
            return new TraitDatas.ExpanderData((float)(double)cooldown);
        }
    }

    public class DiggerFactory : TraitFactory
    {
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _params)
        {
            object targets = _params["Targets"];
            object diggingSpeed =_params["DiggingSpeed"];
            object range = _params["Range"];
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
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _params)
        {
            object _name = _params["ResourceName"];
            object _mineRate = _params["MineRate"];
            return new TraitDatas.VeinData(_name.ToString(), (double)_mineRate);
        }
    }

    public class MinerFactory : TraitFactory
    {
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _params)
        {
            object _range = _params["Range"];
            return new TraitDatas.MinerData((float)(double)_range);
        }
    }
}