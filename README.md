Roshtaty - Pharmacy Management System

📌 Project Overview

Roshtaty is a pharmacy management system built using .NET 8 with Clean Architecture. It allows users to search for medications using active ingredients or trade names, view alternative medications, and manage prescriptions efficiently. The system is integrated with SQL Server as the database.

🚀 Features

Search medications by active ingredient or trade name.

View alternative medications sorted by price, shelf life, and efficacy.

Manage prescriptions with patient and dosage details.

Database management with Entity Framework Core.

Scalable and modular Clean Architecture implementation.

🛠️ Technologies Used

.NET 8 (ASP.NET Core Web API)

SQL Server (Database Management)

Entity Framework Core (Code-First Migrations)

Clean Architecture (Modular and Scalable Design)

📂 Project Structure
Roshtaty
│── Controllers        # API Controllers (Prescriptions, Active Ingredients, etc.)
│── DTOs               # Data Transfer Objects
│── Helpers            # Utility classes
│── Services           # Business logic layer
│── Roshtaty.Core      # Core entities and domain logic
│── Roshtaty.Repository # Data access layer (EF Core, Repositories)
│── appsettings.json   # Configuration settings
│── Program.cs         # Entry point of the application


🗄️ Database Schema

The project includes the following main tables:

Prescriptions (Id, PatientName, PhoneNumber, PrescriptionDate, Active_IngredientId, etc.)

Active_Ingredients (Id, ActiveIngredientName, Strength, StrengthUnit, DiseaseId)

Diseases (Id, DiseaseName, CategoryId)

TradeNames (Id, TradeName, Active_IngredientId, PublicPrice, ShelfLife, etc.)

⚙️ Setup & Installation

1️⃣ Clone the Repository

git clone https://github.com/your-username/Roshtaty.git
cd Roshtaty

2️⃣ Configure Database Connection

Modify appsettings.json to match your SQL Server configuration:

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=RoshtatyDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}

3️⃣ Apply Migrations & Update Database

dotnet ef migrations add InitialCreate
dotnet ef database update

4️⃣ Run the Project

dotnet run

The API will be available at: https://localhost:5001 or http://localhost:5000

📌 API Endpoints

Active Ingredients

GET /api/ActiveIngredients - Get all active ingredients

POST /api/ActiveIngredients - Add a new active ingredient

Trade Names

GET /api/TradeNames - Get all trade names

GET /api/TradeNames/{id} - Get a specific trade name by ID

Prescriptions

POST /api/Prescriptions - Create a new prescription

GET /api/Prescriptions/{id} - Get prescription details

📌 Contributing

Feel free to fork this repository, create a feature branch, and submit a pull request. Contributions are welcome! 😊

📜 License

This project is licensed under the MIT License.
