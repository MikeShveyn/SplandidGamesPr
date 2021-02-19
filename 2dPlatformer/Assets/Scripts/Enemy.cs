using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;

        private Rigidbody2D rigit;

        private void Start()
        {
            rigit = GetComponent<Rigidbody2D>();
            
        }

        private void Update()
        {
            if (isFacingRight())
            {
                rigit.velocity = new Vector2(speed, 0f);
            }
            else
            {
                rigit.velocity = new Vector2(-speed, 0f);
            }
            
            
        }

        private bool isFacingRight() // face right 
        {
            return transform.localScale.x > 0;
        }
        

        private void OnTriggerExit2D(Collider2D other) // Flip side on end of platform
        {
            transform.localScale = new Vector2(-(Mathf.Sign(rigit.velocity.x)), 1f);
        }
    }
}