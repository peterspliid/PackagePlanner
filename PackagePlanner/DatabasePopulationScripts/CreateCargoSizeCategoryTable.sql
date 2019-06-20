CREATE TABLE CargoSizeCategory (
	Id varchar(255) PRIMARY KEY,
	MaxSize int,
	Unit varchar(255)
);

INSERT INTO CargoSizeCategory
VALUES
	('Small', 25, 'cm'),
	('Medium', 40, 'cm'),
	('Large', 200, 'cm');