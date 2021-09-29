using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody myRigidbody;
    private Camera _camera;

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Vector3 mousePosition;

    public bool playerEnabled = true;

    private InputHandler _inputHandler;
    private static bool _gameIsPaused;
    private float current_rotation_;


    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        _inputHandler = GameObject.Find("InputHandler").GetComponent<InputHandler>();
        _gameIsPaused = _inputHandler._isPaused;
        _camera = Camera.main;
        current_rotation_ = transform.rotation.eulerAngles.z;
    }

    void Update()
    {
        if (playerEnabled && !_inputHandler._isPaused)
        {
            moveVelocity = moveInput * moveSpeed;
            Look();
        }
    }

    public void Move(Vector3 movement)
    {
        moveInput = movement;
    }

    private void FixedUpdate()
    {
        if (playerEnabled)
        {
            myRigidbody.velocity = moveVelocity;
        }
        else
            myRigidbody.velocity = Vector3.zero;
    }

    private void Look()
    {

        Vector2 mousePosition = Input.mousePosition;
        Vector2 playerPosition = _camera.WorldToScreenPoint(transform.position);

        Vector2 dir = mousePosition - playerPosition;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (angle < 0.0f)
        {
            angle += 360;
        }

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -(angle - current_rotation_));
    }
}
