using UnityEngine;
using System.Collections; // Wajib ada untuk Coroutine
using TMPro; // Untuk akses Text UI

public class EnemySpawner : MonoBehaviour
{
    [Header("Zombie Types")]
    public GameObject normalZombiePrefab; // Masukkan Prefab Zombie Biasa
    public GameObject fastZombiePrefab;   // Masukkan Prefab Fast Zombie

    [Header("UI References")]
    public TextMeshProUGUI waveText;      // Drag UI WaveText ke sini
    public GameObject victoryPanel;       // Drag Victory Panel (buat jaga-jaga)

    [Header("Spawn Area")]
    public float xRange = 14f; 
    public float zRange = 14f; 

    // Tidak butuh timer/Update lagi karena kita pakai Coroutine
    
    void Start()
    {
        // Mulai Skenario Wave saat game dimulai
        StartCoroutine(WaveSystem());
    }

    // --- LOGIKA UTAMA WAVE ---
    IEnumerator WaveSystem()
    {
        // === WAVE 1 ===
        // 1. Tampilkan Teks
        yield return StartCoroutine(ShowWaveUI("WAVE 1"));
        
        // 2. Spawn 10 Zombie Biasa (Satu per satu tiap 1 detik)
        for (int i = 0; i < 10; i++)
        {
            SpawnEnemy(normalZombiePrefab);
            yield return new WaitForSeconds(1f); // Jeda antar spawn
        }

        // 3. Tunggu sampai Player membunuh 10 Zombie (Total kill harus 10)
        // WaitUntil akan menahan kode di baris ini sampai syarat terpenuhi
        yield return new WaitUntil(() => GameLogic.instance.currentKills >= 10);


        // === WAVE 2 ===
        yield return StartCoroutine(ShowWaveUI("WAVE 2"));

        // Spawn 10 Fast Zombie (Satu per satu tiap 0.8 detik)
        for (int i = 0; i < 10; i++)
        {
            SpawnEnemy(fastZombiePrefab);
            yield return new WaitForSeconds(0.8f);
        }

        // Tunggu sampai Total Kill = 20 (10 dari wave 1 + 10 dari wave 2)
        yield return new WaitUntil(() => GameLogic.instance.currentKills >= 20);


        // === FINAL WAVE ===
        yield return StartCoroutine(ShowWaveUI("FINAL WAVE"));

        // Batch 1: Muncul 5 Fast Zombie SEKALIGUS
        for (int i = 0; i < 5; i++)
        {
            SpawnEnemy(fastZombiePrefab);
        }
        
        // Tunggu sebentar sebelum gelombang kedua (misal 3 detik)
        yield return new WaitForSeconds(3f);

        // Batch 2: Muncul 5 Fast Zombie SEKALIGUS LAGI
        for (int i = 0; i < 5; i++)
        {
            SpawnEnemy(fastZombiePrefab);
        }

        // Tunggu sampai Total Kill = 30 (20 sebelumnya + 10 final)
        yield return new WaitUntil(() => GameLogic.instance.currentKills >= 30);


        // === VICTORY ===
        Debug.Log("Menang!");
        GameLogic.instance.Victory();
    }

    // Fungsi Pembantu: Munculkan Teks Wave selama 2 detik
    IEnumerator ShowWaveUI(string text)
    {
        waveText.text = text;
        waveText.gameObject.SetActive(true); // Muncul
        yield return new WaitForSeconds(2f); // Tunggu 2 detik
        waveText.gameObject.SetActive(false); // Hilang
    }

    // Fungsi Pembantu: Spawn 1 biji Zombie
    void SpawnEnemy(GameObject prefab)
    {
        if (prefab == null) return;

        Vector3 spawnPos = Vector3.zero;
        float randomSide = Random.value; 

        // Logika Pinggir Layar (Sama seperti sebelumnya)
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

        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}