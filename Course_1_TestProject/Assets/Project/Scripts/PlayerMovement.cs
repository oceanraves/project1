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

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        moveInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        moveVelocity = moveInput * moveSpeed;
        Look();

    }

    private void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }

    private void Look()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane plane = new Plane(Vector3.back, Vector3.zero);

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 target = ray.GetPoint(distance);
            Vector3 direction = target - transform.position;
            float rotation = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + 180f;
            transform.rotation = Quaternion.Euler(180, 0, rotation);
        }
    }
}
