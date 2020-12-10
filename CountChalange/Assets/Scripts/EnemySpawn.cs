using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject enemyPrefabs = null;
    [SerializeField] private int amount = 1;
    [SerializeField] private float spawnRadius = 10f;
    [SerializeField] private float wavesTime = 5f;

    private float _timeSinceLastWave = Mathf.Infinity;
  

    // Update is called once per frame
    void Update()
    {
        _timeSinceLastWave += Time.deltaTime;
        if (_timeSinceLastWave > wavesTime)
        {
            SpawnEnemies();
        }
        
    }

    private void SpawnEnemies()
    {
        var position = this.transform.position;
        for (int i = 0; i < amount; i++)
        {
            Vector3 randomPos = new Vector3(position.x, position.y, position.z + +Random.Range(-spawnRadius, spawnRadius));
            Instantiate(enemyPrefabs, randomPos, Quaternion.identity);
        }

        _timeSinceLastWave = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
        }
    }
}
