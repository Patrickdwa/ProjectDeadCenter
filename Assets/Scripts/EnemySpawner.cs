using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject zombiePrefab; // Cetakan Zombie
    public float spawnInterval = 3f; // Muncul setiap 3 detik
    private float timer;

    // Batas area spawn (di luar jangkauan kamera)
    // Sesuaikan angka ini nanti di Inspector
    public float xRange = 14f; // Jarak Kiri-Kanan
    public float zRange = 14f; // Jarak Atas-Bawah

    void Update()
    {
        // Hitung mundur waktu
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnZombie();
            timer = spawnInterval; // Reset waktu
        }
    }

    void SpawnZombie()
    {
        Vector3 spawnPos = Vector3.zero;

        // LOGIKA MATEMATIKA:
        // Kita ingin zombie muncul di "Bingkai" luar arena, bukan di tengah.
        // Caranya: Pilih acak, mau spawn di sisi Horizontal (Kiri/Kanan) atau Vertikal (Atas/Bawah)?
        
        float randomSide = Random.value; // Angka acak 0.0 sampai 1.0

        if (randomSide > 0.5f) 
        {
            // --- OPSI A: Spawn di Kiri atau Kanan ---
            // Tentukan X: Kalau > 0.5 pakai Sisi Kanan (+xRange), kalau tidak pakai Sisi Kiri (-xRange)
            spawnPos.x = Random.value > 0.5f ? xRange : -xRange;
            
            // Tentukan Z: Acak sembarang dari bawah (-zRange) sampai atas (zRange)
            spawnPos.z = Random.Range(-zRange, zRange);
        }
        else
        {
            // --- OPSI B: Spawn di Atas atau Bawah ---
            // Tentukan Z: Kalau > 0.5 pakai Sisi Atas (+zRange), kalau tidak pakai Sisi Bawah (-zRange)
            spawnPos.z = Random.value > 0.5f ? zRange : -zRange;

            // Tentukan X: Acak sembarang dari kiri (-xRange) sampai kanan (xRange)
            spawnPos.x = Random.Range(-xRange, xRange);
        }

        // Cetak Zombie di posisi tersebut
        Instantiate(zombiePrefab, spawnPos, Quaternion.identity);
    }
}