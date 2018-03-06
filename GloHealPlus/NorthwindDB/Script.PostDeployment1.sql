/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r .\Data\"dbo.Categories.Table.sql"
:r .\Data\"dbo.Customers.Table.sql"
:r .\Data\"dbo.CustomerCustomerDemo.Table.sql"
:r .\Data\"dbo.CustomerDemographics.Table.sql"
:r .\Data\"dbo.Employees.Table.sql"
:r .\Data\"dbo.EmployeeTerritories.Table.sql"
:r .\Data\"dbo.Orders.Table.sql"
:r .\Data\"dbo.Order Details.Table.sql"
:r .\Data\"dbo.Products.Table.sql"
:r .\Data\"dbo.Region.Table.sql"
:r .\Data\"dbo.Shippers.Table.sql"
:r .\Data\"dbo.Suppliers.Table.sql"
:r .\Data\"dbo.Territories.Table.sql"
