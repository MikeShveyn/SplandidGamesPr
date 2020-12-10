using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.TextCore;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 1f;
    [SerializeField] private int health = 100;

    private GameObject _player;
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        transform.rotation = _player.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.LookAt(_player.transform);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        Die();
    }

    private void Die()
    {
        if (health == 0)
        {
            Destroy(gameObject);
            GameStats.Score += 10;
        }
    }

    public void TakeDamage(int damage)
    {
        health = Mathf.Max(0, health - damage);
    }
}
