using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class GameLogic : MonoBehaviour
{
    public static GameLogic instance;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    
    // --- BARU: Variable untuk Victory ---
    public GameObject victoryPanel; // Drag Panel Victory ke sini
    // public int targetKills = 10;    // Syarat menang (10 kill)
    public int currentKills = 0;   // Penghitung kill saat ini

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

    // --- BARU: Fungsi Mencatat Kill ---
    public void AddKill()
    {
        if (isGameOver) return;

        currentKills++; // Tambah 1 kill

        // Cek apakah target tercapai?
        // if (currentKills >= targetKills)
        // {
        //     Victory();
        // }
    }

    public void Victory()
    {
        isGameOver = true;
        victoryPanel.SetActive(true); // Munculkan panel menang
        Time.timeScale = 0f; // Pause game
    }

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

    // --- BARU: Fungsi Balik ke Menu ---
    public void BackToHome()
    {
        Time.timeScale = 1f; // Jangan lupa kembalikan waktu jadi normal
        SceneManager.LoadScene("MainMenu"); // Pastikan nama scene menu kamu "MainMenu"
    }
}