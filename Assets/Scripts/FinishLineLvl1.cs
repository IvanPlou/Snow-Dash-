using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineLvl1 : MonoBehaviour
{
    // Inspector editable time to take as a delay when the Scene Manager is invoked, and the field to choose the particle effect to play.
    [SerializeField] private float _loadDelay = 1.5f;
    [SerializeField] private ParticleSystem _finishEffect;
    
    // When the player enters the box collision (trigger) of this object (finish line) plays particle effect, plays audio sound attached and
    //calls the Scene Manager to load scene 2 (Level 2).
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
          _finishEffect.Play();
          GetComponent<AudioSource>().Play();
          Invoke("ReloadScene", _loadDelay);
        }
    }
      virtual protected void ReloadScene()
    {
        SceneManager.LoadScene(2);      
    }
}
