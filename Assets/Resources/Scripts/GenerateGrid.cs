using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GenarateGrid : MonoBehaviour {
    public float x;
    public float y;
    public float z;
    public float width;
    public float height;
    public float depth;
    private Vector3 coordinate;
    private Vector3 size;
    public GameObject Node;
    public int ncols;
    public int nrows;
    void Awake(){
        coordinate = new Vector3(x, y, z);
        size = new Vector3(width, height, depth);
        
        CreateGrid();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
        }
        if (Input.GetMouseButtonDown(1))
        {
            
        }
    }
    public void CreateGrid()
    {

        for (float i = 1; i < ncols; i++)
        {
            for(float j = 1; j < nrows; j++)
            {
                size = new Vector3(1, 1, 1);
                coordinate = new Vector3(i, coordinate.y, j);
                Instantiate(Node, new Vector3(i, coordinate.y, j), Quaternion.identity);
                Debug.Log("X: " + coordinate.x + "Y: " + coordinate.y + "Z: " + coordinate.z);
            }
        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(coordinate.x, coordinate.y, coordinate.z));

    }
}
