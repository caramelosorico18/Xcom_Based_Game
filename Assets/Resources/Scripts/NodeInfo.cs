using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInfo
{
    public Vector3 WorldPosition;
    public bool walkable;
    public NodeInfo(bool _walkable, Vector3 _worldPos)
    {
        walkable = _walkable;
        WorldPosition = _worldPos;
    }
}
