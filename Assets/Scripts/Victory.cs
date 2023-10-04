using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{

    [SerializeField] private Animator myAnimationController;
    
    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.CompareTag("Player"))
        {
            myAnimationController.SetBool("Win", true);
        }
    } 
}
