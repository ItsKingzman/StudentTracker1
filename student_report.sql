CREATE TABLE StudentReport 
(
    Id int IDENTITY(1,1) PRIMARY KEY,
    Name varchar(255) NOT NULL,
    Course varchar(255) NOT NULL,
    Grade int NOT NULL 
);
-- This creates a table called "StudentReport" containing four columns: 
-- Id (primary key, identity, auto-incrementing), Name (varchar, not null), Course (varchar, not null)
-- and Grade (int, not null). The Id column is the primary key and is auto incrementing which means it 
-- will assign sequential numbers to each new row inserted into the table.