# CSharpveSQL-1


# CSharp ADO.NET Repository Pattern Example

This project is a clean and well-structured **C# Console Application** that demonstrates how to access a SQL Server database using **ADO.NET**, applying **Repository Pattern** and **Layered Architecture** principles.

The project uses the **AdventureWorksDW2022** database and focuses on writing maintainable, testable, and professional data access code.

---

## 🧠 Project Purpose

The main goal of this project is to demonstrate:

- Clean ADO.NET usage with `SqlDataReader`
- Separation of concerns using layered architecture
- Repository Pattern implementation
- Proper SQL-to-C# object mapping
- Secure and parameterized SQL queries
- Configuration-based connection string management

This project is intentionally kept simple to focus on **architecture and best practices** rather than UI complexity.

---

## 🏗️ Project Architecture

CSharpADO.Net
│
├── Models
│ └── DimEmployee.cs
│
├── Data
│ └── DbConnectionFactory.cs
│
├── Repositories
│ ├── IEmployeeRepository.cs
│ └── EmployeeRepository.cs
│
└── Program.cs


How to Run

Clone the repository

Restore the AdventureWorksDW2022 database in SQL Server (download link: https://learn.microsoft.com/en-us/sql/samples/adventureworks-install-configure?view=sql-server-ver17&tabs=ssms)

Update the connection string in App.config

Build and run the project
