CREATE TABLE [People](
[Id] BIGINT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(200) NOT NULL,
[Picture] VARBINARY(MAX),
CHECK (DATALENGTH([Picture]) <= 2000000),
[Height] DECIMAL(2,2),
[Weight] DECIMAL(2,2),
[Gender] CHAR(1) NOT NULL,
[Birthdate] DATE NOT NULL,
[Biography] NVARCHAR(MAX)
)
INSERT INTO [People] ([Name],[Gender],[Birthdate])
VALUES ('Petko','m','2008-11-11')

INSERT INTO [People] ([Name],[Gender],[Birthdate])
VALUES ('Ivo','m','2004-01-11'),
('Pesho','m','2014-01-11'),
('Drago','m','2009-01-11'),
('Iva','f','2020-01-11')