/*Blibliotecas importadas de unity, estas tres vienen por defecto*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

/*Esta linea hace que funciones todo el script, todo debe estas dentro de sus llaves*/
{
    public Rigidbody player;
    public PlayerStats playerStats;
    public float inputMovimientoX; /*Registra inputs*/
    public float inputMovimientoZ;
    public float speed;
    public float jumpHeight;
    public float health;
    public float gravity = -190f;
    public LayerMask groundMask;
    public GroundedController groundCheck;
    public MouseController mouseController;

    public string direction;
    private bool isGrounded;
    public float groundDistance;
    //public PlayerStats playerStats;
    //public Animator PyAnims;
    private Vector3 velocity;
    private bool isMoving;
    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);
    void Start()
    {
        player = GetComponent<Rigidbody>();
        health = playerStats.MaxHealth;
        speed = playerStats.SpeedRun;
        jumpHeight = playerStats.SpeedJump;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = groundCheck.IsGrounded();
        ProcesarMovimiento();
        if (health <= 0)
        {
            Die();
        }
    }

    void ProcesarMovimiento()
    {
        float inputMovimientoX = Input.GetAxis("Horizontal");
        float inputMovimientoZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * inputMovimientoZ + transform.forward * inputMovimientoX;
        player.AddForce(move * speed * Time.deltaTime);

        player.transform.localRotation = mouseController.currentRotation;
    }
    void FixedUpdate()
    {
        if (isGrounded == false) { player.AddForce(0, gravity, 0); }

        if (Input.GetKey("d"))
        {
            player.AddForce(transform.right * speed);
        }
        if (Input.GetKey("s"))
        {
            player.AddForce(transform.forward * -speed);
        }
        if (Input.GetKey("a"))
        {
            player.AddForce(transform.right * -speed);
        }
        if (Input.GetKey("w"))
        {
            player.AddForce(transform.forward * speed);
        }
        if (Input.GetKey("w") && Input.GetKey("d"))
        {
            player.AddForce(transform.right * speed);
            player.AddForce(transform.forward * speed);
        }
        if (Input.GetKey("w") && Input.GetKey("a"))
        {
            player.AddForce(transform.right * speed);
            player.AddForce(transform.forward * speed);
        }
        if (Input.GetKey("s") && Input.GetKey("a"))
        {
            player.AddForce(transform.right * speed);
            player.AddForce(transform.forward * speed);
        }
        if (Input.GetKey("s") && Input.GetKey("d"))
        {
            player.AddForce(transform.right * speed);
            player.AddForce(transform.forward * speed);
        }
        if (Input.GetKey("space") && isGrounded == true)
        {
            player.AddForce(transform.up * jumpHeight);
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
        Debug.Log("Sa Murío");
    }
}
