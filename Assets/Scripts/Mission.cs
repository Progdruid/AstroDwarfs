using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Mission : MonoBehaviour
{
    [SerializeField] string LoadMapName;

    public Map MissionMap { get; private set; }

    public void Start()
    {
        CreateMapFromConfig(LoadMapName);
        Camera.main.GetComponent<CameraMovement>().SetSizes(MissionMap.Width, MissionMap.Height);

    }

    private void CreateMapFromConfig(string name)
    {
        FileStream stream = new FileStream(Application.dataPath + "/Maps/" + name, FileMode.OpenOrCreate);
        StreamReader reader = new StreamReader(stream);
        string text = reader.ReadToEnd();

        MapConfig config = JsonUtility.FromJson<MapConfig>(text);
        MissionMap = new Map();
        MissionMap.Init(config);
    }


}
