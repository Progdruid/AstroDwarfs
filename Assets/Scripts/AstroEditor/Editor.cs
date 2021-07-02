using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Editor : MonoBehaviour
{
    [SerializeField] GameObject BGObj;
    [Space]
    [SerializeField] int Width;
    [SerializeField] int Height;
    [SerializeField] Sprite BgTileSprite;
    [SerializeField] StructureType SpawningStructure;
    [SerializeField] string SavePath;
    [SerializeField] string FileName;

    private List<(int x, int y, StructureType str, GameObject go)> structures;

    private StructureType Selected;

    public void SetSelected(int ID) => Selected = IndexTable.GameStructures[ID];


    public void CreateStructure (int x, int y)
    {
        if (x < 0 || x >= Width || y < 0 || y >= Height)
            return;

        (int x, int y, StructureType str, GameObject go)? overlapItem = null;
        foreach ((int x, int y, StructureType str, GameObject go) item in structures)
        {
            if(Utilities.AreOverlapping(x, y, Selected.width, Selected.height, item.x, item.y, item.str.width, item.str.height))
                overlapItem = item;
        }

        if (overlapItem.HasValue)
            return;

        GameObject go = new GameObject($"{Selected.Name}: {x}, {y}");
        go.transform.position = new Vector3(x, y, -1);
        go.AddComponent<SpriteRenderer>().sprite = Selected.sprite;

        structures.Add((x, y, Selected, go));
    }

    public void DeleteStructure (int x, int y)
    {
        if (x < 0 || x >= Width || y < 0 || y >= Height)
            return;

        (int x, int y, StructureType str, GameObject go)? deletingItem = null;

        for (int i = 0; i < structures.Count; i++)
        {
            if (Utilities.AreOverlapping(x, y, 1, 1, structures[i].x, structures[i].y, structures[i].str.width, structures[i].str.height))
                deletingItem = structures[i];
        }

        if (deletingItem == null)
            return;

        Destroy(deletingItem.Value.go);
        structures.Remove(deletingItem.Value);
    }

    public void Save ()
    {
        MapConfig config = new MapConfig();
        config.width = Width;
        config.height = Height;
        config.SpawningStructureIndex = SpawningStructure.GetID();
        config.structCount = structures.Count;

        List<int> xs = new List<int>();
        List<int> ys = new List<int>();
        List<int> ids = new List<int>();

        foreach ((int x, int y, StructureType str, GameObject go) item in structures)
        {
            xs.Add(item.x);
            ys.Add(item.y);
            ids.Add(item.str.GetID());
        }

        config.xs = xs.ToArray();
        config.ys = ys.ToArray();
        config.ids = ids.ToArray();

        string configText = JsonUtility.ToJson(config);
        FileStream stream = new FileStream(Application.dataPath + "/Maps/" + FileName, FileMode.Create);
        using (StreamWriter writer = new StreamWriter(stream))
        {
            writer.Write(configText);
        }
    }

    void Start()
    {
        for (int x = 0; x < Width; x++)
            for (int y = 0; y < Height; y++)
            {
                GameObject go = new GameObject($"BgTile: {x}, {y}");
                go.transform.position = new Vector3(x, y, 0);
                go.AddComponent<SpriteRenderer>().sprite = BgTileSprite;
                go.transform.SetParent(BGObj.transform);
            }

        structures = new List<(int x, int y, StructureType str, GameObject go)>();
        Selected = IndexTable.GameStructures[0]; //default

        Camera.main.GetComponent<CameraMovement>().SetSizes(Width, Height);
    }
}
