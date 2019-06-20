CREATE TABLE CargoSizeCategory (
	Id varchar(255) PRIMARY KEY,
	MaxSize int,
	Unit varchar(255)
);

INSERT INTO CargoSizeCategory
VALUES
	('A', 25, 'cm'),
	('B', 40, 'cm'),
	('C', 200, 'cm');