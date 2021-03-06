USE [TaskManagement]
GO
/****** Object:  Table [dbo].[Assignments]    Script Date: 29.8.2021. 22:26:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assignments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Progress] [decimal](18, 2) NOT NULL,
	[Deadline] [datetime2](7) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[StatusTypeId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Assignments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 29.8.2021. 22:26:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 29.8.2021. 22:26:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusTypes]    Script Date: 29.8.2021. 22:26:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_StatusTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UseCaseLogs]    Script Date: 29.8.2021. 22:26:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UseCaseLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[UseCaseName] [nvarchar](max) NULL,
	[Data] [nvarchar](max) NULL,
	[Actor] [nvarchar](max) NULL,
 CONSTRAINT [PK_UseCaseLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 29.8.2021. 22:26:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[Username] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserUseCases]    Script Date: 29.8.2021. 22:26:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserUseCases](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[UseCaseId] [int] NOT NULL,
 CONSTRAINT [PK_UserUseCases] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Projects] ON 

INSERT [dbo].[Projects] ([Id], [Name], [Code], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (1, N'Online Book Store', N'OBS', CAST(N'2021-08-12T23:22:02.9035960' AS DateTime2), NULL, 0, NULL, 0)
INSERT [dbo].[Projects] ([Id], [Name], [Code], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (2, N'Online Language Platform', N'OLP', CAST(N'2021-08-12T23:22:02.9036137' AS DateTime2), NULL, 0, NULL, 0)
INSERT [dbo].[Projects] ([Id], [Name], [Code], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (3, N'Shoes web shop', N'SWS', CAST(N'2021-08-12T23:22:02.9036152' AS DateTime2), NULL, 0, NULL, 0)
SET IDENTITY_INSERT [dbo].[Projects] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (1, N'Developer', CAST(N'2021-08-12T23:22:02.9008851' AS DateTime2), NULL, 0, NULL, 0)
INSERT [dbo].[Roles] ([Id], [Name], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (2, N'Project Manager', CAST(N'2021-08-12T23:22:02.9032583' AS DateTime2), NULL, 0, NULL, 0)
INSERT [dbo].[Roles] ([Id], [Name], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (3, N'Administrator', CAST(N'2021-08-12T23:22:02.9032622' AS DateTime2), NULL, 0, NULL, 0)
INSERT [dbo].[Roles] ([Id], [Name], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (1001, N'test1', CAST(N'2021-08-29T18:11:46.8896953' AS DateTime2), CAST(N'2021-08-29T18:18:38.1257302' AS DateTime2), 1, CAST(N'2021-08-29T18:13:30.6516679' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[StatusTypes] ON 

INSERT [dbo].[StatusTypes] ([Id], [Name], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (1, N'new', CAST(N'2021-08-12T23:22:02.9035424' AS DateTime2), NULL, 0, NULL, 0)
INSERT [dbo].[StatusTypes] ([Id], [Name], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (2, N'in progress', CAST(N'2021-08-12T23:22:02.9035480' AS DateTime2), NULL, 0, NULL, 0)
INSERT [dbo].[StatusTypes] ([Id], [Name], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (3, N'finished', CAST(N'2021-08-12T23:22:02.9035485' AS DateTime2), NULL, 0, NULL, 0)
INSERT [dbo].[StatusTypes] ([Id], [Name], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (1001, N'test', CAST(N'2021-08-29T18:15:49.1717689' AS DateTime2), CAST(N'2021-08-29T18:16:31.0086656' AS DateTime2), 1, CAST(N'2021-08-29T18:16:31.0084736' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[StatusTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[UseCaseLogs] ON 

INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (1, CAST(N'2021-08-28T17:44:15.2816499' AS DateTime2), N'Get/search all users users', N'{"FirstName":null,"Email":null,"LastName":null,"Username":null,"PerPage":2,"Page":1}', N'Fake Admin')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (2, CAST(N'2021-08-28T17:56:21.2535002' AS DateTime2), N'Search/Get UseCaseLog', N'{"UseCaseName":null,"Actor":null,"PerPage":2,"Page":1}', N'Fake Admin')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (1002, CAST(N'2021-08-29T16:11:45.2432549' AS DateTime2), N'Create Role', N'{"Id":0,"Name":"test"}', N'Fake Admin')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (1003, CAST(N'2021-08-29T16:12:00.5768563' AS DateTime2), N'Get Roles', N'{"Name":null,"PerPage":2,"Page":1}', N'Fake Admin')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (1004, CAST(N'2021-08-29T16:12:42.8725560' AS DateTime2), N'Get Roles', N'{"Name":null,"PerPage":2,"Page":1}', N'Fake Admin')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (1005, CAST(N'2021-08-29T16:13:30.5647921' AS DateTime2), N'Delete Role', N'1001', N'Fake Admin')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (1006, CAST(N'2021-08-29T16:15:04.0968882' AS DateTime2), N'Get StatusTypes', N'{"Name":null,"PerPage":2,"Page":1}', N'Fake Admin')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (1007, CAST(N'2021-08-29T16:15:49.0978530' AS DateTime2), N'Create StatusType', N'{"Id":0,"Name":"test"}', N'Fake Admin')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (1008, CAST(N'2021-08-29T16:15:59.3255078' AS DateTime2), N'Get StatusTypes', N'{"Name":"test","PerPage":2,"Page":1}', N'Fake Admin')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (1009, CAST(N'2021-08-29T16:16:03.7020466' AS DateTime2), N'Get StatusTypes', N'{"Name":null,"PerPage":2,"Page":1}', N'Fake Admin')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (1010, CAST(N'2021-08-29T16:16:23.7150204' AS DateTime2), N'Get StatusTypes', N'{"Name":"test","PerPage":2,"Page":1}', N'Fake Admin')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (1011, CAST(N'2021-08-29T16:16:30.9690448' AS DateTime2), N'Delete STatusType', N'1001', N'Fake Admin')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (1012, CAST(N'2021-08-29T16:16:39.2222394' AS DateTime2), N'Get StatusTypes', N'{"Name":"test","PerPage":2,"Page":1}', N'Fake Admin')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (1013, CAST(N'2021-08-29T16:16:49.4676994' AS DateTime2), N'Get StatusTypes', N'{"Name":null,"PerPage":2,"Page":1}', N'Fake Admin')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (1014, CAST(N'2021-08-29T16:17:18.6970613' AS DateTime2), N'Get assignments', N'{"Description":null,"PerPage":2,"Page":1}', N'Fake Admin')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (1015, CAST(N'2021-08-29T16:17:27.7512514' AS DateTime2), N'Project search/get', N'{"Name":null,"PerPage":2,"Page":1}', N'Fake Admin')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (1016, CAST(N'2021-08-29T16:18:36.5282014' AS DateTime2), N'Update Role', N'{"Id":1001,"Name":"test1"}', N'Fake Admin')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (1017, CAST(N'2021-08-29T16:19:26.1119096' AS DateTime2), N'Get/search all users users', N'{"FirstName":null,"Email":null,"LastName":null,"Username":null,"PerPage":2,"Page":1}', N'Fake Admin')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (1018, CAST(N'2021-08-29T16:25:31.2902295' AS DateTime2), N'Create new user', N'{"Id":0,"FirstName":"milutin","LastName":"velisic","Email":"mvelisic@gmail.com","Password":"Sifra123!","Username":"MilutinVelisic","RoleId":0}', N'Fake Admin')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (1019, CAST(N'2021-08-29T16:25:51.1357173' AS DateTime2), N'Create new user', N'{"Id":0,"FirstName":"milutin","LastName":"velisic","Email":"mvelisic@gmail.com","Password":"Sifra123!","Username":"MilutinVelisic","RoleId":2}', N'Fake Admin')
SET IDENTITY_INSERT [dbo].[UseCaseLogs] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [Email], [RoleId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (1, N'Pera', N'Peric', N'perica', N'sifra1', N'pera@gmail.com', 1, CAST(N'2021-08-12T23:22:02.9033048' AS DateTime2), NULL, 0, NULL, 0)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [Email], [RoleId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (2, N'Marcos', N'Swill', N'marcosswill', N'sifra1', N'marcosswill@gmail.com', 2, CAST(N'2021-08-12T23:22:02.9034050' AS DateTime2), NULL, 0, NULL, 0)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [Email], [RoleId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (3, N'Lina', N'Brown', N'linabrown', N'sifra1', N'linabrown@gmail.com', 3, CAST(N'2021-08-12T23:22:02.9034104' AS DateTime2), NULL, 0, NULL, 0)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [Email], [RoleId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (5, N'Sandra', N'Mladenovic', N'sandra', N'sifra1', N'sandra@gmail.com', 2, CAST(N'2021-08-12T23:22:02.9034108' AS DateTime2), NULL, 0, NULL, 0)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [Email], [RoleId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (6, N'Mikica', N'Mikic', N'MikicaCar123!', N'Mikica123!', N'mikica@gmail.com', 1, CAST(N'2021-08-28T18:43:50.5910234' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [Email], [RoleId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (1002, N'milutin', N'velisic', N'MilutinVelisic', N'Sifra123!', N'mvelisic@gmail.com', 2, CAST(N'2021-08-29T18:25:51.1484462' AS DateTime2), NULL, 0, NULL, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[UserUseCases] ON 

INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (1, 1, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (2, 1, 2)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (3, 1, 3)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (4, 1, 4)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (5, 1, 5)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (6, 1, 6)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (7, 1, 7)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (8, 1, 8)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (9, 1, 9)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (10, 1, 10)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (11, 1, 11)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (12, 1, 12)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (13, 1, 13)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (14, 1, 14)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (15, 1, 15)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (16, 1, 16)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (17, 1, 17)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (18, 1, 18)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (19, 1, 19)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (20, 1, 20)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (21, 1, 21)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (22, 1, 22)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (23, 1, 23)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (24, 1, 24)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (25, 1, 25)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (26, 1, 26)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (27, 1, 27)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (28, 1, 28)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (29, 1, 29)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId]) VALUES (30, 1, 30)
SET IDENTITY_INSERT [dbo].[UserUseCases] OFF
GO
ALTER TABLE [dbo].[Assignments]  WITH CHECK ADD  CONSTRAINT [FK_Assignments_Projects_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[Assignments] CHECK CONSTRAINT [FK_Assignments_Projects_ProjectId]
GO
ALTER TABLE [dbo].[Assignments]  WITH CHECK ADD  CONSTRAINT [FK_Assignments_StatusTypes_StatusTypeId] FOREIGN KEY([StatusTypeId])
REFERENCES [dbo].[StatusTypes] ([Id])
GO
ALTER TABLE [dbo].[Assignments] CHECK CONSTRAINT [FK_Assignments_StatusTypes_StatusTypeId]
GO
ALTER TABLE [dbo].[Assignments]  WITH CHECK ADD  CONSTRAINT [FK_Assignments_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Assignments] CHECK CONSTRAINT [FK_Assignments_Users_UserId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserUseCases]  WITH CHECK ADD  CONSTRAINT [FK_UserUseCases_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserUseCases] CHECK CONSTRAINT [FK_UserUseCases_Users_UserId]
GO
