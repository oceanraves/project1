using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    int health;

    private Renderer _rend;
    private Material[] _materials;
    private ColorChange _colorChange;
    private bool _isRed = false;

    private HealthHandler _healthHandler;
    private AudioHandler _audioHandler;
    private Animator _animator;
    private BoxCollider[] _allColliders;

    void Start()
    {
        _healthHandler = GameObject.Find("HealthHandler").GetComponent<HealthHandler>();
        _audioHandler = GameObject.Find("AudioHandler").GetComponent<AudioHandler>();
        _colorChange = GameObject.Find("ColorChange").GetComponent<ColorChange>();
        _allColliders = gameObject.GetComponents<BoxCollider>();

        //Store Color Data//
        _rend = gameObject.GetComponent<Renderer>();
        _materials = _rend.materials;
        //------------------------------------------
    }

    private void Update()
    {

    }


    private void OnTriggerEnter(Collider bullet)
    {
        if (bullet.gameObject.tag == "Boundary")
        {
            Destroy(gameObject.transform.parent.gameObject);
        }

        if (bullet.gameObject.tag == "Projectile" && bullet.GetComponent<Bullet>().fromPlayer == true)
        {
            //Deal Damage To Enemy//
            if (bullet.GetComponent<Bullet>() != null)
            {
                health -= bullet.GetComponent<Bullet>().damage;
            }

            //Enemy Death Behaviour//
            if (health <= 0)
            {
                _audioHandler.Play("EnemyExplode");

                ExplosionSpawner explosionSpawner = GameObject.Find("ExplosionSpawner").GetComponent<ExplosionSpawner>();
                explosionSpawner.SpawnExplosion(gameObject.transform.position, "Ship");
                FindObjectOfType<ScoreDisplay>().AddScore();
                _animator = gameObject.GetComponent<Animator>();

                if (_animator != null)
                {
                    _animator.SetBool("Dead", true);

                    if (gameObject.GetComponent<Enemy02shooting>() != null)
                    {
                        gameObject.GetComponent<Enemy02shooting>().isDead = true;
                    }

                    if (gameObject.GetComponent<Enemy00x2Shooting>() != null)
                    {
                        gameObject.GetComponent<Enemy00x2Shooting>().isDead = true;
                    }

                    if (gameObject.GetComponent<Enemy00x4Shooting>() != null)
                    {
                        gameObject.GetComponent<Enemy00x4Shooting>().isDead = true;
                    }

                    foreach (BoxCollider collider in _allColliders)
                        Destroy(collider);

                    Destroy(gameObject, 1.5f);
                }
                else
                    Destroy(gameObject);
            }

            if (!_isRed)
            {
                ChangeColor();
            }
            Destroy(bullet.gameObject);
        }
    }

    private void ChangeColor()
    {
        _isRed = true;
        _colorChange.StoreColor(_materials, new Color(224, 137, 9, 255), 1);
        Invoke("ChangeBack", 0.03f);
    }

    private void ChangeBack()
    {
        _colorChange.ColorChangeBack(_materials, 1);
        _isRed = false;
    }
}
