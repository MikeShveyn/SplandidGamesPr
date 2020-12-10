using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float MinPos = 0f;
    [SerializeField] float MaxPos = 16f;

    //cached refrence
    GameStatus theGameStatus;
    Ball theBall;
  
    // Start is called before the first frame update
    void Start()
    {
        theGameStatus = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 paddlePos = new Vector3(transform.position.x, transform.position.y, 5f); // x y stay in same place
        paddlePos.x = Mathf.Clamp(GetxPos(),MinPos,MaxPos);
        transform.position = paddlePos;  
    }

    private float GetxPos()
    {
        if (theGameStatus.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return (Input.mousePosition.x / Screen.width * screenWidthInUnits);//mouse pos in units
        }
    }
}
