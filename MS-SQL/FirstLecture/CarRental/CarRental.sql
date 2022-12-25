CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories
(
   Id INT PRIMARY KEY IDENTITY,
   CategoryName VARCHAR(30),
   DailyRate DECIMAL(10,2),
   WeeklyRate DECIMAL(10,2),
   MonthlyRate DECIMAL(10,2),
   WeekendRate DECIMAL(10,2)
)

CREATE TABLE Cars
(
   Id int primary key identity,
   PlateNumber varchar(30) not null,
   Manufacturer varchar(30),
   Model varchar(20),
   CarYear int,
   CategoryId int,
   Doors int,
   Picture varchar(max),
   Condition varchar(50),
   Available bit
)

Create Table Employees
(
   Id int primary key identity,
   FirstName varchar(30) not null,
   LastName varchar(30) not null,
   Title varchar(30),
   Notes varchar(max)
);

Create table Customers
(
   Id int primary key identity,
   DriveLicenseNumber int not null,
   FullName varchar(80),
   [Address] varchar(70),
   City varchar(30),
   ZIPCode int,
   Notes varchar(max)
);

Create table RentalOrders
(
   Id int primary key identity,
   employee_id int not null,
   customer_id int,
   car_id int not null,
   car_condition varchar(50),
   tank_level int,
   kilometrage_start int,
   kilometrage_end int,
   total_kilometrage int,
   start_date date,
   end_date date,
   total_days int,
   rate_applied int,
   tax_rate int,
   order_status varchar(50),
   notes varchar(max)
);

insert into cars(plateNumber)
values ('123'),('1234'),('12345');

insert into categories(CategoryName)
values ('Classic'),('Limuzine'),('Sport');

insert into customers(DriveLicenseNumber)
values ('2232'),('232323'),('111');

insert into employees(FirstName, LastName)
values ('Ivan', 'Ivanov'),('Ivan1', 'Ivanov1'), ('Ivan2', 'Ivanov2');

insert into RentalOrders(employee_id,car_id)
values (1, 1),(1, 2), (2, 3);