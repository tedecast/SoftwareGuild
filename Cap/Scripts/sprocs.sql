USE GuildCars;
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DbReset')
      DROP PROCEDURE DbReset
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddContactUs')
      DROP PROCEDURE AddContactUs
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetAllContactUs')
      DROP PROCEDURE GetAllContactUs
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddVehicle')
      DROP PROCEDURE AddVehicle
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetAllVehicles')
      DROP PROCEDURE GetAllVehicles
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DeleteVehicle')
      DROP PROCEDURE DeleteVehicle
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'UpdateVehicle')
      DROP PROCEDURE UpdateVehicle
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetFeatured')
      DROP PROCEDURE GetFeatured
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetMakeItems')
      DROP PROCEDURE GetMakeItems
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetModelItems')
      DROP PROCEDURE GetModelItems
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddMakeItem')
      DROP PROCEDURE AddMakeItem
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddModelItem')
      DROP PROCEDURE AddModelItem
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetVehicleById')
      DROP PROCEDURE GetVehicleById
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetVehicleItemById')
      DROP PROCEDURE GetVehicleItemById
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddSale')
      DROP PROCEDURE AddSale
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetAllUsers')
      DROP PROCEDURE GetAllUsers
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetAllSpecials')
      DROP PROCEDURE GetAllSpecials
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddSpecial')
      DROP PROCEDURE AddSpecial
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DeleteSpecial')
      DROP PROCEDURE DeleteSpecial
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetInventoryReport')
      DROP PROCEDURE GetInventoryReport
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetUsers')
      DROP PROCEDURE GetUsers
