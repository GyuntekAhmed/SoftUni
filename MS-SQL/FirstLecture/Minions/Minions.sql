CREATE DATABASE Minions


-- Minions (Id, Name, Age). Then add new table Towns (Id, Name). 

CREATE TABLE Minions
(
    Id Int Primary key,
	[Name] Varchar(30),
	Age Int
)

Create Table Towns
(
Id Int Primary key,
	[Name] Varchar(50),
	)

	Alter Table Minions
	Add TownId Int

	ALTER TABLE Minions
	ADD FOREIGN KEY (TownId) REFERENCES Towns(Id)

--	Minions		                Towns
--Id	Name	Age	  TownId		Id	Name
--1	   Kevin	22	     1		     1 Sofia
--2	   Bob	     15	     3	         2 Plovdiv
--3	   Steward	NULL	 2		     3	Varna

INSERT INTO Towns (Id, Name) VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions (Id, Name, Age, TownId) Values
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward',null, 2)