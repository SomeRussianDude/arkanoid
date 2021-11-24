using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Config Params
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minUnitsPos;
    [SerializeField] float maxUnitsPos;

    // Cached References
    GameSession gameSession;
    Ball ball;


    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2 (transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minUnitsPos, maxUnitsPos);
        transform.position = paddlePos;

    }

    private float GetXPos()
    {
        if (gameSession.AutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
