using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    [SerializeField] AudioClip brokenAudio;
    [SerializeField] GameObject sparkles;
    [SerializeField] int timesHit;
    [SerializeField] Sprite[] hitSprites;

    Level level;
    GameStatus gameStatus;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
        if (gameObject.tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
        Debug.Log("Test" + gameObject.name);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Breakable")
        {
            int maxHits = hitSprites.Length + 1;
            timesHit++;
            if (timesHit >= maxHits)
            {
                DestroyBlocks();
            }
            else
            {
                ShowNextHitSprites();
            }
        }
    }

    private void ShowNextHitSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("array out of range problem");
        }

    }

    public void DestroyBlocks()
    {
        AudioSource.PlayClipAtPoint(brokenAudio, Camera.main.transform.position);
        level.BlockDestroyed();
        gameStatus.AddToScore();
        TriggerSparkles();
        Destroy(gameObject);
    }

    public void TriggerSparkles()
    {
        GameObject sparkleEffect = Instantiate(sparkles, transform.position, transform.rotation);
        Destroy(sparkleEffect, 1f);
    }
}
