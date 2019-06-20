CREATE TABLE WeightCategory (
	name varchar(255) PRIMARY KEY,
	price decimal
);

INSERT INTO WeightCategory
VALUES
	('Less than 1kg', 10),
	('1kg - 5kg', 15),
	('5kg - 20kg', 20);