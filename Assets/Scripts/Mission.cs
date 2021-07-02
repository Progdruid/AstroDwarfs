using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Mission : MonoBehaviour
{
    [SerializeField] string LoadMapName;
    [SerializeField] float TickTime;

    private float tickTime;

    public Map MissionMap { get; private set; }

    private void Start()
    {
        CreateMapFromConfig(LoadMapName);
        Camera.main.GetComponent<CameraMovement>().SetSizes(MissionMap.Width, MissionMap.Height);

    }

    private void Update()
    {
        tickTime += Time.fixedDeltaTime;
        if (tickTime >= TickTime)
        {
            tickTime = 0f;
            MissionMap.TickAll();
        }
    }

    private void CreateMapFromConfig(string name)
    {
        FileStream stream = new FileStream(Application.dataPath + "/Maps/" + name + ".json", FileMode.OpenOrCreate);
        StreamReader reader = new StreamReader(stream);
        string text = reader.ReadToEnd();

        MapConfig config = JsonUtility.FromJson<MapConfig>(text);
        MissionMap = new Map();
        MissionMap.Init(config);
    }


}
