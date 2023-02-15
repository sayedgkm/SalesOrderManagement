# SalesOrderManagement
This is a simple .NET Blazor WebAssembly based Sales Order Management web app. Used Entity Framework core to create databases. 


# Project Setup guidelines 

## Prerequisites
1. Visual Studio 2022
2. MSSQL SERVER
3. ASP .NET 6 SDK

## Setup Steps 
1. Clone this project
2. Open the project solution in the visual studio
3. Set connection string value in the appsettings.json file of SalesOrderManagement.Server project.
4. Build the project
5. Open Package Manager Console and set SalesOrderManagement.Data as the default project.
6. Run the following command to create database.
```
update-database
```
7. Finally run the solution and browse.

## Future possible improvement scope
1. More elegant UI design. 
2. Pagination can be added in UI where lists are shown. 
3. Http Patch can be added to minimize data transfer while updating.
4. Authentication & Authorization can be added. 