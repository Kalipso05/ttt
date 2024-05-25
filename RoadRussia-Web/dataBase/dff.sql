USE [master]
GO
/****** Object:  Database [dbRoad]    Script Date: 25.05.2024 15:54:53 ******/
CREATE DATABASE [dbRoad]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbRoad', FILENAME = N'D:\servermssqla\MSSQL16.MSSQLSERVER\MSSQL\DATA\dbRoad.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbRoad_log', FILENAME = N'D:\servermssqla\MSSQL16.MSSQLSERVER\MSSQL\DATA\dbRoad_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [dbRoad] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbRoad].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbRoad] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbRoad] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbRoad] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbRoad] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbRoad] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbRoad] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbRoad] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbRoad] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbRoad] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbRoad] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbRoad] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbRoad] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbRoad] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbRoad] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbRoad] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbRoad] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbRoad] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbRoad] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbRoad] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbRoad] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbRoad] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbRoad] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbRoad] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbRoad] SET  MULTI_USER 
GO
ALTER DATABASE [dbRoad] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbRoad] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbRoad] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbRoad] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbRoad] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbRoad] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [dbRoad] SET QUERY_STORE = ON
GO
ALTER DATABASE [dbRoad] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [dbRoad]
GO
/****** Object:  Table [dbo].[Candidate]    Script Date: 25.05.2024 15:54:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Candidate](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[PathToResume] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Candidate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentSection]    Script Date: 25.05.2024 15:54:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentSection](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TypeLibrary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 25.05.2024 15:54:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] NOT NULL,
	[Photo] [varbinary](max) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[IdStructuralDivision] [int] NOT NULL,
	[IdJobTitle] [int] NOT NULL,
	[Cabinet] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[WorkPhone] [nvarchar](50) NOT NULL,
	[Director] [nvarchar](150) NULL,
	[AsssistantDirector] [nvarchar](150) NULL,
	[OtherInformation] [nvarchar](255) NULL,
	[DateOfBirth] [date] NULL,
	[Phone] [nvarchar](50) NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[IDRole] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 25.05.2024 15:54:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[Id] [int] NOT NULL,
	[NameEvent] [nvarchar](50) NOT NULL,
	[IdTypeEvent] [int] NOT NULL,
	[IdStatusEvent] [int] NOT NULL,
	[DateTimeEvent] [datetime] NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
	[IdEmployee] [int] NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InformationProject]    Script Date: 25.05.2024 15:54:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InformationProject](
	[Id] [int] NOT NULL,
	[NameProject] [nvarchar](50) NOT NULL,
	[IdDirectorProject] [int] NOT NULL,
	[StartProject] [date] NOT NULL,
	[EndProject] [date] NOT NULL,
	[DeviationOfDeadline] [int] NOT NULL,
 CONSTRAINT [PK_InformationProject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobTitle]    Script Date: 25.05.2024 15:54:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobTitle](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[IdStructuralDivision] [int] NULL,
 CONSTRAINT [PK_JobTitle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Library]    Script Date: 25.05.2024 15:54:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Library](
	[Id] [int] NOT NULL,
	[IdDocumentSection] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PathToDocument] [nvarchar](50) NULL,
	[DocumentFile] [varbinary](max) NULL,
 CONSTRAINT [PK_Library] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialCard]    Script Date: 25.05.2024 15:54:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialCard](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateOfApproval] [date] NOT NULL,
	[DateOfChange] [date] NOT NULL,
	[IdStatus] [int] NULL,
	[Type] [nvarchar](50) NULL,
	[Area] [nvarchar](50) NULL,
	[IdAuthor] [int] NULL,
 CONSTRAINT [PK_MaterialCard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 25.05.2024 15:54:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateNews] [date] NOT NULL,
	[IdAuthor] [int] NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 25.05.2024 15:54:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 25.05.2024 15:54:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_StatusEvent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StructuralDivision]    Script Date: 25.05.2024 15:54:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StructuralDivision](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_StructuralDivision] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TemporaryAbsenceEmployees]    Script Date: 25.05.2024 15:54:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TemporaryAbsenceEmployees](
	[Id] [int] NOT NULL,
	[IdEmployee] [int] NOT NULL,
	[VacantionUntil] [date] NULL,
	[BusinessTripUntil] [date] NULL,
 CONSTRAINT [PK_TemporaryAbsenceEmployees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeEvent]    Script Date: 25.05.2024 15:54:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeEvent](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TypeEvent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Candidate] ([Id], [Name], [Surname], [MiddleName], [PathToResume]) VALUES (1, N'Иван', N'Иванов', N'Иванович', N'r1.docx')
GO
INSERT [dbo].[DocumentSection] ([Id], [Title]) VALUES (1, N'Регламентирующие документы')
INSERT [dbo].[DocumentSection] ([Id], [Title]) VALUES (2, N'Архив общих документов')
INSERT [dbo].[DocumentSection] ([Id], [Title]) VALUES (3, N'Архив приказов и распоряжений')
INSERT [dbo].[DocumentSection] ([Id], [Title]) VALUES (4, N'Материалы по обучениям')
INSERT [dbo].[DocumentSection] ([Id], [Title]) VALUES (5, N'Прочие документы')
GO
INSERT [dbo].[Employee] ([Id], [Photo], [Name], [Surname], [MiddleName], [IdStructuralDivision], [IdJobTitle], [Cabinet], [Email], [WorkPhone], [Director], [AsssistantDirector], [OtherInformation], [DateOfBirth], [Phone], [Login], [Password], [IDRole]) VALUES (1, NULL, N'Мурад', N'Курбанов', N'Гаджиевич', 1, 2, N'43', N'kurbanovmurad13@gmail.com', N'+7983123123', N'Василий', N'Отсувствует', N'Хороший работник', CAST(N'2024-05-08' AS Date), N'55555555', N'root', N'123123', NULL)
INSERT [dbo].[Employee] ([Id], [Photo], [Name], [Surname], [MiddleName], [IdStructuralDivision], [IdJobTitle], [Cabinet], [Email], [WorkPhone], [Director], [AsssistantDirector], [OtherInformation], [DateOfBirth], [Phone], [Login], [Password], [IDRole]) VALUES (2, NULL, N'Иван', N'Иванов', N'Иванович', 2, 1, N'43', N'ivan@gmail.com', N'+712312313', N'Мурад', N'Василий', N'Плохой работник', CAST(N'2005-02-27' AS Date), N'+799999999999999999', N'mura', N'test', NULL)
GO
INSERT [dbo].[Event] ([Id], [NameEvent], [IdTypeEvent], [IdStatusEvent], [DateTimeEvent], [Description], [IdEmployee]) VALUES (1, N'День Рождения', 7, 1, CAST(N'2024-05-22T13:25:11.000' AS DateTime), N'днюха у чела', 1)
INSERT [dbo].[Event] ([Id], [NameEvent], [IdTypeEvent], [IdStatusEvent], [DateTimeEvent], [Description], [IdEmployee]) VALUES (2, N'Встреча', 1, 1, CAST(N'2024-05-21T15:52:22.000' AS DateTime), N'встреча работников', 2)
INSERT [dbo].[Event] ([Id], [NameEvent], [IdTypeEvent], [IdStatusEvent], [DateTimeEvent], [Description], [IdEmployee]) VALUES (3, N'Разминка', 6, 1, CAST(N'2024-05-25T15:15:15.000' AS DateTime), N'Тренировка', 1)
INSERT [dbo].[Event] ([Id], [NameEvent], [IdTypeEvent], [IdStatusEvent], [DateTimeEvent], [Description], [IdEmployee]) VALUES (4, N'Курсы', 6, 1, CAST(N'2024-05-25T16:15:20.000' AS DateTime), N'Проведение курсов', 2)
GO
INSERT [dbo].[JobTitle] ([Id], [Title], [IdStructuralDivision]) VALUES (1, N'Генеральный директор', 1)
INSERT [dbo].[JobTitle] ([Id], [Title], [IdStructuralDivision]) VALUES (2, N'Заместитель директора', 1)
INSERT [dbo].[JobTitle] ([Id], [Title], [IdStructuralDivision]) VALUES (3, N'Отдел бухгалтерии', 2)
INSERT [dbo].[JobTitle] ([Id], [Title], [IdStructuralDivision]) VALUES (4, N'Отдел корпаративного права', 3)
INSERT [dbo].[JobTitle] ([Id], [Title], [IdStructuralDivision]) VALUES (5, N'Отдел интернет-маркетинга', 4)
INSERT [dbo].[JobTitle] ([Id], [Title], [IdStructuralDivision]) VALUES (6, N'Отдел брендинга и рекламы', 4)
GO
INSERT [dbo].[Library] ([Id], [IdDocumentSection], [Name], [PathToDocument], [DocumentFile]) VALUES (1, 1, N'Положение о направлении деятельности', N'test.docx', NULL)
INSERT [dbo].[Library] ([Id], [IdDocumentSection], [Name], [PathToDocument], [DocumentFile]) VALUES (2, 1, N'Политика в определенной области деятельности', N'test.docx', NULL)
INSERT [dbo].[Library] ([Id], [IdDocumentSection], [Name], [PathToDocument], [DocumentFile]) VALUES (3, 1, N'Регламент', N'test.docx', NULL)
INSERT [dbo].[Library] ([Id], [IdDocumentSection], [Name], [PathToDocument], [DocumentFile]) VALUES (4, 1, N'Инструкции', N'test.docx', NULL)
INSERT [dbo].[Library] ([Id], [IdDocumentSection], [Name], [PathToDocument], [DocumentFile]) VALUES (5, 1, N'Шаблоны', N'test.docx', NULL)
INSERT [dbo].[Library] ([Id], [IdDocumentSection], [Name], [PathToDocument], [DocumentFile]) VALUES (6, 2, N'Стратегические', N'test.docx', NULL)
INSERT [dbo].[Library] ([Id], [IdDocumentSection], [Name], [PathToDocument], [DocumentFile]) VALUES (7, 2, N'Долгосрочные', N'test.docx', NULL)
INSERT [dbo].[Library] ([Id], [IdDocumentSection], [Name], [PathToDocument], [DocumentFile]) VALUES (8, 2, N'Плановые', N'test.docx', NULL)
INSERT [dbo].[Library] ([Id], [IdDocumentSection], [Name], [PathToDocument], [DocumentFile]) VALUES (9, 2, N'Учетные', N'test.docx', NULL)
INSERT [dbo].[Library] ([Id], [IdDocumentSection], [Name], [PathToDocument], [DocumentFile]) VALUES (10, 2, N'Информационно-справочные', N'test.docx', NULL)
GO
INSERT [dbo].[Role] ([ID], [Title]) VALUES (1, N'Администратор системы')
INSERT [dbo].[Role] ([ID], [Title]) VALUES (2, N'Системный администратор')
INSERT [dbo].[Role] ([ID], [Title]) VALUES (3, N'Редактор')
INSERT [dbo].[Role] ([ID], [Title]) VALUES (4, N'Контент-менеджер аппарата уапрвления')
INSERT [dbo].[Role] ([ID], [Title]) VALUES (5, N'Пользователь')
GO
INSERT [dbo].[Status] ([Id], [Title]) VALUES (1, N'ожидание')
INSERT [dbo].[Status] ([Id], [Title]) VALUES (2, N'просрочена')
INSERT [dbo].[Status] ([Id], [Title]) VALUES (3, N'подтверждена')
GO
INSERT [dbo].[StructuralDivision] ([Id], [Title]) VALUES (1, N'Исполнительный офис')
INSERT [dbo].[StructuralDivision] ([Id], [Title]) VALUES (2, N'Финансовый департамент')
INSERT [dbo].[StructuralDivision] ([Id], [Title]) VALUES (3, N'Юридический департамент')
INSERT [dbo].[StructuralDivision] ([Id], [Title]) VALUES (4, N'Маркетинг и PR')
GO
INSERT [dbo].[TemporaryAbsenceEmployees] ([Id], [IdEmployee], [VacantionUntil], [BusinessTripUntil]) VALUES (1, 2, CAST(N'2024-05-19' AS Date), NULL)
INSERT [dbo].[TemporaryAbsenceEmployees] ([Id], [IdEmployee], [VacantionUntil], [BusinessTripUntil]) VALUES (2, 1, NULL, CAST(N'2024-05-25' AS Date))
GO
INSERT [dbo].[TypeEvent] ([Id], [Title]) VALUES (1, N'Общекорпоративное собрание')
INSERT [dbo].[TypeEvent] ([Id], [Title]) VALUES (2, N'выздная проверка')
INSERT [dbo].[TypeEvent] ([Id], [Title]) VALUES (3, N'общекорпаротивное культурное мероприятие')
INSERT [dbo].[TypeEvent] ([Id], [Title]) VALUES (4, N'корпоративные PR-мероприятия')
INSERT [dbo].[TypeEvent] ([Id], [Title]) VALUES (5, N'командировка сотрудника')
INSERT [dbo].[TypeEvent] ([Id], [Title]) VALUES (6, N'обучение')
INSERT [dbo].[TypeEvent] ([Id], [Title]) VALUES (7, N'День Рождения')
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_JobTitle] FOREIGN KEY([IdJobTitle])
REFERENCES [dbo].[JobTitle] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_JobTitle]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Role] FOREIGN KEY([IDRole])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Role]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_StructuralDivision] FOREIGN KEY([IdStructuralDivision])
REFERENCES [dbo].[StructuralDivision] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_StructuralDivision]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Employee] FOREIGN KEY([IdEmployee])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Employee]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_StatusEvent] FOREIGN KEY([IdStatusEvent])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_StatusEvent]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_TypeEvent] FOREIGN KEY([IdTypeEvent])
REFERENCES [dbo].[TypeEvent] ([Id])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_TypeEvent]
GO
ALTER TABLE [dbo].[InformationProject]  WITH CHECK ADD  CONSTRAINT [FK_InformationProject_Employee] FOREIGN KEY([IdDirectorProject])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[InformationProject] CHECK CONSTRAINT [FK_InformationProject_Employee]
GO
ALTER TABLE [dbo].[JobTitle]  WITH CHECK ADD  CONSTRAINT [FK_JobTitle_StructuralDivision] FOREIGN KEY([IdStructuralDivision])
REFERENCES [dbo].[StructuralDivision] ([Id])
GO
ALTER TABLE [dbo].[JobTitle] CHECK CONSTRAINT [FK_JobTitle_StructuralDivision]
GO
ALTER TABLE [dbo].[Library]  WITH CHECK ADD  CONSTRAINT [FK_Library_TypeLibrary] FOREIGN KEY([IdDocumentSection])
REFERENCES [dbo].[DocumentSection] ([Id])
GO
ALTER TABLE [dbo].[Library] CHECK CONSTRAINT [FK_Library_TypeLibrary]
GO
ALTER TABLE [dbo].[MaterialCard]  WITH CHECK ADD  CONSTRAINT [FK_MaterialCard_Employee] FOREIGN KEY([IdAuthor])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[MaterialCard] CHECK CONSTRAINT [FK_MaterialCard_Employee]
GO
ALTER TABLE [dbo].[MaterialCard]  WITH CHECK ADD  CONSTRAINT [FK_MaterialCard_Status] FOREIGN KEY([IdStatus])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[MaterialCard] CHECK CONSTRAINT [FK_MaterialCard_Status]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_Employee] FOREIGN KEY([IdAuthor])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_Employee]
GO
ALTER TABLE [dbo].[TemporaryAbsenceEmployees]  WITH CHECK ADD  CONSTRAINT [FK_TemporaryAbsenceEmployees_Employee] FOREIGN KEY([IdEmployee])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[TemporaryAbsenceEmployees] CHECK CONSTRAINT [FK_TemporaryAbsenceEmployees_Employee]
GO
USE [master]
GO
ALTER DATABASE [dbRoad] SET  READ_WRITE 
GO
