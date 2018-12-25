USE [master]
GO
/****** Object:  Database [QuestionnaireDB]    Script Date: 26.12.2018 0:07:45 ******/
CREATE DATABASE [QuestionnaireDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuestionnaireDB', FILENAME = N'D:\Working\Questionnaire\QuestionnaireDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuestionnaireDB_log', FILENAME = N'D:\Working\Questionnaire\QuestionnaireDB_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuestionnaireDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuestionnaireDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuestionnaireDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuestionnaireDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuestionnaireDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuestionnaireDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuestionnaireDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuestionnaireDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuestionnaireDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuestionnaireDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuestionnaireDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuestionnaireDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuestionnaireDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuestionnaireDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuestionnaireDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuestionnaireDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuestionnaireDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuestionnaireDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuestionnaireDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuestionnaireDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuestionnaireDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuestionnaireDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuestionnaireDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuestionnaireDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuestionnaireDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuestionnaireDB] SET  MULTI_USER 
GO
ALTER DATABASE [QuestionnaireDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuestionnaireDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuestionnaireDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuestionnaireDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuestionnaireDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuestionnaireDB] SET QUERY_STORE = OFF
GO
USE [QuestionnaireDB]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 26.12.2018 0:07:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 26.12.2018 0:07:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](256) NULL,
	[Discriminator] [nvarchar](128) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 26.12.2018 0:07:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 26.12.2018 0:07:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 26.12.2018 0:07:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 26.12.2018 0:07:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Data]    Script Date: 26.12.2018 0:07:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Data](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionAnswerId] [int] NULL,
	[FormId] [int] NOT NULL,
	[Comment] [nvarchar](300) NULL,
 CONSTRAINT [PK_Data] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[District]    Script Date: 26.12.2018 0:07:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_District] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Family]    Script Date: 26.12.2018 0:07:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Family](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Sex] [nvarchar](10) NOT NULL,
	[DateBorn] [datetime] NOT NULL,
	[Age] [smallint] NOT NULL,
	[FormId] [int] NOT NULL,
	[Interviewed] [bit] NULL,
 CONSTRAINT [PK_Respondent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Form]    Script Date: 26.12.2018 0:07:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Form](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumberForm] [int] NOT NULL,
	[SurveyGeographyId] [smallint] NOT NULL,
	[HousingTypeId] [smallint] NOT NULL,
	[DistrictId] [smallint] NOT NULL,
	[Address] [nvarchar](300) NULL,
	[Phone] [nvarchar](30) NULL,
	[InterviewerId] [smallint] NOT NULL,
	[InterviewDate] [datetime] NOT NULL,
	[StartTime] [datetime2](7) NULL,
	[EndTime] [datetime2](7) NULL,
 CONSTRAINT [PK_Form] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HousingType]    Script Date: 26.12.2018 0:07:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HousingType](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_HousingType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Interviewer]    Script Date: 26.12.2018 0:07:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interviewer](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](30) NULL,
 CONSTRAINT [PK_Interviewer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 26.12.2018 0:07:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionTypeId] [smallint] NULL,
	[Name] [nvarchar](450) NOT NULL,
	[MultipleAnswer] [bit] NOT NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionAnswer]    Script Date: 26.12.2018 0:07:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionAnswer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionId] [int] NOT NULL,
	[AnswerId] [int] NOT NULL,
 CONSTRAINT [PK_QuestionAnswer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionType]    Script Date: 26.12.2018 0:07:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionType](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_QuestionType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SurveyGeography]    Script Date: 26.12.2018 0:07:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SurveyGeography](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_SurveyGeography] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Answer] ON 

