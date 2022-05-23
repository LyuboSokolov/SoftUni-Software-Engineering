CREATE TABLE [Categories](
[Id] INT PRIMARY KEY IDENTITY,
[CategoryName] NVARCHAR(50) NOT NULL,
[DailyRate] FLOAT,
[WeeklyRate] FLOAT,
[MonthlyRate] FLOAT,
[WeekendRate] FLOAT)

CREATE TABLE [Cars](
[Id] INT PRIMARY KEY IDENTITY,
[PlateNumber] NVARCHAR(10) NOT NULL,
[Manufacturer] NVARCHAR(30) NOT NULL,
[Model] NVARCHAR(30) NOT NULL,
[CarYear] INT NOT NULL,
[CategoryId] INT,
[Doors] INT,
[Pictures] VARBINARY(MAX),
[Condition] NVARCHAR(10),
[Available] bit NOT NULL
)

CREATE TABLE [Employees](
[Id] INT PRIMARY KEY IDENTITY,
[FirstName] NVARCHAR(30) NOT NULL,
[LastName] NVARCHAR(30) NOT NULL,
[Title] NVARCHAR(30),
[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Customers](
[Id] INT PRIMARY KEY IDENTITY,
[DriverLicenceNumber] INT NOT NULL,
[FullName] NVARCHAR(50) NOT NULL,
[Address] NVARCHAR(50),
[City] NVARCHAR(30),
[ZIPCode] INT,
[Notes] NVARCHAR(MAX)
)

CREATE TABLE [RentalOrders](
[Id] INT PRIMARY KEY IDENTITY,
[EmployeeId] INT NOT NULL,
[CustomerId] INT NOT NULL,
[CarId] INT NOT NULL,
[TankLevel] INT,
[KilometrageStart] INT NOT NULL,
[KilometrageEnd] INT NOT NULL,
[TotalKilometrage] INT,
[StartDate] DATETIME2,
[EndDate] DATETIME2,
[TotalDays] INT,
[RateApplied] NVARCHAR(30),
[TaxRate] FLOAT,
[OrderStatus] BIT,
[NOTES] NVARCHAR(MAX)
)

INSERT INTO [Categories] ([CategoryName]) VALUES
('Джип'),
('Лек автомобил'),
('Бус')

INSERT INTO [Cars] ([PlateNumber],[Manufacturer],[Model],[CarYear],[Available])
VALUES
('РВ 123','Алфа','Ромео',2000,0),
('РВ 1213 РС','Алфа','Ромео',2020,1),
('РВ 1523','Алфа','Ромео',2009,1)


INSERT INTO [Employees] ([FirstName],[LastName])
VALUES
('Petko','Ivanovich'),
('Vasko','Petrov'),
('Neno','Nenovich')

INSERT INTO [Customers] ([DriverLicenceNumber],[FullName])
VALUES
(65343,'Petko Petkov'),
(15343,'Ivan Ivanov'),
(123,'Sasho N')

INSERT INTO [RentalOrders] ([EmployeeId],[CustomerId],[CarId],[KilometrageStart],[KilometrageEnd])
VALUES
(123,45,1212,200,250),
(456,55,1202,2100,2250),
(789,65,1200,12200,13250)