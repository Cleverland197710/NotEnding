using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    //Adds audio to the player
    public AudioClip jump;
    public AudioClip backgroundMusic;

    public AudioSource sfxPlayer;
    public AudioSource musicPlayer;
    
    //Create a refrence to the Rigidbody2D so we can manipulate it
    Rigidbody2D playerObject;
    public float speed = 10; 
    // Start is called before the first frame update
    void Start()
    {
        //find the Rigidbody2D component that is attached to the same object 
        playerObject = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ///Create a 'float' that will be equal to the players horizontial input
        float movementValueX = Input.GetAxis("Horizontal");

        ///Change the x velocity of the Rigidbody2D to be equal to the movement value
        playerObject.velocity = new Vector2(movementValueX*speed, playerObject.velocity.y);

        ///Create a 'float' that will be equal to the players horizontial input
        float movementValueY = Input.GetAxis("Vertical");

        ///Change the x velocity of the Rigidbody2D to be equal to the movement value
        playerObject.velocity = new Vector2(movementValueX * speed, playerObject.velocity.x);
    }
}
