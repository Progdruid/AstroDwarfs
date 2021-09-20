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
            new TraitDatas.TraitData[] {
                new TraitDatas.PropData(8.5f),
                new TraitDatas.HealthData(20),
                new TraitDatas.RenderData(new Sprite[]{ Utilities.LoadSprite("Arts/Prop", 10) }) 
            }
        ));
        
        //1
        datas.Add(new StructureData(
            "Rock",
            1, 1,
            new TraitDatas.TraitData[] { 
                new TraitDatas.ExpanderData(1f), 
                new TraitDatas.TiledRenderData( Utilities.LoadSlicedSet("Arts/RockSet", 10)) 
            }
        ));

        //2
        datas.Add(new StructureData(
            "Digger",
            2, 2,
            new TraitDatas.TraitData[] {
                new TraitDatas.DiggerData(new string[] { "Rock" }, 25, 9f),
                new TraitDatas.HealthData(100),
                new TraitDatas.RenderData(new Sprite[]{ Utilities.LoadSprite("Arts/Digger", 10) })
            }
        ));

        //3
        datas.Add(new StructureData(
            "Metal",
            1, 1,
            new TraitDatas.TraitData[] {
                new TraitDatas.ResourceData(),
                new TraitDatas.RenderData(new Sprite[]{ Utilities.LoadSprite("Arts/Rock", 10) })
            }
        ));
    }
}
