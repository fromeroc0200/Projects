/*--------------------------------------------------------------------
© 2017 sqlservertutorial.net All Rights Reserved
--------------------------------------------------------------------
Name   : BikeStores
Link   : http://www.sqlservertutorial.net/load-sample-database/
Version: 1.0
--------------------------------------------------------------------*/
-- create schemas
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'production')
BEGIN
	EXEC('CREATE SCHEMA production')
END
GO

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'sales')
BEGIN
	EXEC('CREATE SCHEMA sales')
END
GO

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'security')
BEGIN
	EXEC('CREATE SCHEMA security')
END
GO

-- create tables

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = N'security' and TABLE_NAME = N'user')
BEGIN
	CREATE TABLE security.[user](
		UserId uniqueidentifier NOT NULL PRIMARY KEY,
		UserName varchar(255) NOT NULL,
		[Password] varchar(255) NOT NULL,
	)
END


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = N'security' and TABLE_NAME = N'userClaim')
BEGIN
	CREATE TABLE security.userClaim (
		ClaimId uniqueidentifier NOT NULL,
		UserId uniqueidentifier NOT NULL,
		ClaimType varchar(100) NOT NULL,
		ClaimValue varchar(50) NOT NULL,
		FOREIGN KEY (UserId) REFERENCES security.[user] (UserId) ON DELETE CASCADE ON UPDATE CASCADE,
	) 
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = N'production' and TABLE_NAME = N'categories')
BEGIN
	
	CREATE TABLE production.categories (
		category_id INT IDENTITY (1, 1) PRIMARY KEY,
		category_name VARCHAR (255) NOT NULL
	);
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = N'production' and TABLE_NAME = N'brands')
BEGIN
	CREATE TABLE production.brands (
		brand_id INT IDENTITY (1, 1) PRIMARY KEY,
		brand_name VARCHAR (255) NOT NULL
	);
END


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = N'production' and TABLE_NAME = N'products')
BEGIN
	CREATE TABLE production.products (
		product_id INT IDENTITY (1, 1) PRIMARY KEY,
		product_name VARCHAR (255) NOT NULL,
		brand_id INT NOT NULL,
		category_id INT NOT NULL,
		model_year SMALLINT NOT NULL,
		list_price DECIMAL (10, 2) NOT NULL,
		FOREIGN KEY (category_id) REFERENCES production.categories (category_id) ON DELETE CASCADE ON UPDATE CASCADE,
		FOREIGN KEY (brand_id) REFERENCES production.brands (brand_id) ON DELETE CASCADE ON UPDATE CASCADE
	);
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = N'sales' and TABLE_NAME = N'customers')
BEGIN
	CREATE TABLE sales.customers (
		customer_id INT IDENTITY (1, 1) PRIMARY KEY,
		first_name VARCHAR (255) NOT NULL,
		last_name VARCHAR (255) NOT NULL,
		phone VARCHAR (25),
		email VARCHAR (255) NOT NULL,
		street VARCHAR (255),
		city VARCHAR (50),
		state VARCHAR (25),
		zip_code VARCHAR (5)
	);
