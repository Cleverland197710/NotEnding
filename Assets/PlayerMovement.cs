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

    public bool doubleJump;

    private Rigidbody2D rb;                // Refrence to the Rigidbody2D component
    private bool isGrounded;               // Is the player on the ground?
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component attached to the player
        hopSfx = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Constant forward movement
        rb.velocity = new Vector2(movespeed, rb.velocity.y);

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, checkRadius, groundLayer);

        // Jumping logic
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }

        if(Input.GetButtonUp("jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y) * (2f);
        }
    }
        
    private void jump()
    {
        playerSfx.PlayOneShot(airSpin);
        // Add an upward force for jumping
        rb.velocity = new Vector2(rb.velocity.x, jumpforce);
    }


    private void OnDrawGizmosSelected()
    {
        // Draw a circle to visualize the ground check point in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.position, checkRadius);
     }
        
    
    
    
    
}
