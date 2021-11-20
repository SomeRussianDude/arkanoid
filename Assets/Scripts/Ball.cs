using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //configuration parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float dirX = 2f;
    [SerializeField] float dirY = 15f;
    [SerializeField] AudioClip[] ballSounds;

    //state
    Vector2 ballToPaddleDistance;
    bool hasStarted = false;

    // Cashed component reference
    AudioSource myAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        ballToPaddleDistance = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        { 
            LockToPaddle();
            LaunchOnClick();
        }

    }

    private void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(dirX, dirY);
            hasStarted = true;
        }
    }

    private void LockToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + ballToPaddleDistance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            myAudioSource.Play();
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (hasStarted)
    //    {
    //        AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
    //        myAudioSource.PlayOneShot(clip);
    //    }
    //}
}