GO
CREATE PROCEDURE DbReset
AS
	DELETE FROM Special
	DELETE FROM ContactUs
	DELETE FROM Sale
	DELETE FROM Vehicle
	DELETE FROM Interior
	DELETE FROM Model
	DELETE FROM Body
	DELETE FROM Color
	DELETE FROM Make
	DELETE FROM PurchaseType
	DELETE FROM Transmission
	DELETE FROM [Type]

	SET IDENTITY_INSERT Special ON 
	INSERT INTO Special (SpecialId,SpecialTitle, SpecialDescription)
	VALUES (1, 'Labor Day Sale', '15% Off All New Cars!'), (2, 'Auction Bid Day','Come bid on the largest selection of used vehicles!'), (3, 'New Selection of Luxury Vehicles!','Come check out the latest from Tesla, Audi, BMW and More!')
	SET IDENTITY_INSERT Special OFF

	SET IDENTITY_INSERT Body ON 
	INSERT INTO Body (BodyId, BodyType)
	VALUES (1,'Car'), (2,'SUV'), (3,'Truck'), (4,'Van')
	SET IDENTITY_INSERT Body OFF

	SET IDENTITY_INSERT Color ON 
	INSERT INTO Color (ColorId, ColorName)
	VALUES (1,'Black'), (2,'White'), (3,'Grey'), (4,'Red'), (5,'Beige')
	SET IDENTITY_INSERT Color OFF

	SET IDENTITY_INSERT ContactUs ON 
	INSERT INTO ContactUs (ContactUsId, [Name], Phone, Email, [Message])
	VALUES (1,'Charles', '1111111111', 'charles@gmail.com', 'What are your hours on weekends?'), (2,'Thomas', '2222222222', 'Thomas@gmail.com', 'Can I test drive a vehicle this next Wednesday?')
	SET IDENTITY_INSERT ContactUs OFF

	SET IDENTITY_INSERT Interior ON 
	INSERT INTO Interior (InteriorId, InteriorColor)
	VALUES (1,'Black'), (2,'White'), (3,'Red'), (4,'Leather - Black'), (5,'Leather - Tan')
	SET IDENTITY_INSERT Interior OFF

	SET IDENTITY_INSERT Make ON 
	INSERT INTO Make (MakeId, UserId, MakeName, DateAdded)
	VALUES (1,'admin@test.com', 'Subaru', '1/1/2011'), (2,'admin@test.com', 'Ford', '1/1/2012'), (3,'admin@test.com', 'Kia', '1/1/2013'), (4, 'admin@test.com', 'Toyota', '2019-06-27 09:34:44.9966667')
	SET IDENTITY_INSERT Make OFF

	SET IDENTITY_INSERT Model ON 
	INSERT INTO Model (ModelId, MakeId, UserId, ModelName, DateAdded)
	VALUES (1, 1, '00000000-0000-0000-0000-000000000000', 'Outback', '1/1/2019'), 
	(2, 2, '00000000-0000-0000-0000-000000000000', 'F-150', '1/1/2018'), 
	(3, 3, '00000000-0000-0000-0000-000000000000', 'Sedona', '1/1/2017'), 
	(4, 1, '00000000-0000-0000-0000-000000000000', 'Forester', '1/1/2017'),
	(5,	4,	'ron@gmail.com',	'Tacoma',	'2019-06-27 09:35:07.0200000'),
	(6,	4,	'ron@gmail.com',	'RAV ',	'2019-06-27 09:35:14.8966667'),
	(7,	4,	'ron@gmail.com',	'Highlander',	'2019-06-27 09:35:18.8566667'),
	(8,	4,	'ron@gmail.com',	'Camry',	'2019-06-27 09:35:31.8633333'),
	(9,	4,	'ron@gmail.com',	'Corolla',	'2019-06-27 09:36:54.3433333'),
	(10,	2,	'ron@gmail.com',	'Escape',	'2019-06-27 09:38:02.0933333'),
	(11,	2,	'ron@gmail.com',	'Explorer',	'2019-06-27 09:38:15.3666667'),
	(12,	2,	'ron@gmail.com',	'Mustang',	'2019-06-27 09:38:26.0733333'),
	(13,	2,	'ron@gmail.com',	'Fusion',	'2019-06-27 09:38:53.9766667'),
	(14,	3,	'ron@gmail.com',	'Sorento',	'2019-06-27 09:39:47.9600000'),
	(15,	3,	'ron@gmail.com',	'Optima',	'2019-06-27 09:40:08.2900000'),
	(16,	3,	'ron@gmail.com',	'Soul',	'2019-06-27 09:40:12.2633333'),
	(17,	1,	'ron@gmail.com',	'Impreza',	'2019-06-27 09:41:26.6400000'),
	(18,	1,	'ron@gmail.com',	'CrossTrek',	'2019-06-27 09:41:43.9633333')
	SET IDENTITY_INSERT Model OFF

	SET IDENTITY_INSERT Transmission ON 
	INSERT INTO Transmission (TransmissionId, TransmissionType)
	VALUES (1, 'Automatic'), (2, 'Manual')
	SET IDENTITY_INSERT Transmission OFF
	
	SET IDENTITY_INSERT [Type] ON 
	INSERT INTO [Type] (TypeId, TypeName)
	VALUES (1, 'New'), (2, 'Used')
	SET IDENTITY_INSERT [Type] OFF

	SET IDENTITY_INSERT PurchaseType ON 
	INSERT INTO PurchaseType (PurchaseTypeId, PurchaseType)
	VALUES (1,'Bank Finance'), (2,'Cash'), (3,'Dealer Finance')
	SET IDENTITY_INSERT PurchaseType OFF

	SET IDENTITY_INSERT Vehicle ON 
	INSERT INTO Vehicle (VehicleId, MakeId, ModelId, BodyId, InteriorId, ColorId, TypeId, TransmissionId, [Year], VIN, Mileage, MSRP, SalePrice, [Description], PhotoPath, isSold, isFeatured, isDeleted)
	VALUES (1, 3, 3, 4, 1, 3, 1,   1, 2019, '3TMMU4FN2AM023309', 0, 25000.00, 23000.00, 'New Kia for sale', 'inventory-1.jpg', 0, 1, 0), 
	(2, 2, 2, 3, 2, 4, 2,  2, 2015, 'JT2SW22N7M0049240', 30000, 20000.00, 18000.00, 'Gently used Ford F-150 for sale', 'inventory-2.jpg', 0, 1, 0), 
	(3, 1, 1,  1, 1, 2, 2, 1, 2011,'1GDHK39KX7E580109', 75000, 13000.00, 12000.00, 'Subaru OutBack for sale. Only one previous owner. Great family car!', 'inventory-3.jpg', 0, 0, 0),
	(4, 1, 4, 1, 1, 2, 2, 1, 2012,'JH4DA9390MS033554', 80000, 16000, 14000.00, 'Subaru Forester for sale.', 'inventory-4.jpg', 0, 0, 0),
	(5,	4,	5, 3, 1, 4,	2,	1,	2017, '3TMCZ5ANXHM058927',	22053,	35000,	33587,	'This loaded up 2017 Toyota Tacoma TRD is equipped with a SUNROOF.', 	'inventory-5.png', 1, 1, 0),
	(6,	4,	6,	2,	1,	2,	2,	1,	2016,	'2T3WFREV8GW279026', 48931,	20414,	19495,	'Buying a new or pre-owned vehicle has never been easier!',	'inventory-6.png',	1,	0,	0),
	(7,	4,	7, 2,	1,	1,	2,	1,	2002,	'JTEGF21A820064866',	137231,	7000,	5000,	'Prices do not include tax, title, or license fees.',	'inventory-7.png',	0,	0,	0),
	(8,	4,	8,	1,	3,	3,	1,	1,	2019,	'T1B11HK9KU247803',	5,	25858,	22677,	'29/41 City/Highway MPG The 2019 Toyota Camry is the daring side of dependability.',	'inventory-8.png',	1,	1,	0),
	(9,	4,	9,	1,	2,	5,	2,	1,	2011,	'2T1BU4EE6DC096236',	47990,	13000,	12100,	'CARVANA CERTIFIED INCLUDES: 150-POINT INSPECTION',	'inventory-9.png',	0,	0,	0),
	(10, 2,	10,	2,	1,	3,	2,	1,	2015,	'1FMCU9J99FUB22436',	64510,	18000,	15588,	'REAR BACK UP CAMERA, BLUE TOOTH HANDSFREE, GOOD TIRES, GOOD BRAKES',	'inventory-10.png',	0,	1,	0),
	(11, 2,	10,	2,	5,	5,	2,	1,	2011,	'1FMCU9J99FUB22',	70354,	10000,	9500,	'REAR BACK UP CAMERA, BLUE TOOTH HANDSFREE, GOOD TIRES, GOOD BRAKES',	'inventory-11.png',	0,	0,	0),
	(12, 2,	11,	1,	2,	1,	1,	1,	2019,	'1FM5K8GT4KGA38951',	5,	45355,	53855,	'AVIGATION/NAV/GPS, SYNC3 TOUCHSCREEN', 	'inventory-12.png',	0,	1,	0),
	(13, 2,	12,	1,	1,	1,	2,	2,	2010,	'JTEGF21A820064866',	45984,	12000,	10000,	'A nice used Mustang!',	'inventory-13.png',	0,	0,	0),
	(14, 2,	13,	1,	4,	2,	2,	1,	2014,	'2T3WFREV8GW279026',	45010,	13454,	12500,	'A great Ford Fusion for sale!',	'inventory-14.png',	0,	0,	0),
	(15, 3,	14,	2,	4,	4,	1,	1,	2018,	'2T3WFREV8GW279026',	5,	25000,	23155,	'A nice Kia Sorento for sale',	'inventory-15.png',	0,	0,	0),
	(16, 3,	15,	1,	1,	1,	2,	1,	2016,	'JTEGF21A820064866',	30554,	18000,	16987,	'A nice Kia Optima for sale!',	'inventory-16.png',	0,	0,	0),
	(17, 3,	16,	1,	2,	3,	2,	1,	2008,	'JTEGF21A820064866',	80453,	14098,	13444,	'A Kia Soul with Soul!',	'inventory-17.png',	0,	1,	0),
	(18, 1,	17,	1,	4,	5,	1,	1,	2019,	'T1B11HK9KU247803',	30,	23000,	22484,	'A new Subaru!',	'inventory-18.png',	0,	0,	0),
	(19, 1,	18,	1,	1,	1,	2,	1,	2009,	'3TMCZ5ANXHM058927',	60483,	15434,	13092,	'A used Subaru.',	'inventory-19.png',	0,	1,	0),
	(20, 4,	9,	1,	1,	1,	2,	1,	2011,	'T1B11HK9KU247803',	5,	14000,	13000,	'Toyota for sale',	'inventory-20.png',	0,	0,	0)
	SET IDENTITY_INSERT Vehicle OFF

