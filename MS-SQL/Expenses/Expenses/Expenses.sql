CREATE TABLE [dbo].[Table1]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Description] NCHAR(500) NOT NULL, 
    [Amount] DECIMAL(18, 2) NOT NULL, 
    [TimeOfExpense] SMALLDATETIME NULL
)
