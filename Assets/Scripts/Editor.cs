using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Editor : MonoBehaviour
{
    [SerializeField] int Width;
    [SerializeField] int Height;
    [SerializeField] Sprite BgTileSprite;
    [SerializeField] StructureType SpawningStructure;
    [SerializeField] string SavePath;
    [SerializeField] string FileName;

    private List<(int x, int y, StructureType str, GameObject go)> structures;

    public void CreateStructure (StructureType str, int x, int y)
    {
        GameObject go = new GameObject($"{str.Name}: {x}, {y}");
        go.transform.position = new Vector3(x, y, -1);
        go.AddComponent<SpriteRenderer>().sprite = str.sprite;

        structures.Add((x, y, str, go));
    }

    public void DeleteStructure (int x, int y)
    {
        (int x, int y, StructureType str, GameObject go)? deletingItem = null;
        foreach ((int x, int y, StructureType str, GameObject go) item in structures)
        {
            if (item.x <= x && item.y <= y && x < item.x + item.str.width && y < item.y + item.str.height)
                deletingItem = item;
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
        
        List<(int x, int y, int id)> strs = new List<(int x, int y, int id)>();
        foreach ((int x, int y, StructureType str, GameObject go) item in structures)
        {
            strs.Add((item.x, item.y, item.str.GetID()));
        }
        config.structures = strs.ToArray();

        string configText = JsonUtility.ToJson(config);
        FileStream stream = new FileStream(SavePath + FileName, FileMode.Create);
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
            }

        structures = new List<(int x, int y, StructureType str, GameObject go)>();
    }
}
