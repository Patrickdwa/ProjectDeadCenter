# 🧟‍♂️ DeadCenter: Zombie Survival Arena

> **Proyek Ujian Akhir Semester (UAS)**
> **Mata Kuliah:** Grafika Komputer & Visualisasi (Semester Ganjil 2025/2026)
> **Program Studi:** Ilmu Komputer, Fasilkom-TI, Universitas Sumatera Utara.
> **Dosen Pengampu:** Jos Timanta Tarigan

![MainMenu Screenshot](https://github.com/Patrickdwa/ProjectDeadCenter/blob/main/Screenshots/MainMenu.png)

## 📖 Deskripsi Proyek
**DeadCenter** adalah game *Top-Down Shooter Survival* yang dikembangkan menggunakan **Unity Engine**. Proyek ini dibangun untuk mendemonstrasikan pemahaman mendalam mengenai konsep dasar Grafika Komputer tanpa bergantung pada fitur otomatis Unity (seperti NavMesh atau Physics velocity).

Seluruh pergerakan karakter dan logika visual dihitung menggunakan **Transformasi Geometri Manual** dan **Custom Shader** sesuai syarat tugas.

## 🎮 Fitur Utama (Game Mechanics)
* **Wave System:** Tantangan bertahan hidup dalam 3 fase (Wave 1, Wave 2, dan Final Wave).
* **Zombie Variations:**
  * *Normal Zombie:* Berjalan lambat namun mematikan.
  * *Fast Zombie:* Varian lebih kecil dengan kecepatan lari tinggi.
* **Weapon Mechanics:** Sistem menembak dengan *Fire Rate delay*, efek animasi *Recoil*, dan visual peluru *Glowing Laser*.
* **Atmosphere:** Nuansa survival horror dengan pencahayaan malam hari (Night Mode).
* **Win/Loss Condition:** Sistem *Victory* setelah menyelesaikan semua wave dan *Game Over* jika tersentuh musuh.

## 🛠️ Implementasi Teknis (Technical Highlights)
Sesuai syarat tugas Proyek Akhir, game ini menerapkan konsep teknis berikut:

### 1. Transformasi Manual (Tanpa RigidBody Physics)
Pergerakan Player, Musuh, dan Peluru **tidak** menggunakan `AddForce` atau `NavMeshAgent`, melainkan rumus matematika vektor manual:
* **Translasi:** Menggunakan rumus `position += direction * speed * deltaTime`.
* **Rotasi:** Menggunakan Trigonometri `Mathf.Atan2` untuk menghitung sudut hadap ke kursor mouse.
* **Skala:** Efek *Breathing* pada karakter menggunakan fungsi Sinus (`Mathf.Sin`) secara real-time.

### 2. Custom Shader Graph (HLSL Logic)
Menggunakan Shader Graph buatan sendiri (URP) untuk efek visual interaktif:
* **Damage Blink:** Musuh berkedip merah terang saat terkena peluru, diimplementasikan dengan parameter `_FlashAmount` dan interpolasi warna (Lerp).


### 3. Animation Layering & Avatar Mask
Menggunakan teknik *Avatar Mask* untuk menggabungkan dua state animasi berbeda secara bersamaan:
* *Lower Body:* Menjalankan animasi lari/jalan.
* *Upper Body:* Menjalankan animasi menodong (Hold) dan menembak (Recoil) secara independen.

## 👥 Anggota Kelompok & Pembagian Tugas

| Nama Mahasiswa | Peran (Role) | Detail Tugas |
| :--- | :--- | :--- |
| **Michael Purba** | Programmer Core | • Script `ManualMovement.cs` (Logika Matematika Translasi & Rotasi)<br>• Script `BulletSystem.cs` |
| **Patrick Nathan Wangsa** | Game Logic & Spawner | • Script `EnemySpawner.cs` (Logika acak posisi & Wave System)<br>• Game Manager (Score, Win/Lose Condition) |
| **Muhammad Kevin Gibran Lubis** | Shader & Visual Artist | • Custom Shader Graph (Effect Blink & Emission)<br>• Setup Scene (Lighting, Camera, Environment) |
| **Michael Ginting** | UI/UX & Laporan | • Membuat Menu Start & Game Over UI<br>• Laporan Proyek & Video Progress |

## 🕹️ Cara Bermain (Controls)
* **W, A, S, D:** Bergerak (Movement).
* **Mouse Cursor:** Membidik (Aiming).
* **Klik Kiri (Left Click):** Menembak (Shoot).

## 📂 Struktur Folder Unity
* `/Assets/Scripts`: Berisi seluruh kode C# (`PlayerController`, `EnemySpawner`, `GameLogic`, `Zombie`).
* `/Assets/Shaders`: Berisi file Shader Graph (`ZombieBlinkShader`).
* `/Assets/Prefabs`: Objek game yang sudah disetting (`Zombie`, `FastZombie`, `Bullet`, `Player`).
* `/Assets/Animations`: Controller animasi dan Avatar Mask.

## 🏆 Credits & External Assets
Proyek ini menggunakan aset pihak ketiga dengan lisensi legal (CC0):
* **3D Models:** Kenney Assets (Toon Characters & Weapons).
* **Sound Effects:** Random from Internet.
* **BGM:** [Toby Fox - Hall of Fame](https://www.youtube.com/watch?v=rHUNnF0u7dg) & [REPULSIVE - 1908 Vol. II](https://www.youtube.com/watch?v=oYujekSjsaw).

---

### 📺 Video Demo
Saksikan demo gameplay dan penjelasan teknis kami di YouTube:
**[▶️ Tonton Video Demo DeadCenter](https://www.youtube.com/watch?v=4jUTGqS-ZM0)**

---
#UniversitasSumateraUtara #Fasilkom-TI #GraphicProgramming #Unity
