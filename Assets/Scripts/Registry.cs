using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    public void Init ()
    {
        InitDatas();
    }

    private void InitDatas ()
    {
        datas = new List<StructureData>();

        //0
        datas.Add(new StructureData (
            "Prop",
            2, 2,
            new TraitData[] {
                new PropData(8.5f),
                new HealthData(20),
                new RenderData(new Sprite[]{ Utilities.LoadSprite("Arts/Prop", 10) }) 
            }
        ));
        
        //1
        datas.Add(new StructureData(
            "Rock",
            1, 1,
            new TraitData[] { 
                new ExpanderData(1), 
                new TiledRenderData( Utilities.LoadSlicedSet("Arts/RockSet", 10)) 
            }
        ));
    }
}
