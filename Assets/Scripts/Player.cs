using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _mouseY;
    private float _mouseX;
    private float _xRotation;
    private CharacterController _controller;

    private Vector2 _inputDirection;
    private Vector3 _velocity;
    
    public Transform cameraPlayer;
    
    public float mouseSensitivity;
    public float walkSpeed;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
    }

    private void UpdateMouseLook()
    {
        _mouseY = Input.GetAxis("Mouse X");
        _mouseX = Input.GetAxis("Mouse Y");
        
        _xRotation -= _mouseX;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        cameraPlayer.localEulerAngles = Vector3.right * _xRotation;
        
        transform.Rotate(Vector3.up * (_mouseY * mouseSensitivity));
    }
    
    private void UpdateMovement()
    {
        _inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized; // This .normalized need to make a diagonal movement speed like on axis
        _velocity = (transform.forward * _inputDirection.y + transform.right * _inputDirection.x) * walkSpeed;
        _controller.Move(_velocity * Time.deltaTime);
    }
}
