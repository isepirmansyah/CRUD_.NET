# Aplikasi Web Sederhana - Implementasi .NET

Repositori ini berisi solusi untuk Tes Penilaian Software Engineer, dengan fokus pada implementasi .NET dari aplikasi web sederhana dengan fitur Otentikasi dan Manajemen Post (CRUD).

## Struktur Proyek:

my-assessment-project/
├── .Net/ # Berisi aplikasi ASP.NET Core Razor Pages
│ ├── MyWebApp/ # Proyek aplikasi web .NET utama
│ ├── README.md # README spesifik untuk stack .NET
│ └── Dockerfile # Dockerfile untuk mengkontainerisasi aplikasi .NET
├── docker-compose.yml # Setup Docker Compose untuk menjalankan semua layanan (saat ini hanya .NET)
└── README.md # File README utama repositori ini

## Fitur Utama:

### Otentikasi (Authentication)

- **Daftar Akun (Sign Up):** Pendaftaran pengguna.
- **Masuk (Sign In):** Masuk pengguna.
- **Keluar (Sign Out):** Keluar pengguna.
- **Manajemen Akun:** Pengguna dapat mengelola detail profil, mengubah kata sandi, dll.

### Manajemen Post (CRUD)

- **Daftar semua post (dengan paginasi):** Menampilkan daftar post yang terpaginasi.
- **Lihat detail post:** Melihat konten lengkap dan detail post tertentu.
- **Buat post baru:** Pengguna yang terotentikasi dapat membuat post baru.
- **Edit post yang sudah ada:** Pengguna yang terotentikasi hanya dapat memodifikasi _post mereka sendiri_.
- **Hapus post:** Pengguna yang terotentikasi hanya dapat menghapus _post mereka sendiri_.

## Persyaratan UI:

- Mengimplementasikan antarmuka pengguna yang bersih dan responsif menggunakan komponen **DaisyUI** (di atas **Tailwind CSS**) untuk tampilan dan nuansa yang modern.
- Menambahkan **Font Awesome** untuk ikon yang relevan guna meningkatkan pengalaman pengguna.

## Ikhtisar Stack Teknologi:

Proyek ini menunjukkan kemahiran dengan stack **.NET**, secara khusus:

- **Backend/Frontend:** ASP.NET Core Razor Pages
- **Database:** Entity Framework Core dengan SQLite
- **Otentikasi:** ASP.NET Core Identity
- **UI:** DaisyUI, Tailwind CSS, Font Awesome

_(Jika Anda mengimplementasikan stack lain, mereka akan dicantumkan di sini beserta teknologi masing-masing.)_

## Cara Menginstal dan Menjalankan:

### A. Menjalankan Aplikasi .NET Secara Lokal (Native):

1.  **Prasyarat:**

    - [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) atau yang lebih baru sudah terinstal.
    - Editor kode (misalnya, Visual Studio Code, Visual Studio).

2.  **Navigasi ke direktori proyek .NET:**

    ```bash
    cd .Net/MyWebApp
    ```

3.  **Lakukan pengaturan awal (jika belum pernah dilakukan):**

    ```bash
    dotnet restore
    dotnet new tool-manifest # Membuat .config/dotnet-tools.json jika belum ada
    dotnet tool install dotnet-ef --local --version 8.0.0
    dotnet tool install dotnet-aspnet-codegenerator --local --version 8.0.0
    dotnet ef database update
    ```

    _Catatan: `dotnet ef migrations add InitialCreate` telah dijalankan untuk menghasilkan migrasi awal. Hanya `dotnet ef database update` yang diperlukan untuk menjalankan selanjutnya di lingkungan baru._

4.  **Jalankan aplikasi:**
    ```bash
    dotnet watch run
    ```
    Aplikasi akan diluncurkan, biasanya dapat diakses di `https://localhost:7001` (atau port serupa yang ditampilkan di konsol).

### B. Menjalankan dengan Docker Compose (Bonus):

Opsi ini memungkinkan menjalankan aplikasi dalam lingkungan ter-container.

1.  **Prasyarat:**

    - [Docker Desktop](https://www.docker.com/products/docker-desktop/) sudah terinstal dan berjalan.

2.  **Navigasi ke root repositori ini:**

    ```bash
    cd my-assessment-project
    ```

3.  **Bangun dan jalankan layanan:**

    ```bash
    docker-compose up --build -d
    ```

    - Flag `-d` menjalankan container dalam mode detached (di latar belakang).
    - Flag `--build` memastikan image Docker dibangun ulang dari Dockerfile mereka.

4.  **Akses aplikasi:**
    Aplikasi .NET akan dapat diakses di `http://localhost:8080`.

5.  **Untuk menghentikan dan menghapus container:**
    ```bash
    docker-compose down
    ```

## Catatan Khusus & Pilihan Desain:

- **Konsistensi Antar Stack:** Implementasi ini menunjukkan fitur yang diperlukan menggunakan stack .NET. Meskipun stack lain tidak secara eksplisit disediakan dalam prompt, struktur repositori disiapkan untuk inklusi mereka.
- **Performa & Pemeliharaan:** ASP.NET Core Razor Pages menawarkan pendekatan yang produktif dan berkinerja tinggi untuk aplikasi web yang dirender di server, menyeimbangkan kemudahan pengembangan dengan fitur-fitur modern.
- **Modularitas:** Proyek ini distrukturkan dengan pemisahan tanggung jawab yang jelas (Model, Data, Pages).
- **Kustomisasi UI:** DaisyUI menyediakan pustaka komponen yang mempercepat pengembangan UI tanpa memerlukan CSS kustom yang kompleks. Ikon dari Font Awesome meningkatkan kegunaan.
- **Setup Lingkungan Pengembangan Lokal:** Penggunaan alat .NET lokal (`dotnet-ef`, `dotnet-aspnet-codegenerator`) memastikan konsistensi lingkungan pengembangan dan menghindari konflik alat global.
- **Otorisasi:** Semua fitur Manajemen Post (`Index`, `Details`, `Create`, `Edit`, `Delete`) dilindungi oleh otentikasi (`[Authorize]`). Selain itu, operasi `Edit` dan `Delete` mencakup logika untuk memastikan hanya penulis asli post yang dapat memodifikasi atau menghapusnya.
