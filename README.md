# UserManagementSharding

A simple ASP.NET Core Web API project demonstrating data sharding with a functional frontend.

---

## Project Overview

This project showcases a basic user management system with:
- ASP.NET Core Web API backend
- Simple HTML frontend
- Data sharding across two SQLite databases: Even User.Id goes to AppDbContext1, Odd User.Id goes to AppDbContext2
- Features include: Add user, View all users, Delete all users, Delete user by ID

---

## Folder Structure

Controllers/ -> UsersController.cs  
Data/ -> AppDbContext1.cs, AppDbContext2.cs, ShardManager.cs  
Models/ -> User.cs  
Services/ -> UserService.cs  
index.html  
Program.cs

---

## Features

1. Data Sharding Logic: Users are split between two databases based on their ID (even/odd)  
2. Functional Frontend: Add users via a form, View all users, Delete users by ID or delete all  
3. CORS Support: Allows frontend hosted on a different origin to interact with the API  

---

## How to Run

1. Clone the repository: git clone https://github.com/44ha/UserManagementSharding.git  
2. Navigate into the folder: cd UserManagementSharding  
3. Open the project in Visual Studio or VS Code  
4. Run the project using: dotnet run  
5. The backend API will be hosted at http://localhost:5261  
6. Open index.html in your browser to access the frontend  

---

## Endpoints

GET /api/users -> Get all users  
POST /api/users -> Add a new user  
DELETE /api/users -> Delete all users  
DELETE /api/users/{id} -> Delete a user by ID  

---

## Data Sharding Logic

- Even IDs go to AppDbContext1  
- Odd IDs go to AppDbContext2  
- ShardManager decides which database a user is saved to or retrieved from  
- When fetching all users, results from both databases are combined  

---

## Technologies Used

- ASP.NET Core 7 (Web API)  
- Entity Framework Core  
- SQLite (two databases for sharding)  
- HTML frontend using Fetch API for asynchronous requests

---

## Notes

- The frontend fetches data from the API and updates dynamically  
- CORS is enabled to allow local frontend requests  
- This project is for educational and portfolio purposes to demonstrate simple data sharding  
