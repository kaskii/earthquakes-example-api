# Earthquake Example API

An example project of ASP.NET Core Web API Application, using Entity Framework (Sql Server) and AutoMapper. This project uses .NET 8.

### What is included

- Entity Framework with Sql Server and migrations (inside WebApi project)
- AutoMapper to map Entity <-> DTO
- Swagger
- Some dummy data from kaggle.com as .csv file that can be seeded to database via API route

### How to run

1. Clone the repo
2. Open the solution
3. Change `appsettings.Development.json` file ConnectionString
4. `cd Earthquakes.WebApi`
5. `dotnet ef database update`
6. Start the project
7. Open swagger
8. Call `/api/data/update-database` endpoint once to seed the database
