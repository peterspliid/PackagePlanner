CREATE TABLE WeightCategory (
	Id varchar(255) PRIMARY KEY,
	Name varchar(255) UNIQUE
);

INSERT INTO WeightCategory
VALUES
	('Light','Less than 1kg'),
	('Normal','1kg - 5kg'),
	('Heavy','5kg - 20kg');