SET IDENTITY_INSERT Sale ON 
INSERT INTO Sale (SaleId, UserId, PurchaseTypeId, VehicleId, PurchasePrice, [Name], Phone, Email, Street1, Street2, City, [State], Zipcode, DateSold)
VALUES (1, '00000000-0000-0000-0000-000000000000', 1, 1, 22500.00, 'John', '5555555555','john@gmail.com', '555 BobCat Way', 'Apt 7', 'Austin', 'Texas', '55551', '1/1/2018'), 
(2, '00000000-0000-0000-0000-000000000000', 2, 2, 18000.00, 'James', '5555555555', 'James@gmail.com', '555  Whirlaway Court', '', 'Union', 'Kentucky', '55552', '1/2/2019')
SET IDENTITY_INSERT Sale OFF


GO

CREATE PROCEDURE AddContactUs(
	@ContactUsId int output,
	@Name VARCHAR(30),
	@Phone VARCHAR(10),
	@Email VARCHAR(30),
	@Message VARCHAR(300)
)
AS
	INSERT INTO ContactUs( [Name], Phone, Email, [Message])
	VALUES (@Name, @Phone, @Email, @Message)
	
	SET @ContactUsId = SCOPE_IDENTITY()

GO

CREATE PROCEDURE GetAllContactUs
AS
	SELECT * FROM ContactUs
