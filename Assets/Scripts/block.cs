using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    [SerializeField] AudioClip brokenAudio;
    [SerializeField] GameObject sparkles;
    Level level;
    GameStatus gameStatus;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
        level.CountBreakableBlocks();
    }
    private void OnCollisionEnter2D(Collision2D collision)
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
