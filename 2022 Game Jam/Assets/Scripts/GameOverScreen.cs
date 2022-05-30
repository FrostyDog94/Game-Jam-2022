using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public PlayerStats playerStats;
    public Timer timer;
    public ScoreController scoreController;
    public TextMeshProUGUI scoreText;

    void Update() {
        if (playerStats.currentHealth <= 0 || timer.currentTime <= 0) {
            Setup(scoreController.score);
        }
    }

    public void Setup(int score) {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        transform.GetChild(0).gameObject.SetActive(true);
        scoreText.SetText("Score: " + score.ToString());
    }

    public void RestartButton() {
        SceneManager.LoadScene("MainLevel");
    }

    public void ExitButton() {
        SceneManager.LoadScene("TitleScreen");
    }
}
