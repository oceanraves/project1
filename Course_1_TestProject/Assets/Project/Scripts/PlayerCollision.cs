using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private HealthHandler _healthHandler;
    private Renderer _rend;
    private Material[] _materials;
    private ColorChange _colorChange;
    private bool _isRed = false;

    void Start()
    {
        _healthHandler = GameObject.Find("HealthHandler").GetComponent<HealthHandler>();
        _colorChange = GameObject.Find("ColorChange").GetComponent<ColorChange>();
        _rend = gameObject.GetComponent<Renderer>();
        _materials = _rend.materials;
    }
    private void OnTriggerEnter(Collider collision)
    {    
        //ENEMY BULLET COLLISION BEHAVIOUR
        if (collision.gameObject.tag == "Projectile")
        {
            _healthHandler.PlayerHit(0);
        }

        //ENEMY COLLISION BEHAVIOUR
        if (collision.gameObject.tag == "Enemy")
        {
            _healthHandler.PlayerHit(2);
            GameObject explosion = Instantiate(Resources.Load("Explosion_0", typeof(GameObject))) as GameObject;
            explosion.transform.position = collision.gameObject.transform.position;
            Destroy(collision.gameObject);

            if (!_isRed)
            {
                //ChangeColor();
            }
        }

        if (!_isRed)
        {
            //ChangeColor();
        }
        Destroy(collision.gameObject);
    }
    private void ChangeColor()
    {
        _isRed = true;
        _colorChange.StoreColor(_materials, Color.red, 2);
        Invoke("ChangeBack", 0.1f);
    }
    private void ChangeBack()
    {
        _colorChange.ColorChangeBack(_materials, 2);
        _isRed = false;
    }
}
