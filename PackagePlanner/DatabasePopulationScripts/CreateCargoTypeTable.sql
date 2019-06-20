CREATE TABLE CargoType (
	Id varchar(255) PRIMARY KEY,
	Name varchar(255) UNIQUE
);

INSERT INTO CargoType
VALUES
	('refr', 'Refrigerated goods'),
	('std', 'Standard goods'),
	('caut', 'Fragile goods'),
	('weap', 'Weapons'),
	('anim', 'Live Animals');