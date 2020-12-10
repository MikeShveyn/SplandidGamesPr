using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speedRotation = 1f;
    [SerializeField] private float speedCycle = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.one, Vector3.up, speedCycle * Time.deltaTime);
        transform.Rotate(0, speedRotation * Time.deltaTime, 0);
    }
}
