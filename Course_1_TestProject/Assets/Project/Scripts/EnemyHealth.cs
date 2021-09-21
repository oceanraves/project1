using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    int health;

    private Renderer _rend;
    private Material[] _materials;

    private bool _isRed = false;
    private float _counter;

    private HealthHandler _healthHandler;
    private AudioHandler _audioHandler;
    private ColorChange _colorChange;
    private Animator _animator;

    private BoxCollider[] _allColliders;

    void Start()
    {
        _healthHandler = GameObject.Find("HealthHandler").GetComponent<HealthHandler>();
        _audioHandler = GameObject.Find("AudioHandler").GetComponent<AudioHandler>();
        _colorChange = GameObject.Find("ColorChange").GetComponent<ColorChange>();
        _allColliders = gameObject.GetComponents<BoxCollider>();

        //Store Color Data
        _rend = gameObject.GetComponent<Renderer>();
        _materials = _rend.materials;
        //------------------------------------------
    }

    private void Update()
    {
        if (_isRed && Time.time > _counter + 0.05f)
        {
            //_colorChange.ColorChangeBack(_materials);
            _isRed = false;
        }
    }
        
    private void OnTriggerEnter(Collider bullet)
    {
        if (bullet.gameObject.tag == "Projectile" && bullet.GetComponent<Bullet>().fromPlayer == true)
        {            
            if(bullet.GetComponent<Bullet>() != null)
            {
                health -= bullet.GetComponent<Bullet>().damage;
            }

            if (health <= 0)
            {
                _audioHandler.Play("EnemyExplode");

                FindObjectOfType<ScoreDisplay>().AddScore();

                EnemySpawner enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
                enemySpawner.SpawnExplosion(gameObject.transform.position, "Ship");

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
                } else
                    Destroy(gameObject);
            }

            _isRed = true;
            _counter = Time.time;
            //_colorChange.StoreColor(_materials);

            Destroy(bullet.gameObject);
        }
    }

    /*
    //COLOR---------------------------------------------------
    private void ColorChange()
    {
        _counter = Time.time;
        _materials[1].color = new Color(224, 137, 9, 255);
        _isRed = true;
    }

    private void ColorChangeBack()
    {
        _materials[1].color = _originalMat;
        _isRed = false;
    }
    //--------------------------------------------------------
    */
}
