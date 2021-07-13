using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Mission : MonoBehaviour
{
    [SerializeField] string LoadMapName;
    [SerializeField] float TickTime;

    private float tickTime;

    public static Map Map { get; private set; }

    private void Start()
    {
        CreateMapFromConfig(LoadMapName);
        Camera.main.GetComponent<CameraMovement>().SetSizes(Map.Width, Map.Height);

    }

    private void Update()
    {
        tickTime += Time.deltaTime;
        if (tickTime >= TickTime)
        {
            tickTime = 0f;
            Map.TickAll();
        }
    }

    private void CreateMapFromConfig(string name)
    {
        FileStream stream = new FileStream(Application.dataPath + "/Maps/" + name + ".json", FileMode.OpenOrCreate);
        StreamReader reader = new StreamReader(stream);
        string text = reader.ReadToEnd();

        MapConfig config = JsonUtility.FromJson<MapConfig>(text);
        Map = new Map();
        Map.Init(config);
    }


}
