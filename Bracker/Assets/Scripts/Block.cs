using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config parametrs
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSpaRklesVFX;
    [SerializeField] Sprite[] hitSprites;

    //cached refrence
    Level level;
    GameStatus gamestatus;

    //state variables
    [SerializeField] int timesHit; // serialized for debug


    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }

        gamestatus = FindObjectOfType<GameStatus>();
    }

    private void OnCollisionEnter2D(Collision2D collision)//collision can be used to add infirmation about collision and object that involve in
    {
        if (tag == "Breakable")
        {
            HandleHit();

        }


    }

    private void HandleHit()
    {
        timesHit++;
         int  maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlocks();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array");
            Debug.LogError(gameObject.name);
        }
    }

    private void DestroyBlocks()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
        gamestatus.AddToScore();
        TriggerSparklesVFX();
        
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSpaRklesVFX,transform.position,transform.rotation);
        Destroy(sparkles, 1f);
    }
}
