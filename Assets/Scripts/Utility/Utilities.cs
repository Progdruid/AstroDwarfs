using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{
    public static bool AreOverlapping (int x, int y, int w, int h, int objx, int objy, int objw, int objh)
    {
        for (int _x = x; _x < x + w; _x++)
            for (int _y = y; _y < y + h; _y++)
                if (objx <= _x && _x < objx + objw && objy <= _y && _y < objy + objh)
                    return true;
        return false;
    }

    public static Sprite LoadSprite (string _path, int _pixelsPerUnit)
    {
        Texture2D texture = (Texture2D)Resources.Load(_path);
        texture.filterMode = FilterMode.Point;
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0f, 0f), _pixelsPerUnit);
        
        return sprite;
    }

    public static Sprite[] LoadSlicedSet (string _path, int _ppu)
    {
        Texture2D loadTexture = (Texture2D)Resources.Load(_path);
        int w = loadTexture.width / 4;
        int h = loadTexture.height / 4;

        Sprite[] sprites = new Sprite[16];
        sprites[0] = GetPiece(loadTexture, 1 * w, 1 * h, w, h, _ppu);  //center          - 0000
        sprites[1] = GetPiece(loadTexture, 1 * w, 2 * h, w, h, _ppu);  //up              - 0001
        sprites[2] = GetPiece(loadTexture, 2 * w, 1 * h, w, h, _ppu);  //right           - 0010
        sprites[3] = GetPiece(loadTexture, 2 * w, 2 * h, w, h, _ppu);  //up-right        - 0011
        sprites[4] = GetPiece(loadTexture, 1 * w, 0 * h, w, h, _ppu);  //down            - 0100
        sprites[5] = GetPiece(loadTexture, 1 * w, 3 * h, w, h, _ppu);  //up-down         - 0101
        sprites[6] = GetPiece(loadTexture, 2 * w, 0 * h, w, h, _ppu);  //right-down      - 0110
        sprites[7] = GetPiece(loadTexture, 2 * w, 3 * h, w, h, _ppu);  //up-right-down   - 0111
        sprites[8] = GetPiece(loadTexture, 0 * w, 1 * h, w, h, _ppu);  //left            - 1000
        sprites[9] = GetPiece(loadTexture, 0 * w, 2 * h, w, h, _ppu);  //up-left         - 1001
        sprites[10] = GetPiece(loadTexture, 3 * w, 1 * h, w, h, _ppu); //right-left      - 1010
        sprites[11] = GetPiece(loadTexture, 3 * w, 2 * h, w, h, _ppu); //up-right-left   - 1011
        sprites[12] = GetPiece(loadTexture, 0 * w, 0 * h, w, h, _ppu); //down-left       - 1100
        sprites[13] = GetPiece(loadTexture, 0 * w, 3 * h, w, h, _ppu); //up-down-left    - 1101
        sprites[14] = GetPiece(loadTexture, 3 * w, 0 * h, w, h, _ppu); //right-down-left - 1110
        sprites[15] = GetPiece(loadTexture, 3 * w, 3 * h, w, h, _ppu); //all             - 1111

        return sprites;
    }

    private static Sprite GetPiece (Texture2D _texture, int _x, int _y, int _w, int _h, int _ppu)
    {
        Color[] colors = _texture.GetPixels(_x, _y, _w, _h);
        Texture2D resTex = new Texture2D(_w, _h);
        resTex.filterMode = FilterMode.Point;
        resTex.SetPixels(colors);
        resTex.Apply();

        Rect rect = new Rect(0, 0, _w, _h);
        Sprite sprite = Sprite.Create(resTex, rect, Vector2.zero, _ppu);
        return sprite;
    }
}
