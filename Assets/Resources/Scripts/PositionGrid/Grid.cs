using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid {
   private int width;
   private int height;
   private int depth;
   private int[,,] gridArray;
   private TextMesh[,] debugTextArray;
   private float cellSize;
   private Vector3 originPosition;
    public Grid(int width, int height, int depth, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.depth = depth;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new int[width, height, depth];
        debugTextArray = new TextMesh[width, depth];
        //Debug.Log("Width: " + width + "Height: " + height);

        for (int x = 0; x<gridArray.GetLength(0); x++)
        {
            for(int z=0; z<gridArray.GetLength(2); z++)
            {
                gridArray[x, 0, z] = 0;
                debugTextArray[x, z] = UtilsClass.CreateWorldText(gridArray[x, 0, z].ToString(), null, GetWorldPosition(x, z) + new Vector3(cellSize, 0, cellSize) * 0.5f, 20, Color.white, TextAnchor.MiddleCenter);
                debugTextArray[x, z].transform.rotation = Quaternion.Euler(90, 0, 0);
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x + 1, z), Color.white, 100f);
                Debug.Log("X: " + x + "Z: " + z);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, depth), GetWorldPosition(width, depth), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, depth), Color.white, 100f);
        SetValue(2, 1, 56);
    }
    private Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 1, z) * cellSize + originPosition;
    }
    private void GetXZ(Vector3 worldPosition, out int x, out int z)
    {
        x = Mathf.FloorToInt((worldPosition.x - originPosition.x) / cellSize);
        z = Mathf.FloorToInt((worldPosition.z - originPosition.z) / cellSize);
    }

    public void SetValue(int x, int z, int value)
    {
        if(x>= 0 && z >= 0 && x < width && z < depth)
        {
            gridArray[x, 0, z] = value;
            debugTextArray[x, z].text = gridArray[x, 0, z].ToString();
            debugTextArray[x, z].transform.rotation = Quaternion.Euler(90, 0, 0);
        }
    }
    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, z;
        GetXZ(worldPosition, out x, out z);
        SetValue(x, z, value);
    }
    public int GetValue(int x, int z)
    {
        if (x >= 0 && z >= 0 && x < width && z < depth)
        {
            return gridArray[x, 0, z];
        }
        else
        {
            return 0;
        }
    }
    public int GetValue(Vector3 worldPosition)
    {
        int x, z;
        GetXZ(worldPosition, out x, out z);
        return GetValue(x, z);
    }
}
