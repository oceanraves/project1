using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    bool move = true;

    [SerializeField]
    float _moveSpeed;

    void Start()
    {
    }

    //Gets Speed From "EnemySpawner"
    public float SetMoveSpeed(float speed)
    {
        _moveSpeed = speed;
        return speed;
    }

    private void FixedUpdate()
    {
        if (move)
        {
            gameObject.transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider boundary)
    {
        if (boundary.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
