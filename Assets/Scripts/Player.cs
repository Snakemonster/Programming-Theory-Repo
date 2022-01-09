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
    private GameObject[] _guns;
    public GameObject _currentGun { get; private set; }

    private Vector2 _inputDirection;
    private Vector3 _velocity;
    
    public Transform cameraPlayer;
    
    public float mouseSensitivity;
    public float walkSpeed;


    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        SetGun();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SetSpeed();
    }

    private void Update()
    {
        SwitchGun();
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
        _currentGun.transform.localEulerAngles = new Vector3(_currentGun.transform.rotation.x, 90, _xRotation);
        
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

    private void SetGun()
    {
        _guns = GameObject.FindGameObjectsWithTag("Gun");
        _currentGun = _guns[0];
        _guns[1].gameObject.SetActive(false);
    }
    private void SwitchGun()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1) && _currentGun.gameObject != _guns[0].gameObject)
        {
            _guns[0].gameObject.SetActive(true);
            _guns[1].gameObject.SetActive(false);
            if(_guns[0].GetComponent<Gun>().Ammo == 0) _guns[0].GetComponent<Gun>().Reload();
            _currentGun = _guns[0];
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2) && _currentGun.gameObject != _guns[1].gameObject)
        {
            _guns[0].gameObject.SetActive(false);
            _guns[1].gameObject.SetActive(true);
            if(_guns[1].GetComponent<Gun>().Ammo == 0) _guns[1].GetComponent<Gun>().Reload();
            _currentGun = _guns[1];
        }
    }
}
