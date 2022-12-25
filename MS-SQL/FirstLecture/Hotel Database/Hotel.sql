--Create Database Hotel

--

Create Table Employees
(
   Id int primary key,
   FirstName varchar(30) not null,
   LastName varchar(30) not null,
   Title varchar(20),
   Notes varchar(max)
);

Insert into Employees Values
(1,'Gyuntek', 'Ahmed', 'STO', 'Uraaa'),
(2,'Gyuni', 'Ahmed', 'CEO', 'Uraaaaaa'),
(3,'Georgi', 'Aleksiev', 'CFO', 'bbbb')

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

Insert Into Customers Values
(123456789, 'Gyuntek', 'Ahmed', '0123456789', 'Aaa', '00000', null),
(123456788, 'fsffv', 'vvvv', '0123456788', 'bbb', '0001100', null),
(123456787, 'sssss', 'dddd', '0123456787', 'vvvv', '0022000', null)

Create Table RoomStatus
(
   RoomStatus varchar(20) not null,
   Notes varchar(max)
);

Insert Into RoomStatus values
('Free', null),
('Not free', null),
('Repeair', null)

Create Table RoomTypes
(
  RoomTypes varchar(20) not null,
  Notes varchar(max)
);

Insert Into RoomTypes Values
('One Bedroom', null),
('Two Bedroom', null),
('Apartment', null)

Create Table BedTypes
(
   BedTypes varchar(20) not null,
   Notes varchar(max)
);

Insert Into BedTypes Values
('Single', null),
('Double', null),
('Child Bed', null)

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

Insert Into Rooms Values
(1, 'One Bedroom', 'Double', 10, 'Not free', null),
(2, 'Two Bedroom', 'Single', 10, 'Free', null),
(3, 'One Bedroom', 'Double', 10, 'Not free', null)

Create Table Payments
(
   Id int primary key,
   EmployeeId int not null,
   PaymentDate datetime not null,
   AccountNumber int not null,
   FirstDateOccupied datetime not null,
   LastDateOccupied datetime not null,
   TotalDays int not null,
   AmountCharged decimal(15,2) not null,
   TaxRate int,
   TaxAmount int,
   PaymentTotal decimal(15,2),
   Notes varchar(max)
);

Insert Into Payments Values
(1, 1, GETDATE(), 120, '23/12/22', '31/12/22', 5, 430.20, null, null, 520.55, null),
(2, 2, GETDATE(), 121, '24/12/22', '30/12/22', 5, 430.20, null, null, 520.55, null),
(3, 3, GETDATE(), 122, '26/12/22', '29/12/22', 5, 430.20, null, null, 520.55, null)

Create Table Occupancies
(
   Id int primary key,
   EmployeeId int not null,
   DateOccupied datetime not null,
   AccountNumber int not null,
   RoomNumber int not null,
   RateApplied int,
   PhoneCharge decimal(15,2),
   Notes varchar(max)
);

Insert Into Occupancies Values
(1, 120, GETDATE(), 100, 120, 1, 1, null),
(2, 121, GETDATE(), 101, 121, 2, 2, null),
(3, 122, GETDATE(), 102, 122, 3, 3, null)