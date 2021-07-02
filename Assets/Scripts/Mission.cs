using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Mission : MonoBehaviour
{
    [SerializeField] string LoadMapPath, LoadMapName;
    [SerializeField] GameObject Camera;


    public Map MissionMap { get; private set; }

    public void Start()
    {
        CreateMapFromConfig(LoadMapPath, LoadMapName);
        
    }

    private void CreateMapFromConfig(string path, string name)
    {
        FileStream stream = new FileStream(Application.dataPath + "/Assets/Maps/" + LoadMapPath, FileMode.OpenOrCreate);
        StreamReader reader = new StreamReader(stream);
        string text = reader.ReadToEnd();

        MapConfig config = JsonUtility.FromJson<MapConfig>(text);
        MissionMap = new Map();
        MissionMap.Init(config);
    }


}
