using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    float _angle = 0;

    void Start()
    {
    }
    void Update()
    {
        _angle += 2 * Time.deltaTime;
        _angle %= 360;
        RenderSettings.skybox.SetFloat("_Rotation", _angle);
    }

}
