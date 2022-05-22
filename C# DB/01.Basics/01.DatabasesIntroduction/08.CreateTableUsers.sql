CREATE TABLE [Users](
[Id] BIGINT PRIMARY KEY IDENTITY,
[Username]  VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(26) NOT NULL,
[ProfilePicture] VARBINARY(MAX),
CHECK (DATALENGTH([ProfilePicture]) <= 900000),
[LastLoginTime] Time,
[IsDeleted] BIT
)

INSERT INTO [Users] ([Username],[Password])
VALUES
('Dragan','1223Pa'),
('Petkan','123Pae3a'),
('Vilian','123Psa'),
('Pesho','123Password'),
('Bogi','123Paasd')