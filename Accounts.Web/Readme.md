Account.Web is a .NET Core MVC application that manages clients' account using basic CRUD operations.

# Important Files:
  - launchSettings.json : to change appliaction's port and environment.
  - appsettings.json : to change the database connection string as well as database name.
# Required Nuget Packages!

  - Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
  - Microsoft.EntityFrameworkCore.SqlServer
  - Microsoft.EntityFrameworkCore.Design
  - Microsoft.EntityFrameworkCore.Tools
  - Microsoft.VisualStudio.Web.CodeGeneration.Design (optional): used to generate views or controllers.
# How to build!

  - Database can be generated using the following Nuget package Manager console commands in Visual Studio:
    >add-migration <Migration_Name>
    
    update-database
  - The add-migration <Migration_Name> command will add a migration folder (if not created yet) with the respective changes made.
  - The update-database command will apply the change to the database.
  - The application can be then launched in debug mode using F5, or without debug mode using Ctrl+F5.