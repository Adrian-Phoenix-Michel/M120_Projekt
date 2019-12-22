CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Username] NVARCHAR(16) NOT NULL, 
    [E-Mail] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(30) NOT NULL, 
    [DateOfBirth] DATE NULL, 
    [PreferredLocation] NVARCHAR(30) NULL, 
    [PreferredLanguage] NVARCHAR(30) NULL
)