GO

CREATE PROCEDURE GetAllVehicles
AS
	SELECT  VehicleId, m.MakeName, mo.ModelName, b.BodyType, i.InteriorColor, c.ColorName, t.TypeName,  tr.TransmissionType,
			[Year], VIN, Mileage, MSRP, SalePrice, [Description], PhotoPath, isFeatured, isSold
	FROM Vehicle v
	INNER JOIN Make m ON m.MakeId = v.MakeId
	INNER JOIN Model mo	ON mo.ModelId = v.ModelId
	INNER JOIN Interior i ON i.InteriorId = v.InteriorId
	INNER JOIN Color c ON c.ColorId = v.ColorId
	INNER JOIN [Type] t ON t.TypeId = v.TypeID
	INNER JOIN Body b ON b.BodyId = v.BodyId
	INNER JOIN Transmission tr ON tr.TransmissionId = v.TransmissionId
	WHERE isDeleted = 0
GO

CREATE PROCEDURE GetVehicleById(
	@VehicleId INT
)
AS
		SELECT  VehicleId, MakeId, ModelId, BodyId, InteriorId, ColorId, TypeId,  TransmissionId,
			[Year], VIN, Mileage, MSRP, SalePrice, [Description], PhotoPath, isFeatured, isSold
	FROM Vehicle v
	WHERE v.VehicleId = @VehicleId AND v.isDeleted = 0

GO

