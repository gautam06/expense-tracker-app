# ExpenseTracker

ExpenseTracker is a web application designed to help users manage their personal finances efficiently. It includes features for adding, editing, and deleting expenses, categorizing them, generating summaries, and visualizing spending trends.

## Table of Contents

- [Features](#features)
- [Prerequisites](#prerequisites)
- [Setting Up the Database](#setting-up-the-database)
- [Steps to Run the Application](#steps-to-run-the-application)
- [Dependencies](#dependencies)
- [Swagger Documentation](#swagger-documentation)
- [UI Images](#attaching-images-in-the-ui)
- [Contributing](#contributing)
- [License](#license)

---

## Features

- **Expense Management**: Add, edit, or delete expense entries.
- **Expense Categorization**: Categorize expenses (e.g., Food, Travel, Utilities, Entertainment).
- **Summary View**: Display a categorized summary of expenses with total amounts.
- **Search Functionality**: Perform full-text or semantic searches across expenses.
- **Data Visualization**: Generate visual insights using pie charts and bar charts for expense summaries.
- **Additional Features**: Support for enhanced user experience through customizable options and extended data filters.

---

## Prerequisites

Before setting up the ExpenseTracker application, ensure the following tools are installed:

- **.NET SDK 8**: [Download here](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Microsoft SQL Server**: Install and configure SQL Server ([Setup Guide](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)).
- **Visual Studio 2022** or any preferred IDE with .NET Core support.

---

## Setting Up the Database

1. **Create the Database**:
   - Open SQL Server Management Studio (SSMS).
   - Create a database named `ExpenseTracker`.

2. **Run the SQL Script**:
   - Use the script in `Database/SetupScript.sql` to set up the necessary tables:
     
3. **Update Connection String**:
   - Edit the `appsettings.json` file:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=ExpenseTrackerDB;Trusted_Connection=True;"
     }
     ```

---

## Steps to Run the Application

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-repository/ExpenseTracker.git
   cd ExpenseTracker
   ```

2. **Build the Application**: Build the Application and run both the application for API and WebApp projects. 

3. **Access the Application**:
   - Open your browser and navigate to `http://localhost:5027/User/Login`

---

## Dependencies

### Frameworks and Tools
- **.NET SDK 8**
- **Razor Pages**
- **MS SQL Server**

### NuGet Packages
- `Microsoft.EntityFrameworkCore.SqlServer`: Database connectivity.
- `Microsoft.EntityFrameworkCore.Tools`: Database migrations.
- `Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore`: Error diagnostics.
- `Newtonsoft.Json`: JSON handling.
- `LiveCharts`: For rendering visualizations.

To install the packages, run:
```bash
# Example
 dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

---

## Swagger Documentation

This application provides Swagger UI for exploring the API endpoints:

1. **Enable Swagger**:
   Swagger is pre-configured in the application. Run the application and navigate to:
   ``` http://localhost:5138/swagger/index.html
   ```

2. **Usage**:
   - Use the Swagger interface to test all REST API endpoints interactively.
   - View request/response structures and perform API calls.

---

## UI Images

Refer attached images of UI for reference.

![Expense Tracker Screenshot1](https://github.com/gautam06/expense-tracker-app/blob/main/WebApp/WebApp/wwwroot/ScreenShot/CategoryAPI.png)
![Expense Tracker Screenshot2](https://github.com/gautam06/expense-tracker-app/blob/main/WebApp/WebApp/wwwroot/ScreenShot/Form.png)
![Expense Tracker Screenshot3](https://github.com/gautam06/expense-tracker-app/blob/main/WebApp/WebApp/wwwroot/ScreenShot/List.png)
![Expense Tracker Screenshot4](https://github.com/gautam06/expense-tracker-app/blob/main/WebApp/WebApp/wwwroot/ScreenShot/Login.png)
![Expense Tracker Screenshot5](https://github.com/gautam06/expense-tracker-app/blob/main/WebApp/WebApp/wwwroot/ScreenShot/SigninAPI.png)

---

