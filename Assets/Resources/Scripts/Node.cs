using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool walkable;
    public Vector3 WorldPosition;
    public int gridX;
    public int gridY;
    public int gCost;
    public int hCost;
    public Node(bool _walkable, Vector3 _worldPos)
    {
        walkable = _walkable;
        WorldPosition = _worldPos;
        gridX = _gridX;
        gridY = _gridY;
    }
    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }
}
