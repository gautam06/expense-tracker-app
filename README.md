# ExpenseTracker

ExpenseTracker is a web application designed to help users manage their personal finances efficiently. It includes features for adding, editing, and deleting expenses, categorizing them, generating summaries, and visualizing spending trends.

## Table of Contents

- [Features](#features)
- [Prerequisites](#prerequisites)
- [Setting Up the Database](#setting-up-the-database)
- [Steps to Run the Application](#steps-to-run-the-application)
- [Dependencies](#dependencies)
- [UnitTestCases](#unittestcases)
- [Swagger Documentation](#swagger-documentation)
- [UI Images](#attaching-images-in-the-ui)
- [Contributing](#contributing)
- [License](#license)

---

## Features

- **Expense Management**: Add, edit, or delete expense entries.
- **Expense Categorization**: Categorize expenses (e.g., Food, Travel, Utilities, Entertainment).
- **Summary View**: Display a categorized summary of expenses with total amounts and percentages.
- **Search Functionality**: Perform full-text or semantic searches across expenses.
- **Additional Features**: Support for enhanced user experience through customizable options and extended data filters.

---

## Prerequisites

Before setting up the ExpenseTracker application, ensure the following tools are installed:

- **.NET SDK 8**: [Download here](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Microsoft SQL Server**: Install and configure SQL Server ([Setup Guide](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)).
- **Visual Studio 2022** or any preferred IDE with .NET Core support.

---

## Setting Up the Database
   
1. **Database Connectivity:** We have hosted MS SQL Server Database Instance on a local machine and it can be accessed using the below connection string.
2. **Update Connection String**:
   - Edit the `appsettings.json` file:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=tcp:192.168.5.112,49175;Database=ExpenseTracker;User ID=sa;Password=sa123;TrustServerCertificate=True;Encrypt=True;"
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

To install the packages, run:
```bash
# Example
 dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

---

## UnitTestCases
### XUnit TestCases
- Test cases have been written using XUnit for API Controllers and Application Service Classes. 

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

![Expense Tracker Screenshot1](https://github.com/gautam06/expense-tracker-app/blob/main/WebApp/WebApp/wwwroot/ScreenShot/Login.png)
![Expense Tracker Screenshot2](https://github.com/gautam06/expense-tracker-app/blob/main/WebApp/WebApp/wwwroot/ScreenShot/Form.png)
![Expense Tracker Screenshot3](https://github.com/gautam06/expense-tracker-app/blob/main/WebApp/WebApp/wwwroot/ScreenShot/ExpenseList.png)
![Expense Tracker Screenshot4](https://github.com/gautam06/expense-tracker-app/blob/main/WebApp/WebApp/wwwroot/ScreenShot/CategoryAPI.png)
![Expense Tracker Screenshot5](https://github.com/gautam06/expense-tracker-app/blob/main/WebApp/WebApp/wwwroot/ScreenShot/SigninAPI.png)
![Expense Tracker Screenshot6](https://github.com/gautam06/expense-tracker-app/blob/main/WebApp/WebApp/wwwroot/ScreenShot/ExpenseAPI.png)

---

