CREATE TABLE Connection (
    Id int IDENTITY(001,1) PRIMARY KEY,
    Place1 varchar(255) FOREIGN KEY REFERENCES City(Id) NOT NULL,
	Place2 varchar(255) FOREIGN KEY REFERENCES City(Id) NOT NULL,
	ConnectionType varchar(255) NOT NULL
); 