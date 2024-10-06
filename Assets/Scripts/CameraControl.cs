using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Create a public refrence to the player - we will asign this using the unity editor
    public GameObject player;

    void Update()
    {
        // Change our position relative to the players positon
        transform.position = new Vector3(player.transform.position.x + 7, transform.position.y, transform.position.z);

    }
}
