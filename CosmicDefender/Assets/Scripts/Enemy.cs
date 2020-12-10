using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header(" Enemy Stats")]
    [SerializeField] float health = 100;
    [SerializeField] int points = 10;

    [Header("Shooting")]
    float shootCounter = 0f;
    [SerializeField] float minTimeBetweenSHOTS = 0.2f;
    [SerializeField] float maxTimeBetweenSHOTS = 3f;
    [SerializeField] float fireSpeed = 10f; 
    [SerializeField] GameObject shootPrefab;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationExplosion = 1f;

    [Header(" Audio")]
    [SerializeField] AudioClip explAudio;
    [SerializeField] [Range(0,1)] float explVolume = 0.7f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVol = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        shootCounter = UnityEngine.Random.Range(minTimeBetweenSHOTS, maxTimeBetweenSHOTS);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownandShoot();
    }

    private void CountDownandShoot()
    {
        shootCounter -= Time.deltaTime;
        if(shootCounter <= 0f)
        {
            Fire();
            shootCounter = UnityEngine.Random.Range(minTimeBetweenSHOTS, maxTimeBetweenSHOTS);
        }   
    }

    private void Fire()
    {
        GameObject laser = Instantiate(shootPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -fireSpeed);
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVol);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) return;
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
       
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();

        }
    }

    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScore(points);
        Destroy(gameObject);
        GameObject exlosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(exlosion, durationExplosion);
        AudioSource.PlayClipAtPoint(explAudio,Camera.main.transform.position,explVolume);
    }
}
