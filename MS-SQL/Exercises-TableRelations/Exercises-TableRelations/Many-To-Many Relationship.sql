CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(40) NOT NULL
)

CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY IDENTITY(101,1),
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams
(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL,
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID) NOT NULL,
	PRIMARY KEY (StudentID, ExamID)
)

INSERT INTO Students([Name]) VALUES
('Mila'),('Toni'),('Ron')

INSERT INTO Exams([Name]) VALUES
('SpringMVC'),('Neo4j'),('Oracle 11g')

INSERT INTO StudentsExams(StudentID, ExamID) VALUES
(1,101),(1,102),(2,101),(3,103),(2,102),(2,103)

SELECT *
	FROM Students AS S
	JOIN Exams AS e ON S.Name = S.Name