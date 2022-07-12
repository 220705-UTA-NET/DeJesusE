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





