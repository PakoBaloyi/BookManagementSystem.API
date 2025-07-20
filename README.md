# BookManagementSystem

A full-stack Blazor application for managing books using clean architecture, Dapper, and SQL Server.

## Prerequisites

- .NET SDK 8.0
- SQL Server (LocalDB or full version)
- Visual Studio 2022 or later (with Blazor support)

---

## Setup Instructions

### 1. 📦 Clone the Repository

```bash
git clone https://your-repo-url/BookManagementSystem.git

2. Create the Database and Schema
All SQL scripts are located in the Scripts folder.

▶️ Step-by-step:
Open SSMS

Connect to your local SQL Server instance — the connection string uses . (local)

Execute the following scripts in order:

**CreateDatabaseScript.sql**
Creates the BookManagementSystem database
Defines the [dbo].[Books] table and adds table data

**StoredProceduresScript.sql**
Adds all required stored procedures

[dbo].[AddBook]

[dbo].[UpdateBook]

etc.

**3. Set Startup Projects**
After the database is created and ready:

In Visual Studio:

Right-click the solution > Set Startup Projects

Select Multiple startup projects

BookManagementSystem.API → Start

BookManagementSystem.UI → Start

Run the solution both projects will launch:

BookManagementSystem.API hosts the backend

BookManagementSystem.UI (Blazor) is the frontend


**Configuration Notes**
The app uses Local SQL Server with connection string:

"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=BookManagementSystem;Trusted_Connection=True;"
}
Update the connection string if your SQL Server instance is not on ..
