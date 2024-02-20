using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    // Particle effect to be played when the player collides with this object's trigger box.
    [SerializeField] private ParticleSystem _checkpointEffect;
    // When the player collides with this, plays particle effect, sound effect and changes the Spawn Point to respawn to this objects transform position.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Player"))
        {
            _checkpointEffect.Play();
            GetComponent<AudioSource>().Play();
            other.GetComponent<PlayerController>().SetSpawnPoint(this.gameObject.transform);
        }

    }

}
