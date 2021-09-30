using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    public GameObject bulletPrefab;
    private PlayerMovement _playerMovement;
    private InputHandler _inputHandler;
    private AudioHandler _audioHandler;

    public float bulletForce = 50;
    public float forceBonus = 100f;
    public float cooldown = 0.15f;
    public float cooldownBonus = 0.05f;
    float timer;
    public float duration = 5f;
    bool _powerActive = false;

    private void Start()
    {
        _playerMovement = _playerMovement = GameObject.Find("TEST_Player_Spaceship Variant").GetComponent<PlayerMovement>();
        _inputHandler = GameObject.Find("InputHandler").GetComponent<InputHandler>();
        _audioHandler = GameObject.Find("AudioHandler").GetComponent<AudioHandler>();
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (_playerMovement.playerEnabled == true && Input.GetButton("Fire1") && !_inputHandler._isPaused && timer > cooldown)
        {
            Shoot();
            _audioHandler.Play("Lazer_1");
            timer = 0.0f;
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject bullet1= Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        bullet.GetComponent<Bullet>().fromPlayer = true;
        bullet1.GetComponent<Bullet>().fromPlayer = true;

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        Rigidbody rb1 = bullet1.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode.Impulse);
        rb1.AddForce(firePoint.right * bulletForce, ForceMode.Impulse);

    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("PowerUp"))
        {
            StartCoroutine(Pickup());
            _powerActive = true;
        }
    }
    IEnumerator Pickup()
    {
        if (_powerActive == false)
        {
            cooldown -= cooldownBonus;
            //Debug.Log("Start");
            yield return new WaitForSeconds(duration);
            //Debug.Log("Stop");
            cooldown += cooldownBonus;
            _powerActive = false;
        }
        
    }
}

