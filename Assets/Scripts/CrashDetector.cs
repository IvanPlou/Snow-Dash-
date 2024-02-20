using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    // Inspector editable variables and fields.
    [SerializeField] private float _gameOverDelay = 1f;
    [SerializeField] private ParticleSystem _crashEffect;
    [SerializeField] private AudioClip _crashSFX;

    // To be abple to call the Player Spawn function from PlayerController.
    PlayerController player;

    // Calls the PlayerComponent object at the start of the game.
    private void Start()
    {
        player = GetComponent<PlayerController>();
    }


    // When the player collides with the ground, checks the PlayerController public live count to call the Respawn Function or Load GameOver Scene from the Scene Manager.
    void OnTriggerEnter2D(Collider2D other)
   {
        if (other.tag == "Ground" )
        {
            if (player.lives > 0)
            {
                _crashEffect.Play();
                player.lives --;
                player.PlayerSpawn();
                
            }
            else if (player.lives <= 0 )
            {
                FindAnyObjectByType<PlayerController>().DisableControls();
                _crashEffect.Play();
                GetComponent<AudioSource>().PlayOneShot(_crashSFX);
                Invoke("ReloadScene", _gameOverDelay);
            }

        }
    }
     private void ReloadScene()
    {
        SceneManager.LoadScene(3);      
    }

    
}