END


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = N'sales' and TABLE_NAME = N'stores')
BEGIN
CREATE TABLE sales.stores (
	store_id INT IDENTITY (1, 1) PRIMARY KEY,
	store_name VARCHAR (255) NOT NULL,
	phone VARCHAR (25),
	email VARCHAR (255),
	street VARCHAR (255),
	city VARCHAR (255),
	state VARCHAR (10),
	zip_code VARCHAR (5)
);
END


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = N'sales' and TABLE_NAME = N'staffs')
BEGIN
	CREATE TABLE sales.staffs (
		staff_id INT IDENTITY (1, 1) PRIMARY KEY,
		first_name VARCHAR (50) NOT NULL,
		last_name VARCHAR (50) NOT NULL,
		email VARCHAR (255) NOT NULL UNIQUE,
		phone VARCHAR (25),
		active tinyint NOT NULL,
		store_id INT NOT NULL,
		manager_id INT,
		FOREIGN KEY (store_id) REFERENCES sales.stores (store_id) ON DELETE CASCADE ON UPDATE CASCADE,
		FOREIGN KEY (manager_id) REFERENCES sales.staffs (staff_id) ON DELETE NO ACTION ON UPDATE NO ACTION
	);
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = N'sales' and TABLE_NAME = N'orders')
BEGIN
	CREATE TABLE sales.orders (
		order_id INT IDENTITY (1, 1) PRIMARY KEY,
		customer_id INT,
		order_status tinyint NOT NULL,
		order_date DATE NOT NULL,
		required_date DATE NOT NULL,
		shipped_date DATE,
		store_id INT NOT NULL,
		staff_id INT NOT NULL,
		FOREIGN KEY (customer_id) REFERENCES sales.customers (customer_id) ON DELETE CASCADE ON UPDATE CASCADE,
		FOREIGN KEY (store_id) REFERENCES sales.stores (store_id) ON DELETE CASCADE ON UPDATE CASCADE,
		FOREIGN KEY (staff_id) REFERENCES sales.staffs (staff_id) ON DELETE NO ACTION ON UPDATE NO ACTION
	);
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = N'sales' and TABLE_NAME = N'order_items')
BEGIN
	CREATE TABLE sales.order_items (
		order_id INT,
		item_id INT,
		product_id INT NOT NULL,
		quantity INT NOT NULL,
		list_price DECIMAL (10, 2) NOT NULL,
		discount DECIMAL (4, 2) NOT NULL DEFAULT 0,
		PRIMARY KEY (order_id, item_id),
		FOREIGN KEY (order_id) REFERENCES sales.orders (order_id) ON DELETE CASCADE ON UPDATE CASCADE,
		FOREIGN KEY (product_id) REFERENCES production.products (product_id) ON DELETE CASCADE ON UPDATE CASCADE
	);
END


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = N'production' and TABLE_NAME = N'stocks')
BEGIN
	CREATE TABLE production.stocks (
		store_id INT,
		product_id INT,
		quantity INT,
		PRIMARY KEY (store_id, product_id),
		FOREIGN KEY (store_id) REFERENCES sales.stores (store_id) ON DELETE CASCADE ON UPDATE CASCADE,
		FOREIGN KEY (product_id) REFERENCES production.products (product_id) ON DELETE CASCADE ON UPDATE CASCADE
	);
END

INSERT INTO security.[user] (UserId, UserName, [Password]) SELECT NEWID(), 'fer', 'admin' WHERE NOT EXISTS (SELECT UserName FROM security.[user] WHERE UserName='fer')
INSERT INTO security.[user] (UserId, UserName, [Password]) SELECT NEWID(), 'admin', 'admin' WHERE NOT EXISTS (SELECT UserName FROM security.[user] WHERE UserName='admin')

INSERT INTO security.userClaim (ClaimId, UserId, ClaimType, ClaimValue)
	SELECT NEWID(), us.UserId, 'CanAccessCategory', 1  FROM security.[user] us WHERE NOT EXISTS (SELECT UserName FROM security.userClaim WHERE ClaimType = 'CanAccessCategory')
	UNION SELECT NEWID(), us.UserId, 'CanAccessProducts', 1  FROM security.[user] us WHERE NOT EXISTS (SELECT UserName FROM security.userClaim WHERE ClaimType = 'CanAccessProducts')
 	UNION SELECT NEWID(), us.UserId, 'CanAddCategory', 1  FROM security.[user] us WHERE NOT EXISTS (SELECT UserName FROM security.userClaim WHERE ClaimType = 'CanAddCategory')
	UNION SELECT NEWID(), us.UserId, 'CanAddProduct', 1  FROM security.[user] us WHERE NOT EXISTS (SELECT UserName FROM security.userClaim WHERE ClaimType = 'CanAddProduct')
	UNION SELECT NEWID(), us.UserId, 'CanSaveProduct', 1  FROM security.[user] us WHERE NOT EXISTS (SELECT UserName FROM security.userClaim WHERE ClaimType = 'CanSaveProduct')

	SELECT * FROM security.userClaim ORDER BY UserId
