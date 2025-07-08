# MyStore Backend

A modern e-commerce REST API backend built with ASP.NET Core 8.0.

Frontend repository: [MyStore](https://github.com/TecJoJo/MyStore)

## 🚀 Features

- **User Authentication** - JWT-based authentication and registration
- **Product Management** - CRUD operations for products
- **Shopping Cart** - Add, modify, and retrieve cart items
- **Secure API** - Role-based authorization and user validation
- **Database** - SQLite databases with Entity Framework Core
- **API Documentation** - Swagger/OpenAPI integration

## 🛠️ Technology Stack

- **ASP.NET Core 8.0** - Web API framework
- **Entity Framework Core** - ORM with SQLite
- **ASP.NET Core Identity** - Authentication and user management
- **JWT Bearer** - Token-based authentication
- **AutoMapper** - Object mapping
- **Swagger** - API documentation

## 🏗️ Project Structure

```
MyStore_backend/
├── Controllers/          # API controllers
├── Models/              # Domain models and DTOs
├── Repository/          # Data access layer
├── Data/               # Database contexts
├── Migrations/         # Database migrations
└── Program.cs          # Application entry point
```

## 🚀 Getting Started

1. **Prerequisites**
   - .NET 8.0 SDK
   - SQLite

2. **Clone and run**
   ```bash
   git clone <repository-url>
   cd MyStore_backend
   dotnet run
   ```

3. **Access the API**
   - API: `https://localhost:7xxx/api`
   - Swagger: `https://localhost:7xxx/swagger`

## 📋 API Endpoints

### Authentication
- `POST /api/Auth/register` - Register new user
- `POST /api/Auth/login` - Login and get JWT token

### Products
- `GET /api/Products` - Get all products
- `POST /api/Products` - Create product
- `PUT /api/Products/{id}` - Update product
- `DELETE /api/Products/{id}` - Delete product

### Shopping Cart
- `GET /api/Cart/cart` - Get cart items
- `POST /api/Cart/cartitem` - Add item to cart
- `PUT /api/Cart/cartitem/{id}` - Update cart item quantity

## 📄 License

```
Copyright 2025 Yao Lu

All rights reserved.

Unauthorized copying, reproduction, distribution, modification, or use 
of this code or any part of it is strictly prohibited without prior 
written permission from the copyright holder.
```