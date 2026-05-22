using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid {
   private int width;
   private int height;
   private int depth;
   private int[,,] gridArray;
   private float cellSize;
   public Grid(int width, int height, int depth, float cellSize)
    {
        this.width = width;
        this.depth = depth;
        this.height = height;
        this.cellSize = cellSize;
        gridArray = new int[width, height, depth];
        //Debug.Log("Width: " + width + "Height: " + height);
        for(int x = 0; x<gridArray.GetLength(0); x++)
        {
            for(int z=0; z<gridArray.GetLength(2); z++)
            {
                gridArray[x, 0, z] = 0;
                UtilsClass.CreateWorldText(gridArray[x, 0, z].ToString(), null, GetWorldPosition(x, z), 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x + 1, z), Color.white, 100f);
                Debug.Log("X: " + x + "Z: " + z);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, depth), GetWorldPosition(width, depth), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, depth), Color.white, 100f);
    }
    private Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 1, z) * cellSize;
    }
}
