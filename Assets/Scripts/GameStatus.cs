using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    // Configuration parameters
    [Range(0.5f, 5f)] [SerializeField] private float gameSpeed = 1f;
    [SerializeField] private int pointsPerBlock = 5;
    [SerializeField] TextMeshProUGUI scoreDisplay;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        scoreDisplay.text = $"Score: {score}";
    }

    public void CountPoints()
    {
        score += pointsPerBlock;
    }
}
