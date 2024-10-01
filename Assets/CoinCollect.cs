using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the object is colliding with the coin is the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Add any score incrementing logic here, e.g.:
            // ScoreManager.instance.AddScore(1);

            // Destroy the coin when it hits the player
            Destroy(gameObject);
        }
    }
}
