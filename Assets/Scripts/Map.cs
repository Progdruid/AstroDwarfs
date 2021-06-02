using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Sprite GroundSprite;

    public int Width, Height;
    public Building[,] matrix;

    public bool IsEmpty (BuildingTransform tf)
    {
        for (int _x = tf.x; _x < tf.x + tf.width; _x++)
            for (int _y = tf.y; _y < tf.y + tf.height; _y++)
                if (matrix[_x, _y] != null)
                    return false;
        return true;
    }

    public void CreateBuilding (BuildingTransform tf, Sprite sprite)
    {
        if (tf.x + tf.width >= Width || tf.y + tf.height >= Height)
            Debug.LogError($"Building out of border");
        if (tf.x < 0 || tf.y < 0)
            Debug.LogError($"Building out of border");

        if (!IsEmpty(tf))
        {
            Debug.Log("A building already exists");
            return;
        }

        GameObject go = Instantiate(new GameObject($"Building ({tf.x}, {tf.y})"), new Vector3(tf.x, tf.y, 0), Quaternion.identity);
        Building building = go.AddComponent<Building>();
        building.tf = tf;
        building.Sprite = sprite;
        SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
        renderer.sprite = building.Sprite;

        
        for (int _x = tf.x; _x < tf.x + tf.width; _x++)
            for (int _y = tf.y; _y < tf.y + tf.height; _y++)
                matrix[_x, _y] = building;

        building.OnCreate();
    }

    public void DestroyBuilding(int x, int y)
    {
        if (matrix[x, y] == null)
        {
            Debug.Log("Building does not exist");
            return;
        }

        Building building = matrix[x, y];
        BuildingTransform tf = matrix[x, y].tf;

        for (int _x = tf.x; _x < tf.x + tf.width; _x++)
            for (int _y = tf.y; _y < tf.y + tf.height; _y++)
                matrix[_x, _y] = null;

        building.OnBuildingDestroy();
    }
}