SET IDENTITY_INSERT [production].[brands] ON 
INSERT [production].[brands] ([brand_id], [brand_name]) VALUES
	 (1, N'Electra')
	,(2, N'Haro')
	,(3, N'Heller')
	,(4, N'Pure Cycles')
	,(5, N'Ritchey')
	,(6, N'Strider')
	,(7, N'Sun Bicycles')
	,(8, N'Surly')
	,(9, N'Trek')
SET IDENTITY_INSERT [production].[brands] OFF

SET IDENTITY_INSERT [production].[categories] ON 
INSERT [production].[categories] ([category_id], [category_name]) VALUES
 (1, N'Children Bicycles')
,(2, N'Comfort Bicycles')
,(3, N'Cruisers Bicycles')
,(4, N'Cyclocross Bicycles')
,(5, N'Electric Bikes')
,(6, N'Mountain Bikes')
,(7, N'Road Bikes')
SET IDENTITY_INSERT [production].[categories] OFF

SET IDENTITY_INSERT [sales].[stores] ON 
INSERT [sales].[stores] ([store_id], [store_name], [phone], [email], [street], [city], [state], [zip_code]) VALUES
 (1, N'Santa Cruz Bikes', N'(831) 476-4321', N'santacruz@bikes.shop', N'3700 Portola Drive', N'Santa Cruz', N'CA', N'95060')
,(2, N'Baldwin Bikes', N'(516) 379-8888', N'baldwin@bikes.shop', N'4200 Chestnut Lane', N'Baldwin', N'NY', N'11432')
,(3, N'Rowlett Bikes', N'(972) 530-5555', N'rowlett@bikes.shop', N'8000 Fairway Avenue', N'Rowlett', N'TX', N'75088')
SET IDENTITY_INSERT [sales].[stores] OFF

SET IDENTITY_INSERT [sales].[staffs] ON 
INSERT [sales].[staffs] ([staff_id], [first_name], [last_name], [email], [phone], [active], [store_id], [manager_id]) VALUES
 (1, N'Fabiola', N'Jackson', N'fabiola.jackson@bikes.shop', N'(831) 555-5554', 1, 1, NULL)
,(2, N'Mireya', N'Copeland', N'mireya.copeland@bikes.shop', N'(831) 555-5555', 1, 1, 1)
,(3, N'Genna', N'Serrano', N'genna.serrano@bikes.shop', N'(831) 555-5556', 1, 1, 2)
,(4, N'Virgie', N'Wiggins', N'virgie.wiggins@bikes.shop', N'(831) 555-5557', 1, 1, 2)
,(5, N'Jannette', N'David', N'jannette.david@bikes.shop', N'(516) 379-4444', 1, 2, 1)
,(6, N'Marcelene', N'Boyer', N'marcelene.boyer@bikes.shop', N'(516) 379-4445', 1, 2, 5)
,(7, N'Venita', N'Daniel', N'venita.daniel@bikes.shop', N'(516) 379-4446', 1, 2, 5)
,(8, N'Kali', N'Vargas', N'kali.vargas@bikes.shop', N'(972) 530-5555', 1, 3, 1)
,(9, N'Layla', N'Terrell', N'layla.terrell@bikes.shop', N'(972) 530-5556', 1, 3, 7)
,(10, N'Bernardine', N'Houston', N'bernardine.houston@bikes.shop', N'(972) 530-5557', 1, 3, 7)
SET IDENTITY_INSERT [sales].[staffs] OFF