CREATE PROCEDURE GetVehicleItemById(
	@VehicleId INT
)
AS
		SELECT  VehicleId, m.MakeName, mo.ModelName, b.BodyType, i.InteriorColor, c.ColorName, t.TypeName,  tr.TransmissionType,
			[Year], VIN, Mileage, MSRP, SalePrice, [Description], PhotoPath, isFeatured, isSold
	FROM Vehicle v
	INNER JOIN Make m ON m.MakeId = v.MakeId
	INNER JOIN Model mo	ON mo.ModelId = v.ModelId
	INNER JOIN Interior i ON i.InteriorId = v.InteriorId
	INNER JOIN Color c ON c.ColorId = v.ColorId
	INNER JOIN [Type] t ON t.TypeId = v.TypeID
	INNER JOIN Body b ON b.BodyId = v.BodyId
	INNER JOIN Transmission tr ON tr.TransmissionId = v.TransmissionId
	WHERE v.VehicleId = @VehicleId AND v.isDeleted = 0

GO

CREATE PROCEDURE AddVehicle(
	@VehicleId INT OUTPUT,
	@MakeID INT,
	@ModelId INT,
	@InteriorId INT,
	@ColorId INT,
	@TypeId INT,
	@BodyId INT,
	@TransmissionId INT,
	@Year INT,
	@VIN VARCHAR(17),
	@Mileage INT,
	@MSRP DECIMAL,
	@SalePrice DECIMAL,
	@Description VARCHAR(300),
	@PhotoPath NVARCHAR(100),
	@isSold BIT,
	@isFeatured BIT,
	@isDeleted BIT = 0
)
AS
	INSERT INTO Vehicle(MakeId, ModelId, InteriorId, ColorId, TypeID, BodyId, TransmissionId, [Year], VIN, Mileage, MSRP, SalePrice, [Description], PhotoPath, isFeatured, IsSold, isDeleted)
	VALUES (@MakeId, @ModelId, @InteriorId, @ColorId, @TypeID, @BodyId, @TransmissionId, @Year, @VIN, @Mileage, @MSRP, @SalePrice, @Description, @PhotoPath, @isFeatured, @IsSold, @isDeleted)

	SET @VehicleId = SCOPE_IDENTITY()
GO

CREATE PROCEDURE DeleteVehicle(
	@id INT
)
AS
	DELETE FROM Vehicle
	Where @id = VehicleId
GO

CREATE PROCEDURE UpdateVehicle (
	@VehicleId INT,
	@MakeID INT,
	@ModelId INT,
	@InteriorId INT,
	@ColorId INT,
	@TypeId INT,
	@BodyId INT,
	@TransmissionId INT,
	@Year INT,
	@VIN VARCHAR(17),
	@Mileage INT,
	@MSRP DECIMAL,
	@SalePrice DECIMAL,
	@Description VARCHAR(300),
	@PhotoPath NVARCHAR(100),
	@isSold BIT,
	@isFeatured BIT,
	@isDeleted BIT
)
AS
	UPDATE Vehicle
		SET MakeId = @MakeId,
		ModelId = @ModelId,
		InteriorId = @InteriorId,
		ColorId = @ColorId,
		TypeID = @TypeId,
		BodyId = @BodyId,
		TransmissionId = @TransmissionId,
		[Year] = @Year,
		VIN = @VIN,
		Mileage = @Mileage,
		MSRP = @MSRP,
		SalePrice = @SalePrice,
		[Description] = @Description,
		PhotoPath = @PhotoPath,
		isSold = @isSold,
		isFeatured = @isFeatured,
		isDeleted = @isDeleted

	WHERE VehicleId = @VehicleId
GO

CREATE PROCEDURE GetFeatured
AS
	SELECT  VehicleId, m.MakeName, mo.ModelName, [Year], SalePrice, PhotoPath
	FROM Vehicle v
	INNER JOIN Make m ON m.MakeId = v.MakeId
	INNER JOIN Model mo	ON mo.ModelId = v.ModelId
	Where isFeatured = 1  AND v.isDeleted = 0
GO

CREATE PROCEDURE GetMakeItems
AS
	SELECT  m.MakeId, u.UserName AS UserId, m.MakeName, m.DateAdded
	FROM Make m
	INNER JOIN AspNetUsers u ON u.UserName = m.UserId

GO

