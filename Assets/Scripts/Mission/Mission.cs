using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[DisallowMultipleComponent]
public class Mission : MonoBehaviour
{
    #region public API

    public static Mission ins;

    public Registry Registry;
    public Map Map;
    public MissionInfo MissionInfo;

    public float tickTime;
    
    private delegate void TickHandler();
    private event TickHandler tickEvent;
    public void SubscribeTickable(ITickable tickable) => tickEvent += tickable.Tick;
    public void UnsubscribeTickable(ITickable tickable) => tickEvent -= tickable.Tick;

    #endregion

    //inspector fields
    [SerializeField] string LoadMapName;
    [SerializeField] Transform MapParent;

    private float _tickTime;


    private void Awake()
    {
        ins = this;

        Init(LoadMapName);
        Camera.main.GetComponent<CameraMovement>().SetSizes(Map.Width, Map.Height);

    }

    private void Init(string loadMapName)
    {
        Registry = new Registry();
        MissionInfo = new MissionInfo();

        //mapconfig
        FileStream stream = new FileStream(Application.dataPath + "/Configs/" + loadMapName + ".json", FileMode.OpenOrCreate);
        StreamReader reader = new StreamReader(stream);
        string text = reader.ReadToEnd();

        MapConfig config = JsonUtility.FromJson<MapConfig>(text);
        Map = new Map(MapParent);
        Map.Init(config);
    }

    private void Update()
    {
        _tickTime += Time.deltaTime;
        if (_tickTime >= tickTime)
        {
            _tickTime = 0f;

            tickEvent();
        }
    }
}
