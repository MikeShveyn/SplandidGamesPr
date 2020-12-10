using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScrollier : MonoBehaviour
{

    [SerializeField] float backgroundScrollSpeed = 0.2f;
    Material backMatereal;
    Vector2 offSet;
    // Start is called before the first frame update
    void Start()
    {
        backMatereal = GetComponent<Renderer>().material;
        offSet = new Vector2(0f, backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        backMatereal.mainTextureOffset += offSet * Time.deltaTime;
    }
}
