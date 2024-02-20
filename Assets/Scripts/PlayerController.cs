using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Inspector editable variables and fields.
    [SerializeField] private float _torqueAmount = 1f;
    [SerializeField] private float _boostSpeed = 30f;
    [SerializeField] private float _baseSpeed = 20f;
    [SerializeField] private ParticleSystem _finishEffect;
    [SerializeField] private AudioClip _jumpSFX;
    [SerializeField] private AudioClip _landSFX;
    [SerializeField] TextMeshProUGUI _coinCountText;
    [SerializeField] TextMeshProUGUI _livesText;

    //Gameplay private variables.
    private SurfaceEffector2D _surfaceEffector2D;
    private Rigidbody2D _rb;
    private bool _canMove = true;

    //Public variables
    static int _coinCount;

    public int lives;
    public Transform spawnPoint;

    // Sets the main variables to the initial value for the game and calls the compoonents needed.
    void Start()
    {
        _coinCount = 0;
        lives = 3;
        _rb = GetComponent<Rigidbody2D>();
        _surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
    }

    //Does every frame
    void Update()
    {
        //If the controllers are not disabled, calls Rotate and Boost functions.
        if (_canMove)
        {
        RotatePlayer();
        RespondToBoost();
        }
        
        // Shows Coin count and Lives count on the UI.
        _coinCountText.text = "Coins: " + _coinCount.ToString();
        _livesText.text = "Lives: " + lives.ToString();

    }

    // Sets bool to false, to indicate the controllers are diabled (on game over).
    public void DisableControls()
    {
        _canMove = false;
    }

    // Sets the ground speed (player movement on ground) to the base surface effector indicated speed or the speed used with the boost by pressing space bar. 
    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _surfaceEffector2D.speed = _boostSpeed;
        }
        else
        {
            _surfaceEffector2D.speed = _baseSpeed;
        }
    }

    // On A,D, Left Arrow, Right Arrow, applies torque to make the player rotate when input is pressed.
    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            _rb.AddTorque(_torqueAmount);
        }

        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            _rb.AddTorque(-_torqueAmount);
        }
    }

    // When the player is colliding with the ground (only other object with non trigger collision), plays sound clip and particle effects.
    void OnCollisionEnter2D(Collision2D other) 
    {
            _finishEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(_landSFX);
    }

    // When the player collides with coins, increases coin count.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Coin")
        {
            _coinCount += 1;           
        }
    }

    // Changes the player position and rotation to the one on the active SpawnPoint object.
    public void PlayerSpawn()
    {
        gameObject.transform.position = spawnPoint.position;
        gameObject.transform.rotation = spawnPoint.rotation;
    }

    // Sets the current SpawnPoint to serve as reference for the PlayerSpawn funciton.
    public void SetSpawnPoint(Transform newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }


}
