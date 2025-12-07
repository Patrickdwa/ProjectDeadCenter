using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Settings")]
    public GameObject[] zombiePrefabs; // Masukkan Prefab dari FOLDER, bukan dari Scene
    public float spawnInterval = 3f; 
    
    [Header("Spawn Area")]
    public float xRange = 14f; 
    public float zRange = 14f; 

    private float timer;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnZombie();
            timer = spawnInterval; 
        }
    }

    void SpawnZombie()
    {
        // --- SAFETY CHECK (Pencegah Error) ---
        if (zombiePrefabs.Length == 0)
        {
            Debug.LogError("ERROR: Slot 'Zombie Prefab' di Inspector masih kosong! Tolong isi dulu.");
            return; // Batalkan spawn agar tidak crash
        }

        Vector3 spawnPos = Vector3.zero;
        float randomSide = Random.value; 

        if (randomSide > 0.5f) 
        {
            // Spawn Kiri/Kanan
            spawnPos.x = Random.value > 0.5f ? xRange : -xRange;
            spawnPos.z = Random.Range(-zRange, zRange);
        }
        else
        {
            // Spawn Atas/Bawah
            spawnPos.z = Random.value > 0.5f ? zRange : -zRange;
            spawnPos.x = Random.Range(-xRange, xRange);
        }
        // Pilih angka acak dari 0 sampai jumlah jenis zombie
        int randomIndex = Random.Range(0, zombiePrefabs.Length);
        
        // Spawn zombie yang terpilih
        Instantiate(zombiePrefabs[randomIndex], spawnPos, Quaternion.identity);
    }
}