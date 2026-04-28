/*Blibliotecas importadas de unity, estas tres vienen por defecto*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

/*Esta linea hace que funciones todo el script, todo debe estas dentro de sus llaves*/
{
    private Vector3 lastPosition;
    private Rigidbody player;
    public float speedRun = 4f;
    private Vector3 moveInput;
    void Start()
    {

        player = GetComponent<Rigidbody>(); /*El objeto se establece a si mismo como el player*/
    }

    // Update is called once per frame
    void Update()
    {
        lastPosition = new Vector3(player.position.x, player.position.y, player.position.z);
        Vector3 mousePos = Input.mousePosition;
        moveInput = new Vector3(mousePos.x, 0, mousePos.z);


        if (Input.GetMouseButtonDown(2))
        {
            player.velocity = new Vector3((lastPosition.x + moveInput.x) * speedRun, 0, (lastPosition.z + moveInput.z) * speedRun);
        }
        if (player.position == moveInput)
        {
            player.velocity = new Vector3(0, 0, 0);
        }
    }
    private void FixedUpdate()
    {
        player.MovePosition(player.position + moveInput.normalized * speedRun * Time.fixedDeltaTime);
    }
}
