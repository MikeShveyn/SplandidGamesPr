using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float fireSpeed = 10f;
    [SerializeField] private float desTime = 10f;
    [SerializeField] private int damage = 25;
    // Start is called before the first frame update
    private new Rigidbody _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {    
        
        _rigidbody.velocity = transform.TransformDirection(Vector3.forward * fireSpeed);
        
        Destroy(gameObject, desTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.rigidbody != null)//check if its enemy
        {
            Enemy enemy = other.collider.GetComponent<Enemy>();
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        
    }
}
