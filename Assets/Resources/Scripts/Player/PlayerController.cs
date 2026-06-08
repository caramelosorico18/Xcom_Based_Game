using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerb;
    public float inputMovimiento; /*Registra inputs*/
    public float speedRun;
    public bool IsGrounded;
    public float speedJump;
    public float Health;
    public float damage;
    public GroundedController gc;
    public PlayerStats playerStats;
    public Animator anim;
    public int velocity;

    void Start()
    {
        playerb = GetComponent<Rigidbody2D>();
        Health = playerStats.MaxHealth;
        speedRun = playerStats.SpeedRun;
        speedJump = playerStats.SpeedJump;
        damage = playerStats.Damage;
        velocity = 2;
    }

    void Update()
    {
        IsGrounded = gc.IsGrounded1() || gc.IsGrounded2();
        ProcesarMovimiento();
        if (Health <= 0)
        {
            Die();
        }
        if (Input.GetMouseButtonDown(0))
        {
            //Shoot();
        }


    }
    void ProcesarMovimiento()
    {
        inputMovimiento = Input.GetAxis("Horizontal");
        playerb.velocity = new Vector2(inputMovimiento * speedRun, playerb.velocity.y);
        anim.SetBool("Walking", true);
        if (inputMovimiento < 0)
        {
            //anim.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            //anim.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (inputMovimiento == 0) { anim.SetBool("Walking", false); }
    }

    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            playerb.AddForce(transform.right * speedRun);
            //anim.SetBool("Walking", true);
            velocity = 1;
        }
        else if (Input.GetKey("a"))
        {
            playerb.AddForce(transform.right * -speedRun);
            //anim.SetBool("Walking", true);
            velocity = 0;
        }
        if (Input.GetKey("w"))
        {
            velocity = 2;
        }
        if (Input.GetKey("w") && Input.GetKey("d"))
        {
            velocity = 3;
        }
        if (Input.GetKey("w") && Input.GetKey("a"))
        {
            velocity = 4;
        }
        if (Input.GetKey("s") && Input.GetKey("a"))
        {
            velocity = 5;
        }
        if (Input.GetKey("s") && Input.GetKey("d"))
        {
            velocity = 6;
        }
        if (Input.GetKey("space") && gc.IsGrounded1())
        {
            playerb.AddForce(transform.up * speedJump);
        }
        if (Input.GetKey("space") && gc.IsGrounded2())
        {
            playerb.AddForce(transform.up * speedJump);
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

