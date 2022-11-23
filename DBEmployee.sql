--CREATE DATABASE DBEmployee;

USE DBEmployee;

CREATE TABLE Department
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50)
)

CREATE TABLE Employee
(
	Id INT PRIMARY KEY IDENTITY,
	FullName VARCHAR(50),
	DepartmentId INT REFERENCES Department(Id),
	Salary DECIMAL(10, 2),
	HireDate DATETIME
)

--INSERT INTO Department (Name) VALUES ('Administration'), ('Marketing'), ('Sales'), ('Production');

--SELECT * FROM Department;

INSERT INTO Employee (FullName, DepartmentId, Salary, HireDate) VALUES
('Mary Patterson', 1, 1500, GETDATE());

SELECT * FROM Employee;