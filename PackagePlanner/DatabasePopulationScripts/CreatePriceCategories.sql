CREATE TABLE PriceCategory (
	Id varchar(255) PRIMARY KEY,
    CargoSizeCategoryId varchar(255) FOREIGN KEY REFERENCES CargoSizeCategory(Id) NOT NULL,
	WeightCategoryId varchar(255) FOREIGN KEY REFERENCES WeightCategory(Id) NOT NULL,
	Price decimal(19,4) NOT NULL,	
	Currency varchar(255) NOT NULL
);

INSERT INTO PriceCategory
VALUES
	('SL','Small', 'Light', 10.00, 'USD'),
	('SN','Small', 'Normal', 15.00, 'USD'),
	('SH','Small', 'Heavy', 30.00, 'USD'),
	('ML','Medium', 'Light', 15.00, 'USD'),
	('MN','Medium', 'Normal', 25.00, 'USD'),
	('MH','Medium', 'Heavy', 60.00, 'USD'),
	('LL','Large', 'Light', 20.00, 'USD'),
	('LN','Large', 'Normal', 35.00, 'USD'),
	('LH','Large', 'Heavy', 90.00, 'USD');