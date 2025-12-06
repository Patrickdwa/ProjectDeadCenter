using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    
    // Array untuk menyimpan semua bagian tubuh (kepala, badan, kaki, dll)
    private Renderer[] allRenderers; 
    
    void Start() {
        // Mencari Player secara otomatis
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if(playerObj != null) player = playerObj.transform;

        // Ambil SEMUA renderer yang ada di anak-anak object ini (Kepala, Torso, dll)
        allRenderers = GetComponentsInChildren<Renderer>();
    }

    void Update() {
        if(player == null) return;
        
        // Gerak mengejar player
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.forward = direction; 
    }

    // Deteksi Tabrakan
    void OnTriggerEnter(Collider other) {
        
        // KONDISI 1: Kena Peluru
        if(other.CompareTag("Bullet")) {
            // 1. Jalankan efek kedip
            StartCoroutine(FlashEffect());
            
            // 2. Hapus Peluru segera
            Destroy(other.gameObject); 
            
            // 3. Tambah Skor (Panggil GameLogic)
            // Pastikan script GameLogic sudah ada di scene
            if(GameLogic.instance != null) {
                GameLogic.instance.AddScore(10);
            }

            // 4. Hapus Zombie
            // Kita kasih delay 0.1 detik biar sempat kelihatan warna merahnya sebentar
            Destroy(gameObject, 0.1f); 
        }

        // KONDISI 2: Kena Player (Game Over)
        if(other.CompareTag("Player")) {
            if(GameLogic.instance != null) {
                GameLogic.instance.GameOver();
            }
        }
    }

    System.Collections.IEnumerator FlashEffect() {
        // Ubah warna SEMUA bagian tubuh jadi Merah/Flash
        foreach (Renderer r in allRenderers) {
            r.material.SetFloat("_FlashAmount", 1f);
        }

        yield return new WaitForSeconds(0.1f);

        // Kembalikan warna SEMUA bagian tubuh jadi Normal
        // (Note: Kalau zombie keburu mati di 0.1 detik, baris ini mungkin ga sempat jalan, tapi tidak masalah)
        foreach (Renderer r in allRenderers) {
            r.material.SetFloat("_FlashAmount", 0f);
        }
    }
}