CREATE PROCEDURE AddMakeItem(
	@MakeId INT OUTPUT,
	@UserId VARCHAR(128),
	@MakeName VARCHAR(25),
	@DateAdded DATETIME2
)
AS
	INSERT INTO Make(UserId, MakeName, DateAdded)
	VALUES (@UserId, @MakeName, @DateAdded)

	SET @MakeId = SCOPE_IDENTITY()
GO

CREATE PROCEDURE GetModelItems
AS
	SELECT  m.MakeId, m.UserId, MakeName, mo.ModelName, mo.DateAdded, mo.MakeId, mo.ModelId
	FROM Make m
	INNER JOIN Model mo ON mo.MakeId = m.MakeId
GO
CREATE PROCEDURE AddModelItem(
	@ModelId INT OUTPUT,
	@MakeId INT,
	@UserId VARCHAR(128),
	@ModelName VARCHAR(25),
	@DateAdded DATETIME2
)
AS
	INSERT INTO Model (MakeId, UserId, ModelName, DateAdded)
	VALUES (@MakeId, @UserId, @ModelName, @DateAdded)
	 
	SET @ModelId = SCOPE_IDENTITY()
GO

CREATE PROCEDURE AddSale(
	@SaleId INT OUTPUT,
	@UserID VARCHAR(128),
	@PurchaseTypeID INT,
	@VehicleId INT,
	@PurchasePrice DECIMAL,
	@Name VARCHAR(30),
	@Phone VARCHAR(10),
	@Email VARCHAR(30),
	@Street1 VARCHAR(30),
	@Street2 VARCHAR(15),
	@City VARCHAR(25),
	@State VARCHAR(19),
	@Zipcode VARCHAR(5),
	@DateSold DateTime2
)
AS
	INSERT INTO Sale (UserId, PurchaseTypeId, VehicleId, PurchasePrice, [Name], Phone, Email, Street1, Street2, City, [State], Zipcode, DateSold)
	VALUES (@UserId, @PurchaseTypeId, @VehicleId, @PurchasePrice, @Name, @Phone, @Email, @Street1, @Street2, @City, @State, @Zipcode, @DateSold)
	SET @SaleId = SCOPE_IDENTITY()

	UPDATE Vehicle 
	 SET isSold = 1
	 WHERE VehicleId = @VehicleId

GO

CREATE PROCEDURE GetAllSpecials
AS
	SELECT * FROM Special 
GO

CREATE PROCEDURE AddSpecial(
	@SpecialId INT OUTPUT,
	@SpecialTitle VARCHAR(25),
	@SpecialDescription VARCHAR(300)

)
AS
	INSERT INTO Special (SpecialTitle, SpecialDescription)
	VALUES (@SpecialTitle, @SpecialDescription)

	SET @SpecialId = SCOPE_IDENTITY()
GO

CREATE PROCEDURE DeleteSpecial(
	@id INT
)
AS
	DELETE FROM Special
	Where @id = SpecialId
GO

CREATE PROCEDURE GetInventoryReport
AS
	SELECT  Distinct [Year], m.MakeName, (mo.ModelName), Count(*) AS Count, SUM(v.MSRP) AS StockValue, t.TypeName
 	FROM Vehicle v
	INNER JOIN Make m ON m.MakeId = v.MakeId
	INNER JOIN Model mo ON mo.ModelId = v.ModelId
	INNER JOIN [Type] t ON t.TypeId = v.TypeID
	WHERE v.isSold = 0
	group by [Year], m.MakeName, mo.ModelName, t.TypeName
	order by [Year], m.MakeName, mo.ModelName, t.TypeName desc

GO

CREATE PROCEDURE GetAllUsers
AS
	SELECT  u.Id AS UserId, LastName, FirstName, UserName, r.Name AS RoleId, PasswordHash FROM AspNetUsers u
	INNER JOIN AspNetUserRoles ur ON ur.UserId = u.Id
	INNER JOIN AspNetRoles r ON r.Id = ur.RoleId
GO
