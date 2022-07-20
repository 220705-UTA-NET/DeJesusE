-- DROP TABLE CF.Round;
-- DROP TABLE CF.Player;
-- DROP TABLE CF.Flips;
-- DROP SCHEMA CF;


CREATE SCHEMA CF;
Go

CREATE TABLE CF.Player
(
    Id INT NOT Null IDENTITY PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE CF.Flips
(
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    Name NVARCHAR(30) NOT NULL UNIQUE
);

CREATE TABLE CF.Round
(
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    Timestamp DATETIMEOFFSET NOT NULL DEFAULT (SYSDATETIMEOFFSET()),
    PlayerId INT NULL,
    PlayerChoice INT NOT NULL,
    FlipResult INT NOT NULL
);

ALTER TABLE CF.Round ADD CONSTRAINT FK_Round_PlayerId
    FOREIGN KEY (PlayerId) REFERENCES CF.Player (Id);
ALTER TABLE CF.Round ADD CONSTRAINT FK_Round_PlayerChoice
    FOREIGN KEY (PlayerChoice) REFERENCES CF.Flips (Id);
ALTER TABLE CF.Round ADD CONSTRAINT FK_Rround_FlipResult
    FOREIGN KEY (FlipResult) REFERENCES CF.Flips (Id);

INSERT INTO CF.Flips (Name)
VALUES
('Heads'),
('Tails');

INSERT INTO CF.Player (Name)
VALUES
('Rich'),
('Eunice'),
('Nandi'),
('Hau'),
('Kadin'),
('Lance');

INSERT INTO CF.Round (PlayerId, PlayerChoice, FlipResult)
VALUES
((SELECT Id FROM CF.Player WHERE Name = 'Rich'), (SELECT Id FROM CF.Flips WHERE Name = 'Heads'), (SELECT Id FROM CF.Flips WHERE Name = 'Tails')),
((SELECT Id FROM CF.Player WHERE Name = 'Rich'), (SELECT Id FROM CF.Flips WHERE Name = 'Tails'), (SELECT Id FROM CF.Flips WHERE Name = 'Tails')),
((SELECT Id FROM CF.Player WHERE Name = 'Eunice'), (SELECT Id FROM CF.Flips WHERE Name = 'Tails'), (SELECT Id FROM CF.Flips WHERE Name = 'Tails')),
((SELECT Id FROM CF.Player WHERE Name = 'Eunice'), (SELECT Id FROM CF.Flips WHERE Name = 'Tails'), (SELECT Id FROM CF.Flips WHERE Name = 'Heads')),
((SELECT Id FROM CF.Player WHERE Name = 'Nandi'), (SELECT Id FROM CF.Flips WHERE Name = 'Heads'), (SELECT Id FROM CF.Flips WHERE Name = 'Heads')),
((SELECT Id FROM CF.Player WHERE Name = 'Nandi'), (SELECT Id FROM CF.Flips WHERE Name = 'Heads'), (SELECT Id FROM CF.Flips WHERE Name = 'Heads')),
((SELECT Id FROM CF.Player WHERE Name = 'Hau'), (SELECT Id FROM CF.Flips WHERE Name = 'Heads'), (SELECT Id FROM CF.Flips WHERE Name = 'Tails')),
((SELECT Id FROM CF.Player WHERE Name = 'Hau'), (SELECT Id FROM CF.Flips WHERE Name = 'Tails'), (SELECT Id FROM CF.Flips WHERE Name = 'Tails')),
((SELECT Id FROM CF.Player WHERE Name = 'Kadin'), (SELECT Id FROM CF.Flips WHERE Name = 'Tails'), (SELECT Id FROM CF.Flips WHERE Name = 'Tails')),
((SELECT Id FROM CF.Player WHERE Name = 'Kadin'), (SELECT Id FROM CF.Flips WHERE Name = 'Heads'), (SELECT Id FROM CF.Flips WHERE Name = 'Heads')),
((SELECT Id FROM CF.Player WHERE Name = 'Lance'), (SELECT Id FROM CF.Flips WHERE Name = 'Heads'), (SELECT Id FROM CF.Flips WHERE Name = 'Heads')),
((SELECT Id FROM CF.Player WHERE Name = 'Lance'), (SELECT Id FROM CF.Flips WHERE Name = 'Heads'), (SELECT Id FROM CF.Flips WHERE Name = 'Heads'));


Select Timestamp, P.Name, PC.Name, FR.Name
From CF.Round
    INNER JOIN CF.Player AS P ON PlayerId = P.Id
    LEFT JOIN CF.Flips AS PC ON PlayerChoice = PC.Id
    INNER JOIN CF.Flips AS FR ON FlipResult = FR.Id
WHERE P.Name = 'Rich';

SELECT * FROM CF.Player;
SELECT * FROM CF.Round;