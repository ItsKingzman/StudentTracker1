CREATE TABLE StudentReport 
(
    Id int IDENTITY(1,1) PRIMARY KEY,
    Name varchar(255) NOT NULL,
    Course varchar(255) NOT NULL,
    Grade int NOT NULL 
);