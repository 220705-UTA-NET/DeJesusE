-- double hyphen denotes a comment
/* Provides multi
   line 
   comments */

/*
   DDL - Data Definition Language: allows us to the create structure of our database, i.e. create and manipulating tables
   - CREATE
   - ALTER
   - DROP

   DML - Data Manipulation Language: allows us to create and modify data within our databases, i.e. manipulating cells within a table
   - INSERT
   - DELETE
   - TRUNCATE
   - UPDATE

   DCL - Data Control Language: controls access to data within the tables
   - GRANT/REVOKE USER
   - GRANT/REVOKE LOGIN

   DQL - Data Query Language: the commands we use to phrase, filter, and structurea query
   - SELECT
   - FROM
   - WHERE
   - IF, OR, AND
   - JOINS

   */

/*
    -CREATE TABLE [NAME]([type][column_name] ... )
    - VERB NOUN
*/
   CREATE TABLE Pokemon(
       -- column-name variable type modifiers
       Id INT NOT NULL PRIMARY KEY IDENTITY, -- NOT NULL and UNIQUE, identity == index
       Name NVARCHAR(64) NOT NULL UNIQUE,
       Height INT NOT NULL,
       Weight INT NOT NULL
   );

   CREATE TABLE Type(
       Id INT PRIMARY KEY IDENTITY,
       Name NVARCHAR(64) NOT NULL UNIQUE,
   );

   /* Multiplicity - the relationships between the entries in a database/tables
   - 1-to-1 : for each entry in table A, there is 1 entry related to it in table B
   - 1-to-many : for each entry in table A, there are many possible entries related to it in table B
   - many-to-many : for many entries in table A, there are many related entries in table B
   */

   -- create a linking table between Pokemon and Type

   CREATE TABLE Pokemon_Type (
       Id INT NOT NULL PRIMARY KEY IDENTITY,
       PokemonId INT NOT NULL FOREIGN KEY REFERENCES Pokemon (Id)
            ON DELETE CASCADE,
       TypeId INT NOT NULL FOREIGN KEY REFERENCES Type (Id)
            ON DELETE CASCADE
   );

   -- CASCADE triggers the specified column to also delete/update when the FK entry is affected.

   -- Insert data into the tables

   INSERT INTO Pokemon (Name, Height, Weight) VALUES 
   ('Charizard', 67, 200),
   ('Mudkip', 24, 45);

   INSERT INTO Type (Name) VALUES 
   ('Fire'),
   ('Water'),
   ('Dragon'),
   ('Flying'),
   ('Grass'),
   ('Earth');


   -- Retrieve data from the tables
   SELECT Name FROM Type;
   SELECT Name, Height, Weight FROM Pokemon;

   -- Use WHERE to add a filter to your query
   SELECT Name FROM Pokemon WHERE (Height > 50);
   SELECT Name FROM Pokemon WHERE Name LIKE 'C%'; 

   DROP TABLE Pokemon_Type;
   DROP TABLE Pokemon;
   DROP TABLE Type;

   -- Joins two tables along a common column (key pair) so that we can retrieve data from both tables at the same time

   SELECT Id, Name FROM Pokemon;
   SELECT Id, Name FROM Type;

   INSERT INTO Pokemon_Type VALUES
   (2,2),
   (1, 1),
   (1, 4),
   (1, 3);

/* JOINS
   table a      table b
      1            null
      2            b
      null         null
      null         e

    full - Returns all records when theres a match in either left or right tables, ignoring null
    inner - Returns all records when there a match in both left and right tables, removing all null entries
    outer - Returns all records when there isn't a match in both left and right tables
    left - Returns all records where there is a match in both left and right, and wheres there is a match on the
           left
    right - left but it instead checks the right table
    cross - returns the cartesian product of rows from the tables in the join. It combines
            each row from the first table with each row from the second table.

*/

   SELECT P.Name, T.Name AS 'Type' -- AS is an alias modifier (RENAME T.Name as Type)
   FROM Pokemon AS P 
   JOIN Pokemon_Type AS PT
   ON P.Id = PT.PokemonId
   JOIN Type AS T
   ON T.Id = PT.TypeId;


-- Schema : a list of logical structures of data
-- dbo is the default schema;
-- Create SCHEMA newschema;
-- SELECT * FROM newschema.NewTable;

SELECT * FROM dbo.Customer;
SELECT FirstName FROM dbo.Customer WHERE LEN(FirstName) = 6;

-- User-Defined Functions
-- Functions CAN NOT modify the data of a table, they are "read-only"
-- Only really useful for SELECT statements

GO -- Used to "batch" your statements together
CREATE FUNCTION dbo.TotalNumberOfCustomers()
RETURNS INT
AS 
   BEGIN
      DECLARE @result INT;
      SELECT @result = Count(*) FROM dbo.Customer;
      RETURN @result;
   END
GO

SELECT dbo.TotalNumberOfCustomers() AS "Number of Customers";
SELECT Count(*) FROM dbo.Customer AS "Number of Customers";

GO
CREATE FUNCTION dbo.CustomersWithFirstNameLengthof(@length INT)
RETURNS TABLE -- stored / user defined functions can return an entire table
AS
   RETURN (SELECT * FROM dbo.Customer WHERE LEN(FirstName) = @length); 
GO

-- Use the select statement on the return from the function, because it is a table
SELECT FirstName FROM dbo.CustomersWithFirstNameLengthof(9);

-- Stored Procedures are similiar to function, except that we can also modify the database
GO
CREATE OR ALTER PROCEDURE dbo.UpdateAllCustomers( @postalcode INT, @modified INT OUTPUT) -- use OUTPUT as a parameter to take the place of a RETURN; 
AS                                                                                       -- OR ALTER, will alter a pre-existing function if it has already been declared
BEGIN
   BEGIN TRY
      IF (NOT EXISTS (SELECT * FROM dbo.Customer))
         BEGIN
            RAISERROR ('No data found in table', 15, 1);
         END
      SET @modified = (SELECT COUNT(*) FROM dbo.Customer);
      UPDATE dbo.Customer SET PostalCode = @postalcode;
   END TRY
   BEGIN CATCH
      PRINT 'ERROR'
   END CATCH
END
GO

SELECT PostalCode FROM dbo.Customer;

DECLARE @result INT;
EXECUTE dbo.UpdateAllCustomers 12343, @result OUTPUT;
SELECT @result;

SELECT PostalCode FROM dbo.Customer;


-- Triggers
-- Some code that will run, instead of or after you insert
-- , update, or delete to a specified table.

GO
CREATE TRIGGER Playlist.DateModified ON Playlist.Name
AFTER UPDATE
AS
   BEGIN
      UPDATE Playlist.Name 
      SET DateModified = SYSUTCDATETIME()
      WHERE Id IN (SELECT Id FROM Inserted) --triggers get access to two special table-valued variables, inserted and deleted.
   END
GO

GO
CREATE TRIGGER PreventDelete ON Playlist
INSTEAD OF DELETE
AS
   BEGIN
      RAISERROR('Delete not authorized.', 15, 1)
   END
GO