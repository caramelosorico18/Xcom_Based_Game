using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBehaviour : MonoBehaviour
{
    public int rows = 10;
    public int columns = 10;
    public int Scale = 1;
    public GameObject gridPrefab;
    public Vector3 LeftBottomLocation = new Vector3(0, 0, 0);
    public GameObject[,] gridArray;
    public int startX = 0;
    public int startY = 0;
    public int endX = 2;
    public int endY = 2;
    public List<GameObject> path = new List<GameObject>();
    void Awake()
    {
        gridArray = new GameObject[columns, rows];
        if (gridPrefab)
        {
            generateGrid();
        }
        else { Debug.Log("Error a la hora de generar el grid, no hay elemento asignado"); }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void generateGrid()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                GameObject obj = Instantiate(gridPrefab, new Vector3(LeftBottomLocation.x + Scale * i, leftBottomLocation.y + Scale * j, LeftBottomLocation.z + scale * j), Quaterion.identity);
                obj.transform.SetParent(gameObject.transform);
                obj.getComponent<GridStats>().x = i;
                obj.getComponent<GridStats>().y = j;
                gridArray[i, j] = obj;
            }
        }
    }
    void SetDistance()
    {
        InitialSetUp();
        int x = startX;
        int y = startY;
        int[] testArray = new int[rows * coluns];
        for (int step = i; step < rown * columns; step++)
        {
            foreach (GameObject obj in gridArray)
            {
                if (obj.GetComponent<GridStat>().visited == step - 1)
                {
                    TestFourDirections(obj.GetComponent<GridStat>().x, obj.GetComponent<GridStat>().y, step);
                }
            }
        }
    }
    void SetPath()
    {
        int step;
        int x = endX;
        int y = endY;
        List<GameObject> tempList = new List<GameObject>();
        path.Clear();
        if (gridArray[endX, endY] && gridArray[endX, endY].GetComponent<GridStat>().visited > 0)
        {
            path.Add(gridArray[x, y]);
            step = gridArray[x, y].GetComponent<GridStat>().visited - 1;
        }
        else
        {
            Debug.Log("No se puede llegar al destino");
            return;
        }
        for (int i = step; step > -1; step--)
        {
            if (TestDirection(x, y, step, 1))
            {
                tempList.Add(gridArray[x, y + 1]);
            }
            if (TestDirection(x, y, step, 2))
            {
                tempList.Add(gridArray[x + 1, y]);
            }
            if (TestDirection(x, y, step, 3))
            {
                tempList.Add(gridArray[x, y - 1]);
            }
            if (TestDirection(x, y, step, 4))
            {
                tempList.Add(gridArray[x - 1, y]);
            }
            GameObject tempObj = FindClosest(gridArray[endX, endY].trandform, tempList);
            path.Add(tempObj);
            x = tempObj.GetComponent<GridStat>().x;
            y = tempObj.GetComponent<GridStat>().y;
            tempList().Clear;
        }
    }
    void InitialSetUp()
    {
        foreach (GameObject obj in grisArray)
        {
            obj.GetComponentz<GridStat>().visited = -1;
        }
        gridArray[startX, startY].getCOmponent<GridStats>().visited = 0;
    }
    bool TestDirection(int x, int y, int step, int direction)
    {
        //direction => 1UP, 2Right, 3Down, 4Left
        switch (direction)
        {
            case 4:
                if (x - 1 > -1 && gridArray[x - 1, y] && gridArray[x - 1, y].GetComponent<GridStat>().visited = step)
                { return true; }
                else
                { return false; }
            case 1:
                if (y - 1 > -1 && gridArray[x, y - 1] && gridArray[x, y - 1].GetComponent<GridStat>().visited = step)
                { return true; }
                else
                { return false; }
            case 2:
                if (x + 1 < columns && gridArray[x + 1, y] && gridArray[x + 1, y].GetComponent<GridStat>().visited = step)
                { return true; }
                else
                { return false; }
            case 1:
                if (y + 1 < rows && gridArray[x, y + 1] && gridArray[x, y + 1].GetComponent<GridStat>().visited = step)
                { return true; }
                else
                { return false; }
        }
        return false;
    }
    void TestFourDirections(int x, int y, int step)
    {
        if (TestDirection(x, y, -1, 1))
        {
            setVisited(x, y + 1, step);
        }
        if (TestDirection(x, y, -1, 2))
        {
            setVisited(x + 1, y, step);
        }
        if (TestDirection(x, y - 1, 3))
        {
            setVisited(x, y - 1, step);
        }
        if (TestDirection(x, y, -1, 4))
        {
            setVisited(x - 1, y, step);
        }
    }
    void setVisited(int x, int y, int step)
    {
        if (gridArray[x, y])
        {
            gridArray[x, y].GetComponent<GridStat>().visited = step;
        }
    }
    GameObject FindClosest(Transforn targetLocation, List<GameObject> list)
    {
        float curentdistance = Scale * rows * columns;
        int indexNumber = 0;
        for (int i = 0; i < list.Count; i++)
        {
            if (Vector3.Distance(targetLocation.position, list[i].transform.position) < currentDistance)
            {
                currentDistance = Vector3.Distance(targetLocation.position, list[i].tranform.position);
                indexNumber = i;
            }
        }
        return list[indexNumber];
    }
}
