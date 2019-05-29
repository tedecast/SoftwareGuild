USE DVDLibrary;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdSelectById')
      DROP PROCEDURE DvdSelectById
GO

CREATE PROCEDURE DvdSelectById (
	@DvdId int
)
AS
	SELECT d.DvdId, Title, ReleaseYear, Director, RatingName, Notes
	FROM Dvd d
	INNER JOIN Rating r ON r.RatingId = d.RatingId
	WHERE d.DvdId = @DvdId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdSelectAll')
      DROP PROCEDURE DvdSelectAll
GO

CREATE PROCEDURE DvdSelectAll
AS
	SELECT d.DvdId, Title, ReleaseYear, Director, RatingName, Notes
	FROM Dvd d
	INNER JOIN Rating r ON r.RatingId = d.RatingId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdSelectByTitle')
      DROP PROCEDURE DvdSelectByTitle
GO

CREATE PROCEDURE DvdSelectByTitle (
	@Title varchar(50)
)
AS
	SELECT d.DvdId, Title, ReleaseYear, Director, RatingName, Notes
	FROM Dvd d
	INNER JOIN Rating r ON r.RatingId = d.RatingId
	WHERE Title LIKE @Title
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdSelectByReleaseYear')
      DROP PROCEDURE DvdSelectByReleaseYear
GO

CREATE PROCEDURE DvdSelectByReleaseYear (
	@ReleaseYear int
)
AS
	SELECT d.DvdId, Title, ReleaseYear, Director, RatingName, Notes
	FROM Dvd d
	INNER JOIN Rating r ON r.RatingId = d.RatingId
	WHERE ReleaseYear = @ReleaseYear
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdSelectByDirectorName')
      DROP PROCEDURE DvdSelectByDirectorName
GO

CREATE PROCEDURE DvdSelectByDirectorName (
	@Director varchar(40)
)
AS
	SELECT d.DvdId, Title, ReleaseYear, Director, RatingName, Notes
	FROM Dvd d
	INNER JOIN Rating r ON r.RatingId = d.RatingId
	WHERE d.Director LIKE @Director
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdSelectByRating')
      DROP PROCEDURE DvdSelectByRating
GO

CREATE PROCEDURE DvdSelectByRating (
	@Rating varchar(5)
)
AS
	SELECT d.DvdId, Title, ReleaseYear, Director, RatingName, Notes
	FROM Dvd d
	INNER JOIN Rating r ON r.RatingId = d.RatingId
	WHERE r.RatingName LIKE @Rating
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdInsert')
      DROP PROCEDURE DvdInsert
GO

CREATE PROCEDURE DvdInsert (
	@DvdId int output,
	@Title varchar(50),
	@ReleaseYear int,
	@Director varchar(50),
	@RatingId int,
	@Notes varchar(140)
)
AS
	INSERT INTO Dvd (Title, ReleaseYear, Director, RatingId, Notes)
	VALUES (@Title, @ReleaseYear, @Director, @RatingId, @Notes)
	SET @DvdId = SCOPE_IDENTITY()

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdUpdate')
      DROP PROCEDURE DvdUpdate
GO

CREATE PROCEDURE DvdUpdate (
	@DvdId int output,
	@Title varchar(50),
	@ReleaseYear int,
	@Director varchar(50),
	@RatingId int,
	@Notes varchar(140)
)
AS
	UPDATE Dvd
		SET Title = @Title,
		ReleaseYear = @ReleaseYear,
		Director = @Director,
		RatingId = @RatingId,
		Notes = @Notes
	WHERE DvdId = @DvdId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdDelete')
      DROP PROCEDURE DvdDelete
GO

CREATE PROCEDURE DvdDelete (
	@DvdId int
)
AS
	DELETE FROM Dvd
	WHERE DvdId = @DvdId
GO
