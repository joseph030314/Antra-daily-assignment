USE AdventureWorks2019
GO
--1.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, with no filter.
SELECT p.ProductID, p.Name, p.Color, p.Listprice
FROM Production.Product AS p;
--2.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, excludes the rows that ListPrice is 0.
SELECT p.ProductID, p.Name, p.Color, p.Listprice
FROM Production.Product AS p
WHERE ListPrice <> 0;
--3.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are NULL for the Color column.
SELECT p.ProductID, p.Name, p.Color, p.Listprice
FROM Production.Product AS p
WHERE Color IS NULL;
--4.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are not NULL for the Color column.
SELECT p.ProductID, p.Name, p.Color, p.Listprice
FROM Production.Product AS p
WHERE Color IS NOT NULL;
--5.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are not NULL for the column Color, and the column ListPrice has a value greater than zero.
SELECT p.ProductID, p.Name, p.Color, p.Listprice
FROM Production.Product AS p
WHERE Color IS NOT NULL AND ListPrice > 0;
--6.Write a query that concatenates the columns Name and Color from the Production.Product table by excluding the rows that are null for color.
SELECT p1.Name + ' ' + p1.Color AS ConcatenatedResult
FROM Production.Product p1
JOIN Production.Product p2 ON p1.ProductID = p2.ProductID
WHERE p1.Color IS NOT NULL;
--7.Write a query that generates the following result set  from Production.Product:
SELECT 'NAME: ' + Name + '  --  COLOR: ' + Color AS Result
FROM Production.Product
WHERE (Name LIKE '%Crankarm' AND Color = 'Black')
   OR (Name LIKE 'Chainring%' AND Color IN ('Silver', 'Black'));
--8.Write a query to retrieve the to the columns ProductID and Name from the Production.Product table filtered by ProductID from 400 to 500
SELECT p.ProductID, p.Name
FROM Production.Product AS p
WHERE ProductID BETWEEN 400 AND 500;
--9.Write a query to retrieve the to the columns  ProductID, Name and color from the Production.Product table restricted to the colors black and blue
SELECT P.ProductID, P.Name, P.Color
FROM Production.Product AS p
WHERE Color IN ('Black', 'Blue');
--10.Write a query to get a result set on products that begins with the letter S. 
SELECT P.ProductID, P.Name, P.Color
FROM Production.Product AS p
WHERE Name LIKE 'S%';
--11.Write a query that retrieves the columns Name and ListPrice from the Production.Product table. Your result set should look something like the following. Order the result set by the Name column. 
SELECT p.Name, p.ListPrice
FROM Production.Product AS p
WHERE Name LIKE 'Seat%'
   OR Name LIKE 'Short-Sleeve Classic Jersey% L'
   OR Name LIKE 'Short-Sleeve Classic Jersey% M'
ORDER BY Name;
--12.Write a query that retrieves the columns Name and ListPrice from the Production.Product table. Your result set should look something like the following. Order the result set by the Name column. The products name should start with either 'A' or 'S'
SELECT TOP 5 p.Name, p.ListPrice
FROM Production.Product AS p
WHERE Name LIKE '[AS]%'  
ORDER BY Name;
--13.Write a query so you retrieve rows that have a Name that begins with the letters SPO, but is then not followed by the letter K. After this zero or more letters can exists. Order the result set by the Name column.
Select p.Name
From Production.Product AS p
Where Name Like 'SPO[^K]%'
Order by Name
--14.Write a query that retrieves unique colors from the table Production.Product. Order the results  in descending  manner.
Select Distinct p.Color
From Production.Product AS p
ORDER BY Color DESC

