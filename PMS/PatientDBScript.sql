USE [master]
GO

CREATE DATABASE [PatientDB]
GO

ALTER DATABASE [PatientDB] MODIFY FILE
( NAME = N'PatientDB', SIZE = 512MB, MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
GO

ALTER DATABASE [PatientDB] MODIFY FILE
( NAME = N'PatientDB_log', SIZE = 256MB, MAXSIZE = UNLIMITED, FILEGROWTH = 10% )
GO

USE [PatientDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tests](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TestName] [varchar](50) NOT NULL,
	[Description] [varchar](100) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Tests] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Labs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LabName] [varchar](50) NOT NULL,
	[Address] [varchar](200) NULL,
	[Capacity] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Labs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](100) NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientEnrollment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[TestID] [int] NOT NULL,
	[EnrolledOn] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_PatientEnrollment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Address] [varchar](100) NULL,
	[LabID] [int] NOT NULL,
	[Gender] [char](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[RoleID] [int] NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[Tests] ON 
GO
INSERT [dbo].[Tests] ([ID], [TestName], [Description], [IsActive]) VALUES (1, N'KFT', N'Kidney Function Test', 1)
GO
INSERT [dbo].[Tests] ([ID], [TestName], [Description], [IsActive]) VALUES (2, N'LFT', N'Liver Function Test', 1)
GO
INSERT [dbo].[Tests] ([ID], [TestName], [Description], [IsActive]) VALUES (3, N'BloodWork', N'Complete Blood Work', 1)
GO
SET IDENTITY_INSERT [dbo].[Tests] OFF
GO
SET IDENTITY_INSERT [dbo].[Labs] ON 
GO
INSERT [dbo].[Labs] ([ID], [LabName], [Address], [Capacity], [IsActive]) VALUES (1, N'Lab A', N'Location 1', 20, 1)
GO
INSERT [dbo].[Labs] ([ID], [LabName], [Address], [Capacity], [IsActive]) VALUES (2, N'Lab B', N'Location 2', 20, 1)
GO
INSERT [dbo].[Labs] ([ID], [LabName], [Address], [Capacity], [IsActive]) VALUES (3, N'Lab C', N'Location 3', 20, 1)
GO
INSERT [dbo].[Labs] ([ID], [LabName], [Address], [Capacity], [IsActive]) VALUES (4, N'Lab D', N'Location 4', 20, 1)
GO
SET IDENTITY_INSERT [dbo].[Labs] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([ID], [RoleName], [IsActive]) VALUES (1, N'Admin', 1)
GO
INSERT [dbo].[Roles] ([ID], [RoleName], [IsActive]) VALUES (2, N'User', 1)
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[PatientEnrollment] ON 
GO
INSERT [dbo].[PatientEnrollment] ([ID], [PatientID], [TestID], [EnrolledOn], [IsActive]) VALUES (1, 1, 1, CAST(N'2020-10-29T15:05:47.790' AS DateTime), 1)
GO
INSERT [dbo].[PatientEnrollment] ([ID], [PatientID], [TestID], [EnrolledOn], [IsActive]) VALUES (2, 1, 2, CAST(N'2020-10-29T15:23:26.247' AS DateTime), 1)
GO
INSERT [dbo].[PatientEnrollment] ([ID], [PatientID], [TestID], [EnrolledOn], [IsActive]) VALUES (1004, 1, 3, CAST(N'2020-11-01T22:36:20.757' AS DateTime), 1)
GO
INSERT [dbo].[PatientEnrollment] ([ID], [PatientID], [TestID], [EnrolledOn], [IsActive]) VALUES (1017, 2, 2, CAST(N'2020-11-01T23:03:19.633' AS DateTime), 1)
GO
INSERT [dbo].[PatientEnrollment] ([ID], [PatientID], [TestID], [EnrolledOn], [IsActive]) VALUES (1018, 2, 3, CAST(N'2020-11-01T23:03:19.637' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[PatientEnrollment] OFF
GO
SET IDENTITY_INSERT [dbo].[Patients] ON 
GO
INSERT [dbo].[Patients] ([ID], [Name], [Address], [LabID], [Gender], [IsActive]) VALUES (1, N'John', N'Address 1', 1, N'Male   ', 1)
GO
INSERT [dbo].[Patients] ([ID], [Name], [Address], [LabID], [Gender], [IsActive]) VALUES (2, N'Jack', N'Test', 1, N'Male   ', 1)
GO
SET IDENTITY_INSERT [dbo].[Patients] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([ID], [UserName], [Password], [RoleID], [Email], [IsActive]) VALUES (1, N'admin', N'admin', 1, N'admin@gmail.com', 1)
GO
INSERT [dbo].[Users] ([ID], [UserName], [Password], [RoleID], [Email], [IsActive]) VALUES (2, N'visitor', N'visitor', 2, N'visitor@gmail.com', 1)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[PatientEnrollment]  WITH CHECK ADD  CONSTRAINT [FK_PatientEnrollment_Tests] FOREIGN KEY([TestID])
REFERENCES [dbo].[Tests] ([ID])
GO
ALTER TABLE [dbo].[PatientEnrollment] CHECK CONSTRAINT [FK_PatientEnrollment_Tests]
GO
ALTER TABLE [dbo].[PatientEnrollment]  WITH CHECK ADD  CONSTRAINT [FK_PatientEnrollment_Patients] FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patients] ([ID])
GO
ALTER TABLE [dbo].[PatientEnrollment] CHECK CONSTRAINT [FK_PatientEnrollment_Patients]
GO
ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [FK_Patients_Labs] FOREIGN KEY([LabID])
REFERENCES [dbo].[Labs] ([ID])
GO
ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [FK_Patients_Labs]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([ID])
REFERENCES [dbo].[Roles] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
