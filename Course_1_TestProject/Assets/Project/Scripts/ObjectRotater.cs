using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotater : MonoBehaviour
{
    public Vector3 objectRotation;
    public float rotationSpeed = 0.01f;

    private void FixedUpdate()
    {
        gameObject.transform.Rotate(objectRotation * rotationSpeed * Time.deltaTime); 
    }

    public void SetRotation(Vector3 rotation)
    {
        objectRotation = rotation;
    }

}
