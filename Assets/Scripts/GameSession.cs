using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    // Configuration parameters
    [Range(0.5f, 5f)] [SerializeField] private float gameSpeed = 1f;
    [SerializeField] private int pointsPerBlock = 5;
    [SerializeField] TextMeshProUGUI scoreDisplay;

    private int score;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
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

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
