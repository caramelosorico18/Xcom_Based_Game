/*Blibliotecas importadas de unity, estas tres vienen por defecto*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

/*Esta linea hace que funciones todo el script, todo debe estas dentro de sus llaves*/
{
    public Vector3 mousePos = Input.mousePosition;
    private Vector3 lastPosition;
    public float speed = 4f;
    public Vector3 pos;
    private Rigidbody player; /*Cuerpo rigido que permite moverse*/
    private Vector3 moveInput;
    void Start()
    {
        player = GetComponent<Rigidbody>(); /*El objeto se establece a si mismo como el player*/
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector3(mousePos.x, 0, mousePos.z);
        if (Input.GetButton("2"))
        {
            pos = Input.mousePosition;
            pos.z = 45;
            pos = Camera.main.ScreenToWorldPoint(pos);
        }
        transform.position = Vector3.Lerp(transform.moveInput, pos, speed * Time.deltaTime);


    }
    private void FixedUpdate()
    {
        player.MovePosition(player.position + moveInput.normalized * speed * Time.fixedDeltaTime);
    }
}
