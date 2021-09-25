using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        if (player != null)
        {
            Vector3 position = transform.position;
            position.y = (player.position + offset).y;
            transform.position = position;
        }        
    }
}
