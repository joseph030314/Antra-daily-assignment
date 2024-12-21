--1.How many products can you find in the Production.Product table?
SELECT COUNT(*) AS Products
FROM Production.Product;
--2.Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.
SELECT COUNT(*) AS NumberOfProductsInSubcategory
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL;
--3.How many Products reside in each SubCategory? Write a query to display the results with the following titles.ProductSubcategoryID CountedProducts-------------------- ---------------
SELECT ProductSubcategoryID AS ProductSubcategoryID,
COUNT(*) AS CountedProducts
FROM Production.Product
GROUP BY ProductSubcategoryID
ORDER BY ProductSubcategoryID DESC;
--4.How many products that do not have a product subcategory.
SELECT COUNT(*) AS ProductsWithoutSubcategory
FROM Production.Product
WHERE ProductSubcategoryID IS NULL;
--5.Write a query to list the sum of products quantity in the Production.ProductInventory table.
SELECT SUM(Quantity) AS TotalProductQuantity
FROM Production.ProductInventory;
--6.Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.
SELECT ProductID,SUM(Quantity) AS TheSum
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY ProductID
HAVING SUM(Quantity) < 100
ORDER BY ProductID ASC;
--7.Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100
SELECT Shelf,ProductID,SUM(Quantity) AS TheSum
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY Shelf, ProductID
HAVING SUM(Quantity) < 100;
--8.Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.
SELECT AVG(Quantity) AS AverageQuantity
FROM Production.ProductInventory
WHERE LocationID = 10;
--9.Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
GROUP BY ProductID, Shelf
ORDER BY ProductID, Shelf;
--10.Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
WHERE Shelf != 'N/A'
GROUP BY ProductID, Shelf
ORDER BY ProductID, Shelf;
--11.List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.
SELECT Color, Class, COUNT(*) AS TheCount, AVG(ListPrice) AS AvgPrice
FROM Production.Product
WHERE Color IS NOT NULL AND Class IS NOT NULL
GROUP BY Color, Class
ORDER BY Color, Class;
--12.Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. Join them and produce a result set similar to the following.
SELECT c.CountryRegionCode AS Country, s.Name AS Province 
FROM Person.CountryRegion c JOIN Person.StateProvince s ON c.CountryRegionCode = s.CountryRegionCode;
--13.Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.
SELECT c.CountryRegionCode AS Country, s.Name AS Province
FROM Person.CountryRegion c JOIN Person.StateProvince s ON c.CountryRegionCode = s.CountryRegionCode
WHERE c.CountryRegionCode IN (
    SELECT CountryRegionCode
    FROM Person.CountryRegion
    WHERE CountryRegionCode IN ('DE', 'CA')
);
--14.List all Products that has been sold at least once in last 27 years.
SELECT DISTINCT p.ProductID, p.ProductName
FROM Products p
JOIN [Order Details] od ON p.ProductID = od.ProductID
JOIN Orders o ON o.OrderID = od.OrderID
WHERE o.OrderDate >= DATEADD(YEAR, -27, GETDATE())
ORDER BY p.ProductID, p.ProductName ASC;
--15.List top 5 locations (Zip Code) where the products sold most.
SELECT TOP 5 o.ShipPostalCode, COUNT(od.ProductID) AS ProductCount
FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID
WHERE o.ShipPostalCode IS NOT NULL
GROUP BY o.ShipPostalCode
ORDER BY ProductCount DESC;
--16.List top 5 locations (Zip Code) where the products sold most in last 27 years.
SELECT TOP 5 o.ShipPostalCode, COUNT(od.ProductID) AS ProductCount
FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID
WHERE o.OrderDate >= DATEADD(YEAR, -27, GETDATE())
GROUP BY o.ShipPostalCode
ORDER BY ProductCount DESC;
--17.List all city names and number of customers in that city.     
SELECT o.ShipCity, COUNT(DISTINCT o.CustomerID) AS NumOfCustomers
FROM Orders o
GROUP BY o.ShipCity
ORDER BY NumofCustomers DESC;
--18.List city names which have more than 2 customers, and number of customers in that city
SELECT o.ShipCity, COUNT(DISTINCT o.CustomerID) AS NumOfCustomers
FROM Orders o
GROUP BY o.ShipCity
HAVING COUNT(DISTINCT o.CustomerID) > 2
ORDER BY NumOfCustomers DESC;
--19.List the names of customers who placed orders after 1/1/98 with order date.
SELECT c.ContactName, o.OrderDate
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate > '1998-01-01'
ORDER BY o.OrderDate;
--20.List the names of all customers with most recent order dates
SELECT c.ContactName, MAX(o.OrderDate) AS MostRecentOrderDate
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.ContactName
ORDER BY MostRecentOrderDate DESC;
--21.Display the names of all customers  along with the  count of products they bought
SELECT c.ContactName, COUNT(od.ProductID) AS ProductCount
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.ContactName
ORDER BY ProductCount DESC;
--22.Display the customer ids who bought more than 100 Products with count of products.
SELECT o.CustomerID, COUNT(od.ProductID) AS ProductCount
FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY o.CustomerID
HAVING COUNT(od.ProductID) > 100
ORDER BY ProductCount DESC;
--23.List all of the possible ways that suppliers can ship their products.
SELECT DISTINCT s.CompanyName AS [Supplier Company Name], sh.CompanyName AS [Shipping Company Name]
FROM Suppliers s
CROSS JOIN Shippers sh
ORDER BY s.CompanyName, sh.CompanyName;
--24.Display the products order each day. Show Order date and Product Name.
SELECT o.OrderDate, p.ProductName
FROM Orders o
JOIN [Order Details] od ON o.OrderID = od.OrderID
JOIN Products p ON od.ProductID = p.ProductID
ORDER BY o.OrderDate, p.ProductName;
--25.Displays pairs of employees who have the same job title.
SELECT 
    e1.FirstName + ' ' + e1.LastName AS Employee1,
    e2.FirstName + ' ' + e2.LastName AS Employee2,
    e1.Title
FROM Employees e1
JOIN Employees e2 ON e1.Title = e2.Title AND e1.EmployeeID < e2.EmployeeID
ORDER BY e1.Title, Employee1, Employee2;
--26.Display all the Managers who have more than 2 employees reporting to them.
SELECT m.EmployeeID, m.LastName, m.FirstName
FROM Employees m
JOIN Employees e ON e.ReportsTo = m.EmployeeID
GROUP BY m.EmployeeID, m.LastName, m.FirstName
HAVING COUNT(e.ReportsTo) > 2;
--27.Display the customers and suppliers by city. 
SELECT City, CompanyName AS Name, ContactName, 'Customer' AS Type
FROM Customers
UNION
SELECT City, CompanyName AS Name, ContactName, 'Supplier' AS Type
FROM Suppliers
ORDER BY City, Name;






