INSERT [dbo].[Answer] ([Id], [Name]) VALUES (242, N'10001-20000 сом')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (243, N'20001-30000 сом')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (244, N'30001-40000 сом')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (241, N'5000 - 10000 сом')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (100, N'Абсолютно безопасно')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (204, N'Автомат')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (231, N'Без образования')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (6, N'Безопасно')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (220, N'Безработный(ая)')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (129, N'Бесполезно потому, что милиция не будет ничего делать')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (185, N'Бесполезно/Никто не будет ничего делать')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (117, N'Более трех раз')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (165, N'Более четырех человек')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (132, N'Боюсь обращаться в милицию')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (187, N'Боюсь обращаться куда-либо')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (251, N'Бывший парень')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (249, N'Бывший супруг')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (161, N'Бытовой конфликт')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (152, N'В магазине/на рынке')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (151, N'В транспорте')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (229, N'Вдовец/Вдова')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (181, N'Ведут себя недостойно')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (207, N'Винтовка')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (15, N'Возле дома')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (16, N'Возле работы')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (263, N'Выдали охранный ордер')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (196, N'Вымогатель остался без наказания')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (236, N'Высшее, Незаконченное высшее')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (188, N'Вышестоящий орган')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (17, N'Где-то в городе')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (194, N'Госкомитет по национальной безопасности (ГКНБ)')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (63, N'Да')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (184, N'Дал взятку, вознаграждение')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (115, N'Два раза')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (163, N'Двое человек')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (213, N'Для защиты')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (210, N'Для охоты')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (214, N'Для работы (вооруженные силы, милиция, охрана)')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (211, N'Для спортивной стрельбы')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (240, N'До 5000 сом')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (247, N'До этого')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (149, N'Дома')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (260, N'Домогательство')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (225, N'Домохозяйка')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (7, N'Достаточно безопасно')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (254, N'Друг')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (134, N'Другое')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (246, N'За последние 12 месяцев')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (18, N'За пределами города')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (19, N'За пределами страны')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (11, N'Затрудняюсь ответить')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (121, N'Заявление не приняли')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (94, N'Значительно улучшилась')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (98, N'Значительно ухудшилась')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (154, N'Избиение')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (261, N'Изнасилование')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (200, N'Иногда')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (206, N'Карабин')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (256, N'Клиент')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (255, N'Коллега')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (212, N'Коллекционирую')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (159, N'Конфликт на национальной почве')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (160, N'Конфликт на религиозной почве')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (182, N'Коррумпированы')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (258, N'Кто-то другой')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (237, N'Кыргызы')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (123, N'Машину нашли, но угонщиков не поймали')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (122, N'Машину нашли, угонщиков поймали')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (124, N'Машину не нашли, угонщиков не поймали')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (193, N'Местные органы самоуправления')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (168, N'Милицию')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (223, N'На пенсии (с ежемесячной пенсией)')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (150, N'На работе')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (156, N'Нападение из-за этнического признака')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (232, N'Начальное образование (4 класса)')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (147, N'Нашли преступников и привлекли к ответственности')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (148, N'Нашли преступников, но отпустили их')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (130, N'Не доверяю милиции')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (186, N'Не доверяю/Не хочу вмешивать кого-либо')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (259, N'Не желаю отвечать')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (226, N'Не женат/не замужем')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (179, N'Не заинтересованы в работе')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (202, N'Не знаю')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (96, N'Не изменилась')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (180, N'Не могут поймать преступников')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (139, N'Не нашли пропажу, не поймали преступников')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (146, N'Не поймали преступников')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (267, N'Не принято по такому случаю обращаться в милицию')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (178, N'Не работают должным образом')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (3, N'Не удовлетворен')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (131, N'Не хочу вмешивать милицию')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (133, N'Не хочу, чтобы кто-то узнал об этом')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (8, N'Небезопасно')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (257, N'Незнакомый')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (102, N'Немного опасно')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (222, N'Непостоянная занятость (случайные заработки, сезонная занятость)')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (219, N'Неприменимо/отказываются отвечать (не имеют дочери, внучки/сестры)')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (64, N'Нет')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (108, N'Ни разу')
GO
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (201, N'Никогда')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (166, N'Нож')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (128, N'Обратился в другие инстанции')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (192, N'Общественная/Неправительственная организация')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (171, N'Общественно-профилактический центр/суд аксакалов')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (172, N'Общественную организацию')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (157, N'Ограбление с применением насилия')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (162, N'Один человек')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (173, N'Органы местного самоуправления')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (233, N'Основное общее (9 классов)')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (10, N'Отказ от ответа')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (218, N'Очень обеспокоены')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (9, N'Очень опасно')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (174, N'Очень хорошо')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (250, N'Парень')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (167, N'Пистолет')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (177, N'Плохо')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (208, N'Пневматическое оружие')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (140, N'Поймали преступников, но пропажу не нашли')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (125, N'Поймали угонщиков, но машину не нашли')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (104, N'Полностью')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (5, N'Полностью безопасно')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (1, N'Полностью удовлетворен')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (262, N'Попытка изнасилования')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (265, N'Поставили на учет')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (221, N'Постоянная занятость (с ежемесячной заработной платой)')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (144, N'Похищение взрослого с целью выкупа')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (145, N'Похищение взрослого с целью угроз')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (142, N'Похищение невесты')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (143, N'Похищение ребенка')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (195, N'Привлекли к ответственности вымогателя')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (155, N'Принуждение к сексу')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (264, N'Провели профилактическую беседу')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (191, N'Прокуратура')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (170, N'Прокуратуру')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (138, N'Пропажу нашли, но преступников не поймали')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (137, N'Пропажу нашли, преступников поймали')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (230, N'Разведен(а)')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (127, N'Разрешил проблему сам/знаю, кто это сделал')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (183, N'Регулярно (раз в месяц)')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (198, N'Регулярно/Часто')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (197, N'Редко')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (252, N'Родственник')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (205, N'Ружье')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (239, N'Русские')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (266, N'Сами разобрались')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (245, N'Свыше 40000 сом')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (216, N'Скорее не обеспокоены')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (217, N'Скорее обеспокоены')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (215, N'Совсем не обеспокоены')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (4, N'Совсем не удовлетворен')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (141, N'сом')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (253, N'Сосед')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (227, N'Состою в официальном браке (ЗАГС)')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (228, N'Состою в религиозном браке (нике, венчание)')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (176, N'Средне')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (234, N'Среднее общее (11 классов)')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (224, N'Студент, учащийся')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (169, N'Суд')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (248, N'Супруг')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (235, N'Техникум, профессиональный лицей, ПТУ')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (109, N'Только один раз')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (209, N'Травматическое оружие')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (116, N'Три раза')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (164, N'Трое человек')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (158, N'Угроза')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (2, N'Удовлетворен')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (238, N'Узбеки')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (95, N'Улучшилась')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (97, N'Ухудшилась')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (126, N'Ущерб был не серьезный')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (175, N'Хорошо')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (105, N'Частично')
INSERT [dbo].[Answer] ([Id], [Name]) VALUES (199, N'Часто')
SET IDENTITY_INSERT [dbo].[Answer] OFF
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'29F9B764-80D5-4C8D-8A30-F90079F992E9', N'user', N'Пользователь', N'ApplicationRole')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'9ED85F14-B87C-411E-82E5-AD403BF0A574', N'manager', N'Менеджер', N'ApplicationRole')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'CE19A6FB-BF9E-4EC3-A990-EA81C2301175', N'admin', N'Администратор', N'ApplicationRole')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'079de872-5383-4ffa-b1bd-aabf60a004a3', N'9ED85F14-B87C-411E-82E5-AD403BF0A574')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4098101c-16c7-43cc-b1ea-56237662bd2c', N'29F9B764-80D5-4C8D-8A30-F90079F992E9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'df9a1b42-fb6a-405a-be84-fb55990bae13', N'9ED85F14-B87C-411E-82E5-AD403BF0A574')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'df9a1b42-fb6a-405a-be84-fb55990bae13', N'CE19A6FB-BF9E-4EC3-A990-EA81C2301175')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'079de872-5383-4ffa-b1bd-aabf60a004a3', N'manager@mail.ru', 0, N'AIi7qcMO3BeZZIq5GcCDe6jQgZZWxmHWnMDN0IW4xWPQzF77tCg0aQ7PG3+IuzZ52A==', N'f06d007e-1c41-480c-a933-d05de57e4691', NULL, 0, 0, NULL, 0, 0, N'manager@stat.kg')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4098101c-16c7-43cc-b1ea-56237662bd2c', N'user@mail.ru', 0, N'ACvjZT97TLbWHU1d/zu3a6sj/umL0omX+4REQMgDk7+8V6cojT3ZxtHlAQWqHVv+vA==', N'f5b2e1b6-525d-45ec-971e-15d94390aa33', NULL, 0, 0, NULL, 0, 0, N'user@stat.kg')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'df9a1b42-fb6a-405a-be84-fb55990bae13', N'administrator@stat.kg', 0, N'AAOSkpXJC6UOKS87MVE1ps1nAdlKngEEb/KuvtIRG27kISd2IRS6YCEBqBNRWWh2WQ==', N'c3cb824a-a274-4686-8407-25508d71e813', NULL, 0, 0, NULL, 1, 0, N'administrator@stat.kg')
SET IDENTITY_INSERT [dbo].[District] ON 

