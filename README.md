# Agri Energy Connect
## ST10256074

![image](https://github.com/user-attachments/assets/6d748bf3-4ed1-487c-b24d-9a7983fb83e9)

This is the prototype developed in ASP.NET MVC with visual studio.

# Setup and Usage
Upon Extracting the zip file/git pull containing the project. Open up the SQL Server Object Explorer under the ‘View’ tab. Under SQL Server there should be a local database called MSSQLLocalDB, under Databases there should be a directory that links to the database included in the project files.
If not, then Right-Click the Databases Folder and Add-Database then select the database in the database folder of the project or create a new one named "Hart_PROG7311_Part_2_Database". 
![image](https://github.com/user-attachments/assets/c6966ad2-6b29-4cdb-91a2-5fb0698120aa)

When that is complete you can click the green Run button at the top. This will build the project and automatically open a browser to view the website. 
You can then enter the Login Details Below to access the site. 

# User Roles
There are 2 Main types of Users of the Agri-Energy Connect platform:
- Employee
  - Can Create, Edit and Delete Farmers
  - Can View and Filter All products
- Farmer
  - Can Create, Edit and Delete Products
  - Can Filter Products


# Functionality
The Platform can allow for Farmers to sell their products on the Marketplace while Employees can add more Farmers to the marketplace. 

Products are uploaded using details such as category, price, quantity, image and description.

Farmers are created using Address, Contact, Name and Image.


# Login Details
Employee Credentials :

Username: admin 

Password: admin

Farmer Credentials :

Username: Farmer 

Password: Farmer

# Authorization 
When accessing controllers or methods when not signed in, it will redirect you to the login page.

# Architecture
Using the MVC design pattern and the Repository design pattern for database access. 

![image](https://github.com/user-attachments/assets/f9af0e32-36ed-4e19-b741-43ea0cf3bd1b)

Error Handling
![image](https://github.com/user-attachments/assets/ed2b3099-99d4-4e35-8e6a-309aaecfa0b9)

Authentication
![image](https://github.com/user-attachments/assets/08a72f6e-7654-4cca-8754-420a376d85ee)


# Pages

Products Page
![image](https://github.com/user-attachments/assets/207c0f29-cc20-4ea3-a1b5-9f8cda54e81c)

Farmers Page
![image](https://github.com/user-attachments/assets/e70fa8c7-7e85-44f6-be76-d0d20b4cd6a5)

Farmer Detail Page
![image](https://github.com/user-attachments/assets/98ab9fa1-0923-4c00-92ec-9331cd5ab65a)

Farmer Add Page 
![image](https://github.com/user-attachments/assets/b1cb5998-1838-4bfa-9759-eb91fb06dbf3)

Farmer Edit Page
![image](https://github.com/user-attachments/assets/4abdbfa0-5bb2-41a7-a48c-b5a5ea2b5ffc)

Product Detail Page
![image](https://github.com/user-attachments/assets/8c412464-af4c-48e8-9423-f62958203651)

Farmer Product Page
![image](https://github.com/user-attachments/assets/065bc386-2e7f-4db9-b60a-db2aa098f266)

Product Edit Page
![image](https://github.com/user-attachments/assets/347777c4-6ef0-4625-8bd2-7e5885a2d65d)

Product Add Page
![image](https://github.com/user-attachments/assets/4d1fa2e6-9e4a-4ae2-bf88-9f1710c56cca)

Login Page
![image](https://github.com/user-attachments/assets/25dabb0f-cd0d-49e8-a438-e48c6810c35d)


# REFERENCES
Halder, K. (2025, May 10). Session based Authorization in ASP.NET Core. Retrieved from Medium: https://medium.com/@KumarHalder/session-based-authorization-in-asp-net-core-95eed1d3dded

Kara, K. (2025, May 12). Authentication and Authorization in ASP.NET Core: A Comprehensive Guide. Retrieved from Medium: https://medium.com/@kerimkkara/authentication-and-authorization-in-asp-net-core-a-comprehensive-guide-dfb8fb806ac7

Microsoft Learn. (2025, May 12). Create an ASP.NET Core web app with user data protected by authorization. Retrieved from Microsoft Learn: https://learn.microsoft.com/en-us/aspnet/core/security/authorization/secure-data?view=aspnetcore-9.0

Microsoft Learn. (2025, May 10). Creating a Consistent Layout in ASP.NET Web Pages (Razor) Sites. Retrieved from Microsoft Learn: https://learn.microsoft.com/en-us/aspnet/web-pages/overview/ui-layouts-and-themes/3-creating-a-consistent-look

Microsoft Learn. (2025, May 10). Routing to controller actions in ASP.NET Core. Retrieved from Microsoft Learn: https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-9.0

rabet, f. (2025, May 11). .NET 6 how to run Migration automatically in program.cs. Retrieved from stack overflow: https://stackoverflow.com/questions/70266442/net-6-how-to-run-migration-automatically-in-program-cs

# AI Declaration

During this project, AI tools were utilized as a educational resource to aid in the 
understanding and exploring certain coding techniques. 


Deepseek AI: Deepseek AI, 2025. Deepseek AI. Available at: https://deepseek.ai [Accessed
11 May 2025].
Screenshots:
Ex
![image](https://github.com/user-attachments/assets/bd9aa1db-541b-47e0-841c-2d041439f84a)
![image](https://github.com/user-attachments/assets/5b311ed8-9ca7-48b7-b8d6-7fdc0ca10ead)

Ideas for columns for the tables in the database. The database has many more columns as it was expanded on to fit the project requirements.
![image](https://github.com/user-attachments/assets/b60e4681-7f90-441a-9fae-80fc9ed76aa3)
![image](https://github.com/user-attachments/assets/173b40b0-144d-4179-b321-478b48db6190)


Github Co-pilot was used in commit messages in visual studio
![image](https://github.com/user-attachments/assets/ff218005-c4a2-43ca-ad25-9837b6e25872)

