# 🧟‍♂️ DeadCenter: Zombie Survival Arena

> **Proyek Ujian Akhir Semester (UAS)**
> **Mata Kuliah:** Grafika Komputer & Visualisasi (Semester Ganjil 2025/2026)
> **Program Studi:** Ilmu Komputer, Fasilkom-TI, Universitas Sumatera Utara
> **Dosen Pengampu:** Jos Timanta Tarigan

![MainMenu Screenshot](https://github.com/Patrickdwa/ProjectDeadCenter/blob/main/Screenshots/MainMenu.png)

---

## 📖 Deskripsi Proyek

**DeadCenter** adalah game *Top-Down Shooter Survival* yang dikembangkan menggunakan **Unity Engine**. Proyek ini dibangun untuk mendemonstrasikan pemahaman konsep dasar **Grafika Komputer** tanpa mengandalkan fitur otomatis Unity (seperti NavMesh atau Rigidbody Physics).

Seluruh pergerakan karakter dan logika visual dihitung menggunakan **Transformasi Geometri Manual** dan **Custom Shader**, sesuai dengan syarat tugas UAS.

---

## 🎮 Fitur Utama (Game Mechanics)

* **Wave System:** Tantangan bertahan hidup dalam 3 fase (Wave 1, Wave 2, dan Final Wave).
* **Zombie Variations:**

  * *Normal Zombie:* Bergerak lambat namun berbahaya.
  * *Fast Zombie:* Ukuran lebih kecil dengan kecepatan tinggi.
* **Weapon Mechanics:** Sistem tembak dengan *Fire Rate delay*, animasi *Recoil*, dan peluru *Glowing Laser*.
* **Atmosphere:** Nuansa *Survival Horror* dengan pencahayaan malam (Night Mode).
* **Win/Loss Condition:** *Victory* setelah semua wave selesai dan *Game Over* jika pemain tersentuh musuh.

---

## 🛠️ Implementasi Teknis (Technical Highlights)

### 1. Transformasi Manual (Tanpa Rigidbody / NavMesh)

Pergerakan Player, Musuh, dan Peluru **tidak menggunakan** `AddForce` atau `NavMeshAgent`:

* **Translasi:**
  `position += direction * speed * deltaTime`
* **Rotasi:**
  Menggunakan `Mathf.Atan2` untuk menghadap ke arah kursor mouse.
* **Skala:**
  Efek *Breathing* menggunakan fungsi Sinus (`Mathf.Sin`) secara real-time.

### 2. Custom Shader Graph (URP)

Shader Graph buatan sendiri untuk efek visual:

* **Damage Blink:** Musuh berkedip merah saat terkena peluru dengan parameter `_FlashAmount` dan interpolasi warna (*Lerp*).

### 3. Animation Layering & Avatar Mask

* **Lower Body:** Animasi jalan/lari.
* **Upper Body:** Animasi menodong senjata dan recoil tembakan.

---

## 🧑‍💻 Cara Clone & Menjalankan Project (Tutorial Setup)

Ikuti langkah berikut agar project bisa dijalankan di **device masing-masing**.

### 1️⃣ Clone Repository

Pastikan **Git** sudah terinstall, lalu jalankan perintah berikut di terminal / command prompt:

```bash
git clone https://github.com/Patrickdwa/ProjectDeadCenter.git
```

Masuk ke folder project:

```bash
cd ProjectDeadCenter
```

---

### 2️⃣ Buka Project di Unity

1. Buka **Unity Hub**
2. Klik **Open Project**
3. Pilih folder `ProjectDeadCenter`
4. Pastikan menggunakan **Unity versi yang sesuai** (disarankan Unity 2022 LTS atau sesuai `ProjectSettings`)

---

### 3️⃣ Setup Render Pipeline (URP)

Jika shader tidak muncul dengan benar:

1. Buka `Project Settings`
2. Masuk ke **Graphics**
3. Pastikan **Universal Render Pipeline Asset (URP)** sudah ter-assign
4. Jika belum, buat URP Asset melalui:

   ```
   Assets → Create → Rendering → Universal Render Pipeline → Pipeline Asset
   ```

---

### 4️⃣ Jalankan Game

1. Buka scene utama di folder:

   ```
   /Assets/Scenes/MainScene.unity
   ```
2. Klik tombol **Play (▶️)** di Unity Editor
3. Game siap dimainkan 🎮

---

## 🕹️ Cara Bermain (Controls)

* **W, A, S, D** → Bergerak
* **Mouse Cursor** → Membidik
* **Klik Kiri (Left Click)** → Menembak

---

## 📂 Struktur Folder Unity

* `/Assets/Scripts` → Script C# (`PlayerController`, `EnemySpawner`, `GameLogic`, `Zombie`)
* `/Assets/Shaders` → Shader Graph (`ZombieBlinkShader`)
* `/Assets/Prefabs` → Prefab (`Zombie`, `FastZombie`, `Bullet`, `Player`)
* `/Assets/Animations` → Animation Controller & Avatar Mask

---

## 👥 Anggota Kelompok & Pembagian Tugas

| Nama Mahasiswa                  | Peran                  | Detail Tugas                               |
| ------------------------------- | ---------------------- | ------------------------------------------ |
| **Michael Purba**               | Programmer Core        | ManualMovement.cs, BulletSystem.cs         |
| **Patrick Nathan Wangsa**       | Game Logic & Spawner   | EnemySpawner.cs, Wave System, Game Manager |
| **Muhammad Kevin Gibran Lubis** | Shader & Visual Artist | Shader Graph, Lighting, Kamera             |
| **Michael Ginting**             | UI/UX & Dokumentasi    | UI Menu, Laporan & Video                   |

---

## 🏆 Credits & External Assets

* **3D Models:** Kenney Assets (CC0)
* **Sound Effects:** Random from Internet
* **BGM:**

  * Toby Fox – *Hall of Fame*
  * REPULSIVE – *1908 Vol. II*

---

## 📺 Video Demo

**[▶️ Tonton Video Demo DeadCenter](https://www.youtube.com/watch?v=4jUTGqS-ZM0)**

---

#UniversitasSumateraUtara #FasilkomTI #Unity #GrafikaKomputer #UAS
