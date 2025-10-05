MillionLuxury - Technical Test Skeleton
Generated: 2025-10-02T15:25:30.879306

This archive contains a ready-to-use skeleton and scripts to scaffold a .NET solution implementing:
- Hexagonal / Clean architecture folders (Domain, Application, Infrastructure, Api)
- Sample Domain entity, repository interface, Infrastructure repository sketch
- A minimal Web API Program.cs and a Properties controller
- nUnit test project placeholder
- Front folder placeholder for React app
- Scripts to scaffold the actual .NET projects using dotnet CLI and to overwrite files in place

Requirements: .NET 6 SDK or later, Node.js (for Front), Docker (optional).

Instructions:
1. Unzip this archive.
2. Run the script create_solution.sh (Linux/macOS) or create_solution.ps1 (Windows PowerShell).
   These scripts will create the dotnet projects and copy the template files into the created projects.
3. Open Million.Luxury.sln in Visual Studio or VS Code. Run 'dotnet restore' then 'dotnet build'.
4. To run API locally: dotnet run --project src/Million.Luxury.Api
5. Front: see front/README_front.md
