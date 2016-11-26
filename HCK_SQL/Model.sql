USE [Hackathon16Dijon]
GO
/****** Object:  Table [dbo].[Adhesion]    Script Date: 26/11/2016 17:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adhesion](
	[idAnnonce] [int] NOT NULL,
	[idUtilisateur] [int] NOT NULL,
	[nbSlot] [int] NULL,
 CONSTRAINT [PK_Adhesion] PRIMARY KEY CLUSTERED 
(
	[idAnnonce] ASC,
	[idUtilisateur] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Annonce]    Script Date: 26/11/2016 17:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Annonce](
	[idAnnonce] [int] IDENTITY(1,1) NOT NULL,
	[idCategorie] [int] NULL,
	[titre] [nvarchar](50) NULL,
	[description] [nvarchar](50) NULL,
	[nbSlot] [int] NULL,
	[nbSlotUtilise] [int] NULL,
	[estActive] [bit] NULL,
	[idUtilisateur] [int] NULL,
 CONSTRAINT [PK_Annonce] PRIMARY KEY CLUSTERED 
(
	[idAnnonce] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categorie]    Script Date: 26/11/2016 17:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorie](
	[idCategorie] [int] IDENTITY(1,1) NOT NULL,
	[libelle] [nvarchar](50) NULL,
 CONSTRAINT [PK_Categorie] PRIMARY KEY CLUSTERED 
(
	[idCategorie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Chat]    Script Date: 26/11/2016 17:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chat](
	[idMessage] [int] IDENTITY(1,1) NOT NULL,
	[idExpediteur] [int] NULL,
	[idDestinataire] [int] NULL,
	[dateEnvoi] [datetime] NULL,
	[message] [nvarchar](250) NULL,
 CONSTRAINT [PK_Chat] PRIMARY KEY CLUSTERED 
(
	[idMessage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Inscription]    Script Date: 26/11/2016 17:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inscription](
	[idUtilisateur] [int] NOT NULL,
	[idVoyage] [int] NOT NULL,
	[estHebdomadaire] [bit] NULL,
	[estQuotidien] [bit] NULL,
	[wagon] [int] NULL,
 CONSTRAINT [PK_Inscription] PRIMARY KEY CLUSTERED 
(
	[idUtilisateur] ASC,
	[idVoyage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Profil]    Script Date: 26/11/2016 17:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profil](
	[idProfil] [int] IDENTITY(1,1) NOT NULL,
	[prenom] [nvarchar](50) NULL,
	[nom] [nvarchar](50) NULL,
	[dateDeNaissance] [datetime] NULL,
	[fonction] [nvarchar](50) NULL,
	[entreprise] [nvarchar](50) NULL,
	[descriptionPro] [nvarchar](250) NULL,
	[descriptionLoisir] [nvarchar](250) NULL,
	[actifLoisir] [bit] NULL,
	[actifPro] [bit] NULL,
 CONSTRAINT [PK_Profil] PRIMARY KEY CLUSTERED 
(
	[idProfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rencontre]    Script Date: 26/11/2016 17:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rencontre](
	[idRencontre] [int] NOT NULL,
	[idDemander] [int] NULL,
	[idDemandeur] [int] NULL,
	[aAccepteDemander] [bit] NULL,
	[aAccepteDemandeur] [bit] NULL,
	[idVoyage] [int] NULL,
 CONSTRAINT [PK_Rencontre] PRIMARY KEY CLUSTERED 
(
	[idRencontre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Utilisateur]    Script Date: 26/11/2016 17:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilisateur](
	[idUtilisateur] [int] IDENTITY(1,1) NOT NULL,
	[motDePasse] [nvarchar](50) NOT NULL,
	[adresseMail] [nvarchar](50) NOT NULL,
	[idProfil] [int] NULL,
 CONSTRAINT [PK_Utilisateur] PRIMARY KEY CLUSTERED 
(
	[idUtilisateur] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Voyage]    Script Date: 26/11/2016 17:12:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voyage](
	[idVoyage] [int] IDENTITY(1,1) NOT NULL,
	[depart] [nvarchar](50) NULL,
	[arrivee] [nvarchar](50) NULL,
	[date] [datetime] NULL,
	[horaireArrivee] [time](7) NULL,
	[horaireDepart] [time](7) NULL,
	[numeroTrain] [int] NULL,
	[nbWagon] [int] NULL,
 CONSTRAINT [PK_Voyage] PRIMARY KEY CLUSTERED 
(
	[idVoyage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Adhesion]  WITH CHECK ADD  CONSTRAINT [FK_Adhesion_Annonce] FOREIGN KEY([idAnnonce])
REFERENCES [dbo].[Annonce] ([idAnnonce])
GO
ALTER TABLE [dbo].[Adhesion] CHECK CONSTRAINT [FK_Adhesion_Annonce]
GO
ALTER TABLE [dbo].[Adhesion]  WITH CHECK ADD  CONSTRAINT [FK_Adhesion_Utilisateur] FOREIGN KEY([idUtilisateur])
REFERENCES [dbo].[Utilisateur] ([idUtilisateur])
GO
ALTER TABLE [dbo].[Adhesion] CHECK CONSTRAINT [FK_Adhesion_Utilisateur]
GO
ALTER TABLE [dbo].[Annonce]  WITH CHECK ADD  CONSTRAINT [FK_Annonce_Categorie1] FOREIGN KEY([idCategorie])
REFERENCES [dbo].[Categorie] ([idCategorie])
GO
ALTER TABLE [dbo].[Annonce] CHECK CONSTRAINT [FK_Annonce_Categorie1]
GO
ALTER TABLE [dbo].[Annonce]  WITH CHECK ADD  CONSTRAINT [FK_Annonce_Utilisateur] FOREIGN KEY([idUtilisateur])
REFERENCES [dbo].[Utilisateur] ([idUtilisateur])
GO
ALTER TABLE [dbo].[Annonce] CHECK CONSTRAINT [FK_Annonce_Utilisateur]
GO
ALTER TABLE [dbo].[Chat]  WITH CHECK ADD  CONSTRAINT [FK_Chat_Utilisateur] FOREIGN KEY([idExpediteur])
REFERENCES [dbo].[Utilisateur] ([idUtilisateur])
GO
ALTER TABLE [dbo].[Chat] CHECK CONSTRAINT [FK_Chat_Utilisateur]
GO
ALTER TABLE [dbo].[Chat]  WITH CHECK ADD  CONSTRAINT [FK_Chat_Utilisateur1] FOREIGN KEY([idDestinataire])
REFERENCES [dbo].[Utilisateur] ([idUtilisateur])
GO
ALTER TABLE [dbo].[Chat] CHECK CONSTRAINT [FK_Chat_Utilisateur1]
GO
ALTER TABLE [dbo].[Inscription]  WITH CHECK ADD  CONSTRAINT [FK_Inscription_Utilisateur] FOREIGN KEY([idUtilisateur])
REFERENCES [dbo].[Utilisateur] ([idUtilisateur])
GO
ALTER TABLE [dbo].[Inscription] CHECK CONSTRAINT [FK_Inscription_Utilisateur]
GO
ALTER TABLE [dbo].[Inscription]  WITH CHECK ADD  CONSTRAINT [FK_Inscription_Voyage] FOREIGN KEY([idVoyage])
REFERENCES [dbo].[Voyage] ([idVoyage])
GO
ALTER TABLE [dbo].[Inscription] CHECK CONSTRAINT [FK_Inscription_Voyage]
GO
ALTER TABLE [dbo].[Rencontre]  WITH CHECK ADD  CONSTRAINT [FK_Rencontre_Utilisateur] FOREIGN KEY([idDemander])
REFERENCES [dbo].[Utilisateur] ([idUtilisateur])
GO
ALTER TABLE [dbo].[Rencontre] CHECK CONSTRAINT [FK_Rencontre_Utilisateur]
GO
ALTER TABLE [dbo].[Rencontre]  WITH CHECK ADD  CONSTRAINT [FK_Rencontre_Utilisateur1] FOREIGN KEY([idDemandeur])
REFERENCES [dbo].[Utilisateur] ([idUtilisateur])
GO
ALTER TABLE [dbo].[Rencontre] CHECK CONSTRAINT [FK_Rencontre_Utilisateur1]
GO
ALTER TABLE [dbo].[Utilisateur]  WITH CHECK ADD  CONSTRAINT [FK_Utilisateur_Profil] FOREIGN KEY([idProfil])
REFERENCES [dbo].[Profil] ([idProfil])
GO
ALTER TABLE [dbo].[Utilisateur] CHECK CONSTRAINT [FK_Utilisateur_Profil]
GO
