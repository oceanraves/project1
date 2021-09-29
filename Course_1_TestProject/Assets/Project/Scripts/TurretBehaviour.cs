using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    private Renderer _rend;
    private Material[] _materials;
    private ColorChange _colorChange;
    private bool _isRed = false;
    int health = 12;
    private AudioHandler _audioHandler;
    private EnemySpawner _enemySpawner;
    private float turretPos;
    private Animator _animator;


    void Start()
    {
        _audioHandler = GameObject.Find("AudioHandler").GetComponent<AudioHandler>();
        _enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        _animator = gameObject.GetComponent<Animator>();
        _colorChange = GameObject.Find("ColorChange").GetComponent<ColorChange>();
        _rend = gameObject.GetComponent<Renderer>();
        _materials = _rend.materials;


    }

    private void OnTriggerEnter(Collider bullet)
    {

        if (bullet.gameObject.tag == "Projectile" && bullet.GetComponent<Bullet>().fromPlayer == true)
        {
            if (bullet.GetComponent<Bullet>() != null)
            {
                health -= bullet.GetComponent<Bullet>().damage;

                if (!_isRed)
                {
                    ChangeColor();
                }
            }
            Destroy(bullet);
        }
        if (health <= 0)
        {
            _audioHandler.Play("EnemyExplode");

            ExplosionSpawner explosionSpawner = GameObject.Find("ExplosionSpawner").GetComponent<ExplosionSpawner>();

            Vector3 turretPosition = gameObject.transform.position;
            //turretPosition.y -= 5.62f;
            //turretPosition.z -= 4f;

            explosionSpawner.SpawnExplosion(turretPosition, "Ship");
            FindObjectOfType<ScoreDisplay>().AddScore();
            //_animator = gameObject.GetComponent<Animator>();

            turretPos = gameObject.transform.position.x;
            _enemySpawner.SpawnTurret(turretPos);
            Destroy(gameObject);
        }
    }

    private void ChangeColor()
    {
        _isRed = true;
        _colorChange.StoreColor(_materials, new Color(224, 137, 9, 255), 0);
        Invoke("ChangeBack", 0.03f);
    }
    private void ChangeBack()
    {
        _colorChange.ColorChangeBack(_materials, 0);
        _isRed = false;
    }
}
