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
   WHERE ROUTINE_NAME = 'AddUser')
      DROP PROCEDURE AddUser
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'EditUser')
      DROP PROCEDURE EditUser
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'EditPassword')
      DROP PROCEDURE EditPassword
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
	DELETE FROM	AspNetUsers Where Id='00000000-0000-0000-0000-000000000000'
	DELETE FROM	AspNetUsers Where Id='00000000-0000-0000-0000-000000000001'
	DELETE FROM	AspNetUsers Where Id='d10dee9d-5dc7-44e3-b550-10cb35982cf5'

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
	VALUES (1,'admin@test.com', 'Subaru', '1/1/2011'), (2,'admin@test.com', 'Ford', '1/1/2012'), (3,'admin@test.com', 'Kia', '1/1/2013')
	SET IDENTITY_INSERT Make OFF

	SET IDENTITY_INSERT Model ON 
	INSERT INTO Model (ModelId, MakeId, UserId, ModelName, DateAdded)
	VALUES (1, 1, '00000000-0000-0000-0000-000000000000', 'Outback', '1/1/2019'), (2, 2, '00000000-0000-0000-0000-000000000000', 'F-150', '1/1/2018'), (3, 3, '00000000-0000-0000-0000-000000000000', 'Sedona', '1/1/2017'), (4, 1, '00000000-0000-0000-0000-000000000000', 'Forester', '1/1/2017')
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
	INSERT INTO Vehicle (VehicleId, MakeId, ModelId, InteriorId, ColorId, TypeId, BodyId, TransmissionId, [Year], VIN, Mileage, MSRP, SalePrice, [Description], PhotoPath, isSold, isFeatured, isDeleted)
	VALUES (1, 3, 3, 3, 1, 1, 4, 1, 2019, '3TMMU4FN2AM023309', 0, 25000.00, 23000.00, 'New Kia for sale', 'inventory-1.jpg', 0, 1, 0), 
	(2, 2, 2, 2, 4, 2, 3, 2, 2015, 'JT2SW22N7M0049240', 30000, 20000.00, 18000.00, 'Gently used Ford F-150 for sale', 'inventory-2.jpg', 0, 1, 0), 
	(3, 1, 1, 1, 2, 2, 1, 1, 2011,'1GDHK39KX7E580109', 75000, 13000.00, 12000.00, 'Subaru OutBack for sale. Only one previous owner. Great family car!', 'inventory-3.jpg', 0, 0, 0),
	(4, 1, 4, 1, 2, 2, 1, 1, 2012,'JH4DA9390MS033554', 80000, 16000, 14000.00, 'Subaru Forester for sale.', 'inventory-4.jpg', 0, 0, 0)
	SET IDENTITY_INSERT Vehicle OFF

	SET IDENTITY_INSERT Sale ON 
	INSERT INTO Sale (SaleId, UserId, PurchaseTypeId, VehicleId, PurchasePrice, [Name], Phone, Email, Street1, Street2, City, [State], Zipcode, DateSold)
	VALUES (1, '00000000-0000-0000-0000-000000000000', 1, 1, 22500.00, 'John', '5555555555','john@gmail.com', '555 BobCat Way', 'Apt 7', 'Austin', 'Texas', '55551', '1/1/2018'), 
	(2, '00000000-0000-0000-0000-000000000000', 2, 2, 18000.00, 'James', '5555555555', 'James@gmail.com', '555  Whirlaway Court', '', 'Union', 'Kentucky', '55552', '1/2/2019')
	SET IDENTITY_INSERT Sale OFF

	INSERT INTO AspNetUsers(Id, RoleId, Email, EmailConfirmed, PasswordHash, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName, FirstName, LastName)
	VALUES ('00000000-0000-0000-0000-000000000000', 'admin', 'test@test.com', 1, 'test123', '5555555555', '5555555555', 0,  0, 0, 'Jeremy', 'Test', 'TestSubject')



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

CREATE PROCEDURE GetAllUsers
AS
	SELECT  u.Id AS UserId, LastName, FirstName, UserName, r.Name AS RoleId, PasswordHash FROM AspNetUsers u
	INNER JOIN AspNetUserRoles ur ON ur.UserId = u.Id
	INNER JOIN AspNetRoles r ON r.Id = ur.RoleId
GO

CREATE PROCEDURE AddUser(
	@UserId NVARCHAR(128),
	@RoleId VARCHAR(10),
	@PasswordHash VARCHAR(30),
	@LockOutEnabled BIT,
	@Username VARCHAR(40),
	@FirstName VARCHAR(20),
	@LastName VARCHAR(20),
	@Email VARCHAR(30),
	@PhoneNumberConfirmed VARCHAR(10),
	@EmailConfirmed BIT,
	@TwoFactorEnabled BIT,
	@AccessFailedCount BIT
)
AS
	INSERT INTO AspNetUsers (Id, RoleId, PasswordHash, LockoutEnabled, Username, FirstName, LastName, Email, PhoneNumberConfirmed, EmailConfirmed, TwoFactorEnabled, AccessFailedCount)
	VALUES (@UserId, @RoleId, @PasswordHash, @LockOutEnabled, @Username, @FirstName, @LastName, @Email, @PhoneNumberConfirmed, @EmailConfirmed, @TwoFactorEnabled, @AccessFailedCount)
GO

CREATE PROCEDURE EditUser(
	@UserId NVARCHAR(128),
	@RoleId VARCHAR(10),
	@PasswordHash VARCHAR(30),
	@LockOutEnabled BIT,
	@Username VARCHAR(40),
	@FirstName VARCHAR(20),
	@LastName VARCHAR(20),
	@Email VARCHAR(30),
	@PhoneNumberConfirmed VARCHAR(10),
	@EmailConfirmed BIT,
	@TwoFactorEnabled BIT,
	@AccessFailedCount BIT
)
AS
	UPDATE AspNetUsers 
	 SET RoleId = @RoleId,
	 PasswordHash = @PasswordHash,
	 LockoutEnabled = @LockOutEnabled,
	 UserName = @UserName,
	 FirstName = @FirstName,
	 LastName = @LastName,
	 Email = @Email,
	 PhoneNumberConfirmed = @PhoneNumberConfirmed,
	EmailConfirmed = @EmailConfirmed,
	TwoFactorEnabled = @TwoFactorEnabled,
	AccessFailedCount = @AccessFailedCount
	 WHERE Id = @UserId
GO

CREATE PROCEDURE EditPassword(
	@UserId NVARCHAR(128),
	@PasswordHash VARCHAR(30)
)
AS
	UPDATE AspNetUsers 
	 SET
	 PasswordHash = @PasswordHash
	 WHERE Id = @UserId
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

