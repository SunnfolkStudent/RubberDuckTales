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
    
    public bool equipPressed;
    public bool jumpPressed, jumpReleased;
    
    // Update is called once per frame
    void Update()
    {
        moveDirection = _controls.Player.MoveHorizontal.ReadValue<float>();

        equipPressed = _controls.Player.Equip.WasPressedThisFrame();
    }
}
