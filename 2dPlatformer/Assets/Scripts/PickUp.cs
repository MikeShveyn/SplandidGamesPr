using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSound = null;
    [SerializeField] private int pointsToScore = 10;
    
    
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {    
            FindObjectOfType<GameManager>().AddScore(pointsToScore);
            //change to events !!!!
            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
            }
            
            Destroy(gameObject);
        }
    }

  
}
