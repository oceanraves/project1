using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    private HealthHandler _hHandler;

    private void Start()
    {
        _hHandler = GameObject.Find("HealthHandler").GetComponent<HealthHandler>();
    }
    public void AlertTrigger(string message)
    {
        if (message.Equals("AnimationEnd"))
        {
            _hHandler.Respawn();
        }
    }
}
