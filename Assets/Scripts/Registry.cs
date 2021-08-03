using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Registry
{
    private List<StructureData> datas;
    private List<TraitData> traitDatas;

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

    public int traitDataCount => traitDatas.Count;
    public TraitData GetTraitData (int _id)
    {
        try
        {
            return traitDatas[_id];
        }
        catch
        {
            throw new System.Exception("No such trait data");
        }
    }
    public int GetTraitDataID(TraitData _data)
    {
        try
        {
            return traitDatas.IndexOf(_data);
        }
        catch { throw new System.Exception("No such trait data"); }
    }


    public void Init ()
    {
        InitDatas();
    }

    private void InitDatas ()
    {
        traitDatas = new List<TraitData>();

        traitDatas.Add(new PropData("PropTrait", 4.5f));  //0
        traitDatas.Add(new ExpanderData("RockTrait"));    //1
        traitDatas.Add(new HealthData("PropHealth", 20)); //2

        datas = new List<StructureData>();

        //0
        datas.Add(new StructureData (
            "Prop",
            1, 1, 
            Utilities.LoadSprite("Arts/Rock", 10), 
            new TraitData[] { traitDatas[0], traitDatas[2] }
            ));
        
        //1
        datas.Add(new StructureData(
            "Rock",
            1, 1,
            Utilities.LoadSprite("Arts/Rock", 10),
            new TraitData[] { traitDatas[1] }
            ));
    }
}
