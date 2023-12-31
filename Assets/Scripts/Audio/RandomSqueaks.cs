using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSqueaks : MonoBehaviour
{

    public AudioClip[] squeaks;
    public AudioSource source;
    public PlayerMovement playerMovement;
    private float timer;
    [Range(0.1f, 0.5f)] 
    public float volumeChangeMultiplier = 0.2f;
    /* public float pitchChangeMultiplier = 0.2f; */

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (squeaks == null) return;

            if (playerMovement.IsPlayerGrounded() && playerMovement._rigidbody2D.velocity.y < -1f)
            {
                source.clip = squeaks[Random.Range(0, squeaks.Length)];
                
                source.PlayOneShot(source.clip);
                
                timer = 1f;
            }
            /* source.volume = Random.Range(1 - volumeChangeMultiplier, 1); */
            /* source.pitch = Random.Range(1 - pitchChangeMultiplier, 1+pitchChangeMultiplier); */
        }
    }

   /* public void RandomSqueak()
    {
        source.clip = squeaks[Random.Range(0, squeaks.Length)];
        source.volume = Random.Range(1 - volumeChangeMultiplier, 1); 
        source.pitch = Random.Range(1 - pitchChangeMultiplier, 1+pitchChangeMultiplier);
        source.PlayOneShot(source.clip); */
   

    /* private void Start()
    {
        Squeaks = GetComponent<AudioSource>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Squeaks()
    {
        AudioClip clip = squeaks[UnityEngine.Random.Range(0, squeaks.Length)];
        AllSqueaks.PlayOneShot(clip);
    } */
    }
