use [Hackathon16Dijon]

CREATE TABLE Utilisateur
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	MAIL varchar(100),
	[PASSWORD] varchar(50),
)