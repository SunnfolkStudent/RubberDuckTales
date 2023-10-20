using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Controls _controls;

    private void Awake()
    {
        _controls = new Controls();
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }
    
    public float moveDirection;
    public float lift;
    public float squeak;
    public float brush;
    public bool pause; 
    
    // Update is called once per frame
    void Update()
    {
        moveDirection = _controls.Player.MoveHorizontal.ReadValue<float>();
        lift = _controls.Player.Lift.ReadValue<float>();
        squeak = _controls.Player.Squeak.ReadValue<float>();
        brush = _controls.Player.Brush.ReadValue<float>();
        pause = _controls.Player.Pause.triggered;
    }
}
