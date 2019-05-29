USE DVDLibrary;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME='SampleData')
DROP PROCEDURE SampleData;
GO
-- Sample Data

CREATE PROCEDURE SampleData AS
BEGIN
	DELETE FROM Rating;
	DELETE FROM DVD;

SET IDENTITY_INSERT Rating ON

INSERT INTO Rating (RatingId, RatingName)
VALUES (1, 'G'),
	(2, 'PG'),
	(3, 'PG-13'),
	(4, 'R')

SET IDENTITY_INSERT Rating OFF

SET IDENTITY_INSERT Dvd ON

INSERT INTO Dvd (DvdId, Title, ReleaseYear, Director, RatingId, Notes)
VALUES (1, 'The Shawshank Redemption', 1994, 'Frank Darabont', 4, 'Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency'),
	(2, 'The Godfather', 1972, 'Francis Ford Coppola', 4, 'The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.'),
	(3, 'The Dark Knight', 2008, 'Christopher Nolan', 3, 'When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.'),
	(4, 'The Godfather: Part II', 1974, 'Francis Ford Coppola', 4, 'The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.'),
	(5, 'The Lord of the Rings: Return of the King', 2003, 'Peter Jackson', 3, 'Gandalf and Aragorn lead the World of Men against Sauron''s army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.')

SET IDENTITY_INSERT Dvd OFF

END

