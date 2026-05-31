# 📒 ContactsConsoleApp

A C# console application for managing contacts, built with a clean **3-tier architecture** using ADO.NET and SQL Server.

> 🎓 This project is part of the learning roadmap by **Dr. Mohammed Abu-hadhoud**
> **Course #18 — C# & Database**
> [ProgrammingAdvices.com](https://programmingadvices.com)

---

## 📌 Overview

ContactsConsoleApp is a simple yet well-structured contacts manager that demonstrates how to build a layered C# application connected to a SQL Server database. It covers core CRUD operations (Create, Read, Update, Delete) following software engineering best practices.

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
│     (clsContact.cs)                 │
└────────────────┬────────────────────┘
                 │
┌────────────────▼────────────────────┐
│     Data Access Layer               │
│     ContactsDataAccessLayer         │
│     (ContactData.cs)                │
└─────────────────────────────────────┘
```

| Layer | Project | Responsibility |
|---|---|---|
| Presentation | `ContactsConsoleApp` | User interaction via console |
| Business | `ContactsBussinessLayer` | Business rules, mode management (Add/Update) |
| Data Access | `ContactsDataAccessLayer` | SQL Server queries via ADO.NET |

---

## ✨ Features

- ➕ **Add** a new contact
- 🔍 **Find** a contact by ID
- ✏️ **Update** an existing contact
- 🗑️ **Delete** a contact
- 📋 **List** all contacts
- ✅ **Check** if a contact exists

---

## 🗂️ Project Structure

```
ContactsConsoleApp/
│
├── ContactsConsoleApp/                  # Presentation Layer
│   ├── Program.cs                       # Entry point & console operations
│   └── ContactsConsoleApp.slnx
│
├── ContactsBussinessLayer/              # Business Logic Layer
│   └── Contact.cs                       # clsContact with Save/Find/Delete logic
│
└── ContactsDataAccessLayer/             # Data Access Layer
    ├── ContactData.cs                   # Raw SQL operations (ADO.NET)
    └── clsDataAccessSettings.cs        # Connection string config
```

---

## 🗃️ Database

The app connects to a **SQL Server** database named `ContactsDB`.

### `Contacts` Table Schema

| Column | Type | Notes |
|---|---|---|
| `ContactID` | INT | Primary Key, Identity |
| `FirstName` | NVARCHAR | Required |
| `LastName` | NVARCHAR | Required |
| `Email` | NVARCHAR | Required |
| `Phone` | NVARCHAR | Required |
| `Address` | NVARCHAR | Required |
| `DateOfBirth` | DATETIME | Required |
| `CountryID` | INT | Foreign Key |
| `ImagePath` | NVARCHAR | Nullable |

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
   - Create the `Contacts` table using the schema above

3. **Configure the connection string**
   Open `ContactsDataAccessLayer/clsDataAccessSettings.cs` and update:
   ```csharp
   public static string ConnectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=YOUR_PASSWORD;";
   ```

4. **Build and run** the solution in Visual Studio

---

## 💡 Key Concepts Demonstrated

- **3-Tier Architecture** — clean separation of concerns
- **ADO.NET** — `SqlConnection`, `SqlCommand`, `SqlDataReader`, `DataTable`
- **OOP in C#** — encapsulation, private constructors, static factory methods
- **Enum-based mode switching** — `enMode.AddNew` vs `enMode.Update` for smart `Save()` logic
- **Parameterized queries** — protection against SQL injection

---

## 🎓 Course Reference

This project was built as part of:

| | |
|---|---|
| **Instructor** | Dr. Mohammed Abu-hadhoud |
| **Platform** | ProgrammingAdvices.com |
| **Course** | C# & Database — Course #18 |

Dr. Abu-hadhoud's roadmap provides a structured path for learning programming from the ground up through practical, real-world projects.
