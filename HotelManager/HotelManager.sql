USE Master;
GO

if exists (select * from sysdatabases where name='HotelManager')
		drop database HotelManager
GO

CREATE DATABASE HotelManager;
GO

USE HotelManager;
GO

CREATE TABLE Room(
	RoomID INT Identity(1,1) PRIMARY KEY,
	Number INT NOT NULL,
	[Floor] TINYINT NOT NULL,
	Occupancy TINYINT NOT NULL
)

CREATE TABLE [Type](
	TypeID	INT Identity(1,1) PRIMARY KEY,
	TypeDescription VARCHAR(10) NOT NULL,
)

CREATE TABLE Amenities(
	AmenitiesID INT Identity(1,1) PRIMARY KEY,
	AmenitiesDescription VARCHAR(30) NOT NULL
)

CREATE TABLE RoomType(
	RoomID INT NOT NULL,
	TypeID INT NOT NULL,
	CONSTRAINT PK_RoomType 
	PRIMARY KEY (RoomID, TypeID),
	CONSTRAINT FK_Room_RoomType
		FOREIGN KEY (RoomID)
		REFERENCES Room(RoomID),
	CONSTRAINT FK_Type_RoomType
		FOREIGN KEY (TypeID)
		REFERENCES [Type](TypeID),
)

CREATE TABLE CustomerInfo(
	CustomerInfoID INT Identity(1,1) PRIMARY KEY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Email VARCHAR(30) NULL,
	Phone VARCHAR(30) NOT NULL
)

CREATE TABLE Promo(
	PromoID INT Identity (1,1) PRIMARY KEY,
	PromoCode VARCHAR(30) NULL,
	PromoValue INT NULL,
	FromDate DATETIME2 NULL,
	ToDate DATETIME2 NULL,
)

CREATE TABLE Reservation(
	ReservationID INT Identity(1,1) PRIMARY KEY,
	CustomerInfoID INT FOREIGN KEY REFERENCES CustomerInfo(CustomerInfoID) NOT NULL,
	PromoID INT FOREIGN KEY REFERENCES Promo(PromoID) NULL,
	FromDate DATETIME2 NOT NULL,
	ToDate DATETIME2 NOT NULL,
)
CREATE TABLE RoomAmenities(
	RoomID INT NOT NULL,
	AmenitiesID INT NOT NULL,
	CONSTRAINT PK_RoomAmenities
		PRIMARY KEY (RoomID, AmenitiesID),
	CONSTRAINT FK_Room_RoomAmenities
		FOREIGN KEY (RoomID)
		REFERENCES Room(RoomID),
	CONSTRAINT FK_Amenities_RoomAmenities
		FOREIGN KEY (AmenitiesID)
		REFERENCES Amenities(AmenitiesID),
)


CREATE TABLE RoomReservation (
	RoomID INT NOT NULL,
	ReservationID INT NOT NULL,
	CONSTRAINT PK_RoomReservation
		PRIMARY KEY (RoomID, ReservationID),
	CONSTRAINT FK_Room_RoomReservation
		FOREIGN KEY (RoomID)
		REFERENCES Room(RoomID),
	CONSTRAINT FK_Reservation_RoomReservation
		FOREIGN KEY (ReservationID)
		REFERENCES Reservation(ReservationID),
)

CREATE TABLE Guest(
	GuestID INT Identity(1,1) PRIMARY KEY,
	ReservationID INT FOREIGN KEY REFERENCES Reservation(ReservationID) NOT NULL,
	Name VARCHAR(30) NOT NULL,
	Age INT NOT NULL,
)
CREATE TABLE RoomRate(
	RoomRateID INT Identity(1,1) PRIMARY KEY,
	RoomID INT FOREIGN KEY REFERENCES Room(RoomID) NOT NULL,
	Price INT NOT NULL,
	FromDate DATETIME2 NOT NULL,
	ToDate DATETIME2 NOT NULL
)
CREATE TABLE Tax(
	TaxID INT Identity(1,1) PRIMARY KEY,
	Tax INT NOT NULL
)

CREATE TABLE BillDetails(
	BillDetailsID INT Identity(1,1) PRIMARY KEY,
	ReservationID INT FOREIGN KEY REFERENCES Reservation(ReservationID) NOT NULL,
	TaxID INT FOREIGN KEY REFERENCES Tax(TaxID) NOT NULL,
	Total Decimal(5,2) NULL,
)

