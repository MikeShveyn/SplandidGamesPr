using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertiaclScrole : MonoBehaviour
{
    [SerializeField] private float scrollRate = 0.5f;

    private void Update()
    {
        float yMove = scrollRate * Time.deltaTime;
        transform.Translate((new Vector2(0f, yMove)));
    }
}
