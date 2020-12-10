using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;// Seria;ized for debigging

    //cache refrence]
    LoadScene loadscene;

    private void Start()
    {
        loadscene = FindObjectOfType<LoadScene>();
    }

    public void CountBlocks()
    {
       
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks <=0)
        {
            loadscene.LoadNextScene();
        }
    }
}
