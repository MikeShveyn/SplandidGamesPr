using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    //connect ball to paddle
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSound;
    [SerializeField] float randomFactor = 0.2f;

    //state
    Vector3 paddletoBallVector;

    //bolean for launch ball in the beginning
    bool hasStarted = false;

    //chached component refrences
    AudioSource myAudioSource;
    Rigidbody2D myRigitBody2d;

    // Start is called before the first frame update
    void Start()
    {
        paddletoBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigitBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            LockBallToPedal();
            LaunchOnMouseClick();
        }
     
        
    }

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            myRigitBody2d.velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
    }

    private void LockBallToPedal()
    {
        Vector3 paddlePos = new Vector3(paddle1.transform.position.x, paddle1.transform.position.y, 5f);
        transform.position = paddlePos + paddletoBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f,randomFactor), UnityEngine.Random.Range(0f,randomFactor));
        if(hasStarted)
        {
            AudioClip clip = ballSound[UnityEngine.Random.Range(0,ballSound.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigitBody2d.velocity += velocityTweak;
        }
        
    }
}
