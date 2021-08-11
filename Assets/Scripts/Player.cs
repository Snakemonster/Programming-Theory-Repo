using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _runSpeed;
    private float _currentSpeed;
    private float _mouseY;
    private float _mouseX;
    private float _xRotation;
    private CharacterController _controller;
    private GameObject _gun;

    private Vector2 _inputDirection;
    private Vector3 _velocity;
    
    public Transform cameraPlayer;
    
    public float mouseSensitivity;
    public float walkSpeed;


    private void Start()
    {
        _gun = GameObject.FindGameObjectWithTag("Gun");
        _controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SetSpeed();
    }

    private void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
        UpdateSpeed();
    }

    private void UpdateMouseLook()
    {
        _mouseY = Input.GetAxis("Mouse X");
        _mouseX = Input.GetAxis("Mouse Y");
        
        _xRotation -= _mouseX;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        cameraPlayer.localEulerAngles = Vector3.right * _xRotation;
        _gun.transform.localEulerAngles = new Vector3(_gun.transform.rotation.x, 90, _xRotation);
        
        transform.Rotate(Vector3.up * (_mouseY * mouseSensitivity));
    }
    
    private void UpdateMovement()
    {
        _inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized; // This .normalized need to make a diagonal movement speed like on axis
        _velocity = (transform.forward * _inputDirection.y + transform.right * _inputDirection.x) * _currentSpeed;
        _controller.Move(_velocity * Time.deltaTime);
    }

    private void UpdateSpeed()
    {
        _currentSpeed = Input.GetKey(KeyCode.LeftShift) ? _runSpeed : walkSpeed;
    }

    private void SetSpeed()
    {
        _runSpeed = 2 * walkSpeed;
        _currentSpeed = walkSpeed;
    }
}
