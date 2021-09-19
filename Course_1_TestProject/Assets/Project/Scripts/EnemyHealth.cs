using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    int health;

    private Renderer _rend;
    private Material[] _materials;
    private Color _originalMat;

    private HealthHandler _healthHandler;

    private bool _isRed = false;
    private float _counter;
    private AudioHandler _audioHandler;

    void Start()
    {
        _rend = gameObject.GetComponent<Renderer>();
        _materials = _rend.materials;
        _originalMat = _materials[1].color;

        _healthHandler = GameObject.Find("HealthHandler").GetComponent<HealthHandler>();
        _audioHandler = GameObject.Find("AudioHandler").GetComponent<AudioHandler>();
    }

    private void Update()
    {
        if (_isRed && Time.time > _counter + 0.05f)
        {
            ColorChangeBack();
        }
    }

    private void OnTriggerEnter(Collider bullet)
    {
        if (bullet.gameObject.tag == "Projectile")
        {            
            if(bullet.GetComponent<Bullet>() != null)
            {
                health -= bullet.GetComponent<Bullet>().damage;
            }

            if (health <= 0)
            {
                _audioHandler.Play("EnemyExplode");
                _healthHandler.EnemyDeath(gameObject.transform.position);
                Destroy(gameObject);
            }
            ColorChange();
            Destroy(bullet.gameObject);
        }
    }

    //COLOR---------------------------------------------------
    private void ColorChange()
    {
        _counter = Time.time;
        _materials[1].color = new Color(224, 137, 9, 255);
        _isRed = true;
    }

    private void ColorChangeBack()
    {
        //Debug.Log("Called Change Back");
        _materials[1].color = _originalMat;
        _isRed = false;
    }
    //--------------------------------------------------------
}
