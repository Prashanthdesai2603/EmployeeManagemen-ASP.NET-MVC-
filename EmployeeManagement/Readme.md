# EmployeeManagement

Solution: `EmployeeManagement.sln`  
Target framework: .NET Framework 4.7.2  
Developed for Visual Studio 2022

Small ASP.NET MVC application to manage employees (Create, Read, Update, Delete). Uses classic ASP.NET MVC + Razor views. Example views live under `Views/Employee` (Index, Create, Edit, Details, Delete). The `Delete` view intentionally posts to the `Delete` action (not `DeleteConfirmed`) and includes an anti-forgery token.

## Table of contents
- Project overview
- Requirements
- Solution layout
- Quickstart (developer)
- Database setup
- CI: GitHub Actions (Windows) — build & package
- Deployment options (IIS / Azure App Service)
- Security & notes
- Contributing

## Project overview
- Purpose: Basic employee CRUD with server-rendered UI using Razor.  
- Key protections: POST actions use anti-forgery tokens. Ensure controller actions validate them with `[ValidateAntiForgeryToken]`.

## Requirements
- Visual Studio 2022 (or later) with the __ASP.NET and web development__ workload
- .NET Framework 4.7.2
- LocalDB/SQL Server for persistent storage (or alternate provider configured in `Web.config`)
- NuGet package restore

## Solution layout
- `EmployeeManagement.sln`
- `Controllers/EmployeeController.cs`
- `Models/Employee.cs`
- `Views/Employee/*.cshtml`
- `Views/Shared/_Layout.cshtml`
- `Web.config`

## Quickstart (developer)
1. Open the solution:
   - __File > Open > Project/Solution__ → select `EmployeeManagement.sln`.
2. Restore NuGet packages:
   - Right-click the solution in __Solution Explorer__ → __Restore NuGet Packages__
3. Build:
   - __Build > Build Solution__
4. Run:
   - __Debug > Start Debugging__ (F5) or __Debug > Start Without Debugging__ (Ctrl+F5)

## Database setup
If the project uses Entity Framework (EF6) with migrations:
1. Open __Tools > NuGet Package Manager > Package Manager Console__.
2. Select the web project as the Default Project in the console.
3. Run:
   - `Update-Database` (applies migrations)

If the project uses a static connection string, verify `Web.config` contains a correct connection string (example):





