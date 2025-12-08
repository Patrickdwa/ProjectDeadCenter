using UnityEngine;
using System.Collections;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    [Header("Zombie Prefabs")]
    public GameObject normalZombiePrefab;
    public GameObject fastZombiePrefab;

    [Header("UI References")]
    public TextMeshProUGUI waveText;
    
    [Header("Spawn Settings")]
    public float xRange = 14f; 
    public float zRange = 14f; 

    [Header("Wave Configuration")]
    // Agar mudah diatur lewat Inspector tanpa ubah kodingan
    public int wave1Count = 10;
    public int wave2Count = 10;
    public int finalWaveBatch = 5; // Muncul 5, lalu 5 lagi (Total 10)

    void Start()
    {
        if (waveText != null) waveText.gameObject.SetActive(false); // Pastikan mati di awal
        StartCoroutine(WaveSystem());
    }

    IEnumerator WaveSystem()
    {
        // Tunggu sebentar agar GameLogic siap sepenuhnya
        yield return new WaitForSeconds(1f);

        // ================= WAVE 1 =================
        yield return StartCoroutine(ShowWaveUI("WAVE 1"));
        
        // Rumus Anti-Rusak: Target = Kill Saat Ini + Jumlah yang mau dispawn
        int targetKills = GameLogic.instance.currentKills + wave1Count;

        // Spawn Loop
        for (int i = 0; i < wave1Count; i++)
        {
            if (CheckGameOver()) yield break; // Stop jika player mati
            SpawnEnemy(normalZombiePrefab);
            yield return new WaitForSeconds(1.5f); // Jeda spawn
        }

        // Tunggu sampai target tercapai
        yield return new WaitUntil(() => GameLogic.instance.currentKills >= targetKills);


        // ================= WAVE 2 =================
        yield return StartCoroutine(ShowWaveUI("WAVE 2"));
        
        // Update Target baru berdasarkan kill terakhir
        targetKills = GameLogic.instance.currentKills + wave2Count;

        for (int i = 0; i < wave2Count; i++)
        {
            if (CheckGameOver()) yield break;
            SpawnEnemy(fastZombiePrefab);
            yield return new WaitForSeconds(1.0f); // Lebih cepat spawnnya
        }

        yield return new WaitUntil(() => GameLogic.instance.currentKills >= targetKills);


        // ================= FINAL WAVE =================
        yield return StartCoroutine(ShowWaveUI("FINAL WAVE"));

        // Batch 1 (Langsung banyak)
        int totalFinalZombie = finalWaveBatch * 2; // Karena ada 2 batch
        targetKills = GameLogic.instance.currentKills + totalFinalZombie;

        // Spawn Batch 1
        for (int i = 0; i < finalWaveBatch; i++)
        {
            if (CheckGameOver()) yield break;
            SpawnEnemy(fastZombiePrefab);
        }

        // Bernapas dulu 4 detik sebelum serbuan terakhir
        yield return new WaitForSeconds(4f);

        // Spawn Batch 2
        for (int i = 0; i < finalWaveBatch; i++)
        {
            if (CheckGameOver()) yield break;
            SpawnEnemy(fastZombiePrefab);
        }

        // Tunggu sampai semua zombie final mati
        yield return new WaitUntil(() => GameLogic.instance.currentKills >= targetKills);


        // ================= VICTORY =================
        if (!GameLogic.instance.isGameOver)
        {
            Debug.Log("WAVE SELESAI - VICTORY!");
            GameLogic.instance.Victory();
        }
    }

    // --- FUNGSI PEMBANTU ---

    bool CheckGameOver()
    {
        // Cek apakah GameLogic ada DAN apakah game sudah over
        if (GameLogic.instance != null && GameLogic.instance.isGameOver)
        {
            return true; // Game sudah berakhir
        }
        return false; // Game masih jalan
    }

    IEnumerator ShowWaveUI(string text)
    {
        if (waveText != null)
        {
            waveText.text = text;
            waveText.gameObject.SetActive(true);
            yield return new WaitForSeconds(3f); // Tampil 3 detik
            waveText.gameObject.SetActive(false);
        }
    }

    void SpawnEnemy(GameObject prefab)
    {
        if (prefab == null) return;

        Vector3 spawnPos = Vector3.zero;
        float randomSide = Random.value; 

        // Spawn di pinggir map (Kotak)
        if (randomSide > 0.5f) 
        {
            spawnPos.x = Random.value > 0.5f ? xRange : -xRange;
            spawnPos.z = Random.Range(-zRange, zRange);
        }
        else
        {
            spawnPos.z = Random.value > 0.5f ? zRange : -zRange;
            spawnPos.x = Random.Range(-xRange, xRange);
        }

        // Agar zombie tidak spawn melayang atau tenggelam, set Y ke 0
        spawnPos.y = 0f;

        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}