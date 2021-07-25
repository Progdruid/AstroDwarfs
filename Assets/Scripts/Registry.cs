using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Registry
{
    private List<StructureFactory> factories;
    private List<StructureData> datas;

    public int factoryCount => factories.Count;
    public StructureFactory GetFactory (int _id)
    {
        try
        {
            return factories[_id];
        } 
        catch 
        {
            throw new System.Exception("No such factory");
        }
    }
    public int GetFactoryID(StructureFactory _factory)
    {
        try
        {
            return factories.IndexOf(_factory);
        }
        catch { throw new System.Exception("No such factory"); }
    }

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
        InitFactories();
        InitDatas();
    }

    private void InitFactories ()
    {
        factories = new List<StructureFactory>();

        factories.Add(new StructureFactory()); //0
        factories.Add(new PropFactory());      //1
        factories.Add(new ExpanderFactory());  //2
    }

    private void InitDatas ()
    {
        datas = new List<StructureData>();

        object sprite = Resources.Load("Arts/Rock");
        datas.Add(new StructureData("Rock", 1, 1, Utilities.LoadSprite("Arts/Rock", 10) as Sprite, 2));   //0
        datas.Add(new PropData("Prop", 1, 1, Utilities.LoadSprite("Arts/Rock", 10) as Sprite, 4.5f, 1));  //1
    }
}
