using System;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.HID;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Player;
    public GameObject BrushRaycaster;
    
    [Header("Movement")]
    public float moveSpeed = 5f;
    private Vector2 _desiredVelocity;

    [Header("CoyoteTime")] 
    public float coyoteTime = 0.2f;
    public float coyoteTimeCounter;
    
    [Header("Acceleration")] 
    public float accelerationTime = 0.10f;
    public float groundFriction = 0.01f;
    public float airFriction = 0.005f;
    
    [Header("isGrounded")]
    public LayerMask whatIsGround;
    public LayerMask whatIsBrush;
    
    [Header("Components")]
    private Rigidbody2D _rigidbody2D;
    private PlayerInput _input;
    
    [Header("Brush)")]
    public BrushMovement _brushMovement;
    public float BrushRotationSpeed;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();
        BrushRaycaster = GameObject.Find("BrushRaycaster");
    }

    private void Update()
    {
        _desiredVelocity = _rigidbody2D.velocity;

        if (IsPlayerGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= 1 * Time.deltaTime;
        }
        
        _rigidbody2D.velocity = _desiredVelocity;
    }
    
    
    
    private bool ducking;
    private void FixedUpdate()
    {
        bool changeable = _input.lift == 0;
        
        if (changeable)
        {
            if (_brushMovement.transform.rotation.eulerAngles.z <= 180)
            {
                ducking = true;
                print("Yes");
            }
            else
            {
                ducking = false;
                print("NOOOO");
            }
        }
        
        if (_brushMovement.isBrushGrounded && _input.lift != 0)
        {
            Vector2 direction = BrushRaycaster.transform.position - transform.position;
            
            _desiredVelocity = Quaternion.Euler(0,0,(ducking ? -1 : 1 ) * 90) * direction * BrushRotationSpeed;
            
            //_desiredVelocity = new Vector2(_rigidbody2D.velocity.x, 1);

        }
        else if (_input.moveDirection != 0) // != "not"
        {
            _desiredVelocity.x = Mathf.Lerp(_desiredVelocity.x, moveSpeed * _input.moveDirection, accelerationTime); // important to multiply moveSpeed with moveDirection!
        }
        else
        {
            _desiredVelocity.x = Mathf.Lerp(
                _desiredVelocity.x, 0f, IsPlayerGrounded()? groundFriction : airFriction); // "?" = If statement, with ":" separating true from false
        }

        
        _rigidbody2D.velocity = _desiredVelocity;
    }

    public bool IsPlayerGrounded()
    {
        return PlayerIsGrounded();
    }

    private bool PlayerIsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.6f, whatIsGround);
    }
}