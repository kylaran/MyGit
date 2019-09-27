CREATE TABLE [dbo].[Table]
(
	[ProductId] INT NOT NULL PRIMARY KEY, 
    [DateTrade] DATETIME NOT NULL, 
    [Name] NVARCHAR(128) NOT NULL, 
    [Quantity] INT NULL, 
    [Country] NVARCHAR(40) NOT NULL, 
    [Articule] NVARCHAR(15) NULL
)
