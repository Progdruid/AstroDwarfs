using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Mission : MonoBehaviour
{
    [SerializeField] string LoadMapName;
    [SerializeField] float TickTime;
    [SerializeField] Transform MapParent;

    private float tickTime;

    public static Registry Registry { get; private set; }
    public static Map Map { get; private set; }

    private delegate void TickHandler();
    private static event TickHandler tickEvent;

    private void Start()
    {
        Init(LoadMapName);
        Camera.main.GetComponent<CameraMovement>().SetSizes(Map.Width, Map.Height);

    }

    private void Update()
    {
        tickTime += Time.deltaTime;
        if (tickTime >= TickTime)
        {
            tickTime = 0f;

            tickEvent();
        }
    }

    private void Init(string loadMapName)
    {
        Registry = new Registry();
        Registry.Init();

        //tickables = new List<ITickable>();

        FileStream stream = new FileStream(Application.dataPath + "/Maps/" + loadMapName + ".json", FileMode.OpenOrCreate);
        StreamReader reader = new StreamReader(stream);
        string text = reader.ReadToEnd();

        MapConfig config = JsonUtility.FromJson<MapConfig>(text);
        Map = new Map(MapParent, config);
    }


    public static void SubscribeTickable(ITickable tickable) => tickEvent += tickable.Tick;

    public static void UnsubscribeTickable(ITickable tickable) => tickEvent -= tickable.Tick;

}