SET IDENTITY_INSERT [production].[products] ON 
INSERT [production].[products] ([product_id], [product_name], [brand_id], [category_id], [model_year], [list_price]) VALUES
 (2, N'Ritchey Timberwolf Frameset - 2016', 5, 6, 2016, 749.99)
,(3, N'Surly Wednesday Frameset - 2016', 8, 6, 2016, 999.99)
,(4, N'Trek Fuel EX 8 29 - 2016', 9, 6, 2016, 2899.99)
,(5, N'Heller Shagamaw Frame - 2016', 3, 6, 2016, 1320.99)
,(6, N'Surly Ice Cream Truck Frameset - 2016', 8, 6, 2016, 469.99)
,(7, N'Trek Slash 8 27.5 - 2016', 9, 6, 2016, 3999.99)
,(8, N'Trek Remedy 29 Carbon Frameset - 2016', 9, 6, 2016, 1799.99)
,(9, N'Trek Conduit+ - 2016', 9, 5, 2016, 2999.99)
,(10, N'Surly Straggler - 2016', 8, 4, 2016, 1549.00)
,(11, N'Surly Straggler 650b - 2016', 8, 4, 2016, 1680.99)
,(12, N'Electra Townie Original 21D - 2016', 1, 3, 2016, 549.99)
,(13, N'Electra Cruiser 1 (24-Inch) - 2016', 1, 3, 2016, 269.99)
,(14, N'Electra Girl''s Hawaii 1 (16-inch) - 2015/2016', 1, 3, 2016, 269.99)
,(15, N'Electra Moto 1 - 2016', 1, 3, 2016, 529.99)
,(16, N'Electra Townie Original 7D EQ - 2016', 1, 3, 2016, 599.99)
,(17, N'Pure Cycles Vine 8-Speed - 2016', 4, 3, 2016, 429.00)
,(18, N'Pure Cycles Western 3-Speed - Women''s - 2015/2016', 4, 3, 2016, 449.00)
,(19, N'Pure Cycles William 3-Speed - 2016', 4, 3, 2016, 449.00)
,(20, N'Electra Townie Original 7D EQ - Women''s - 2016', 1, 3, 2016, 599.99)
,(21, N'Electra Cruiser 1 (24-Inch) - 2016', 1, 1, 2016, 269.99)
,(22, N'Electra Girl''s Hawaii 1 (16-inch) - 2015/2016', 1, 1, 2016, 269.99)
,(23, N'Electra Girl''s Hawaii 1 (20-inch) - 2015/2016', 1, 1, 2016, 299.99)
,(25, N'Electra Townie Original 7D - 2015/2016', 1, 2, 2016, 499.99)
,(26, N'Electra Townie Original 7D EQ - 2016', 1, 2, 2016, 599.99)
SET IDENTITY_INSERT [production].[products] OFF

INSERT [production].[stocks] ([store_id], [product_id], [quantity]) VALUES
 (1, 2, 5)
