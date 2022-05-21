INSERT INTO [Towns]

VALUES
('1','Sofia');

INSERT INTO [Towns]
VALUES
('2','Plovdiv'),
('3','Varna');


INSERT INTO [Minions]
VALUES
('1','Kevin','22','1'),
('2','Bob','15','3'),
('3','Steward','','2');


DELETE FROM [Minions] WHERE Name = 'Steward';

INSERT INTO [Minions]
VALUES
('3','Steward',NULL,'2');