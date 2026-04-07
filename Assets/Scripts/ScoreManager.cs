using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public int score;

    void Awake()
    {
        instance = this;
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log(score);
        if (scoreText != null) { 
            scoreText.text = "Score: " + score;
        }
    }
}