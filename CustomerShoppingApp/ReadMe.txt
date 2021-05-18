*******************
Installing the tools
********************
-dotnet ef can be installed as either a global or local tool. Most developers prefer installing dotnet ef as a global 
tool using the following command:
-dotnet tool install --global dotnet-ef
-dotnet tool update --global dotnet-ef
-dotnet add package Microsoft.EntityFrameworkCore.Design

**************************
Create Migration using CLI
**************************
-dotnet ef migrations add InitialCreate
-dotnet ef database update