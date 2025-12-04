using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    private Renderer rend;
    
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rend = GetComponent<Renderer>();
    }

    void Update() {
        if(player == null) return;

        // Vektor arah dari Zombie ke Player
        Vector3 direction = (player.position - transform.position).normalized;
        
        // Manual Translation
        transform.position += direction * speed * Time.deltaTime;
        
        // Rotasi manual menghadap player (opsional biar rapi)
        transform.forward = direction; 
    }

    // Deteksi Tabrakan (Trigger)
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Bullet")) {
            StartCoroutine(FlashEffect());
            Destroy(other.gameObject); // Hapus peluru
            // Tambah logic nyawa berkurang di sini
        }
    }

    // SYARAT CUSTOM SHADER INTERACTION
    System.Collections.IEnumerator FlashEffect() {
        // Ubah nilai properti shader '_FlashAmount' jadi 1
        rend.material.SetFloat("_FlashAmount", 1f);
        yield return new WaitForSeconds(0.1f);
        // Kembalikan jadi 0
        rend.material.SetFloat("_FlashAmount", 0f);
    }
}