,(1, 3, 6)
,(1, 4, 23)
,(1, 5, 22)
,(1, 6, 0)
,(1, 7, 8)
,(1, 8, 0)
,(1, 9, 11)
,(1, 10, 15)
,(1, 11, 8)
,(1, 12, 16)
,(1, 13, 13)
,(1, 14, 8)
,(1, 15, 3)
,(1, 16, 4)
,(1, 17, 2)
,(1, 18, 16)
,(1, 19, 4)
,(1, 20, 26)
,(1, 21, 24)
,(1, 22, 29)
,(1, 23, 9)
,(1, 25, 10)
,(1, 26, 16)
,(2, 2, 16)
,(2, 3, 28)
,(2, 4, 2)
,(2, 5, 1)
,(2, 6, 11)
,(2, 7, 8)
,(2, 8, 1)
,(2, 9, 17)
,(2, 10, 13)
,(2, 11, 21)
,(2, 12, 2)
,(2, 13, 1)
,(2, 14, 18)
,(2, 15, 6)
,(2, 16, 20)
,(2, 17, 3)
,(2, 18, 13)
,(2, 19, 15)
,(2, 20, 20)
,(2, 21, 16)
,(2, 22, 0)
,(2, 23, 12)
,(2, 25, 18)
,(2, 26, 2)
,(3, 2, 24)
,(3, 3, 0)
,(3, 4, 11)
,(3, 5, 3)
,(3, 6, 27)
,(3, 7, 12)
,(3, 8, 12)
,(3, 9, 23)
,(3, 10, 21)
,(3, 11, 30)
,(3, 12, 30)
,(3, 13, 19)
,(3, 14, 4)
,(3, 15, 22)
,(3, 16, 19)
,(3, 17, 22)
,(3, 18, 5)
,(3, 19, 24)
,(3, 20, 19)
,(3, 21, 8)
,(3, 22, 20)
,(3, 23, 8)
,(3, 25, 15)
,(3, 26, 27)

SET IDENTITY_INSERT [sales].[customers] ON
INSERT [sales].[customers] ([customer_id], [first_name], [last_name], [phone], [email], [street], [city], [state], [zip_code]) VALUES
 (50, N'Cleotilde', N'Booth', NULL, N'cleotilde.booth@gmail.com', N'17 Corona St. ', N'Sugar Land', N'TX', N'77478')
