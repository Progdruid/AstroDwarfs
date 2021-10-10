using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

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
            _params.TryGetValue("Health", out object health);

            return new TraitDatas.HealthData(Convert.ToInt32(health));
        }
    }

    public class PropFactory : TraitFactory
    {
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _params)
        {
            _params.TryGetValue("Range", out object range);
            return new TraitDatas.PropData((float)(double)range);
        }
    }

    #region Render
    
    public class SimpleRenderFactory : TraitFactory
    {
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _params)
        {
            _params.TryGetValue("Path", out object path);
            return new TraitDatas.SimpleRenderData( Utilities.LoadSprite((string)path, 10) );
        }
    }

    public class TiledRenderFactory : TraitFactory
    {
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _params)
        {
            _params.TryGetValue("Path", out object path);
            return new TraitDatas.TiledRenderData(Utilities.LoadSlicedSet((string)path, 10));
        }
    }

    #endregion

    public class ExpanderFactory : TraitFactory
    {
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _params)
        {
            _params.TryGetValue("Cooldown", out object cooldown);
            return new TraitDatas.ExpanderData((float)(double)cooldown);
        }
    }

    public class DiggerFactory : TraitFactory
    {
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _params)
        {
            _params.TryGetValue("Targets", out object targets);
            _params.TryGetValue("DiggingSpeed", out object diggingSpeed);
            _params.TryGetValue("Range", out object range);
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
            _params.TryGetValue("ResourceName", out object _name);
            return new TraitDatas.VeinData(_name.ToString());
        }
    }

    public class MinerFactory : TraitFactory
    {
        public override TraitDatas.TraitData CreateTraitData(Dictionary<string, object> _params)
        {
            _params.TryGetValue("MineRate", out object _efficiency);
            _params.TryGetValue("Range", out object _range);
            return new TraitDatas.MinerData(Convert.ToInt32(_efficiency), (float)(double)_range);
        }
    }
}