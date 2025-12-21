# AES256EncryptDecryptHIPAA
Desktop application for Linux, Windows, Mac to encrypt and decrypt payload recommended by HIPAA using AES 256, IV 96 and Tag 128 bit.
# Bhandarge Soft CryptoDesk

**Bhandarge Soft CryptoDesk** is a cross-platform desktop utility built with **Avalonia UI** and **.NET**, designed to encrypt and decrypt text using **AES-256-GCM**.  
It is intended for **internal and system-specific use**, ensuring compatibility with an existing encryption workflow.

---

## ✨ Features

- 🔐 AES-256-GCM encryption & decryption
- 🧠 Fully in-memory (no files, no persistence)
- 🖥️ Native desktop UI (Windows, macOS, Linux)
- 🎛️ Modern Fluent-style UI
- 🔁 Encrypt / Decrypt toggle switch
- 📦 Single executable build for Windows
- 🔑 Plain-text Key & IV input (system-compatible)

---

## 🧱 Technology Stack

- **.NET** (net8 / net10 preview)
- **Avalonia UI** (Fluent Theme)
- **C#**
- **AES-GCM** (`System.Security.Cryptography`)

---

## 📋 Input Requirements

| Field | Requirement |
|------|------------|
| Key | Exactly **32 characters** (256-bit, UTF-8) |
| IV  | Exactly **12 characters** (96-bit, UTF-8) |
| Text | Any UTF-8 text |

> ⚠️ This tool mirrors an existing system’s encryption logic.  
> Key and IV are treated as **plain text**, not Base64.

---

## ▶️ Running the App (Development)

```bash
dotnet restore
dotnet run


🪟 Build Windows EXE (Recommended)

Generate a self-contained Windows executable:

dotnet publish -c Release -r win-x64 --self-contained true


The executable will be located at:

bin/Release/netX.X/win-x64/publish/


Copy the entire publish folder to another location and run the .exe.

🍎 macOS Build
dotnet publish -c Release -r osx-arm64 --self-contained true


(Requires macOS machine)

🐧 Linux Build
dotnet publish -c Release -r linux-x64 --self-contained true


Make executable if required:

chmod +x CryptoDesk_Bhandarge_Soft

🎨 UI & Design

Fluent-style modern desktop layout

Card-based sections

Toggle switch for Encrypt / Decrypt

Clean, minimal, Windows 11–inspired look

🔒 Security Notes

Uses AES-256-GCM with authentication tag

Intended for controlled/internal use

Key & IV reuse follows legacy system compatibility

Not designed as a general-purpose encryption tool

📦 Distribution Notes

Windows SmartScreen may warn for unsigned EXE

Antivirus software may flag crypto utilities

Code signing recommended for production distribution

🏢 Author

Bhandarge Softwares

Internal desktop utility developed for system-specific cryptographic operations.

📄 License

Internal / Proprietary
(Not intended for public cryptographic use)


