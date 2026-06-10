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

        /*if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }*/
    }

    void ProcesarMovimiento()
    {
        float inputMovimientoX = Input.GetAxis("Horizontal");
        float inputMovimientoZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * inputMovimientoZ + transform.forward * inputMovimientoX;
        player.AddForce(move * speed * Time.deltaTime);
        //PyAnims.SetBool("Walking", true);
        //if(inputMovimientoX == 0 && inputMovimientoZ == 0){PyAnims.SetBool("Walking", false);}
    }
    void FixedUpdate()
    {
        if (isGrounded == false) { player.AddForce(0, gravity, 0); }

        if (Input.GetKey("d"))
        {
            player.AddForce(transform.right * speed);
            //anim.SetBool("Walking", true);
            //direction = 1;
        }
        if (Input.GetKey("s"))
        {
            player.AddForce(transform.forward * -speed);
            //direction = 2;
        }
        if (Input.GetKey("a"))
        {
            player.AddForce(transform.right * -speed);
            //anim.SetBool("Walking", true);
            //direction = 3;
        }
        if (Input.GetKey("w"))
        {
            player.AddForce(transform.forward * speed);
            //direction = 4;
        }
        if (Input.GetKey("w") && Input.GetKey("d"))
        {
            player.AddForce(transform.right * speed);
            player.AddForce(transform.forward * speed);
            //direction = 5;
        }
        if (Input.GetKey("w") && Input.GetKey("a"))
        {
            player.AddForce(transform.right * speed);
            player.AddForce(transform.forward * speed);
            //direction = 6;
        }
        if (Input.GetKey("s") && Input.GetKey("a"))
        {
            player.AddForce(transform.right * speed);
            player.AddForce(transform.forward * speed);
            //direction = 7;
        }
        if (Input.GetKey("s") && Input.GetKey("d"))
        {
            player.AddForce(transform.right * speed);
            player.AddForce(transform.forward * speed);
            //direction = 8;
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

    /*public void Shoot()
    {
        GameObject bullet = BulletPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = playerb.transform.position;
            bullet.transform.rotation = playerb.transform.rotation;
            if (Time.timeScale != 0)
            {
                bullet.SetActive(true);
            }
        }
    }*/
}
