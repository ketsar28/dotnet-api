# 🚀 .NET API Development Portfolio

<div align="center">

![.NET](https://img.shields.io/badge/.NET-6.0-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![Dapper](https://img.shields.io/badge/Dapper-ORM-orange?style=for-the-badge)
![MySQL](https://img.shields.io/badge/MySQL-4479A1?style=for-the-badge&logo=mysql&logoColor=white)

**A comprehensive collection of .NET API projects demonstrating modern backend development practices**

</div>

---

## 📋 Table of Contents

- [Overview](#-overview)
- [Projects](#-projects)
- [Technologies](#-technologies)
- [Getting Started](#-getting-started)
- [Project Structure](#-project-structure)
- [Author](#-author)
- [Connect With Me](#-connect-with-me)
- [License](#-license)

---

## 📖 Overview

This repository showcases my expertise in .NET backend development, featuring multiple projects that demonstrate proficiency in:

- **RESTful API Development** using ASP.NET Core
- **Entity Framework Core** for ORM and database management
- **Dapper** for lightweight data access
- **MySQL** database integration
- **Clean Architecture** and best practices
- **Dependency Injection** and modern .NET patterns

Each project is designed to demonstrate different aspects of .NET development, from fundamental concepts to advanced implementations.

---

## 🎯 Projects

### 1. **ClassicShopAPI**
A full-featured e-commerce API built with ASP.NET Core Web API.

**Features:**
- RESTful API endpoints for shop management
- Entity Framework Core integration
- MySQL database support
- Swagger/OpenAPI documentation
- Clean architecture implementation

**Tech Stack:**
- .NET 6.0
- Entity Framework Core 7.0
- MySQL.EntityFrameworkCore
- Swashbuckle (Swagger)

---

### 2. **EFUpskilling**
A comprehensive Entity Framework Core learning project demonstrating advanced ORM patterns.

**Features:**
- User, Product, and Purchase management
- Service layer implementation
- Entity Framework migrations
- Repository pattern
- CRUD operations

**Tech Stack:**
- .NET 6.0
- Entity Framework Core
- MySQL

---

### 3. **DapperFundamental**
A console application exploring Dapper micro-ORM fundamentals.

**Features:**
- Lightweight data access
- Raw SQL execution
- Performance-optimized queries
- MySQL integration

**Tech Stack:**
- .NET 6.0
- Dapper
- MySQL.Data

---

### 4. **DotnetUpskilling**
A foundational .NET project for learning and experimenting with core .NET concepts.

**Tech Stack:**
- .NET 6.0

---

## 🛠 Technologies

<div align="center">

| Category | Technologies |
|----------|-------------|
| **Framework** | .NET 6.0 |
| **Language** | C# 10 |
| **ORM** | Entity Framework Core 7.0, Dapper |
| **Database** | MySQL |
| **API Documentation** | Swagger/OpenAPI |
| **Architecture** | Clean Architecture, Repository Pattern |

</div>

---

## 🚀 Getting Started

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later
- [MySQL Server](https://dev.mysql.com/downloads/mysql/)
- IDE: [Visual Studio](https://visualstudio.microsoft.com/) / [Visual Studio Code](https://code.visualstudio.com/) / [Rider](https://www.jetbrains.com/rider/)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/ketsar28/dotnet-api.git
   cd dotnet-api
   ```

2. **Navigate to desired project**
   ```bash
   cd ClassicShopAPI/ClassicShopAPI
   # or
   cd EFUpskilling/EFUpskilling
   # or
   cd DapperFundamental/DapperFundamental
   ```

3. **Restore dependencies**
   ```bash
   dotnet restore
   ```

4. **Update database connection string**
   - Configure your MySQL connection string in `appsettings.json` (for Web APIs)
   - Or update connection strings in the respective configuration files

5. **Run migrations** (for EF Core projects)
   ```bash
   dotnet ef database update
   ```

6. **Run the application**
   ```bash
   dotnet run
   ```

### Running ClassicShopAPI

```bash
cd ClassicShopAPI/ClassicShopAPI
dotnet run
```

Access Swagger UI at: `https://localhost:5001/swagger` (or the configured port)

---

## 📁 Project Structure

```
dotnet-api/
├── ClassicShopAPI/          # ASP.NET Core Web API project
│   └── ClassicShopAPI/      # Main API project files
├── EFUpskilling/            # Entity Framework Core learning project
│   └── EFUpskilling/        # EF Core implementations
├── DapperFundamental/       # Dapper micro-ORM project
│   └── DapperFundamental/   # Dapper implementations
├── DotnetUpskilling/        # .NET fundamentals project
│   └── DotnetUpskilling/    # Core .NET concepts
└── README.md                # This file
```

---

## 👨‍💻 Author

**Muhammad Ketsar Ali Abi Wahid (Ketsar)**

I'm a Software Engineering graduate and technology enthusiast passionate about building scalable backend solutions with .NET. This repository represents my journey in mastering modern .NET development practices and showcases my commitment to writing clean, maintainable code.

- 🎓 Graduate in Software Engineering
- 💼 Specializing in .NET Backend Development
- 🌱 Constantly learning and exploring new technologies
- 🤝 Open to collaboration and innovative projects

---

## 🌐 Connect With Me

<div align="center">

[![GitHub](https://img.shields.io/badge/GitHub-ketsar28-181717?style=for-the-badge&logo=github)](https://github.com/ketsar28/)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-ketsarali-0A66C2?style=for-the-badge&logo=linkedin)](https://www.linkedin.com/in/ketsarali/)
[![Instagram](https://img.shields.io/badge/Instagram-ketsar.aaw-E4405F?style=for-the-badge&logo=instagram&logoColor=white)](https://www.instagram.com/ketsar.aaw/)

[![HuggingFace](https://img.shields.io/badge/HuggingFace-ketsar-FFD21E?style=for-the-badge&logo=huggingface&logoColor=black)](https://huggingface.co/ketsar)
[![Streamlit](https://img.shields.io/badge/Streamlit-ketsar28-FF4B4B?style=for-the-badge&logo=streamlit&logoColor=white)](https://share.streamlit.io/user/ketsar28)
[![WhatsApp](https://img.shields.io/badge/WhatsApp-Contact%20Me-25D366?style=for-the-badge&logo=whatsapp&logoColor=white)](https://api.whatsapp.com/send/?phone=6285155343380&text=Hello%20Ketsar!)

</div>

---

## 📄 License

```
Copyright © 2024 Muhammad Ketsar Ali Abi Wahid (Ketsar)

All rights reserved.

This project and its contents are the intellectual property of Muhammad Ketsar Ali Abi Wahid.
Unauthorized copying, modification, distribution, or use of this software,
via any medium, is strictly prohibited without explicit permission from the author.

For permissions or inquiries, please contact via the social media links above.
```

---

<div align="center">

**⭐ If you find this repository helpful, please consider giving it a star!**

Made with ❤️ by [Ketsar](https://github.com/ketsar28)

</div>
