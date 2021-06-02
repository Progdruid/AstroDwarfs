using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BuildingTransform
{
    public int x { get; private set; }
    public int y { get; private set; }
    public int width { get; private set; }
    public int height { get; private set; }

    public int center_x => (int)(x + width / 2 + 0.5f);
    public int center_y => (int)(y + height / 2 + 0.5f);

    public BuildingTransform(int _x, int _y, int _width, int _height)
    {
        x = _x;
        y = _y;
        width = _width;
        height = _height;
    }
}