INSERT [dbo].[District] ([Id], [Name]) VALUES (1, N'Свердловский')
INSERT [dbo].[District] ([Id], [Name]) VALUES (3, N'Октябрьский')
INSERT [dbo].[District] ([Id], [Name]) VALUES (4, N'Первомайский')
INSERT [dbo].[District] ([Id], [Name]) VALUES (6, N'Ленинский')
SET IDENTITY_INSERT [dbo].[District] OFF
SET IDENTITY_INSERT [dbo].[Form] ON 

INSERT [dbo].[Form] ([Id], [NumberForm], [SurveyGeographyId], [HousingTypeId], [DistrictId], [Address], [Phone], [InterviewerId], [InterviewDate], [StartTime], [EndTime]) VALUES (24, 1, 1, 1, 1, N'1', NULL, 3, CAST(N'2018-12-25T00:00:00.000' AS DateTime), CAST(N'0001-01-01T13:22:00.0000000' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Form] OFF
SET IDENTITY_INSERT [dbo].[HousingType] ON 

INSERT [dbo].[HousingType] ([Id], [Name]) VALUES (1, N'Дом')
INSERT [dbo].[HousingType] ([Id], [Name]) VALUES (2, N'Квартира')
SET IDENTITY_INSERT [dbo].[HousingType] OFF
SET IDENTITY_INSERT [dbo].[Interviewer] ON 

INSERT [dbo].[Interviewer] ([Id], [Name], [Phone]) VALUES (3, N'Иванов Иван Иванович', NULL)
SET IDENTITY_INSERT [dbo].[Interviewer] OFF
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (24, 1, N'A1. В целом, насколько Вы удовлетворены своей жизнью?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (25, 1, N'A2. Пожалуйста, оцените по 5-ти бальной шкале уровень безопасности города в целом.', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (26, 1, N'A3. Как Вы считаете, насколько изменилась безопасность в городе за последний год?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (27, 1, N'A4. Насколько безопасно Вы себя чувствуете вечером вне дома?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (28, 1, N'A5. Чувствуете ли Вы себя в безопасности, если остаетесь вечером один/одна дома?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (29, 2, N'B1. Имелось ли у Вас или у кого-то из членов Вашего домохозяйства какое-либо личное транспортное средство (автомобиль, грузовик, мотоцикл, мотороллер, велосипед) за последние  3 года?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (30, 2, N'B2. Угоняли ли у Вас или у кого-либо из членов Вашего домохозяйства транспортное средство (автомобиль, грузовик, мотоцикл, мотороллер, велосипед) за последние 3 года?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (31, 2, N'B3. Как часто были подобные случаи за последние 12 месяцев?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (32, 2, N'B4. Где произошел последний угон транспортного средства?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (33, 2, N'B5. Обращались ли Вы с заявлением в милицию по поводу последнего угона транспорта?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (34, 2, N'B6. Какой был результат обращения в милицию?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (35, 2, N'B7. Почему не обращались?', 1)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (36, 2, N'B8. Происходили ли случаи, чтобы у Вас или у кого-то из членов Вашего домохозяйства что-то было украдено из транспортного средства (личные вещи, радиоприемник, детали автомобиля) за последние 3 года', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (37, 2, N'B9. Где произошла последняя кража из транспортного средства?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (38, 2, N'B10. Обращались ли Вы с заявлением в милицию по поводу кражи из транспортного средства? ', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (39, 2, N'B11. Почему не обратились?', 1)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (40, 2, N'B12. Какой был результат обращения в милицию по поводу кражи из автомобиля?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (42, 3, N'C1. Происходили ли случаи, когда кто-либо проникал в Ваш дом и пытался что-то украсть, за последние 3 года?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (43, 3, N'C2. Как часто происходили подобные случаи за последние 12 месяцев?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (44, 3, N'C3. был ли кто-нибудь из членов домохозяйства дома, когда в дома кто-то проник в последний раз?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (45, 3, N'C4. Было ли что-нибудь украдено?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (46, 3, N'C5. В какую сумму Вы оцениваете ущерб?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (47, 3, N'C6. Обращались ли Вы с заявлением в милицию по поводу последней кражи?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (48, 3, N'C7. Почему не обратились?', 1)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (49, 3, N'C8. Какой был результат обращения в милицию?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (57, 3, N'C9. Были ли свидетельства, что кто-то пытался проникнуть в Ваш дом (поцарапанный замок, поврежденное окно, следы на земле), за последние 3 года?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (58, 4, N'D1. Сталкивалось ли Ваше домохозяйство со случаями похищения кого-либо из членов Вашего домохозяйства, за последние 3 года?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (59, 4, N'D2. Какой именно случай произошел с Вами или с кем-либо из членов Вашего домохозяйства?', 1)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (60, 4, N'D3. Обращались ли Вы или кто-либо из членов Вашего домохозяйства с заявлением в милицию по поводу похищения?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (61, 4, N'D4. Почему не обратились?', 1)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (62, 4, N'D5.  Какой был результат обращения в милицию?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (63, 5, N'E1. Происходили ли с Вами случаи ограбления или попытки ограбления с применением силы или угрозы за последние 3 года?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (64, 5, N'E2. Как часто происходили подобные случаи за последние 12 месяцев?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (65, 5, N'E3. Где произошло последнее ограбление?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (66, 5, N'E4. Обращались ли Вы с заявлением в милицию по поводу последнего ограбления?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (67, 5, N'E5. Почему не обратились?', 1)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (68, 5, N'E6. Какой был результат обращения в милицию?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (69, 6, N'F1. Происходили ли с Вами случаи, когда у Вас было что-то украдено без применения силы (карманные кражи) за последние 3 года?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (70, 6, N'F2. Как часто происходили подобные кражи за последние 12 месяцев?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (71, 6, N'F3. Где произошла последняя карманная кража?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (72, 6, N'F4. Обращались ли Вы с заявлением в милицию по поводу кражи?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (73, 6, N'F5. Почему не обратились?', 1)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (74, 6, N'F6. Какой был результат обращения в милицию?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (75, 7, N'G1. Происходили ли случаи нападения или угроз в Ваш адрес за последние 3 года?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (76, 7, N'G2. Как часто с Вами случались подобные нападения/угрозы за последние 12 месяцев?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (77, 7, N'G3. Где произошло последнее нападение/угроза?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (78, 7, N'G4. Какой именно случай произошел с Вами в последний раз?', 1)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (79, 7, N'G5. Какова была причина нападения/угрозы/конфликта?', 1)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (80, 7, N'G6. Сколько человек было причастно к совершению преступления?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (81, 7, N'G7. Было ли у нападавших оружие - нож, пистолет или что-то еще?', 1)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (82, 7, N'G8. Было ли оружие использовано?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (83, 7, N'G9. Обращались ли Вы с заявлением в милицию по поводу последнего случая насилия?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (84, 7, N'G10. Почему не обратились?', 1)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (85, 7, N'G11. Какой был результат обращения в милицию?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (86, 14, N'H2. Как часто случались подобные случаи за последние 12 месяцев?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (87, 14, N'H3. Обращались ли Вы с заявлением в милицию по поводу обмана?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (88, 14, N'H4. Почему не обратились?', 1)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (89, 14, N'H5. Какой был результат обращения в милицию?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (90, 15, N'I1. Куда Вы обратитесь в первую очередь, в случае правонарушения?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (91, 15, N'I1.1. Пожалуйста, оцените работу этого учреждения.', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (92, 15, N'I2. В целом, Вы удовлетворены работой милиции?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (93, 15, N'I3. Почему Вы не довольны работой милиции?', 1)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (94, 15, N'I4. Вы лично контактировали с правоохранительными органами за последние 12 месяцев? (получение информации, помощи, оплата штрафа)', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (95, 15, N'I5. Сталкивались ли Вы со случаями вымогательства взятки со стороны сотрудников правоохранительных органов за последние 12 месяцев?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (96, 15, N'I6. Как часто случались подобные инциденты за последние 12 месяцев?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (97, 15, N'I7. Обращались ли Вы с заявлением в соответствующие органы по поводу последнего случая вымогательства взятки, вознаграждения?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (98, 15, N'I8. Почему не обратились?', 1)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (99, 15, N'I9. Куда конкретно Вы обращались с заявлением по поводу последнего случая вымогательства взятки, вознаграждения?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (100, 15, N'I10. Какой был результат обращения в инстанцию?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (101, 16, N'J1. Происходили ли случаи, когда Вы чувствовали, что можете стать жертвой преступления, за последние 12 месяцев? (кто-то преследовал, гнался, следил)', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (102, 16, N'J2. Как часто Вы чувствовали подобное за последний год?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (105, 17, N'K1. Имеется ли у Вас или у кого-либо из членов Вашего домохозяйства огнестрельное оружие (травматическое, пневматическое, ружье, винтовка)?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (106, 17, N'K2. Скажите, пожалуйста, какой тип оружия у Вас имеется?', 1)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (107, 17, N'K3. Для каких целей Вы держите оружие?', 1)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (108, 18, N'L1. За последние 3 года приходилось ли вам участвовать или быть свидетелем "ала качуу", например, в качестве жениха/невесты, друга жениха, женелер (невестки со стороны жениха), будущих свекрови, свекра или подруги девушки? (Вспомните прежде чем ответить).', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (109, 18, N'L2. Насколько Вы обеспокоены тем, что Ваша дочь/внучка/сестра/(для женщины вы сами) может быть похищена кем-либо с целью вступления в брак без ее согласия (ала кучуу)?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (110, 19, N'P1. Укажите ваш статус занятости', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (111, 19, N'P2. Ваше семейное положение (Возможно 2 ответа: ЗАГС и НИКЕ)', 1)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (112, 19, N'P3. Укажите Ваше образование', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (113, 19, N'P4. Укажите Вашу национальность (по паспорту)', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (114, 19, N'P5. Какой среднемесячный доход вашего домохозяйства?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (115, 20, N'M1. Иногда мужчины, исходя из своих сексуальных побуждений хватают, касаются или нападают на женщин. Это может произойти на работе, в кафе, в общественном транспорте, на учебе или дома. За последние 3 года с вами случались подобные случаи? Подумайте, прежде чем ответить. ', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (116, 20, N'M2. Это случилось за последние 12 месяцев или до того? (Если несколько раз, то имеется в виду последний случай)', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (117, 20, N'M3. Скажите, кто был нарушителем?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (118, 20, N'M4. Последний случай Вы бы описали как: (Если несколько раз, то имеется в виду самый последний случай)', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (119, 20, N'M5. Последний раз, когда это случилось, обратились ли Вы или кто-нибудь другой о случившемся в милицию?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (120, 20, N'M6. Почему не обратились?', 1)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (121, 20, N'M7. Какой был результат обращения в милицию?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (122, 21, N'N2. Делал ли ваш (последний) (муж, партнер, парень) когда-либо следующие действия и как часто это происходило в течение последних 3-х лет: ', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (123, 21, N'N3. Обращались ли Вы с заявлением в милицию по поводу отмеченных Вами действий?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (124, 21, N'N4. Почему не обратились?', 1)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (125, 21, N'N5. Какой был результат обращения в милицию?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (126, 16, N'J3. Пожалуйста, скажите насколько часто происходят следующие события в районе вашего проживания? Драки/потасовки', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (127, 16, N'J3. Пожалуйста, скажите насколько часто происходят следующие события в районе вашего проживания? Вандализм (разрушение, осквернение памятников, культурных ценностей)', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (128, 16, N'J3. Пожалуйста, скажите насколько часто происходят следующие события в районе вашего проживания? Кражи из домов/квартир', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (129, 16, N'J3. Пожалуйста, скажите насколько часто происходят следующие события в районе вашего проживания? Угон автомобилей', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (130, 16, N'J3. Пожалуйста, скажите насколько часто происходят следующие события в районе вашего проживания? Кражи из автомобилей', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (131, 16, N'J3. Пожалуйста, скажите насколько часто происходят следующие события в районе вашего проживания? Семейное насилие', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (132, 16, N'J3. Пожалуйста, скажите насколько часто происходят следующие события в районе вашего проживания? Употребление спиртных напитков в общественном месте', 0)
GO
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (133, 16, N'J3. Пожалуйста, скажите насколько часто происходят следующие события в районе вашего проживания? Употребление/распространение наркотических веществ', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (134, 16, N'J3. Пожалуйста, скажите насколько часто происходят следующие события в районе вашего проживания? Ограбление/вымогательства на улице/рэкет', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (135, 16, N'J3. Пожалуйста, скажите насколько часто происходят следующие события в районе вашего проживания? Изнасилование', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (136, 16, N'J3. Пожалуйста, скажите насколько часто происходят следующие события в районе вашего проживания? Конфликты на национальной почве', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (137, 17, N'K. Имеются ли в Вашем доме следующие охранные системы: Охранная сигнализация', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (138, 17, N'K. Имеются ли в Вашем доме следующие охранные системы: Бронированная дверь', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (139, 17, N'K. Имеются ли в Вашем доме следующие охранные системы: Решетки на окнах', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (140, 17, N'K. Имеются ли в Вашем доме следующие охранные системы: Собака', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (141, 17, N'K. Имеются ли в Вашем доме следующие охранные системы: Высоких забор', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (142, 17, N'K. Имеются ли в Вашем доме следующие охранные системы: Охрана/КПП', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (143, 17, N'K. Имеются ли в Вашем доме следующие охранные системы: Соглашения с соседями присматривать за домами', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (144, 17, N'K. Имеются ли в Вашем доме следующие охранные системы: Видеонаблюдение', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (145, 17, N'K. Имеются ли в Вашем доме следующие охранные системы: Другое', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (146, 21, N'N1. Я также хочу спросить Вас о ситуациях, которые случаются с некоторыми женщинами. Пожалуйста скажите мне, если это применимо к вашим отношениям с вашим последним мужем/партнером/парнем? Он ревнует/ал или злится/лся, если вы говорите/говорили с другими мужчинами?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (147, 21, N'N1. Я также хочу спросить Вас о ситуациях, которые случаются с некоторыми женщинами. Пожалуйста скажите мне, если это применимо к вашим отношениям с вашим последним мужем/партнером/парнем? Он часто обвиняет/обвинял вас в неверности?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (148, 21, N'N1. Я также хочу спросить Вас о ситуациях, которые случаются с некоторыми женщинами. Пожалуйста скажите мне, если это применимо к вашим отношениям с вашим последним мужем/партнером/парнем? Он запрещает/щал вам встречаться с вашими подругами?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (149, 21, N'N1. Я также хочу спросить Вас о ситуациях, которые случаются с некоторыми женщинами. Пожалуйста скажите мне, если это применимо к вашим отношениям с вашим последним мужем/партнером/парнем? Он пытается/лся ограничить ваши контакты с вашей семьей?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (150, 21, N'N1. Я также хочу спросить Вас о ситуациях, которые случаются с некоторыми женщинами. Пожалуйста скажите мне, если это применимо к вашим отношениям с вашим последним мужем/партнером/парнем? Он (настаивает/настаивал), на том, что он (находитесь/находились)?', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (151, 14, N'H1. Происходили ли с Вами лично случаи крупного обмана или мошенничества за последние 3 года? Обманутые вкладчики', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (152, 14, N'H1. Происходили ли с Вами лично случаи крупного обмана или мошенничества за последние 3 года? Обманутые дольщики строительства', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (153, 14, N'H1. Происходили ли с Вами лично случаи крупного обмана или мошенничества за последние 3 года? Участие в финансовых пирамидах', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (154, 14, N'H1. Происходили ли с Вами лично случаи крупного обмана или мошенничества за последние 3 года? Не возвращенные долги', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (155, 14, N'H1. Происходили ли с Вами лично случаи крупного обмана или мошенничества за последние 3 года? Работодатель не платит зарплату', 0)
INSERT [dbo].[Question] ([Id], [QuestionTypeId], [Name], [MultipleAnswer]) VALUES (156, 14, N'H1. Происходили ли с Вами лично случаи крупного обмана или мошенничества за последние 3 года? Другое', 0)
SET IDENTITY_INSERT [dbo].[Question] OFF
SET IDENTITY_INSERT [dbo].[QuestionAnswer] ON 

INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (49, 24, 1)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (50, 24, 2)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (51, 24, 3)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (52, 24, 4)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (53, 25, 5)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (54, 25, 6)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (55, 25, 7)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (56, 25, 8)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (57, 25, 9)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (58, 25, 10)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (59, 25, 11)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (60, 26, 94)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (61, 26, 98)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (62, 26, 10)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (63, 26, 11)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (64, 26, 95)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (65, 26, 97)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (66, 26, 96)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (67, 27, 100)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (68, 27, 7)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (69, 27, 102)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (70, 27, 9)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (71, 27, 10)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (72, 27, 11)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (73, 28, 104)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (74, 28, 105)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (75, 28, 64)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (76, 28, 10)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (77, 28, 11)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (78, 38, 63)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (79, 38, 64)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (80, 38, 10)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (81, 30, 63)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (82, 30, 64)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (83, 30, 10)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (84, 31, 108)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (85, 31, 109)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (86, 31, 115)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (87, 31, 116)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (88, 31, 117)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (89, 31, 10)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (90, 31, 11)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (91, 32, 15)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (92, 32, 16)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (93, 32, 17)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (94, 32, 18)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (95, 32, 19)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (96, 32, 10)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (97, 32, 11)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (98, 33, 63)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (99, 33, 64)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (100, 33, 10)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (101, 34, 121)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (102, 34, 123)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (103, 34, 122)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (104, 34, 124)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (105, 34, 125)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (106, 34, 134)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (107, 34, 10)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (108, 34, 11)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (109, 35, 126)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (110, 35, 127)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (111, 35, 128)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (112, 35, 132)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (113, 35, 129)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (114, 35, 130)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (115, 35, 131)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (116, 35, 133)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (117, 35, 134)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (118, 35, 10)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (119, 35, 11)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (120, 36, 63)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (121, 36, 64)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (122, 36, 10)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (123, 36, 11)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (124, 37, 15)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (125, 37, 16)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (126, 37, 17)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (127, 37, 18)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (128, 37, 19)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (129, 37, 10)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (130, 37, 11)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (131, 39, 126)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (132, 39, 127)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (133, 39, 128)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (134, 39, 129)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (135, 39, 130)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (136, 39, 131)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (137, 39, 133)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (138, 39, 132)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (139, 39, 134)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (140, 39, 10)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (141, 39, 11)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (142, 40, 121)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (143, 40, 137)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (144, 40, 138)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (145, 40, 140)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (146, 40, 139)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (147, 40, 134)
GO
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (148, 40, 10)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (149, 40, 11)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (150, 29, 63)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (151, 29, 64)
INSERT [dbo].[QuestionAnswer] ([Id], [QuestionId], [AnswerId]) VALUES (152, 29, 10)
SET IDENTITY_INSERT [dbo].[QuestionAnswer] OFF
SET IDENTITY_INSERT [dbo].[QuestionType] ON 

INSERT [dbo].[QuestionType] ([Id], [Name]) VALUES (1, N'A. ОБЩИЕ')
INSERT [dbo].[QuestionType] ([Id], [Name]) VALUES (2, N'B. АВТО (ДОМОХОЗЯЙСТВО)')
INSERT [dbo].[QuestionType] ([Id], [Name]) VALUES (3, N'C. ПРОНИКНОВЕНИЕ И ОГРАБЛЕНИЕ ДОМА (ДОМОХОЗЯЙСТВО)')
INSERT [dbo].[QuestionType] ([Id], [Name]) VALUES (4, N'D. ПОХИЩЕНИЯ (ДОМОХОЗЯЙСТВО)')
INSERT [dbo].[QuestionType] ([Id], [Name]) VALUES (5, N'E. ОГРАБЛЕНИЕ (ЛИЧНОЕ)')
INSERT [dbo].[QuestionType] ([Id], [Name]) VALUES (6, N'F. КРАЖА (ЛИЧНОЕ)')
INSERT [dbo].[QuestionType] ([Id], [Name]) VALUES (7, N'G. НАПАДЕНИЕ И УГРОЗЫ (ЛИЧНОЕ)')
INSERT [dbo].[QuestionType] ([Id], [Name]) VALUES (14, N'H. ОБМАН  (ЛИЧНОЕ)')
INSERT [dbo].[QuestionType] ([Id], [Name]) VALUES (15, N'I. ОТНОШЕНИЕ К ПРАВООХРАНИТЕЛЬНЫМ ОРГАНАМ (ЛИЧНОЕ)')
INSERT [dbo].[QuestionType] ([Id], [Name]) VALUES (16, N'J. БЕЗОПАСНОСТЬ (ЛИЧНОЕ)')
INSERT [dbo].[QuestionType] ([Id], [Name]) VALUES (17, N'K. БЕЗОПАСНОСТЬ ДОМА (ДОМОХОЗЯЙСТВО)')
INSERT [dbo].[QuestionType] ([Id], [Name]) VALUES (18, N'L. ПОХИЩЕНИЕ ДЛЯ ВСТУПЛЕНИЯ В БРАК')
INSERT [dbo].[QuestionType] ([Id], [Name]) VALUES (19, N'P. ДЕМОГРАФИЯ')
INSERT [dbo].[QuestionType] ([Id], [Name]) VALUES (20, N'M. ПРЕСТУПЛЕНИЯ НА ПОЛОВОЙ ПОЧВЕ')
INSERT [dbo].[QuestionType] ([Id], [Name]) VALUES (21, N'N. СЕМЕЙНОЕ НАСИЛИЕ')
SET IDENTITY_INSERT [dbo].[QuestionType] OFF
SET IDENTITY_INSERT [dbo].[SurveyGeography] ON 

INSERT [dbo].[SurveyGeography] ([Id], [Name]) VALUES (1, N'г. Бишкек')
INSERT [dbo].[SurveyGeography] ([Id], [Name]) VALUES (2, N'Ак-Ордо')
INSERT [dbo].[SurveyGeography] ([Id], [Name]) VALUES (3, N'Рухий-Мурас')
SET IDENTITY_INSERT [dbo].[SurveyGeography] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [Unique_Answer]    Script Date: 26.12.2018 0:07:46 ******/
ALTER TABLE [dbo].[Answer] ADD  CONSTRAINT [Unique_Answer] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Unique_NumberForm]    Script Date: 26.12.2018 0:07:46 ******/
CREATE UNIQUE NONCLUSTERED INDEX [Unique_NumberForm] ON [dbo].[Form]
(
	[NumberForm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Unique_QuestionName]    Script Date: 26.12.2018 0:07:46 ******/
ALTER TABLE [dbo].[Question] ADD  CONSTRAINT [Unique_QuestionName] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
GO
ALTER TABLE [dbo].[Data]  WITH CHECK ADD  CONSTRAINT [FK_Data_Form] FOREIGN KEY([FormId])
REFERENCES [dbo].[Form] ([Id])
GO
ALTER TABLE [dbo].[Data] CHECK CONSTRAINT [FK_Data_Form]
GO
ALTER TABLE [dbo].[Data]  WITH CHECK ADD  CONSTRAINT [FK_Data_QuestionAnswer] FOREIGN KEY([QuestionAnswerId])
REFERENCES [dbo].[QuestionAnswer] ([Id])
GO
ALTER TABLE [dbo].[Data] CHECK CONSTRAINT [FK_Data_QuestionAnswer]
GO
ALTER TABLE [dbo].[Family]  WITH CHECK ADD  CONSTRAINT [FK_Respondent_Form] FOREIGN KEY([FormId])
REFERENCES [dbo].[Form] ([Id])
GO
ALTER TABLE [dbo].[Family] CHECK CONSTRAINT [FK_Respondent_Form]
GO
ALTER TABLE [dbo].[Form]  WITH CHECK ADD  CONSTRAINT [FK_Form_District] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[District] ([Id])
GO
ALTER TABLE [dbo].[Form] CHECK CONSTRAINT [FK_Form_District]
GO
ALTER TABLE [dbo].[Form]  WITH CHECK ADD  CONSTRAINT [FK_Form_HousingType] FOREIGN KEY([HousingTypeId])
REFERENCES [dbo].[HousingType] ([Id])
GO
ALTER TABLE [dbo].[Form] CHECK CONSTRAINT [FK_Form_HousingType]
GO
ALTER TABLE [dbo].[Form]  WITH CHECK ADD  CONSTRAINT [FK_Form_Interviewer] FOREIGN KEY([InterviewerId])
REFERENCES [dbo].[Interviewer] ([Id])
GO
ALTER TABLE [dbo].[Form] CHECK CONSTRAINT [FK_Form_Interviewer]
GO
ALTER TABLE [dbo].[Form]  WITH CHECK ADD  CONSTRAINT [FK_Form_SurveyGeography] FOREIGN KEY([SurveyGeographyId])
REFERENCES [dbo].[SurveyGeography] ([Id])
GO
ALTER TABLE [dbo].[Form] CHECK CONSTRAINT [FK_Form_SurveyGeography]
GO
ALTER TABLE [dbo].[QuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_QuestionAnswer_Answer] FOREIGN KEY([AnswerId])
REFERENCES [dbo].[Answer] ([Id])
GO
ALTER TABLE [dbo].[QuestionAnswer] CHECK CONSTRAINT [FK_QuestionAnswer_Answer]
GO
ALTER TABLE [dbo].[QuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_QuestionAnswer_Question] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([Id])
GO
ALTER TABLE [dbo].[QuestionAnswer] CHECK CONSTRAINT [FK_QuestionAnswer_Question]
GO
USE [master]
GO
ALTER DATABASE [QuestionnaireDB] SET  READ_WRITE 
GO
