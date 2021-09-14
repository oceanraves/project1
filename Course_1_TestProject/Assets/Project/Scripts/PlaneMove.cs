using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{
    float getPos;
    float moveSpeed;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        moveSpeed = moveSpeed + 0.1f;
        gameObject.transform.position = new Vector3(0f, moveSpeed, 0f);
        getPos = gameObject.transform.position.y;
        Debug.Log(getPos);
    }
}
