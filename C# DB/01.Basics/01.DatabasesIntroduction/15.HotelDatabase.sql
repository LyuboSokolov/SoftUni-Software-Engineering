CREATE TABLE [Employees] (
[Id] INT PRIMARY KEY IDENTITY,
[FirstName] NVARCHAR(30) NOT NULL,
[LastName] NVARCHAR(30) NOT NULL,
[Title] NVARCHAR(30),
[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Customers] (
[AccountNumber] INT PRIMARY KEY IDENTITY,
[FirstName] NVARCHAR(30) NOT NULL,
[LastName] NVARCHAR(30) NOT NULL,
[PhoneNumber] INT NOT NULL,
[EmergencyName] NVARCHAR(30),
[EmergencyNumber] INT,
[Notes] NVARCHAR(MAX)
)

CREATE TABLE [RoomStatus] (
[Id] INT PRIMARY KEY IDENTITY,
[RoomStatus] BIT NOT NULL,
[Notes] NVARCHAR(MAX)
)

CREATE TABLE [RoomTypes] (
[Id] INT PRIMARY KEY IDENTITY,
[RoomType] NVARCHAR(30) NOT NULL,
[Notes] NVARCHAR(MAX)
)

CREATE TABLE [BedTypes] (
[Id] INT PRIMARY KEY IDENTITY,
[BedType] NVARCHAR(30) NOT NULL,
[Notes] NVARCHAR(MAX)
)


CREATE TABLE [Rooms] (
[RoomNumber] INT PRIMARY KEY IDENTITY,
[RoomType] NVARCHAR(30) NOT NULL,
[BedType] NVARCHAR(30) NOT NULL,
[Rate] FLOAT,
[RoomStatus] INT,
[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Payments] (
[Id] INT PRIMARY KEY IDENTITY,
[EmployeeId] INT NOT NULL,
[PaymentDate] DATE NOT NULL,
[AccountNumber] INT NOT NULL,
[FirstDateOccupied] DATETIME2,
[LastDateOccupied] DATETIME2,
[TotalDays] INT,
[AmountCharged] DECIMAL,
[TaxRate] DECIMAL,
[TaxAmount] DECIMAL,
[PaymentTotal] DECIMAL,
[Notes] NVARCHAR(MAX)
)

CREATE TABLE [Occupancies] (
[Id] INT PRIMARY KEY IDENTITY,
[EmployeeId] INT NOT NULL,
[DateOccupied] DATETIME2 NOT NULL,
[AccountNumber] INT,
[RoomNumber] INT NOT NULL,
[RateApplied] INT,
[PhoneCharge] FLOAT,
[Notes] NVARCHAR(MAX)
)

INSERT INTO [Employees] ([FirstName],[LastName])
VALUES
('Pesho','Margina'),
('Ivan','Kotov'),
('Peshko','Motora')

INSERT INTO [Customers] ([FirstName],[LastName],[PhoneNumber])
VALUES
('Ilko','Ilkov',089545),
('Manol','Manolov',0895),
('Mondragon','Valentinov',01895)

INSERT INTO [RoomStatus] ([RoomStatus])
VALUES
(1),
(1),
(0)

INSERT INTO [RoomTypes] ([RoomType])
VALUES
('Апартамент'),
('Двоина стая'),
('Единична стая')

INSERT INTO [BedTypes] ([BedType])
VALUES
('единичн легло'),
('двойно легло'),
('спалня')


INSERT INTO [Rooms] ([RoomType],[BedType])
VALUES
('Апартамент','спалня'),
('Двоина стая','двойно легло'),
('Единична стая','единично легло')


INSERT INTO [Payments] ([EmployeeId],[PaymentDate],[AccountNumber])
VALUES
(123,'2008-11-11',323),
(1,'2008-11-01',333),
(13,'2008-01-11',313)

INSERT INTO [Occupancies] ([EmployeeId],[DateOccupied],[RoomNumber])
VALUES
(1,'2008-11-11',2),
(2,'2009-11-11',3),
(3,'2010-11-11',7)