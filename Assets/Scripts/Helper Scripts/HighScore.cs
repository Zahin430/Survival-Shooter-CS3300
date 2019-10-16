using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text HighScoreText;
    public int score, HScore;

    void Start()
    {
        score = ScoreManager.score;
    }
    
    void OnEnable()
    {
        HighScoreText.text = $"High Score: {PlayerPrefs.GetInt("hScore")}";
    }

    // Update is called once per frame
    void Update()
    {
        if (score < ScoreManager.score) {
            score = ScoreManager.score;
            if (PlayerPrefs.HasKey("hScore")) {
                int highScore = PlayerPrefs.GetInt("hScore");
                if (score > highScore) {
                    PlayerPrefs.SetInt("hScore", score);
                    HighScoreText.text = $"High Score: {score}";
                }
            } else {
                PlayerPrefs.SetInt("hScore", score);
            }
        }
    }
}
