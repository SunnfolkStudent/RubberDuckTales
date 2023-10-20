using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SqueakNPC : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;

    private void Start()
    {
    }
    
    // Start is called before the first frame update
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(audioClip);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
