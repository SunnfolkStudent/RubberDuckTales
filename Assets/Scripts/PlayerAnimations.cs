using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _anim;
    private SpriteRenderer _renderer;
    private PlayerMovement _pMove;

    void Start()
    {
        _anim = transform.parent.GetComponentInChildren<Animator>();
        _renderer = GetComponentInChildren<SpriteRenderer>();

        _pMove = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (!_pMove.IsPlayerGrounded())
        {
            _anim.Play("player_swim_forward");
        }
        else if (_pMove.IsPlayerGrounded() &&
                 (_pMove._rigidbody2D.velocity.x > 1 || _pMove._rigidbody2D.velocity.x < -1))
        {
            _anim.Play("player_walk_forward");
        }
        else
        {
            _anim.Play("player_lay_idle_1_forward");
        }
        
        if (_pMove._input.lift != 0)
        { return; }

        if (_pMove._rigidbody2D.velocity.x < -1)
        {
            _renderer.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (_pMove._rigidbody2D.velocity.x > 1)
        {
            //_renderer.flipX = false;
            _renderer.transform.rotation = Quaternion.Euler(0, 0, 0);
        } 
    }
}
    
