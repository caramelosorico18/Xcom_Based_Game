/*Blibliotecas importadas de unity, estas tres vienen por defecto*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

/*Esta linea hace que funciones todo el script, todo debe estas dentro de sus llaves*/
{
    public Rigidbody2D player;
    public float inputMovimientoH; /*Registra inputs*/
    public float inputMovimientoV;

    public float speed;
    public float jumpHeight;
    public float health;
    public float gravity = -19f;
    public GroundedController groundCheck;
    public bool isGrounded;
    public float groundDistance;
    public LayerMask groundMask;
    public enum direction;
    public PlayerStats playerStats;
    public Animator PyAnims;
    Vector3 velocity;
    bool isMoving;
    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);
    
    public enum direction{none, w, d, s, a, wd, Wa, sd, sa}
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        health = playerStats.MaxHealth;
        speed = playerStats.SpeedRun;
        jumpHeight = playerStats.SpeedJump;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        ProcesarMovimiento();
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        

        Vector3 move = transform.right * x + transform.forward * y;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //Falling
        velocity.y = gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        if(lastPosition != gameObject.transform.position && isGrounded == true)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    void ProcesarMovimiento()
    {
        float inputMovimientoH = Input.GetAxis("Horizontal");
        float inputMovimientoV = Input.GetAxis("Vertical");
        player.velocity = new Vector3(inputMovimientoH, inputMovimientoV, player.velocity.y);
        //PyAnims.SetBool("Walking", true);
        //if(inputMovimientoH == 0 && inputMovimientoV == 0){PyAnims.SetBool("Walking", false);}
    }
    void FixedUpdate()
    {
        switch (Input.GetKey)
        {
            //Cambiar(enum direction)*
            case input.GetKey("w"):
            PyAnims.SetBool("WalkingFw", true);
            direction = 1;

            case input.GetKey("d"):
            PyAnims.SetBool("WalkingRg", true);
            direction = 2;

             case input.GetKey("s"):
            PyAnims.SetBool("WalkingBw", true);
            direction = 3;

            case input.GetKey("a"):
            PyAnims.SetBool("WalkingLf", true);
            direction = 4;

            case input.GetKey("w"):
            PyAnims.SetBool("WalkingFw", true);
            direction = 1;
        }
        switch (direction)
        {
            case direction == 1:

        }
    }
}
