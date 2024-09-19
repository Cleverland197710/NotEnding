using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    GameObject player; //Refrence to the player so we can track it's position
    Renderer rend; //Refrence to the Renderer so we can modify it's texture

    float playerStartPos; //Float used to track the starting position of the player
    public float speed = 0.5f; //How fast should we scroll? we change this for each layer
    
    void Start()
    {
        player = GameObject.Find("player"); //Find the player
        rend = GetComponent<Renderer>(); //Find renderer
        playerStartPos = player.transform.position.x; //Save our starting position
    }

    void Update()
    {
        float offset = (player.transform.position.x - playerStartPos) * speed;
        //^^^^^^^^^^^^^^^^^^^This line finds out much to offset the texture by.
        //We do this by subtracting our starting X position from our current X position
        //We then multiply the offset by the speed, so that we can have diffrent layers
        //moving at diffrent speeds

        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0f));
        //^^^^^^^^^^^^^^^^^^^This line sets our textures 'offset'. We use the
        //SetTextureOffset method to do this, which takes 2 parameters.
        //The first parameter is a string that refers to the texture we want to modify
        //The second parameter is a vector2, with the first (X) varible shifting the texture
        //left and right, and the second (Y) varible shifting the texture up and down
    }
}
