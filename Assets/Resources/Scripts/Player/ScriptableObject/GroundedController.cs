using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedController : MonoBehaviour
{
    public float distToGround;
    public bool helper1;
    public int layer1;
    public int layerMask1;
    public bool helper2;
    public int layer2;
    public int layerMask2;
    void Start()
    {
        distToGround = GetComponent<Collider2D>().bounds.extents.y; /*Recoge distancia al suelo*/
        layer1 = 6; /*Gound Object -> inspector -> Layers -> Add Layer -> Layer 6 -> "Ground"*/
        layerMask1 = 1 << layer1;
        layer2 = 9; /*Gound Object -> inspector -> Layers -> Add Layer -> Layer 6 -> "Ground"*/
        layerMask2 = 1 << layer2;
    }

    public bool IsGrounded1()
    {
        Debug.DrawRay(transform.position, -Vector3.up, Color.yellow);
        return Physics2D.Raycast(transform.position, -Vector3.up, distToGround + 0.1f, layerMask1);
    }

    public bool IsGrounded2()
    {
        Debug.DrawRay(transform.position, -Vector3.up, Color.yellow);
        return Physics2D.Raycast(transform.position, -Vector3.up, distToGround + 0.1f, layerMask2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsGrounded1();
        helper1 = IsGrounded1();
        IsGrounded2();
        helper2 = IsGrounded2();
    }
}
