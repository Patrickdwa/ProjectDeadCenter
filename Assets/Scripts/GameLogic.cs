using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class GameLogic : MonoBehaviour
{
    public static GameLogic instance;

    [Header("UI References")]
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public GameObject victoryPanel; 
    
    [Header("Audio Settings")]
    public AudioSource bgmSource;   // Masukkan AudioManager (BGM) ke sini
    public AudioClip victoryClip;   // Masukkan file lagu Victory ke sini

    public int currentKills = 0;   
    private int score = 0;
    public bool isGameOver = false;

    void Awake()
    {
        instance = this;
    }

    // ... (Fungsi AddScore dan AddKill biarkan sama) ...
    public void AddScore(int amount)
    {
        if (isGameOver) return;
        score += amount;
        scoreText.text = "Score: " + score;
    }

    public void AddKill()
    {
        if (isGameOver) return;
        currentKills++;
    }

    // --- FUNGSI VICTORY DI-UPDATE ---
    public void Victory()
    {
        isGameOver = true;
        
        // 1. Munculkan UI
        victoryPanel.SetActive(true);
        
        // 2. Stop Waktu
        Time.timeScale = 0f; 

        // 3. Ganti Musik
        if (bgmSource != null && victoryClip != null)
        {
            bgmSource.Stop();           // Matikan BGM Game
            bgmSource.clip = victoryClip; // Ganti kasetnya jadi lagu Victory
            bgmSource.loop = true;      // Pastikan Looping aktif
            bgmSource.Play();           // Mainkan!
        }
    }

    // ... (Fungsi GameOver, RestartGame, BackToHome biarkan sama) ...
    public void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToHome()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu");
    }
}