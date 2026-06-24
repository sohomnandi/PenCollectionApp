# PenCollectionApp

PenCollectionApp is a simple .NET desktop application for managing a personal pen collection. The project contains a Windows Forms UI (Form1.cs) and targets .NET 10.

## Features
- Basic UI to view and manage pen entries
- Save and load collection data (implementation-specific)

## Requirements
- .NET 10 SDK
- Microsoft Visual Studio 2026 (or later) or any IDE that supports .NET 10 projects

## Database / Backend
The application uses a SQL Server backend for storing pen collection data. If you don't already have a database, create one in SQL Server (for example, named `PenCollectionDb`) and update the application's connection string (App.config, Settings, or other config location) to point to your server and database.

Quick example using sqlcmd or SSMS to create a database and a simple table:

   CREATE DATABASE PenCollectionDb;
   GO
   USE PenCollectionDb;
   GO
   CREATE TABLE Pens (
	   Id INT IDENTITY(1,1) PRIMARY KEY,
	   Make NVARCHAR(200) NOT NULL,
	   Model NVARCHAR(200) NULL,
	   Color NVARCHAR(100) NULL,
	   Notes NVARCHAR(MAX) NULL
   );

If the repository includes a SQL script or migration files, run those instead of the example above. Ensure the connection string is secured and, when deploying, use an appropriate authentication method (Windows Auth or SQL Auth) for your environment.

## Getting started
1. Clone the repository:

   git clone https://github.com/sohomnandi/PenCollectionApp

2. Open the solution file: `PenCollectionApp.slnx` in Visual Studio.
3. Build the solution (Build -> Build Solution) or run from the IDE.

Alternatively, from a command line with the .NET 10 SDK installed:

   dotnet build PenCollectionApp.slnx
   dotnet run --project PeCollectionApp/PeCollectionApp.csproj

## Project structure
- PeCollectionApp/ - main WinForms project (contains Form1.cs)
- PenCollectionApp.slnx - solution file

## Contributing
- Open issues or pull requests on the repository: https://github.com/sohomnandi/PenCollectionApp

