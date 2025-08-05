# 📘 Setup Script Generator untuk .NET Core MVC 9

## 📌 1. Struktur Project
Pastikan project kamu punya folder seperti ini:

```/YourProject
│
├── DTOs/
├── Services/
├── Repositories/
├── Scripts/
│ ├── make-dto.sh
│ ├── make-service.sh
│ └── make-repository.sh
└── YourProject.csproj


> Semua script `.sh` disimpan di folder `Scripts/`.

```

## 📌 2. Beri Akses Eksekusi untuk Script

Secara default, file `.sh` tidak bisa dijalankan.  
Jadi beri akses eksekusi:

```bash
cd /var/www/dotnet/University/Scripts

chmod -R +x /var/www/dotnet/University/Scripts


