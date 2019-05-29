USE master;
GO

IF EXISTS(SELECT * FROM sys.databases WHERE Name='DVDLibrary')
DROP DATABASE DVDLibrary;
GO

CREATE DATABASE DVDLibrary;
GO

USE DVDLibrary;
GO



IF EXISTS(SELECT * FROM sys.tables WHERE name='Rating')
	DROP TABLE Rating
IF EXISTS(SELECT * FROM sys.tables WHERE name='Dvd')
	DROP TABLE Dvd


CREATE TABLE Rating(
	RatingId int identity (1,1) primary key not null,
	RatingName varchar(5) not null
)

CREATE TABLE Dvd(
	DvdId int identity(1,1) primary key not null,	
	Title varchar(50) not null,
	ReleaseYear int  not null,
	Director varchar(50)  not null,
	RatingId int foreign key references Rating(RatingId) not null,
	Notes varchar(500) null
)

