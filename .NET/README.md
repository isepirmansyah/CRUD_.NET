# MyWebApp - Implementasi .NET

Direktori ini berisi implementasi proyek penilaian menggunakan stack .NET, dibangun dengan ASP.NET Core Razor Pages.

## Fitur Utama yang Diimplementasikan:

### Otentikasi (Authentication)

- **Daftar Akun (Sign Up):** Pengguna dapat mendaftar akun baru.
- **Masuk (Sign In):** Pengguna terdaftar dapat masuk ke aplikasi.
- **Keluar (Sign Out):** Pengguna yang sudah masuk dapat keluar dari aplikasi.
- **Manajemen Akun (Account Management):** Pengguna dapat mengelola profil mereka, email, kata sandi, dll. (fungsionalitas dasar disediakan oleh ASP.NET Core Identity UI).

### Manajemen Post (CRUD)

- **Daftar semua post (dengan paginasi):** Menampilkan daftar semua post yang terpaginasi, mencakup Judul, Penulis, Waktu Dibuat, dan Aksi.
- **Lihat detail post:** Menampilkan konten lengkap dari post tertentu, beserta penulis dan cap waktu.
- **Buat post baru:** Pengguna yang sudah terotentikasi dapat membuat post baru, yang secara otomatis terkait dengan akun mereka.
- **Edit post yang sudah ada:** Pengguna yang sudah terotentikasi dapat mengedit _hanya post milik mereka sendiri_.
- **Hapus post:** Pengguna yang sudah terotentikasi dapat menghapus _hanya post milik mereka sendiri_.

## Persyaratan UI:

- **UI Bersih menggunakan komponen DaisyUI:** Antarmuka pengguna yang modern, responsif, dan bersih diimplementasikan menggunakan DaisyUI dan Tailwind CSS di semua halaman aplikasi utama (Home, CRUD Post).
- **Ikonografi:** Mengintegrasikan Font Awesome untuk penanda visual yang lebih baik dan meningkatkan pengalaman pengguna.

## Stack Teknologi:

- **Backend/Frontend Framework:** ASP.NET Core Razor Pages (untuk rendering sisi server)
- **Database:** Entity Framework Core (EF Core) dengan SQLite (untuk manajemen database berbasis file yang sederhana)
- **Otentikasi:** ASP.NET Core Identity (untuk manajemen pengguna yang kuat)
- **UI Framework:** DaisyUI (berbasis Tailwind CSS via CDN)
- **Ikon:** Font Awesome (via CDN)

## Cara Menginstal dan Menjalankan:

1.  **Prasyarat:**

    - [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) atau yang lebih baru sudah terinstal (Pastikan `dotnet --version` berfungsi).
    - Editor kode (seperti Visual Studio Code atau Visual Studio).

2.  **Navigasi ke direktori proyek .NET:**

    ```bash
    cd D:\Doc Kerja Forto\my-assessment-project\.NET\MyWebApp
    ```

3.  **Pulihkan paket NuGet:**

    ```bash
    dotnet restore
    ```

4.  **Instal Alat .NET Lokal:**
    Alat-alat ini diperlukan untuk migrasi Entity Framework dan scaffolding Identity. Alat ini diinstal secara lokal ke proyek untuk menghindari konflik `PATH` global.

    ```bash
    dotnet new tool-manifest # Jika ini membuat manifest di jalur root repositori yang salah, hapus dari root dan jalankan lagi.
    dotnet tool install dotnet-ef --local --version 8.0.0
    dotnet tool install dotnet-aspnet-codegenerator --local --version 8.0.0
    ```

5.  **Terapkan Migrasi Database:**
    Ini akan membuat file database SQLite `app.db` dan semua tabel yang diperlukan untuk Identity dan Post.

    ```bash
    dotnet ef migrations add InitialCreate # Anda mungkin mendapatkan peringatan jika migrasi sudah ada, tidak masalah.
    dotnet ef database update
    ```

6.  **Scaffold UI Identity (Opsional - File sudah disalin/dimodifikasi):**
    _Catatan:_ Karena masalah yang persisten dengan `dotnet aspnet-codegenerator`, halaman UI Identity disiapkan dengan membuat/memodifikasi file secara manual. Jika Anda perlu melakukan scaffolding ulang, gunakan:

    ```bash
    dotnet aspnet-codegenerator identity -dc MyWebApp.Data.ApplicationDbContext --files "Account.*" --force
    # Jika perintah di atas gagal, coba:
    # dotnet aspnet-codegenerator identity -dc MyWebApp.Data.ApplicationDbContext --files "Account.Manage;Account.Manage.ChangePassword;Account.Manage.Email;Account.Manage.ExternalLogins;Account.Manage.Index;Account.Manage.PersonalData;Account.Manage.SetPassword;Account.Manage.TwoFactorAuthentication" --force
    ```

    _(Ingatlah untuk menerapkan kembali styling DaisyUI secara manual setelah melakukan force-scaffolding file Identity.)_

7.  **Jalankan aplikasi:**
    ```bash
    dotnet run
    ```
    Atau untuk hot-reloading selama pengembangan:
    ```bash
    dotnet watch run
    ```
    Aplikasi biasanya akan dapat diakses di `https://localhost:7001` (atau port serupa yang ditampilkan di konsol).

## Catatan Khusus:

- **Razor Pages:** Dipilih karena kesederhanaan dan ketepatannya untuk operasi CRUD yang dirender di server, sangat cocok dengan persyaratan "aplikasi web sederhana".
- **Database:** SQLite digunakan untuk kemudahan pengaturan dan portabilitas dalam lingkungan pengujian. File database `app.db` akan dibuat di direktori `MyWebApp`.
- **UI/DaisyUI & Tailwind CSS:** Diintegrasikan melalui CDN untuk pengaturan dan demonstrasi cepat. Untuk lingkungan produksi, sangat disarankan untuk menginstalnya melalui npm dan menggunakan proses build (misalnya, PostCSS, Tailwind CLI) untuk mengkompilasi CSS.
- **Otentikasi & Otorisasi:** ASP.NET Core Identity menyediakan manajemen pengguna yang kuat. Logika otorisasi kustom memastikan pengguna hanya dapat mengedit atau menghapus post mereka sendiri.
- **Tantangan Codegenerator:** Selama pengembangan, ada masalah yang signifikan dengan `dotnet aspnet-codegenerator` yang tidak konsisten mengenali paket EF Core SQLite untuk scaffolding `razorpage`, atau tidak membuat semua file UI Identity secara langsung. Hal ini diatasi dengan pembuatan/modifikasi file manual dan langkah-langkah manajemen alat yang spesifik.
