using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float fireReit = 1f;
    [SerializeField] private List<GameObject> projectiles;
    [SerializeField] private Transform gunPos;
    
    
    private float _realFireReit;
    private float _timeSinceLastFire = Mathf.Infinity;
    private GameObject _currentProjectile;
    // Update is called once per frame
    
    private void Start()
    {
        
        _currentProjectile = projectiles[0];//first projectile in list
        _realFireReit = 1/(fireReit/60); //real amount of bullets per minuets
    }
    
    void Update()
    {
        _timeSinceLastFire += Time.deltaTime;
        
        //Rotation
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * (Time.deltaTime * rotationSpeed));
        
        //Fire
        Fire();
        
        //StatsCheck !!!!change to level progression!!!!
        if (GameStats.Score > 100)
        {
            _currentProjectile = projectiles[1];
        }
       
    }

    private void Fire()
    {
        if (_timeSinceLastFire > _realFireReit && Input.GetMouseButton(0))
        {
            if (gunPos != null && _currentProjectile != null)
            {
                GameObject boom = Instantiate(_currentProjectile, gunPos.position, gunPos.rotation);
                _timeSinceLastFire = 0;
            }
        }
    }
}
