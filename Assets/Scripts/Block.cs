using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkle;
    [SerializeField] Sprite[] hitSprites;
    [SerializeField] int maxHits;

    //
    Level level;

    // degub
    [SerializeField] int timesHit;

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (tag == "Breakable")
        {
            ifBreakableThenDestroy();
        }
    }

    private void ifBreakableThenDestroy()
    {
        timesHit++;
        int maxHits = 3;
        if (timesHit >= maxHits)
        {
            destroyBlock();
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
            Debug.Log("Block is missin boi" + gameObject.name);
        }
    }

    private void destroyBlock()
    {
        PlayAudioOndestroy();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparkles();

    }

    private void PlayAudioOndestroy()
    {
        FindObjectOfType<GameSession>().AddToScore(10);
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparkles()
    {
        GameObject sparkles = Instantiate(blockSparkle, transform.position, transform.rotation);
        Destroy(sparkles, 0.5f);
}
}
