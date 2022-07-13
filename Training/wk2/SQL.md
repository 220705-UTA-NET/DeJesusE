Database

- series of tables with rows and columns, uses multiple tables to organize data
- SQL(Structured Query Language) -
  uses "families" of commands to
  - creating data
  - manipulating data
  - manage databases (environment)
  - CRUD commands - Create, Read, Update, Delete
- DML - Data Manipulation Language - allows our to modify and manipulate our data (the cells)
  - INSERT
  - DELETE
  - TRUNCATE
  - UPDATE
- DCL - Data Control Language - controls access to data within the tables
- DDL - Data Definition Language - allows us to create the structure for our data (the tables)
  - CREATE
  - ALTER
  - DROP
- DQL - Data Query Language - allows our to structure our query or the search of our data

Normalization

- Normalization is performed to remove the possibility of an anomaly
  - update anomaly - with redundancy, updates can become inconsistent
  - delete anomaly - when delete is performed, more than the intended data is removed.
  - insert anomaly - can't insert revelant data without adding redundancy into our table or inserting
    other connected data.

Normal Forms (NF)

1st Normal Form (1NF)
(1) - All data, entries, and elements have atomic values (Only one value per column per entry)
(2) - Remove repeating groups from a column
(3) - Every entry has a primary key (Every value must be unique)

2nd Normal Form(2NF)
(1) - You must be in 1NF
(2) - No Partial Dependencies - all columns NOT part of a Composite Key must be fully dependant on the entire key

3rd Normal Form (3NF)
(1) - You must be in 2NF
(2) - No Transitive Dependencies - no column may depend on another column that is NOT part of the key

A key, the whole key, and nothing but the key:

- Every table needs a key
- Every value must depend on the key
- Every value must only depend on the key
