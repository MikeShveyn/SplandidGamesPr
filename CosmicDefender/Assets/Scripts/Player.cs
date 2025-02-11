﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //config parameters
    [Header("Player Movment")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] int health = 400;
    [SerializeField] AudioClip explAudio;
    [SerializeField] [Range(0, 1)] float explVolume = 0.7f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVol = 0.25f;

    [Header("Fire Options")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float fireSpeed = 10f;
    [SerializeField] float firePeriod = 0.1f;


    Coroutine fireCouritine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();       
    }

    // Update is called once per frame
    void Update()
    {
    
        Move();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           fireCouritine = StartCoroutine(FireContiniusly()); 
        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireCouritine);
        }
    


    }

     IEnumerator FireContiniusly()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, fireSpeed);
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVol);
            yield return new WaitForSeconds(firePeriod);
        }
       
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private void Move()
    {
         var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
         var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
      
        var newXPos = Mathf.Clamp(transform.position.x + deltaX,xMin,xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY,yMin,yMax);

        transform.position = new Vector3(newXPos, newYPos, transform.position.z);
        
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

    public int GetHealth()
    {
        return health;
    }

    private void Die()
    {
        FindObjectOfType<LevelLoader>().LoadGameOver();
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(explAudio, Camera.main.transform.position, explVolume);
    }
}