,(60, N'Neil', N'Mccall', NULL, N'neil.mccall@gmail.com', N'7476 Oakland Dr. ', N'San Carlos', N'CA', N'94070')
,(91, N'Marvin', N'Mullins', N'(619) 635-2027', N'marvin.mullins@aol.com', N'7489 Redwood Drive ', N'San Diego', N'CA', N'92111')
,(94, N'Sharyn', N'Hopkins', NULL, N'sharyn.hopkins@hotmail.com', N'4 South Temple Ave. ', N'Baldwinsville', N'NY', N'13027')
,(175, N'Nova', N'Hess', NULL, N'nova.hess@msn.com', N'773 South Lafayette St. ', N'Duarte', N'CA', N'91010')
,(258, N'Maribel', N'William', NULL, N'maribel.william@aol.com', N'65 Magnolia Ave. ', N'Torrance', N'CA', N'90505')
,(259, N'Johnathan', N'Velazquez', NULL, N'johnathan.velazquez@hotmail.com', N'9680 E. Somerset Street ', N'Pleasanton', N'CA', N'94566')
,(271, N'Katheleen', N'Marks', NULL, N'katheleen.marks@yahoo.com', N'69 North Tower St. ', N'Longview', N'TX', N'75604')
,(324, N'Laureen', N'Paul', NULL, N'laureen.paul@yahoo.com', N'617 Squaw Creek Rd. ', N'Bellmore', N'NY', N'11710')
,(422, N'Valery', N'Saunders', NULL, N'valery.saunders@msn.com', N'42 Marlborough St. ', N'Victoria', N'TX', N'77904')
,(442, N'Alane', N'Munoz', N'(914) 706-7576', N'alane.munoz@gmail.com', N'8 Strawberry Dr. ', N'Yonkers', N'NY', N'10701')
,(450, N'Ellsworth', N'Michael', NULL, N'ellsworth.michael@yahoo.com', N'9982 White St. ', N'Carmel', N'NY', N'10512')
,(484, N'Chelsey', N'Boyd', NULL, N'chelsey.boyd@yahoo.com', N'9569 Birchpond Ave. ', N'Euless', N'TX', N'76039')
,(523, N'Joshua', N'Robertson', NULL, N'joshua.robertson@gmail.com', N'81 Campfire Court ', N'Patchogue', N'NY', N'11772')
,(526, N'Lazaro', N'Moran', NULL, N'lazaro.moran@gmail.com', N'83 E. Buttonwood Street ', N'Sugar Land', N'TX', N'77478')
,(541, N'Lanita', N'Burton', NULL, N'lanita.burton@msn.com', N'8980 Aspen Avenue ', N'Coachella', N'CA', N'92236')
,(552, N'Lea', N'Key', NULL, N'lea.key@yahoo.com', N'7 Ocean St. ', N'Banning', N'CA', N'92220')
,(668, N'Calandra', N'Stanton', NULL, N'calandra.stanton@aol.com', N'36 Livingston Dr. ', N'Lake Jackson', N'TX', N'77566')
,(677, N'Launa', N'Hull', NULL, N'launa.hull@yahoo.com', N'936 Grove Street ', N'Helotes', N'TX', N'78023')
,(696, N'Norine', N'Huffman', NULL, N'norine.huffman@aol.com', N'363 Dunbar Drive ', N'Encino', N'CA', N'91316')
,(872, N'Silas', N'Tate', N'(361) 219-2149', N'silas.tate@yahoo.com', N'9754 53rd Court ', N'Corpus Christi', N'TX', N'78418')
,(873, N'Patience', N'Clayton', NULL, N'patience.clayton@hotmail.com', N'68 Chestnut Dr. ', N'Niagara Falls', N'NY', N'14304')
,(923, N'Randee', N'Pitts', NULL, N'randee.pitts@msn.com', N'7371B Essex Street ', N'Canyon Country', N'CA', N'91387')
,(1165, N'Rikki', N'Morrow', N'(682) 936-1482', N'rikki.morrow@hotmail.com', N'7096 Plumb Branch Road ', N'Fort Worth', N'TX', N'76110')
,(1175, N'Sindy', N'Anderson', NULL, N'sindy.anderson@gmail.com', N'543 Halifax Ave. ', N'Pomona', N'CA', N'91768')
,(1204, N'Leslie', N'Higgins', NULL, N'leslie.higgins@hotmail.com', N'805 Logan Ave. ', N'Saratoga Springs', N'NY', N'12866')
,(1212, N'Jaqueline', N'Cummings', NULL, N'jaqueline.cummings@hotmail.com', N'478 Wrangler St. ', N'Huntington Station', N'NY', N'11746')
,(1238, N'Edgar', N'Quinn', NULL, N'edgar.quinn@aol.com', N'556 Dogwood Ave. ', N'Harlingen', N'TX', N'78552')
,(1324, N'Arla', N'Ellis', NULL, N'arla.ellis@yahoo.com', N'127 Crescent Ave. ', N'Utica', N'NY', N'13501')
,(1326, N'Tarra', N'Guerrero', NULL, N'tarra.guerrero@aol.com', N'10 Baker St. ', N'Auburn', N'NY', N'13021')
SET IDENTITY_INSERT [sales].[customers] OFF

SET IDENTITY_INSERT [sales].[orders] ON 
INSERT [sales].[orders] ([order_id], [customer_id], [order_status], [order_date], [required_date], [shipped_date], [store_id], [staff_id]) VALUES
 (1, 259, 4, N'2016-01-01', N'2016-01-03', N'2016-01-03', 1, 2)
