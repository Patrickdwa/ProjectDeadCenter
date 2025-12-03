using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 movement;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // 1. INPUT
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        // 2. MANUAL TRANSLATION (Syarat A)
        // Rumus: P_baru = P_lama + (Arah * Speed * DeltaTime)
        movement = new Vector3(moveX, 0f, moveZ).normalized;
        transform.position += movement * speed * Time.deltaTime;

        // 3. MANUAL ROTATION (Syarat B)
        ManualRotation();
    }

    void ManualRotation()
    {
        // Mendapatkan posisi mouse di dunia 3D
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(ray, out rayLength))
        {
            Vector3 pointToLook = ray.GetPoint(rayLength);
            
            // Hitung jarak delta
            float dx = pointToLook.x - transform.position.x;
            float dz = pointToLook.z - transform.position.z;

            // Rumus Trigonometri: Arc Tangent (Atan2)
            float angleRad = Mathf.Atan2(dx, dz); // Hasil dalam radian
            float angleDeg = angleRad * Mathf.Rad2Deg; // Konversi ke derajat

            // Terapkan rotasi langsung ke Euler Angles
            transform.rotation = Quaternion.Euler(0f, angleDeg, 0f);
        }
    }
}