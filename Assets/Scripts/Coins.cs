using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    // Selectable audio clip in the inspector to play when the coin is picked (collides with the player).
    [SerializeField] private AudioClip _pickupSFX;
    protected bool wasCollected = false;

    // When the player collides with the coin (this), plays audio clip, sets the object to invisible and destroys it.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            AudioSource.PlayClipAtPoint(_pickupSFX, Camera.main.transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