,(2, 1212, 4, N'2016-01-01', N'2016-01-04', N'2016-01-03', 2, 6)
,(3, 523, 4, N'2016-01-02', N'2016-01-05', N'2016-01-03', 2, 7)
,(4, 175, 4, N'2016-01-03', N'2016-01-04', N'2016-01-05', 1, 3)
,(5, 1324, 4, N'2016-01-03', N'2016-01-06', N'2016-01-06', 2, 6)
,(6, 94, 4, N'2016-01-04', N'2016-01-07', N'2016-01-05', 2, 6)
,(7, 324, 4, N'2016-01-04', N'2016-01-07', N'2016-01-05', 2, 6)
,(8, 1204, 4, N'2016-01-04', N'2016-01-05', N'2016-01-05', 2, 7)
,(9, 60, 4, N'2016-01-05', N'2016-01-08', N'2016-01-08', 1, 2)
,(10, 442, 4, N'2016-01-05', N'2016-01-06', N'2016-01-06', 2, 6)
,(11, 1326, 4, N'2016-01-05', N'2016-01-08', N'2016-01-07', 2, 7)
,(12, 91, 4, N'2016-01-06', N'2016-01-08', N'2016-01-09', 1, 2)
,(13, 873, 4, N'2016-01-08', N'2016-01-11', N'2016-01-11', 2, 6)
,(14, 258, 4, N'2016-01-09', N'2016-01-11', N'2016-01-12', 1, 3)
,(15, 450, 4, N'2016-01-09', N'2016-01-10', N'2016-01-12', 2, 7)
,(16, 552, 4, N'2016-01-12', N'2016-01-15', N'2016-01-15', 1, 3)
,(17, 1175, 4, N'2016-01-12', N'2016-01-14', N'2016-01-14', 1, 3)
,(18, 541, 4, N'2016-01-14', N'2016-01-17', N'2016-01-15', 1, 3)
,(19, 696, 4, N'2016-01-14', N'2016-01-17', N'2016-01-16', 1, 2)
,(20, 923, 4, N'2016-01-14', N'2016-01-16', N'2016-01-17', 1, 2)
,(31, 1238, 4, N'2016-01-20', N'2016-01-22', N'2016-01-22', 3, 8)
,(50, 872, 4, N'2016-01-31', N'2016-02-03', N'2016-02-02', 3, 8)
,(67, 526, 4, N'2016-02-09', N'2016-02-11', N'2016-02-10', 3, 8)
,(70, 50, 3, N'2016-02-11', N'2016-02-11', NULL, 3, 9)
,(89, 668, 4, N'2016-02-21', N'2016-02-24', N'2016-02-24', 3, 8)
,(99, 1165, 4, N'2016-02-29', N'2016-03-01', N'2016-03-03', 3, 9)
,(101, 271, 4, N'2016-03-01', N'2016-03-04', N'2016-03-04', 3, 8)
,(106, 422, 4, N'2016-03-04', N'2016-03-05', N'2016-03-05', 3, 9)
,(110, 677, 4, N'2016-03-06', N'2016-03-08', N'2016-03-09', 3, 9)
,(127, 484, 4, N'2016-03-17', N'2016-03-18', N'2016-03-19', 3, 8)
SET IDENTITY_INSERT [sales].[orders] OFF

INSERT [sales].[order_items] ([order_id], [item_id], [product_id], [quantity], [list_price], [discount]) VALUES
 (1, 1, 20, 1, 599.99, 0.20)
