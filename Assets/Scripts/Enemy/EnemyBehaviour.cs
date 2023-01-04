using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    public AudioClip clip;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the other object is the projectile by its tag
        if (collision.tag == "Laser")
        {
            print("I'm Hit");

            ScoreCounter.instance.PointAddition(); //I add a point when an enemy is hitted.

            // Allows playing an audio clip even if the Alien is destroyed and removed from the scene
            AudioSource.PlayClipAtPoint(clip, Vector2.zero);

            // Destroy the Alien game object (the one this script is on)
            Destroy(gameObject);

            // Destroy the projectile game object
            Destroy(collision.gameObject);
        }
    }

}
