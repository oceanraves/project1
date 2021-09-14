using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Vector3 mousePosition;
    private Vector3 screenPos;

    //private Camera mainCamera;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
     
    }

    void Update()
    {
        moveInput = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0f);
        moveVelocity = moveInput * moveSpeed;
        Look();

    }

    private void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }

    private void Look()
    {
        




    }
}
