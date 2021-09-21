using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector3 lastCheckPointPos;
    public Vector3 _startPos;

    private void Awake()
    {
        _startPos = new Vector3(-19f, 53.5f, 17f);

        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        } else {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (lastCheckPointPos == Vector3.zero)
        {
            lastCheckPointPos = _startPos;
        }
    }
}
