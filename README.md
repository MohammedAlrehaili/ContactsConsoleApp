# 📒 ContactsConsoleApp

A C# console application for managing **contacts and countries**, built with a clean **3-tier architecture** using ADO.NET and SQL Server.

> 🎓 This project is part of the learning roadmap by **Dr. Mohammed Abu-hadhoud**
> **Course #18 — C# & Database**
> [ProgrammingAdvices.com](https://programmingadvices.com)

---

## 📌 Overview

ContactsConsoleApp is a structured contacts manager that demonstrates how to build a layered C# application connected to a SQL Server database. It covers full CRUD operations for two entities — **Contacts** and **Countries** — following software engineering best practices.

---

## 🏗️ Architecture

The project follows a **3-Tier Architecture**:

```
┌─────────────────────────────────────┐
│     Presentation Layer              │
│     ContactsConsoleApp              │
│     (Program.cs - Console UI)       │
└────────────────┬────────────────────┘
                 │
┌────────────────▼────────────────────┐
│     Business Logic Layer            │
│     ContactsBussinessLayer          │
│     (clsContact.cs / clsCountry.cs) │
└────────────────┬────────────────────┘
                 │
┌────────────────▼────────────────────┐
│     Data Access Layer               │
│     ContactsDataAccessLayer         │
│     (ContactData.cs/CountryData.cs) │
└─────────────────────────────────────┘
```

| Layer | Project | Responsibility |
|---|---|---|
| Presentation | `ContactsConsoleApp` | User interaction via console |
| Business | `ContactsBussinessLayer` | Business rules, mode management (Add/Update) |
| Data Access | `ContactsDataAccessLayer` | SQL Server queries via ADO.NET |

---

## ✨ Features

### 👤 Contacts
- ➕ Add a new contact
- 🔍 Find a contact by ID
- ✏️ Update an existing contact
- 🗑️ Delete a contact
- 📋 List all contacts
- ✅ Check if a contact exists

### 🌍 Countries
- ➕ Add a new country
- 🔍 Find a country by ID or name
- ✏️ Update an existing country
- 🗑️ Delete a country
- 📋 List all countries
- ✅ Check if a country exists (by ID or name)

---

## 🗂️ Project Structure

```
ContactsConsoleApp/
│
├── ContactsConsoleApp/                  # Presentation Layer
│   └── Program.cs                       # Entry point & console operations
│
├── ContactsBussinessLayer/              # Business Logic Layer
│   ├── Contact.cs                       # clsContact — contacts business logic
│   └── Country.cs                       # clsCountry — countries business logic
│
└── ContactsDataAccessLayer/             # Data Access Layer
    ├── ContactData.cs                   # SQL operations for Contacts
    ├── CountryData.cs                   # SQL operations for Countries
    └── clsDataAccessSettings.cs        # Connection string config
```

---

## 🗃️ Database

The app connects to a **SQL Server** database named `ContactsDB`.

### `Contacts` Table

| Column | Type | Notes |
|---|---|---|
| `ContactID` | INT | Primary Key, Identity |
| `FirstName` | NVARCHAR | Required |
| `LastName` | NVARCHAR | Required |
| `Email` | NVARCHAR | Required |
| `Phone` | NVARCHAR | Required |
| `Address` | NVARCHAR | Required |
| `DateOfBirth` | DATETIME | Required |
| `CountryID` | INT | Foreign Key → Countries |
| `ImagePath` | NVARCHAR | Nullable |

### `Countries` Table

| Column | Type | Notes |
|---|---|---|
| `CountryID` | INT | Primary Key, Identity |
| `CountryName` | NVARCHAR | Required |
| `Code` | NVARCHAR | Country code (e.g. SA, AE) |
| `PhoneCode` | NVARCHAR | Dial code (e.g. 966, 971) |

---

## ⚙️ Setup & Configuration

### Prerequisites

- Visual Studio 2019+ or any C# IDE
- SQL Server (local instance)
- .NET Framework

### Steps

1. **Clone the repository**
   ```bash
   git clone https://github.com/MohammedAlrehaili/ContactsConsoleApp.git
   ```

2. **Create the database**
   - Open SQL Server Management Studio (SSMS)
   - Create a database named `ContactsDB`
   - Create the `Countries` and `Contacts` tables using the schemas above

3. **Configure the connection string**
   Open `ContactsDataAccessLayer/clsDataAccessSettings.cs` and update:
   ```csharp
   public static string ConnectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=YOUR_PASSWORD;";
   ```

4. **Build and run** the solution in Visual Studio

---

## 💡 Key Concepts Demonstrated

- **3-Tier Architecture** — clean separation of concerns across three layers
- **ADO.NET** — `SqlConnection`, `SqlCommand`, `SqlDataReader`, `DataTable`
- **OOP in C#** — encapsulation, private constructors, static factory methods, method overloading
- **Enum-based mode switching** — `enMode.AddNew` vs `enMode.Update` for smart `Save()` logic
- **Parameterized queries** — protection against SQL injection
- **Reusable pattern** — the same architecture pattern applied consistently to both `Contact` and `Country` entities

---

## 🎓 Course Reference

This project was built as part of:

| | |
|---|---|
| **Instructor** | Dr. Mohammed Abu-hadhoud |
| **Platform** | ProgrammingAdvices.com |
| **Course** | C# & Database — Course #18 |

Dr. Abu-hadhoud's roadmap provides a structured path for learning programming from the ground up through practical, real-world projects.

---

## 👨‍💻 Author

**Mohammed Alrehaili**
- GitHub: [@MohammedAlrehaili](https://github.com/MohammedAlrehaili)

---

## 📄 License

This project is open source and available for educational purposes.
