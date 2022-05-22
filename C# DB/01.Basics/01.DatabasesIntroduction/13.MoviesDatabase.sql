CREATE TABLE [Directors](
[Id] INT PRIMARY KEY IDENTITY,
[DirectorName] NVARCHAR(30) NOT NULL,
[NOTES] NVARCHAR(MAX)
)

CREATE TABLE [Genres](
[Id] INT PRIMARY KEY IDENTITY,
[GenreName] NVARCHAR(30) NOT NULL,
[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Categories](
[Id] INT PRIMARY KEY IDENTITY,
[CategoryName] NVARCHAR(30) NOT NULL,
[NOTES] NVARCHAR(MAX)
)

CREATE TABLE [Movies](
[Id] INT PRIMARY KEY IDENTITY,
[Title] NVARCHAR(30) NOT NULL,
[DirectorId] INT,
[CopyrightYear] DATE,
[Length] INT NOT NULL,
[GenreId] INT,
[CategoryId] INT,
[Rating] INT,
[Notes] NVARCHAR(MAX)
)INSERT INTO [Directors] ([DirectorName])VALUES
('Mondragon'),
('2000'),
('Fox'),
('AI'),
('Softuni')

INSERT INTO [Genres] ([GenreName]) VALUES
('Екшън'),
('Приключенски'),
('Комедия'),
('Ужас'),
('Психо')

ALTER TABLE [Categories]
ALTER COLUMN [CategoryName] NVARCHAR(100)

INSERT INTO [Categories] ([CategoryName]) VALUES
('Препоръчва се за деца'),
('Без възрастови ограничения'),
('Не се препоръчва за деца под 12'),
('Не се препоръчва за деца под 16'),
('Забранено за лица под 18')

ALTER TABLE [Movies]
ALTER COLUMN [Length] REAL

INSERT INTO [Movies] ([Title],[Length]) VALUES
('Роки',1.45),
('Ледена епоха',1.25),
('Аз роботът',1.05),
('Трансформърс',1.10),
('Такси',2.25)