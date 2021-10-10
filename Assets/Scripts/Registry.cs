using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class Registry
{
    private List<StructureData> datas;

    public int dataCount => datas.Count;
    public StructureData GetData (int _id)
    {
        try
        {
            return datas[_id];
        }
        catch
        {
            throw new System.Exception("No such structure data");
        }
    }
    public int GetDataID (StructureData _data)
    {
        try
        {
            return datas.IndexOf(_data);
        }
        catch { throw new System.Exception("No such structure data"); }
    }

    private Dictionary<string, TraitFactories.TraitFactory> factories;

    private StructureConfig[] LoadStructureConfigs ()
    {
        StructureConfig[] configs;

        FileStream stream = new FileStream(Application.dataPath + "/Configs/StructuresConfig.json", FileMode.OpenOrCreate);
        
        using (StreamReader reader = new StreamReader(stream))
        {
            string text = reader.ReadToEnd();
            configs = (StructureConfig[])JsonConvert.DeserializeObject(text, typeof(StructureConfig[]));
        }

        return configs;
    }

    public void Init ()
    {
        InitFactories();
        InitDatas(LoadStructureConfigs());
    }

    private void InitDatas (StructureConfig[] _configs)
    {
        datas = new List<StructureData>();

        foreach(StructureConfig config in _configs)
        {
            TraitDatas.TraitData[] traitDatas = new TraitDatas.TraitData[config.Traits.Length];
            for (int i = 0; i < config.Traits.Length; i++)
            {
                factories.TryGetValue(config.Traits[i].traitName, out TraitFactories.TraitFactory factory);
                traitDatas[i] = factory.CreateTraitData(config.Traits[i].args);
            }
            datas.Add(new StructureData(config.Name, config.Width, config.Height, traitDatas));
        }
    }

    public void InitFactories ()
    {
        factories = new Dictionary<string, TraitFactories.TraitFactory>();

        factories.Add("DiggerTrait", new TraitFactories.DiggerFactory());
        factories.Add("ExpanderTrait", new TraitFactories.ExpanderFactory());
        factories.Add("HealthTrait", new TraitFactories.HealthFactory());
        factories.Add("PropTrait", new TraitFactories.PropFactory());
        factories.Add("SimpleRenderTrait", new TraitFactories.SimpleRenderFactory());
        factories.Add("TiledRenderTrait", new TraitFactories.TiledRenderFactory());
        factories.Add("VeinTrait", new TraitFactories.VeinFactory());
        factories.Add("MinerTrait", new TraitFactories.MinerFactory());
    }
}
