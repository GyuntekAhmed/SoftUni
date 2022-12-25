CREATE TABLE People
(
   Id int primary key identity,
   [Name] char(200) not null,
   Height decimal(10,2),
   [Weight] decimal(10,2),
   Picture varchar(max),
   Birthdate datetime not null,
   Biography varchar(max),
   Gender bit not null
)

INSERT INTO People
([Name], Height, [Weight], Picture, Birthdate, Biography, Gender)
VALUES
('Gyuni', 1.75, 85, 'https://www.nasa.gov/webbfirstimages', '1991-07-02', 'Me', 0),
('Gyuntek', 1.77, 78, 'https://www.nasa.gov/webbfirstimages', '1991-07-03', 'Me', 0),
('Gyun', 1.88, 87, 'https://www.nasa.gov/webbfirstimages', '1991-07-04', 'Me', 0),
('Gyu', 1.83, 88, 'https://www.nasa.gov/webbfirstimages', '1991-07-05', 'Me', 0),
('G', 1.84, 99, 'https://www.nasa.gov/webbfirstimages', '1991-07-01', 'Me', 0)