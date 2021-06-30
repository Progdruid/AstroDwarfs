using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    public string Path;
    public string Name;

    public GameTicker Game;

    public void Start()
    {
        MapConfig config = ExecuteConfig(Path, Name);
        Map map = new Map();
        map.Init(config);
        //there we need to give GameTicker map
    }

    private MapConfig ExecuteConfig (string path, string name)
    {
        FileStream stream = new FileStream(path + name, FileMode.OpenOrCreate);
        StreamReader reader = new StreamReader(stream);
        string text = reader.ReadToEnd();

        MapConfig config = JsonUtility.FromJson<MapConfig>(text);
        return config;
    }
}
