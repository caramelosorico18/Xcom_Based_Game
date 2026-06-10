using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedController : MonoBehaviour
{
    public float distToGround;
    public bool helper;
    public int layer;
    public int layerMask;
    void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y; /*Recoge distancia al suelo*/
        layer = 6; /*Gound Object -> inspector -> Layers -> Add Layer -> Layer 6 -> "Ground"*/
        layerMask = 1 << layer;

    }

    public bool IsGrounded()
    {
        Debug.DrawRay(transform.position, -Vector3.up, Color.yellow);
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f, layerMask);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsGrounded();
        helper = IsGrounded();
    }
}
