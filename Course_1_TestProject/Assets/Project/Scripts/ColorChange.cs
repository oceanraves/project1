using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    private Color _originalMat;

    public void StoreColor(Material[] mats)
    {
        //mats = rend.materials;
        _originalMat = mats[1].color;

        mats[1].color = new Color(224, 137, 9, 255);

    }

    public void ColorChangeBack(Material[] mats)
    {
        //mats = rend.materials;
        mats[1].color = _originalMat;
    }
}
