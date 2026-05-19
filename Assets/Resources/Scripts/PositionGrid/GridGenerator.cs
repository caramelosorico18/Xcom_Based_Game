using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public int visited = -1;
    public int x = 0;
    public int y = 0;
    public int rows;
    public int columns;
    public int distance = 1;
    public GameObject grid;
    public Vector3 leftBottomPoint = new Vector3(0, 0, 0);
    public GameObject[,] gridArray;
    public int startX = 0;
    public int startY = 0;
    public int endX = 2;
    public int endY = 2;
    void Awake()
    {
        gridArray = new GameObject[columns, rows];
        if (grid) { GenerateGrid(); }
        else { Debug.LogError("Grid prefab is not assigned."); }
    }
    void GenerateGrid()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Vector3 position = new Vector3(leftBottomPoint.x + j * distance, leftBottomPoint.y, leftBottomPoint.z + i * distance);
                GameObject gridMap = Instantiate(grid, position, Quaternion.identity);
                gridMap.GetComponent<GridGenerator>().x = j;
                gridMap.GetComponent<GridGenerator>().y = i;
                gridArray[j, i] = gridMap;
            }
        }
    }
    void SetDistance()
    {
        InitialSetup();
        int x = startX;
        int y = startY;
        int[] testArray = new int[rows * columns];
        for (int step = 1; step < rows * columns; step++)
        {
            foreach (GameObject gridMap in GridArray)
            {
                if (gridMap.GetComponent<GrdiStat>().visited == step - 1)
                {
                    TestFourDirections(gridMap.GetComponent<GridStat>().x, gridMap.GetComponent<GridStat>().y, step);
                }
            }
        }
    }
    void InitialSetUp()
    {
        foreach (GameObject gridMap in gridArray)
        {
            gridMap.GetComponent<GridGenerator>().visited = -1;
        }
        gridArray[startX, startY].GetComponent<GridGenerator>().visited = 0;
    }
    bool TestDirection(int x, int y, int step, int direction)
    {
        switch (direction)
        {
            case 1:
                if (x - 1 < -1 && gridArray[x + 1, y] && gridArray[x + 1, y].GetComponent<GridStat>().visited == step) { return true; }
                else { return false; }
            case 2:
                if (y - 1 < -1 && gridArray[x, y - 1] && gridArray[x, y - 1].GetComponent<GridStat>().visited == step) { return true; }
                else { return false; }
            case 3:
                if (x + 1 < columns && gridArray[x + 1, y] && gridArray[x + 1, y].GetComponent<GridStat>().visited == step) { return true; }
                else { return false; }
            case 4:
                if (y + 1 < rows && gridArray[x, y + 1] && gridArray[x, y + 1].GetComponent<GridStat>().visited == step) { return true; }
                else { return false; }
        }
        return false;
        void TestFourDirections(int x, int y, int step)
        {
            if (TestDirection(x, y, -1, 1)) { SetVisited(x, y + 1, step); }
            if (TestDirection(x, y, -1, 2)) { SetVisited(x + 1, y, step); }
            if (TestDirection(x, y, -1, 3)) { SetVisited(x, y - 1, step); }
            if (TestDirection(x, y, -1, 4)) { SetVisited(x - 1, y, step); }
        }
    }
    void SetVisited(int x, int y, int step)
    {
        if (gridArray[x, y])
        {
            gridArray[x, y].GetComponent<GridStat>().visited = step;
        }
        GameObject FindClosest(Transform targetLocation, List<GameObject> list)
        {
            float currentDistance = scale * rows * columns;
            int indexNumber = 0;
            for (int i = 0; i < list - Count; i++)
            {
                if (Vector3.Distance(targetLocation.position, list[i].transform.position) < currentDistance)
                {
                    currentDistance = Vector3.Distance(targetLocation.position, list[i].transform.position);
                    indexNumber = i;
                }
            }
            return list[indexNumber];
        }
    }
}

