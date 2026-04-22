### Project 1: ADO.NET Customer Management
* **Focus:** Direct database connection using ADO.NET.
* **Features:** Full CRUD (Create, Read, Update, Delete) operations for customer data.

### Project 2: Entity Framework (DbFirst) Product Management
* **Focus:** Introduction to ORM with Entity Framework.
* **Features:** * Dynamic listing and product management.
  * **Advanced UI:** Delete products directly from DataGridView selection.
  * **Reliability:** Integrated `try-catch` blocks for error handling.

### Project 3: EF Statistics Dashboard
* **Focus:** Data analysis and Business Intelligence (BI) visualization.
* **Features:**
  * Real-time e-commerce metrics dashboard.
  * **Advanced DB Design:** Self-referencing (Recursive) category structure.
  * **LINQ Mastery:** Complex queries for financial and inventory statistics.
* **Preview:**
<img width="500" height="300" alt="Statistic Dashboard" src="https://github.com/user-attachments/assets/c8ce1904-1a57-4b60-b176-7a03ca8babee" />

### Project 4 : EF Code First Movies App
* **Focus:** Advanced ORM with Code First Approach & Relational Mapping.
* **Key Features:**
   * **Dynamic Relational Listing:** Displaying movies with their category names using LINQ Select and Navigation Properties.
   * **Automated Database Schema:** Automatic table generation and versioning using EF Migrations.
   * **Smart UI Components:** Using ComboBox for dynamic category selection and DateTimePicker for error-free date entry.
   * **Data Integrity:** Implementing 1-to-Many relationships between Movies and Categories at the code level.
* **Reliability & Clean Code:**
   * **Fail-Fast Validation:** Pre-check logic to ensure a record is selected before Update/Delete operations.
   * **Resource Management:** Using using blocks to ensure efficient database connection handling and memory cleanup.
   * **Type Safety:** Proper data casting and TryParse implementations for robust user input handling.
* **Tech Stack:** C#, Entity Framework 6.x, MS SQL Server, Windows Forms.
* **Preview:**
* <table border="0">
  <tr>
    <td align="center">
      <img src="https://github.com/user-attachments/assets/cccf159c-1fee-4420-b4e5-5b29cdea88e7" alt="Product Management Screen" width="500" height="300" />
      <br />
      <b>Category Management Panel (CRUD)</b>
    </td>
    <td align="center">
      <img src="https://github.com/user-attachments/assets/07bf457b-e8b6-4455-9a7f-9ac0eb94ff1b" alt="Category Management Screen" width="500" height="300" />
      <br />
      <b>Category Management Panel (CRUD)</b>
    </td>
  </tr>
</table>

### Project 5 : Completed Product Management with Dapper
* **Focus:** High-performance database operations and Asynchronous Repository Pattern.
* **Key Features:**
  * **Asynchronous Execution:** All database operations (CRUD) are implemented using async/await to ensure a 100% responsive UI.
  * **Micro-ORM Efficiency:** Leveraged Dapper for near-native SQL execution speed, replacing heavy ORM overhead.
  * **Relational Mapping (Dapper Style):** Manually crafted INNER JOIN queries to fetch and map relational data (Products with Categories) into DTOs.
  * **Dynamic Dashboard:** Integrated a statistics panel using ExecuteScalarAsync to provide real-time business insights (Total Count, Avg Price, etc.).
  * **Smart Data Binding:** Dynamically populating ComboBox with DisplayMember and ValueMember mapping for professional data entry.
* **Reliability & Security:**
   * **SQL Injection Protection:** Used DynamicParameters to sanitize and secure all user-driven SQL queries.
   * **Clean Resource Management:**Implemented using blocks for every SqlConnection to prevent memory leaks and connection pool exhaustion.
   * **Layered DTO Pattern:** Specialized Data Transfer Objects (DTOs) used for Result, Create, and Update operations to ensure data isolation.
* **Tech Stack:** C#, Dapper Micro-ORM, MS SQL Server (Northwind), Asynchronous Programming, Windows Forms.
* **Preview:**
* <table border="0">
  <tr>
    <td align="center">
      <img src="https://github.com/user-attachments/assets/fb55977d-d816-4b1c-8e31-a945eb485a8b" alt="Statistics Dashboard Screen" width="500" height="300" />
      <br />
      <b>Dapper Statistic Dashboard</b>
    </td>
    <td align="center">
      <img src="https://github.com/user-attachments/assets/a0b23a90-0237-462a-8aeb-26e0a59470e6" alt="Product Management Screen" width="500" height="300" />
      <br />
      <b>Product Panel (CRUD)</b>
    </td>
   <td align="center">
      <img src="https://github.com/user-attachments/assets/316c48ef-fb86-4426-a2bd-0b078c99f261" alt="Category Management Screen" width="500" height="300" />
      <br />
      <b>Category Panel (CRUD)</b>
    </td>
  </tr>
</table>

### Project 6: Currency & Exchange Rate Web API
* **Focus:** * Developing a Scalable RESTful API for Financial Data Management.
* **Key Features:** *
  * **Professional CRUD Operations:** * Full implementation of Create, Read, Update, and Delete endpoints for currency management.
  * **Statistical Endpoints:** * Specialized API methods utilizing LINQ to provide real-time business metrics such as Total Currency Count and the Highest Exchange Rate.
  * **Modern Architecture (Dependency Injection):** * Leveraged Constructor Injection to decouple the Controller from the Database Context, ensuring a maintainable and testable codebase.
  * **Universal Data Output:** * Returns standardized JSON responses, making the API compatible with diverse clients such as WinForms, Mobile Apps, and Web Frontend frameworks.
  * **Precise Financial Handling:** * Utilized decimal data types for exchange rates to prevent rounding errors and ensure financial accuracy.
* **Reliability & Security:** *
  * **Entity Framework Core Integration:** * Managed database interactions with a secure, modern ORM layer including Migration-based schema management.
  * **Defensive Programming:** * Implemented null-check validations and specific HTTP Status Codes (NotFound, Ok, BadRequest) for robust error handling.
  * **Interactive API Documentation:** * Integrated Swagger (OpenAPI) for real-time testing and seamless developer collaboration.
* **Tech Stack:** * C#, ASP.NET Core Web API, Entity Framework Core, MS SQL Server, LINQ, Swagger.
* **Preview:** *
*<table border="0">
<tr>
<td align="center">
<img src="https://github.com/user-attachments/assets/3b82beeb-a022-4562-a43f-06f6bf0b2168" alt="Swagger UI API Testing" width="500" height="300" />
<br />
<b>Swagger API Interface</b>
</td>
<td align="center">
<img src="https://github.com/user-attachments/assets/f8f6b680-c079-4c99-9cd1-9fa3f4bb44f9" alt="JSON Data Output" width="500" height="300" />
<br />
<b>JSON Data Response</b>
</td>
</tr>
</table>

*(The list will be updated as I progress with new projects.)*

---

## Technologies Used
- C#
- .NET Framework / .NET Core
- Windows Forms
- ADO.NET
- Entity Framework

---

## About
This repository demonstrates my learning journey in C#.  
Each project starts with a basic version (from the course) and then I add new improvements, optimizations, and error handling before publishing it here.
