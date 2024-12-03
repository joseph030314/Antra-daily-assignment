--1.List all cities that have both Employees and Customers.
SELECT DISTINCT e.City
FROM Employees e
INNER JOIN Customers c ON e.City = c.City;
--2.List all cities that have Customers but no Employee.
--a.Use sub-query
SELECT DISTINCT City
FROM Customers
WHERE City IS NOT NULL
AND City NOT IN (
    SELECT DISTINCT City
    FROM Employees
);
--b.Do not use sub-query
SELECT DISTINCT c.City
FROM Customers c
LEFT JOIN Employees e ON c.City = e.City
WHERE e.City IS NULL AND c.City IS NOT NULL;
--3.List all products and their total order quantities throughout all orders.
SELECT p.ProductID, p.ProductName, SUM(od.Quantity) AS TotalQuantity
FROM Products p
LEFT JOIN [Order Details] od ON p.ProductID = od.ProductID
GROUP BY p.ProductID, p.ProductName
ORDER BY p.ProductID;
--4.List all Customer Cities and total products ordered by that city.
SELECT c.City, SUM(od.Quantity) AS TotalProductsOrdered
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City
ORDER BY c.City;
--5.List all Customer Cities that have at least two customers.
SELECT City, COUNT(*) AS CustomerCount
FROM Customers
GROUP BY City
HAVING COUNT(*) >= 2
ORDER BY CustomerCount DESC;
--6.List all Customer Cities that have ordered at least two different kinds of products.
SELECT c.City, COUNT(DISTINCT od.ProductID) AS ProductKinds
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City
HAVING COUNT(DISTINCT od.ProductID) >= 2
ORDER BY ProductKinds DESC;
--7.List all Customers who have ordered products, but have the ¡®ship city¡¯ on the order different from their own customer cities.
SELECT c.CustomerID, c.ContactName, c.City AS CustomerCity, o.OrderID, o.ShipCity
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE c.City <> o.ShipCity;
--8.List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
WITH ProductPopularity AS (
    SELECT od.ProductID, SUM(od.Quantity) AS TotalQuantityOrdered
    FROM [Order Details] od
    GROUP BY od.ProductID
    ORDER BY TotalQuantityOrdered DESC
    OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY
),
ProductAveragePrice AS (
    SELECT p.ProductID, p.ProductName, AVG(od.UnitPrice) AS AveragePrice
    FROM Products p
    JOIN [Order Details] od ON p.ProductID = od.ProductID
    GROUP BY p.ProductID, p.ProductName
),
ProductCityOrders AS (
    SELECT od.ProductID, c.City, SUM(od.Quantity) AS QuantityByCity
    FROM [Order Details] od
    JOIN Orders o ON od.OrderID = o.OrderID
    JOIN Customers c ON o.CustomerID = c.CustomerID
    GROUP BY od.ProductID, c.City
),
ProductTopCities AS (
    SELECT pco.ProductID, pco.City, pco.QuantityByCity
    FROM ProductCityOrders pco
    JOIN (
        SELECT ProductID, MAX(QuantityByCity) AS MaxQuantity
        FROM ProductCityOrders
        GROUP BY ProductID
    ) MaxCity ON pco.ProductID = MaxCity.ProductID AND pco.QuantityByCity = MaxCity.MaxQuantity
)
SELECT pp.ProductID, pa.ProductName, pa.AveragePrice, ptc.City AS MostPopularCity
FROM ProductPopularity pp
JOIN ProductAveragePrice pa ON pp.ProductID = pa.ProductID
JOIN ProductTopCities ptc ON pp.ProductID = ptc.ProductID
ORDER BY pa.AveragePrice;
--9.List all cities that have never ordered something but we have employees there.
--a.Use sub-query
SELECT DISTINCT e.City
FROM Employees e
WHERE e.City IS NOT NULL
AND e.City NOT IN (
    SELECT DISTINCT o.ShipCity
    FROM Orders o
    WHERE o.ShipCity IS NOT NULL
);
--b.Do not use sub-query
SELECT DISTINCT e.City
FROM Employees e
LEFT JOIN Orders o ON e.City = o.ShipCity
WHERE o.ShipCity IS NULL AND e.City IS NOT NULL;
--10.List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)
WITH EmployeeMostOrders AS (
    SELECT TOP 1 e.City AS EmployeeCity, COUNT(o.OrderID) AS TotalOrders
    FROM Employees e
    JOIN Orders o ON e.EmployeeID = o.EmployeeID
    WHERE e.City IS NOT NULL
    GROUP BY e.City
    ORDER BY TotalOrders DESC
),	
CityMostProductQuantity AS (
    SELECT TOP 1 c.City AS CustomerCity, SUM(od.Quantity) AS TotalQuantity
    FROM Customers c
    JOIN Orders o ON c.CustomerID = o.CustomerID
    JOIN [Order Details] od ON o.OrderID = od.OrderID
    WHERE c.City IS NOT NULL
    GROUP BY c.City
    ORDER BY TotalQuantity DESC
)
SELECT e.EmployeeCity
FROM EmployeeMostOrders e
JOIN CityMostProductQuantity c ON e.EmployeeCity = c.CustomerCity;
--11.How do you remove the duplicates record of a table?
--First we need to identify the duplicates like:
SELECT *, COUNT(*) AS CountOfDuplicates
FROM TableName
GROUP BY Column1, Column2, ..., ColumnN
HAVING COUNT(*) > 1;
--And we can use TempTable to delete:
SELECT DISTINCT *
INTO #TempTable
FROM TableName
DELETE FROM TableName
INSERT INTO TableName
SELECT *
FROM #TempTable;











