using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Vector3 direction; // Arah peluru ditembakkan

    void Update()
    {
        // Manual Translation untuk peluru
        transform.position += direction * speed * Time.deltaTime;
        
        // Hapus peluru jika keluar layar (opsional, untuk performa)
        if(transform.position.magnitude > 50) Destroy(gameObject);
    }
}