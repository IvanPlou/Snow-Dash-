using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    //Field to select the desired particle system in the inspector.
    [SerializeField] ParticleSystem _dustParticles;
    
   //Checks if the object that has this script attached collides with the ground
   //to play the selected particle system when that happens.
    void OnCollisionEnter2D(Collision2D other) 
    {
       if (other.gameObject.tag == "Ground")
       {
          _dustParticles.Play();
       } 
    }

    //Stops playing the partycle system when the collision ends.
    void OnCollisionExit2D(Collision2D other) 
    {
       if (other.gameObject.tag == "Ground")
       {
        _dustParticles.Stop();
       } 
    }
}
