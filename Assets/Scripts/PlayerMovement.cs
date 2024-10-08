using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Adds audio to the player
    public AudioClip airSpin;
    public AudioClip backgroundMusic;

    public AudioSource hopSfx;
    public AudioSource playerSfx;
    public AudioSource musicPlayer;

    public float movespeed = 1f;            // Constant forward speed
    public float jumpforce = 10f;           // Jump force
    public Transform groundCheckPoint;     // A point to check if the player is grounded
    public float checkRadius = 0.2f;       // Radius of the overlap circle for ground detection
    public LayerMask groundLayer;          // Layer of the ground objects
    public float gravity = 4.5f;

    public bool doubleJump;

    private Rigidbody2D rb;                // Refrence to the Rigidbody2D component
    private bool isGrounded;               // Is the player on the ground?
    private bool startFall;

    public Animator anim;

    public bool isPlaying = true;

    //
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component attached to the player
        hopSfx = GetComponent<AudioSource>();
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        //Let the game kow its being played
        if (Input.GetKeyDown(KeyCode.Space)) {
            isPlaying = true;
        }
        //anim.SetBool("IsOnGround", isOnGround);

        // Constant forward movement
        rb.velocity = new Vector2(movespeed, rb.velocity.y);

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, checkRadius, groundLayer);

        // Jumping logic
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }

        if (isGrounded = false && Input.GetKeyDown(KeyCode.Space))
        {
            fall();        
        }

        /*
        if(Input.GetButtonUp("jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y) * (2f);
        }
        */


        if (isGrounded)
        {
            anim.SetBool("IsGrounded", true);
        }
        if (isGrounded == false)
        {
            anim.SetBool("IsGrounded", false);
        }
    }
        
    private void jump()
    {
        playerSfx.PlayOneShot(airSpin);
        // Add an upward force for jumping
        rb.velocity = new Vector2(rb.velocity.x, jumpforce);
    }

    private void fall()
    {
        // Add an upward force for jumping
        rb.gravityScale = (gravity * 10);
    }


    private void OnDrawGizmosSelected()
    {
        // Draw a circle to visualize the ground check point in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.position, checkRadius);
     }
        
    
    
    
    
}
