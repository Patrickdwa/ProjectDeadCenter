using UnityEngine;
using TMPro; // Library untuk TextMeshPro
using UnityEngine.SceneManagement; // Library untuk Reload Scene

public class GameLogic : MonoBehaviour
{
    // Singleton: Agar script ini bisa dipanggil dari mana saja (misal dari Zombie)
    public static GameLogic instance;

    public TextMeshProUGUI scoreText; // Drag Text Skor ke sini
    public GameObject gameOverPanel;  // Drag Panel Game Over ke sini
    
    private int score = 0;
    public bool isGameOver = false;

    void Awake()
    {
        instance = this;
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;

        score += amount;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true); // Munculkan panel
        Time.timeScale = 0f; // Bekukan waktu (Pause Game)
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Kembalikan waktu jadi normal
        // Reload scene saat ini
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}