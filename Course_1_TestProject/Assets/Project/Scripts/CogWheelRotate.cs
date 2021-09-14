using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogWheelRotate : MonoBehaviour
{
    public Vector3 objectRotation;
    public float rotationSpeed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        gameObject.transform.Rotate(objectRotation * rotationSpeed * Time.deltaTime/*, Space.Self*/); 
    }
}
