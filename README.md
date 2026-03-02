# For Garden's Sake

A garden management web app for tracking your plants, beds, and gardening activity.

## Features

- **Plant Catalog** – browse and search plants by type, sun/water requirements, and start method
- **Garden Beds** – create and manage beds, add and remove plant placements
- **Guided Layout** – get suggested plant arrangements for a bed based on a goal
- **Gardening Log** – record activity entries (watering, fertilizing, notes) with full history
- **Dashboard** – overview of your beds and recent activity
- **User Accounts** – register and log in via ASP.NET Core Identity

## Tech Stack

| Layer     | Technology                    |
|-----------|-------------------------------|
| Framework | ASP.NET Core MVC (.NET 10)    |
| ORM       | Entity Framework Core 10      |
| Database  | SQLite                        |
| Auth      | ASP.NET Core Identity         |
| UI        | Razor Views + Bootstrap       |

## Project Structure

The solution follows Clean Architecture:

```
src/
  GardenKeeper.Domain/         # Entities & enums (no external dependencies)
  GardenKeeper.Application/    # Services, repository interfaces, ViewModels
  GardenKeeper.Infrastructure/ # EF Core, SQLite, Identity, repository implementations
  GardenKeeper.Web/            # MVC controllers & Razor views
tests/
  GardenKeeper.Tests/          # Unit tests
```

## Getting Started

**Prerequisites:** [.NET 10 SDK](https://dotnet.microsoft.com/download)

```bash
git clone <repo-url>
cd ForGardensSake
dotnet run --project src/GardenKeeper.Web
```

The app automatically applies migrations and seeds the database on first run. Open `https://localhost:5001` in your browser.
