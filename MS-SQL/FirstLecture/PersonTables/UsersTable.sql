CREATE TABLE Users
(
   Id bigint primary key identity,
   Username varchar(30) not null,
   [Password] varchar(26) not null,
   ProfilePicture varchar(max),
   LastLoginTime date,
   IsDeleted bit
)

INSERT INTO Users
(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
VALUES

('dfbvdgbf','dfssf', 'https://www.nasa.gov/webbfirstimages','2022-12-22', 0),
('dfttb','fgbdfv', 'https://www.nasa.gov/webbfirstimages','2022-12-20', 0),
('dcsd','dcs', 'https://www.nasa.gov/webbfirstimages','2022-12-21', 0)

SELECT * FROM Users

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC0792CE0179

ALTER TABLE Users
ADD CONSTRAINT PK_IdUsername PRIMARY KEY(Id, Username)

ALTER TABLE Users
ADD CONSTRAINT CH_PasswordIsAtLeast5Symbols CHECK (LEN(Password) > 5)

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

ALTER TABLE Users
DROP CONSTRAINT PK_IdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CH_UsernameIsAtLeast3Symbols CHECK (LEN(Username) > 3)

