--Create Database Hotel

--Use Hotel

Create Table Employees
(
   Id int primary key identity,
   FirstName varchar(30) not null,
   LastName varchar(30) not null,
   Title varchar(20),
   Notes varchar(max)
);

Insert into Employees (FirstName, LastName, Title, Notes) Values
('Gyuntek', 'Ahmed', 'STO', 'Uraaa'),
('Gyuni', 'Ahmed', 'CEO', 'Uraaaaaa'),
('Georgi', 'Aleksiev', 'CFO', 'bbbb')

Create Table Customers
(
   AccountNumber int not null,
   FirstName varchar(30) not null,
   LastName varchar(30) not null,
   PhoneNumber varchar(10),
   EmergencyName varchar(30) not null,
   EmergencyNumber varchar(30) not null,
   Notes varchar(max)
);

Create Table RoomStatus
(
   RoomStatus varchar(20) not null,
   Notes varchar(max)
);

Create Table RoomTypes
(
  RoomTypes varchar(20) not null,
  Notes varchar(max)
);

Create Table BedTypes
(
   BedTypes varchar(20) not null,
   Notes varchar(max)
);

--Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
Create Table Rooms
(
   RoomNumber int primary key not null,
   RoomType varchar(20) not null,
   BedType varchar(20) not null,
   Rate int,
   RoomStatus varchar(20) not null,
   Notes varchar(max)
);

Create Table Payments
(
   Id int primary key identity,
   EmployeeId int not null,
   PaymentDate datetime not null,
   AccountNumber int not null,
   FirstDateOccupied varchar(20) not null,
   LastDateOccupied varchar(20) not null,
   TotalDays int not null,
   AmountCharged decimal(15,2) not null,
   TaxRate int,
   TaxAmount int,
   PaymentTotal decimal(15,2),
   Notes varchar(max)
);

Create Table Occupancies
(
   Id int primary key identity,
   EmployeeId int not null,
   DateOccupied datetime not null,
   AccountNumber int not null,
   RoomNumber int not null,
   RateApplied int,
   PhoneCharge decimal(15,2),
   Notes varchar(max)
);