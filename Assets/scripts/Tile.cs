using UnityEngine;
using System.Collections;
using NUnit.Framework;

[System.Serializable]
public class TileData
{
    public Vector3 worldPosition;
    public Vector3Int cellPosition;
    public int gridX;
    public int gridY;

    public TileData parent;
    public bool building;
    public bool road;
    public TileData( Vector3 _worldPos, int _gridX, int _gridY, Vector3Int _cellPos, bool _building, bool _road)
    {
        worldPosition = _worldPos;
        gridX = _gridX;
        gridY = _gridY;
        cellPosition = _cellPos;
        building = _building;
        road = _road;
    }
}