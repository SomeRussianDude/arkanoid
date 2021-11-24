using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] private AudioClip destroySound;
    [SerializeField] private GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    // Cached reference
    private Level level;

    // State vars
    int timesHit;

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
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
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
            Debug.LogError($"Block sprite  for {gameObject.name} is missing from the array");
        }
    }

    private void DestroyBlock()
    {
        TriggerSparklesVFX();
        PlayBlockDestroySFX();
        level.BlockDestroyed();
        FindObjectOfType<GameSession>().CountPoints();
        Destroy(gameObject);
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(destroySound, Camera.current.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
   
}
