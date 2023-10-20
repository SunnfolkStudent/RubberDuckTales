using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    
    [SerializeField] private string levelName;

    [SerializeField] private Animator myAnimationController;
    public string AnimationToPlay = "Transition_start";
    
    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.CompareTag("Player"))
        {
            myAnimationController.Play(AnimationToPlay);
        }
    }
}
