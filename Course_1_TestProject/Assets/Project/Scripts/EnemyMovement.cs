using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    bool move;
    
    public float _moveSpeed;
    void Start()
    {
        
    }


    private void FixedUpdate()
    {
        if (move)
        {
            gameObject.transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
        }
    }
}
