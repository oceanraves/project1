using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    private Color _originalMat;

    public void StoreColor(Material[] mats, Color color, int material)
    {
        _originalMat = mats[1].color;
        mats[material].color = color;
    }

    public void ColorChangeBack(Material[] mats, int material)
    {
        mats[material].color = _originalMat;
    }
}
