using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[DisallowMultipleComponent]
public class Mission : MonoBehaviour
{
    #region public API

    public static Mission ins;
    public Registry Registry { get; private set; }
    public Map Map { get; private set; }

    private delegate void TickHandler();
    private event TickHandler tickEvent;
    public void SubscribeTickable(ITickable tickable) => tickEvent += tickable.Tick;
    public void UnsubscribeTickable(ITickable tickable) => tickEvent -= tickable.Tick;

    #endregion

    //private fields
    [SerializeField] string LoadMapName;
    [SerializeField] float TickTime;
    [SerializeField] Transform MapParent;

    private float tickTime;


    private void Start()
    {
        ins = this;

        Init(LoadMapName);
        Camera.main.GetComponent<CameraMovement>().SetSizes(Map.Width, Map.Height);

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

    private void Update()
    {
        tickTime += Time.deltaTime;
        if (tickTime >= TickTime)
        {
            tickTime = 0f;

            tickEvent();
        }
    }
}
