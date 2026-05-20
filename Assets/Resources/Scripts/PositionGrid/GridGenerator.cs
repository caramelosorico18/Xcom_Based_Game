using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public int rows;
    public int columns;
    public int distance;
    public GameObject gridPoint;
    public Vector3 leftBottomLocation = new Vector3(0, 0, 0);
    void Awake()
    {
       GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateGrid()
    {
        for(int i = 0; i < columns; i++)
        {
            for(int j = 0; j < rows; j++)
            {
                GameObject obj = Instantiate(gridPoint, new Vector3 (leftBottomLocation.x + distance*i, leftBottomLocation.y + distance, leftBottomLocation.z + distance * j), Quaternion.identity);
                obj.transform.SetParent(gameObject.transform);
            }
        }
    }
}
