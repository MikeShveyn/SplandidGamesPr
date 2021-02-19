using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Configurations
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private float climbSpeed = 5f;
    [SerializeField] private Vector2 deathKick = new Vector2(20f, 20f);
    //Stats
    private bool isAlive = true;
    
    //Cached Components
    private Animator anim;
    private Rigidbody2D rigit;
    private CapsuleCollider2D bodyColider;
    private BoxCollider2D feetColider;
    private float gravityScaleStart;
    
   // private Vector2 standartGravity = new Vector2(0, -100); gravity to all game world
   
   
    // Start is called before the first frame update
    void Start()
    {
        //Physics materials with friction and bounciness helps to add different effects
        //Current set not allow wall double jumping
        //Use camera noise to shake scene
        
        anim = GetComponent<Animator>();
        rigit = GetComponent<Rigidbody2D>();
        bodyColider = GetComponent<CapsuleCollider2D>();
        feetColider = GetComponent<BoxCollider2D>();
        gravityScaleStart = rigit.gravityScale;

        // Physics2D.gravity = standartGravity; gravity to all game worlds
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            Movement();
            FlipSprite();
            Jump();
            ClimbLadder();
            Die();
        }

    }

    private void Movement()
    {
        float xAxes = Input.GetAxis("Horizontal") * speed;
        Vector2 velocity = new Vector2(xAxes, rigit.velocity.y);
        rigit.velocity = velocity;
        
        bool playerHasHorSpeed = Mathf.Abs(rigit.velocity.x) > Mathf.Epsilon;
        anim.SetBool("Running", playerHasHorSpeed);
        
    }

    private void FlipSprite()
    {
        bool playerHasHorSpeed = Mathf.Abs(rigit.velocity.x) > Mathf.Epsilon;// player is moving
        if (playerHasHorSpeed)
        {
             transform.localScale = new Vector2(Mathf.Sign(rigit.velocity.x), 1f);
             
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && feetColider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            rigit.velocity += jumpVelocity;
            
        }

      
    }

    private void ClimbLadder()
    {
        if (feetColider.IsTouchingLayers(LayerMask.GetMask("Climb")))
        {
            float control = Input.GetAxis("Vertical");
            Vector2 climbVelocity = new Vector2(rigit.velocity.x, control * climbSpeed);
            rigit.velocity = climbVelocity;

            bool playerHasVertSpeed = Mathf.Abs(rigit.velocity.y) > Mathf.Epsilon;
            anim.SetBool("Climbing", playerHasVertSpeed);
            rigit.gravityScale = 0;
        }
        else
        {
            anim.SetBool("Climbing", false);
            rigit.gravityScale = gravityScaleStart;
        }
        
        
    }


    void Die()
    {
        if (bodyColider.IsTouchingLayers(LayerMask.GetMask("Enemy","Hazard")))
        {
            isAlive = false;
            anim.SetBool("isDead", true);
            GetComponent<Rigidbody2D>().velocity = deathKick;
            FindObjectOfType<GameManager>().PlayerDeath(); // change to events  !!!!

        }
    }
}
