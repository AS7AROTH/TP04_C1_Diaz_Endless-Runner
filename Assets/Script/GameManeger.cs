using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManeger : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private float initialScrollSpeed;

    private int score;
    private float Timer;
    private float scrollSpeed;

    public static GameManeger Instance {  get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Update()
    {
            UpdateScore();
            UpdateSpeed();
    }

    public void ShowGameOverScreen()
    {
               gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    private void UpdateScore()
    {
        int scorePerSecond = 10;

        Timer += Time.deltaTime;
        score = (int)(Timer * scorePerSecond);
        scoreText.text = string.Format("{0:00000}", score);
    }

    public float GetScrollSpeed()
    {
        return scrollSpeed;
    }

    private void UpdateSpeed()
    {
        float speedDivader = 10f;
        scrollSpeed = initialScrollSpeed + (Timer / speedDivader);
    }
}