CREATE TABLE AddOns(
	AddOnsID INT Identity(1,1) PRIMARY KEY,
	BillDetailsID INT FOREIGN KEY  REFERENCES BillDetails(BillDetailsID) NOT NULL,
	Name VARCHAR(30) NULL
)

CREATE TABLE AddOnRates(
	AddOnRatesID INT Identity(1,1) PRIMARY KEY,
	Price INT NULL,
	FromDate DATETIME2 NULL,
	ToDate DATETIME2 NULL
)

CREATE TABLE AddOnAddOnRates(
	AddOnsID INT NOT NULL,
	AddOnRatesID INT NOT NULL,
	CONSTRAINT PK_AddOnAddOnRates
		PRIMARY KEY (AddOnsID, AddOnRatesID),
	CONSTRAINT FK_AddOns_AddOnsAddOnRates
		FOREIGN KEY (AddOnsID)
		REFERENCES AddOns(AddOnsID),
	CONSTRAINT FK_AddOnRates_AddOnsAddOnRates
		FOREIGN KEY (AddOnRatesID)
		REFERENCES AddOnRates(AddOnRatesID),
)

INSERT INTO Room(Number, [Floor], Occupancy) VALUES (1, 1, 4),
(2, 1, 2), (3, 1, 2), (4, 1, 2), (5, 1, 2), (6, 1, 2), (7, 1, 2), 
(8, 1, 2), (9, 1, 2), (10, 1, 2), (1, 2, 4), (2, 2, 4), (3, 2, 4), 
(4, 2, 4), (5, 2, 4), (6, 1, 4), (7, 1, 4), (8, 1, 4), (9, 1, 4),
(10, 3, 4), (1, 3, 4), (2, 3, 4), (3, 3, 4), (4, 3, 4), (5, 3, 4), 
(6, 3, 4), (7, 3, 4), (8, 3, 4), (9, 3, 4), (10, 3, 4);

INSERT INTO Type(TypeDescription) VALUES ('Single'), ('Double'), ('King');
INSERT INTO RoomType VALUES (1,1),(2,1),(3,1),(4,1),(5,1),(6,1),(7,1),(8,1),(9,1),(10,2),(11,2),(12,2),(13,2),(14,2),(15,2),(16,2),(17,2),(18,2),(19,2),(20,3),(21,3),(22,3),(23,3),(24,3),(25,3),(26,3),(27,3),(28,3),(29,3),(30,3);
INSERT INTO Amenities(AmenitiesDescription) VALUES ('Fridge'),('Spa Bath'),('Mini-Bar');
INSERT INTO RoomAmenities VALUES (1,1),(1,2),(2,1),(3,1),(4,1),(5,1),(6,1),(7,1),(8,1),(9,1),(10,2),(11,2),(12,2),(13,2),(14,2),(15,2),(16,2),(17,2),(18,2),(19,2),(20,3),(21,3),(22,3),(23,3),(24,3),(25,3),(26,3),(27,3),(28,3),(29,3),(30,3);
INSERT INTO CustomerInfo VALUES ('Jeremy','Wakefieled','Jwake422@gmail.com','8595477393'), ('John','Smith','jsmith@gmail.com','5555555555'), ('Regan','Rucker','rucker@gmail.com','1111111111');
INSERT INTO Promo VALUES ('SPRING2019', 25, '2019-3-1', '2019-6-1');
INSERT INTO Reservation(CustomerInfoID, FromDate, ToDate) VALUES 
(1, '2019-01-01', '2019-01-05'), (2, '2019-05-01', '2019-05-07');
INSERT INTO Guest VALUES (1, 'A Wakefield', 8), (1, 'Another Wakefield', 5), (2, 'Sally Smith', 25);
INSERT INTO RoomReservation VALUES (1,1), (2,2);
INSERT INTO RoomRate VALUES(8, 100, '2019-1-1', '2019-12-31'), (15, 150,  '2019-1-1', '2019-12-31');
INSERT INTO Tax VALUES (1.06);
INSERT INTO BillDetails VALUES (1,1, 500), (2,1, 500);
INSERT INTO AddOns VALUES (1, 'Movie'), (1, 'Room Service');
INSERT INTO AddOnRates VALUES(5,  '2019-1-1', '2019-12-31'), (15,  '2019-1-1', '2019-12-31');
INSERT INTO AddOnAddOnRates VALUES (1,1), (2,2);
