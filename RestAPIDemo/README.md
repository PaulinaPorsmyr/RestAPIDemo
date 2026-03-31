# RestAPIDemo

A clean REST API demonstrating modern .NET practices with Entity Framework Core, featuring a well-structured data model with relationships and seed data.

## 🎯 Overview

RestAPIDemo is a RESTful API built with .NET 10 that manages people, their interests, and related resources. It showcases core concepts including relational data modeling, Entity Framework Core configuration, and API design patterns.

## 🏗️ Architecture & Data Model

![Database Diagram](database-diagram.png)

The project uses a **relational database design** with the following structure:

- **Person**: Core entity representing individuals with contact information
- **Interest**: Predefined interests/hobbies
- **PersonInterest**: Junction table enabling many-to-many relationships between Person and Interest
- **Link**: Resources/URLs associated with specific PersonInterest combinations

## 🛠️ Tech Stack

- **.NET 10** – Latest framework for performance and features
- **C# 14** – Modern language features
- **Entity Framework Core** – ORM for data access
- **ASP.NET Core** – Web framework

## 🚀 Getting Started

### Prerequisites
- .NET 10 SDK
- Visual Studio 2026

### Installation

1. Clone the repository
2. Run `dotnet restore`
3. Run `dotnet ef database update`
4. Run `dotnet run`

The API will be available at `https://localhost:5001`

## 📚 API Endpoints

- `GET /api/persons` – Get all persons
- `POST /api/persons` – Create new person
- `GET /api/interests` – Get all interests
- `GET /api/personinterests` – Get all person-interest associations

## 🌱 Seed Data

The database includes 10 sample persons and 10 interests with realistic associations.



## 💡 Future Improvements

- Add pagination
- Implement DTOs
- Add validation
- Add Swagger/OpenAPI documentation
- Add unit tests
- Add authentication

---

**Author**: Paulina Porsmyr