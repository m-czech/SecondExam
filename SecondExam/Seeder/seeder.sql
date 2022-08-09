INSERT INTO dbo.Authors (Name, Description)
VALUES ('Dr Dre', 'OG');

INSERT INTO dbo.Authors (Name, Description)
VALUES ('Ryszard Chojnowski', 'Tlumacz');

INSERT INTO dbo.Authors (Name, Description)
VALUES ('Vincent van Gogh', 'Dutch painter');

INSERT INTO dbo.Authors (Name, Description)
VALUES ('Stanislaw Lem', 'Pisarz');

INSERT INTO dbo.Authors (Name, Description)
VALUES ('Olga Tokarczuk', 'Arystokratka');
-----------------

INSERT INTO dbo.EducationalMaterialTypes (Name, Definition)
VALUES ('Video', 'Moving frames');

INSERT INTO dbo.EducationalMaterialTypes (Name, Definition)
VALUES ('Painting', 'Image');

INSERT INTO dbo.EducationalMaterialTypes (Name, Definition)
VALUES ('Book', 'Words put on piece of paper');

INSERT INTO dbo.EducationalMaterialTypes (Name, Definition)
VALUES ('Song', 'Educational song');
------------------

INSERT INTO dbo.EducationalMaterials (AuthorId, Title, Description, Location, EducationalMaterialTypeId, PublicationDate)
VALUES (6, 'Solaris', 'Amazing book', 'Norymberska 12', 2, '2019-02-04');


INSERT INTO dbo.EducationalMaterials (AuthorId, Title, Description, Location, EducationalMaterialTypeId, PublicationDate)
VALUES (6, 'The Invincible', 'Futureproof', 'Main library', 2, '2021-04-02');


INSERT INTO dbo.EducationalMaterials (AuthorId, Title, Description, Location, EducationalMaterialTypeId, PublicationDate)
VALUES (5, 'The  Books of Jacob', 'Not for idiots', 'Trash', 2, '2022-03-03');


INSERT INTO dbo.EducationalMaterials (AuthorId, Title, Description, Location, EducationalMaterialTypeId, PublicationDate)
VALUES (2, 'Gryslaw', 'YouTube channel', 'https://www.youtube.com/c/Ryslaw', 1, '2018-01-05');


INSERT INTO dbo.EducationalMaterials (AuthorId, Title, Description, Location, EducationalMaterialTypeId, PublicationDate)
VALUES (1 'Still D.R.E', 'Banger', 'https://www.youtube.com/watch?v=_CL6n0FJZpk', 4, '1999-11-15');

INSERT INTO dbo.EducationalMaterials (AuthorId, Title, Description, Location, EducationalMaterialTypeId, PublicationDate)
VALUES (1 'Xxplosive', 'Banger x2', 'https://www.youtube.com/watch?v=wL8nunUIi-U', 4, '1999-12-15');