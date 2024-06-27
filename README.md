# Startup News Management System

The **Startup News Management System** is designed to manage and organize news articles, categories, and user comments for a startup-focused news platform. The project is built using ASP.NET MVC for the frontend, ASP.NET Web API for backend services, and Entity Framework for ORM.

## Overview

The Startup News Management System facilitates the management of news articles, categories, and user comments for startups. It provides comprehensive Web API endpoints for CRUD (Create, Read, Update, Delete) operations on articles, categories, and comments. The system is built with ASP.NET MVC and supports user-specific and category-specific content management.

## Running this Project

### Prerequisites

- Visual Studio 2019 or later
- .NET Framework 4.8

### Setup Steps

1. **Clone the Repository:**
    ```bash
    git clone https://github.com/your-username/Startup-News-Management-System.git
    cd Startup-News-Management-System
    ```

2. **Open the Project:**
    - Open the solution file `StartupNewsManagementSystem.sln` in Visual Studio.

3. **Set Target Framework:**
    - Navigate to `Project > StartupNewsManagementSystem Properties`.
    - Change the target framework to `.NET Framework 4.8` and save.

4. **Ensure App_Data Folder Exists:**
    - Right-click on the solution in Visual Studio and select `Open Folder in File Explorer`.
    - Create the `App_Data` folder if it does not exist.

5. **Update Database:**
    - Open Package Manager Console in Visual Studio (`Tools > NuGet Package Manager > Package Manager Console`).
    - Run the following command to update the database:
      ```powershell
      ```Update-Database
      
6. **Verify Database Creation:**
    - In Visual Studio, go to `View > SQL Server Object Explorer`.
    - Expand `MSSQLLocalDb` to check if the database is created under `Databases`.

## Common Issues and Resolutions

- **(update-database) Could not attach .mdf database:**
  - **SOLUTION:** Ensure the `App_Data` folder is created in the project directory.

- **(update-database) Error: 'Type' cannot be null:**
  - **SOLUTION:** Update Entity Framework to the latest version using NuGet Package Manager (`Tools > NuGet Package Manager > Manage NuGet Packages for Solution`).

- **(update-database) System Exception: Exception has been thrown by the target of an invocation:**
  - **SOLUTION:** Clone the project repository to a local drive (not cloud-based storage).

- **(running server) Could not find part to the path ../bin/roslyn/csc.exe:**
  - **SOLUTION:** Change the target framework to `.NET Framework 4.7.1` and then back to `.NET Framework 4.8`.

- **(running server) Project Failed to build. System.Web.Http does not have reference to serialize:**
  - **SOLUTION:** Add a reference to `System.Web.Extensions` in `Solution Explorer > References`.

## API Commands

Use tools like `curl` or Postman to interact with the API.

### Article Management

- **Get List of Articles:**
  ```bash
  curl https://localhost:{port}/api/articles

*  **Get Single Article:**
   ```bash
   curl https://localhost:{port}/api/articles/{id}


*   **Update an Article (existing article info including id in article.json):**
    ```bash
    curl -H"Content-Type: application/json" -d @article.jsonhttps://localhost:{port}/api/articles/{id}
*  **Delete an Article:**
    ```bash
   curl -XDELETE https://localhost:{port}/api/articles/{id}
*   **List Articles by User:**
     ```bash
    curl https://localhost:{port}/api/articles/byuser/{userId}
*   **List Articles by Category:**
     ```bash
    curl https://localhost:{port}/api/articles/bycategory/{categoryId}

**CategoryManagement**
*   **Get List of Categories:**
    ```bash
    curl https://localhost:{port}/api/categories
*   **Get Single Category:**
    ```bash
    curl https://localhost:{port}/api/categories/{id}
*   **Add a New Category (data in category.json):**
    ```bash
    curl -H"Content-Type: application/json" -d @category.jsonhttps://localhost:{port}/api/categories

*   **Update a Category (existing category info including id in category.json):**
    ```bash
    curl -H"Content-Type: application/json" -d @category.jsonhttps://localhost:{port}/api/categories/{id}
*   **Delete a Category:**
    ```bash
    curl -XDELETE https://localhost:{port}/api/categories/{id}
**CommentManagement**
*   **Get List of Comments:**
    ```bash
    curl https://localhost:{port}/api/comments
*   **Get Single Comment:**
    ```bash
    curl https://localhost:{port}/api/comments/{id}

*   **Add a New Comment (data in comment.json):**
    ```bash
     curl -H "Content-Type:application/json" -d @comment.json https://localhost:{port}/api/comments

*   **Update a Comment (existing comment info including id in comment.json):**
    ```bash
      curl -H"Content-Type: application/json" -d @comment.jsonhttps://localhost:{port}/api/comments/{id}

*   **Delete a Comment:**
    ```bash
       curl -XDELETE https://localhost:{port}/api/comments/{id}

*   **List Comments for an Article:**
    ```bash
       curl https://localhost:{port}/api/comments/byarticle/{articleId}

*   **List Comments by User:**
    ```bash
       curl https://localhost:{port}/api/comments/byuser/{userId}

**Running theViews**

To manage and view articles, categories, andcomments via the application’s frontend:

2.  **Start the Application:**
5.  **Navigate to Specific Endpoints:**
8.  **Manage Data:**

**Additional Notes**

*   This project demonstrates practical skills in ASP.NET MVC, Web API development, and Entity Framework.

