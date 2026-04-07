using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;

    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Win()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Lose()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }
}