,(1, 2, 8, 2, 1799.99, 0.07)
,(1, 3, 10, 2, 1549.00, 0.05)
,(1, 4, 16, 2, 599.99, 0.05)
,(1, 5, 4, 1, 2899.99, 0.20)
,(2, 1, 20, 1, 599.99, 0.07)
,(2, 2, 16, 2, 599.99, 0.05)
,(3, 2, 20, 1, 599.99, 0.05)
,(4, 1, 2, 2, 749.99, 0.10)
,(5, 1, 10, 2, 1549.00, 0.05)
,(5, 2, 17, 1, 429.00, 0.07)
,(5, 3, 26, 1, 599.99, 0.07)
,(6, 1, 18, 1, 449.00, 0.07)
,(6, 2, 12, 2, 549.99, 0.05)
,(6, 3, 20, 1, 599.99, 0.10)
,(6, 4, 3, 2, 999.99, 0.07)
,(6, 5, 9, 2, 2999.99, 0.07)
,(7, 1, 15, 1, 529.99, 0.07)
,(7, 2, 3, 1, 999.99, 0.10)
,(7, 3, 17, 2, 429.00, 0.10)
,(8, 1, 22, 1, 269.99, 0.05)
,(8, 2, 20, 2, 599.99, 0.07)
,(9, 1, 7, 2, 3999.99, 0.10)
,(10, 1, 14, 1, 269.99, 0.10)
,(11, 1, 8, 1, 1799.99, 0.05)
,(11, 2, 22, 2, 269.99, 0.10)
,(11, 3, 16, 2, 599.99, 0.20)
,(12, 1, 4, 2, 2899.99, 0.10)
,(12, 2, 11, 1, 1680.99, 0.05)
,(13, 1, 13, 1, 269.99, 0.10)
,(13, 2, 17, 2, 429.00, 0.05)
,(13, 3, 20, 2, 599.99, 0.10)
,(13, 4, 16, 2, 599.99, 0.05)
,(14, 1, 6, 1, 469.99, 0.07)
,(15, 1, 12, 2, 549.99, 0.07)
,(15, 2, 8, 1, 1799.99, 0.07)
,(15, 3, 18, 2, 449.00, 0.05)
,(15, 4, 23, 2, 299.99, 0.20)
,(16, 1, 8, 1, 1799.99, 0.20)
,(16, 2, 21, 1, 269.99, 0.05)
,(16, 3, 13, 2, 269.99, 0.07)
,(16, 4, 14, 1, 269.99, 0.07)
,(17, 1, 8, 1, 1799.99, 0.07)
,(17, 2, 23, 1, 299.99, 0.10)
,(17, 3, 5, 1, 1320.99, 0.10)
,(17, 4, 20, 2, 599.99, 0.20)
,(18, 1, 2, 2, 749.99, 0.20)
,(18, 2, 22, 1, 269.99, 0.05)
,(18, 3, 7, 1, 3999.99, 0.10)
,(18, 4, 25, 2, 499.99, 0.05)
,(18, 5, 9, 2, 2999.99, 0.10)
,(19, 1, 10, 1, 1549.00, 0.07)
,(19, 2, 9, 2, 2999.99, 0.20)
,(20, 1, 9, 1, 2999.99, 0.07)
,(20, 2, 10, 2, 1549.00, 0.07)
,(31, 1, 11, 2, 1680.99, 0.05)
,(31, 2, 9, 2, 2999.99, 0.20)
,(50, 1, 3, 1, 999.99, 0.05)
,(50, 2, 26, 2, 599.99, 0.07)
,(50, 3, 13, 2, 269.99, 0.20)
,(67, 1, 23, 2, 299.99, 0.20)
,(67, 2, 12, 2, 549.99, 0.10)
,(67, 3, 21, 1, 269.99, 0.20)
,(67, 4, 5, 2, 1320.99, 0.10)
,(67, 5, 19, 1, 449.00, 0.20)
,(70, 1, 3, 2, 999.99, 0.05)
,(70, 2, 18, 1, 449.00, 0.20)
,(70, 3, 20, 1, 599.99, 0.05)
,(89, 1, 5, 1, 1320.99, 0.05)
,(89, 2, 6, 2, 469.99, 0.10)
,(99, 1, 13, 1, 269.99, 0.20)
,(99, 2, 21, 1, 269.99, 0.20)
,(99, 3, 25, 2, 499.99, 0.05)
,(99, 4, 7, 2, 3999.99, 0.07)
,(99, 5, 23, 2, 299.99, 0.20)
,(101, 1, 12, 2, 549.99, 0.20)
,(106, 1, 17, 1, 429.00, 0.10)
,(106, 2, 13, 2, 269.99, 0.10)
,(110, 1, 14, 1, 269.99, 0.10)
,(127, 1, 17, 1, 429.00, 0.07)
,(127, 2, 20, 1, 599.99, 0.10)
,(127, 3, 4, 2, 2899.99, 0.07)

-- Test

SELECT *
FROM production.products






































