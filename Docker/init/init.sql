USE [master]
GO

/****** Object:  Database [LawFirmCMS]    Script Date: 23/03/2025 22:52:02 ******/
IF NOT EXISTS(SELECT name FROM sys.databases WHERE name = 'LawFirmCMS')
BEGIN
    CREATE DATABASE [LawFirmCMS];
END
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LawFirmCMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [LawFirmCMS] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [LawFirmCMS] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [LawFirmCMS] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [LawFirmCMS] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [LawFirmCMS] SET ARITHABORT OFF 
GO

ALTER DATABASE [LawFirmCMS] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [LawFirmCMS] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [LawFirmCMS] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [LawFirmCMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [LawFirmCMS] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [LawFirmCMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [LawFirmCMS] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [LawFirmCMS] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [LawFirmCMS] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [LawFirmCMS] SET  ENABLE_BROKER 
GO

ALTER DATABASE [LawFirmCMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [LawFirmCMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [LawFirmCMS] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [LawFirmCMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [LawFirmCMS] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [LawFirmCMS] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [LawFirmCMS] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [LawFirmCMS] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [LawFirmCMS] SET  MULTI_USER 
GO

ALTER DATABASE [LawFirmCMS] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [LawFirmCMS] SET DB_CHAINING OFF 
GO

ALTER DATABASE [LawFirmCMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [LawFirmCMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [LawFirmCMS] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [LawFirmCMS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [LawFirmCMS] SET QUERY_STORE = OFF
GO

ALTER DATABASE [LawFirmCMS] SET  READ_WRITE 
GO

USE [LawFirmCMS]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 23/03/2025 21:12:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[__EFMigrationsHistory](
[MigrationId] [nvarchar](150) NOT NULL,
[ProductVersion] [nvarchar](32) NOT NULL,
CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Configurations]    Script Date: 23/03/2025 21:12:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Configurations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](max) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Configurations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


GO
/****** Object:  Table [dbo].[CustomPages]    Script Date: 23/03/2025 21:12:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CustomPages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Path] [nvarchar](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsGroup] [bit] NOT NULL,
	[ParentId] [int] NULL,
 CONSTRAINT [PK_CustomPages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 23/03/2025 21:12:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[Login] [nvarchar](max) NOT NULL,
	[PasswordHash] [varbinary](max) NOT NULL,
	[Boss] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Expertise] [nvarchar](max) NULL,
	[Picture] [varbinary](max) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Forms]    Script Date: 23/03/2025 21:12:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[IsHandled] [bit] NOT NULL,
 CONSTRAINT [PK_Forms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobOffer]    Script Date: 23/03/2025 21:12:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobOffer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Position] [nvarchar](max) NOT NULL,
	[Salary] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Requirements] [nvarchar](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_JobOffer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PageElements]    Script Date: 23/03/2025 21:12:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PageElements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NOT NULL,
	[Order] [int] NOT NULL,
	[TextData] [nvarchar](max) NULL,
	[BinaryData] [varbinary](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[PageId] [int] NOT NULL,
 CONSTRAINT [PK_PageElements] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 23/03/2025 21:12:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[PublishDate] [datetime2](7) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[CustomPages] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsGroup]
GO
ALTER TABLE [dbo].[Employees] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[JobOffer] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Posts] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Posts] ADD  DEFAULT (N'') FOR [Title]
GO
ALTER TABLE [dbo].[CustomPages]  WITH CHECK ADD  CONSTRAINT [FK_CustomPages_CustomPages_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[CustomPages] ([Id])
GO
ALTER TABLE [dbo].[CustomPages] CHECK CONSTRAINT [FK_CustomPages_CustomPages_ParentId]
GO
ALTER TABLE [dbo].[PageElements]  WITH CHECK ADD  CONSTRAINT [FK_PageElements_CustomPages_PageId] FOREIGN KEY([PageId])
REFERENCES [dbo].[CustomPages] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PageElements] CHECK CONSTRAINT [FK_PageElements_CustomPages_PageId]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Posts_Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Posts_Employees_EmployeeId]
GO

SET IDENTITY_INSERT [dbo].[Configurations] ON
INSERT INTO [dbo].[Configurations] ([Id], [Key], [Value]) VALUES (1, N'post_visible', N'True')
INSERT INTO [dbo].[Configurations] ([Id], [Key], [Value]) VALUES (2, N'footer', N'<p>Plac Marii Skłodowskiej-Curie 5, 60-965 Poznań. Telefon: 123</p>
')
SET IDENTITY_INSERT [dbo].[Configurations] OFF

SET IDENTITY_INSERT [dbo].[CustomPages] ON
INSERT INTO [dbo].[CustomPages] ([Id], [Title], [Path], [IsDeleted], [IsGroup], [ParentId]) VALUES (-1, N'Home', N'Home', 0, 0, NULL)
INSERT INTO [dbo].[CustomPages] ([Id], [Title], [Path], [IsDeleted], [IsGroup], [ParentId]) VALUES (17, N'About us', N'AboutUs', 0, 0, NULL)
INSERT INTO [dbo].[CustomPages] ([Id], [Title], [Path], [IsDeleted], [IsGroup], [ParentId]) VALUES (18, N'Practice Areas', N'PracticeAreas', 0, 1, NULL)
INSERT INTO [dbo].[CustomPages] ([Id], [Title], [Path], [IsDeleted], [IsGroup], [ParentId]) VALUES (19, N'Divorces', N'Divorces', 0, 0, 18)
INSERT INTO [dbo].[CustomPages] ([Id], [Title], [Path], [IsDeleted], [IsGroup], [ParentId]) VALUES (20, N'Child Custody', N'ChildCustody', 0, 0, 18)
INSERT INTO [dbo].[CustomPages] ([Id], [Title], [Path], [IsDeleted], [IsGroup], [ParentId]) VALUES (21, N'Prenuptial Agreements', N'PrenuptialAgreements', 0, 0, 18)
INSERT INTO [dbo].[CustomPages] ([Id], [Title], [Path], [IsDeleted], [IsGroup], [ParentId]) VALUES (22, N'Our Lawyers', N'Lawyers', 0, 0, NULL)
INSERT INTO [dbo].[CustomPages] ([Id], [Title], [Path], [IsDeleted], [IsGroup], [ParentId]) VALUES (25, N'Job Offers', N'JobOffers', 0, 0, NULL)
INSERT INTO [dbo].[CustomPages] ([Id], [Title], [Path], [IsDeleted], [IsGroup], [ParentId]) VALUES (26, N'Mediacje', N'Mediacje', 0, 0, 18)
SET IDENTITY_INSERT [dbo].[CustomPages] OFF

SET IDENTITY_INSERT [dbo].[Employees] ON
INSERT INTO [dbo].[Employees] ([Id], [Name], [Surname], [Login], [PasswordHash], [Boss], [IsDeleted], [Expertise], [Picture]) VALUES (-2, N'Employee', N'Employee', N'employee', CONVERT(VARBINARY(MAX), '0x327BA87FB0EBC1BF2058A388727F9AAAEFE12D905C10C5825C513266E4FC768AE7EB9952B059596115E29E0B3FECD2E86C8EC284C4B87BB84AD69788A75A1B22',1), 0, 0, N'Skakanie i jedzenie siana', NULL)
INSERT INTO [dbo].[Employees] ([Id], [Name], [Surname], [Login], [PasswordHash], [Boss], [IsDeleted], [Expertise], [Picture]) VALUES (-1, N'Admin', N'Admin', N'admin', CONVERT(VARBINARY(MAX), '0xE1DE259FA32DE5FAF995F6A3153C2708221525CCD6B06DD8705447F634BC9AFF404EE3D470D652237BB91D9C8255079D3EFE717D2DDDEDFE431FE3D55CC71023',1), 1, 0, NULL, NULL)
INSERT INTO [dbo].[Employees] ([Id], [Name], [Surname], [Login], [PasswordHash], [Boss], [IsDeleted], [Expertise], [Picture]) VALUES (1, N'rthreh', N'rhtrht', N'rthrh', CONVERT(VARBINARY(MAX), '0x8866A26CA4F426E12772FEAE2C3A7A9382BACC64CB1E736DCD4E81C1FA79C29104EB73F0CB17E2E06B24D5345D0799A90EBE21725A3BD9A1CC3F69B203D70A94',1), 0, 1, NULL, NULL)
INSERT INTO [dbo].[Employees] ([Id], [Name], [Surname], [Login], [PasswordHash], [Boss], [IsDeleted], [Expertise], [Picture]) VALUES (2, N'Mateusz', N'Żmigrodzki', N'Mateusz', CONVERT(VARBINARY(MAX), '0x0A350D18EA900114AEFA272B16DDB2FF90557E04C1548C2DB219E6284BED3F85A64C9B7B09D57056881389B3A40885905F4368EF160D8410285C7816ABD447F7',1), 0, 0, N'known for his profound wisdom and dedication to solving life’s challenges, now brings his calm and thoughtful demeanor to helping couples prepare for their future with prenuptial agreements. With a unique blend of empathy and practicality, he guides clients through the process of creating agreements that are fair, transparent, and built on mutual respect.', NULL)
INSERT INTO [dbo].[Employees] ([Id], [Name], [Surname], [Login], [PasswordHash], [Boss], [IsDeleted], [Expertise], [Picture]) VALUES (3, N'Mariusz', N'Pudzianowski', N'Mariusz', CONVERT(VARBINARY(MAX), '0x318CB5A30A9397BD802B12DB2ECB9F9234CA32837E3D04541636A452243B178619B5B42652DDA329A3F99725C9FE5B4A397C2918DF46A1ABCC235A59A7D8186E',1), 0, 0, N'Renowned for his unmatched strength as a world champion strongman, brings the same dedication, focus, and resilience to his work in divorce law. Combining his commanding presence with a strategic and empathetic approach, Mariusz is not just a powerful advocate but also a trusted guide through the often turbulent waters of divorce.', NULL)
INSERT INTO [dbo].[Employees] ([Id], [Name], [Surname], [Login], [PasswordHash], [Boss], [IsDeleted], [Expertise], [Picture]) VALUES (4, N'Niania', N'Frania', N'Niania', CONVERT(VARBINARY(MAX), '0xFADB65BFE470AA697219A8ED20F5F1F9044DAC6206B6CDD4758F90E7662E913B6E203980983BC96D5B6B78694A176CA2F120A5735DAA386ED9F3B831DA6BE1C4',1), 0, 0, N'Compassion and Expertise in Child Custody Cases

Agata Przybysz, the skilled and empathetic lawyer from Prawo Agaty, brings her unwavering dedication and legal expertise to the sensitive matters of child custody. With her sharp intellect and heartfelt approach, Agata understands that custody disputes are not just about legal battles—they are about protecting the well-being and future of your children.', NULL)
INSERT INTO [dbo].[Employees] ([Id], [Name], [Surname], [Login], [PasswordHash], [Boss], [IsDeleted], [Expertise], [Picture]) VALUES (5, N'Tony', N'Stark', N'Tony', CONVERT(VARBINARY(MAX), '0x3EC5345B8429904938B62C74B27BDD9236D41D6E1B634DB7DD26440AE4722A934B8951E700D9EED5DBC070CE0E15D6AC08FE98756275FA1F1A274FE5780991E9',1), 0, 0, N'When it comes to solving legal problems with cutting-edge innovation and unmatched charisma, Tony Stark is your go-to attorney. While some know him as a futurist and tech pioneer, his talents extend beyond engineering marvels—he''s also a sharp legal mind ready to take on the most challenging cases (no, he didn’t build a suit for that... yet).', NULL)
INSERT INTO [dbo].[Employees] ([Id], [Name], [Surname], [Login], [PasswordHash], [Boss], [IsDeleted], [Expertise], [Picture]) VALUES (6, N'imie', N'nazwisko', N'123', CONVERT(VARBINARY(MAX), '0x9ADDA956D476E5E68ECC5D2B2D9CA389FFE7E7EDAB4596C9FEF1F4832BEC39CCDB99B5D3D46CDCC5FC5245FEA3D9F8BE6EC41DFE2B7758805817C9975AAF39D5',1), 0, 0, N'zdobienie', NULL)
SET IDENTITY_INSERT [dbo].[Employees] OFF

SET IDENTITY_INSERT [dbo].[Forms] ON
INSERT INTO [dbo].[Forms] ([Id], [Email], [Content], [IsHandled]) VALUES (17, N'jffjfj@jdfj', N'fshgfhfghs', 1)
SET IDENTITY_INSERT [dbo].[Forms] OFF

SET IDENTITY_INSERT [dbo].[JobOffer] ON
INSERT INTO [dbo].[JobOffer] ([Id], [Position], [Salary], [Description], [Requirements], [IsDeleted]) VALUES (1, N'Specjalista do spraw sprzątania zupy', 16000, N'Poszukujemy chętnej i pomocnej osobie która pozwoli przetrwać rozlew zupy nawet naszym najbardziej wymagającym klientom. Jęsli szukasz takiego czegos to cho do nas mordeczko.', N'Posiadanie chochli, 5 lat doświadczenia w robieniu pomidorowej', 1)
INSERT INTO [dbo].[JobOffer] ([Id], [Position], [Salary], [Description], [Requirements], [IsDeleted]) VALUES (2, N'Divorce and Custody Lawyer', 7000, N'Join our dynamic team to handle complex divorce cases and custody negotiations. This position involves managing a diverse caseload, working with clients through emotionally charged situations, and ensuring favorable outcomes.', N'Juris Doctor (JD), active state bar license, minimum 5 years of experience in family law, excellent negotiation and communication skills.', 0)
INSERT INTO [dbo].[JobOffer] ([Id], [Position], [Salary], [Description], [Requirements], [IsDeleted]) VALUES (3, N'Family Law Attorney', 9000, N'A well-established law firm is seeking an experienced attorney specializing in family law, including divorce cases, child custody arrangements, and drafting prenuptial agreements. The role involves client consultations and courtroom representation.', N'Juris Doctor (JD), active state bar license, minimum 5 years of experience in family law, excellent negotiation and communication skills.', 0)
INSERT INTO [dbo].[JobOffer] ([Id], [Position], [Salary], [Description], [Requirements], [IsDeleted]) VALUES (4, N'Senior Family Law Attorney', 12000, N'We are seeking a senior-level attorney to lead our family law department, focusing on high-profile divorce cases, custody disputes, and prenuptial agreement negotiations.', N'JD degree, active bar membership, over 7 years of experience in family law, leadership capabilities, courtroom expertise, strong analytical and client relationship management skills.', 0)
INSERT INTO [dbo].[JobOffer] ([Id], [Position], [Salary], [Description], [Requirements], [IsDeleted]) VALUES (5, N'Associate Attorney – Family Law', 5000, N'This role involves working closely with senior attorneys to manage family law cases, including divorce settlements, child custody agreements, and drafting legal documents like prenuptial agreements.', N'This role involves working closely with senior attorneys to manage family law cases, including divorce settlements, child custody agreements, and drafting legal documents like prenuptial agreements.', 0)
INSERT INTO [dbo].[JobOffer] ([Id], [Position], [Salary], [Description], [Requirements], [IsDeleted]) VALUES (6, N'Family Law Specialist', 7000, N'A client-focused firm is looking for a Family Law Specialist to handle divorce cases, shared custody arrangements, and prenuptial agreement drafting.', N'JD degree, active license to practice law, minimum 4 years of experience in family law, exceptional written and oral communication skills, ability to manage a heavy caseload effectively.', 0)
INSERT INTO [dbo].[JobOffer] ([Id], [Position], [Salary], [Description], [Requirements], [IsDeleted]) VALUES (7, N'praca', 10, N'praca', N'coś', 0)
SET IDENTITY_INSERT [dbo].[JobOffer] OFF

SET IDENTITY_INSERT [dbo].[PageElements] ON
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (19, 1, 3, N'<h3><strong>Welcome to LawFirm CMS</strong></h3>

<p>At LawFirm CMS, we are dedicated to providing exceptional legal services tailored to meet the unique needs of every client. Whether you are facing a complex legal challenge or seeking guidance to navigate important life decisions, our experienced team is here to support you every step of the way.</p>

<p><strong>Who We Are</strong></p>

<p>Founded on the principles of integrity, diligence, and client-centered service, [Your Law Firm Name] has built a reputation for excellence in legal representation. Our attorneys bring a wealth of experience across a diverse range of practice areas, including family law, business law, real estate, estate planning, and litigation. With a deep understanding of the law and a commitment to personalized service, we strive to achieve the best possible outcomes for our clients.</p>

<p><strong>Our Mission</strong></p>

<p>Our mission is simple: to provide expert legal counsel with compassion, professionalism, and a results-driven approach. We believe in fostering strong relationships with our clients, built on trust, transparency, and open communication. Your goals become our goals, and we work tirelessly to protect your rights and interests.</p>

<p><strong>What We Offer</strong></p>

<p>At [Your Law Firm Name], we understand that no two legal matters are the same. That&rsquo;s why we take the time to listen to your concerns, understand your objectives, and craft a strategy tailored to your specific situation. Our comprehensive range of services includes:</p>

<ul>
	<li><strong>Family Law:</strong> Divorce, child custody, prenuptial agreements, and more.</li>
	<li><strong>Business Law:</strong> Incorporation, contracts, dispute resolution, and compliance.</li>
	<li><strong>Real Estate:</strong> Transactions, lease agreements, and property disputes.</li>
	<li><strong>Estate Planning:</strong> Wills, trusts, and probate services.</li>
	<li><strong>Litigation: Aggressive representation in civil and commercial disputes.</strong></li>
</ul>

<p><strong>Why Choose Us?</strong></p>

<p>Choosing the right legal partner is an important decision. Here&rsquo;s why clients trust [Your Law Firm Name]:</p>

<ul>
	<li><strong>Expertise You Can Rely On:</strong> Our attorneys have years of experience and a proven track record of success.</li>
	<li><strong>Client-Centered Approach:</strong> We prioritize your needs and keep you informed at every stage of your case.</li>
	<li><strong>Results-Oriented Representation:</strong> We focus on achieving practical and favorable outcomes.</li>
	<li><strong>Accessible and Responsive:</strong> We value your time and are always here to address your questions and concerns.</li>
</ul>

<p>Let&rsquo;s Work Together</p>

<p>Navigating the legal system can be overwhelming, but you don&rsquo;t have to face it alone. At [Your Law Firm Name], we are committed to guiding you with confidence, care, and expertise. Whether you&rsquo;re planning for the future, resolving a dispute, or starting a new venture, our team is ready to provide the legal support you need.</p>

<p>Get Started Today</p>

<p>Your legal journey starts with a conversation. Contact us today to schedule a consultation and discover how we can help you achieve peace of mind and the results you deserve.</p>

<p>Welcome to LawFirm CMS]&mdash;where your success is our priority.</p>
', NULL, 0, -1)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (20, 4, 2, N'<p>Welcome to LawCMS</p>
', NULL, 0, -1)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (23, 4, 0, N'<p><strong>Contact Us</strong></p>
', NULL, 0, 17)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (24, 1, 1, N'<p><strong>LawFirmCMS</strong><br />
Your Partner in Legal Management Solutions</p>

<p><strong>Head Office</strong>:<br />
123 Justice Avenue<br />
Suite 456<br />
New York, NY 10001<br />
United States</p>

<p><strong>Phone</strong>: +1 (555) 123-4567<br />
<strong>Fax</strong>: +1 (555) 987-6543<br />
<strong>Email</strong>: info@lawfirmcms.com</p>

<p><strong>Customer Support</strong>:<br />
Phone: +1 (555) 111-2222<br />
Email: support@lawfirmcms.com<br />
Hours: Monday&ndash;Friday, 9:00 AM to 6:00 PM (EST)</p>

<p><strong>Website</strong>: <a href="http://www.lawfirmcms.com" target="_new">www.lawfirmcms.com</a></p>

<p><strong>Social Media</strong>:</p>

<ul>
	<li>LinkedIn: <a href="http://linkedin.com/company/lawfirmcms" target="_new">linkedin.com/company/lawfirmcms</a></li>
	<li>Twitter: <a href="http://twitter.com/lawfirmcms" target="_new">twitter.com/lawfirmcms</a></li>
	<li>Facebook: <a href="http://facebook.com/lawfirmcms" target="_new">facebook.com/lawfirmcms</a></li>
</ul>

<p><strong>Regional Offices</strong>:</p>

<ul>
	<li><strong>Chicago</strong>: 789 Legal Drive, Suite 101, Chicago, IL 60602, Phone: +1 (555) 223-3445</li>
	<li><strong>Los Angeles</strong>: 456 Barrister Blvd, Suite 789, Los Angeles, CA 90012, Phone: +1 (555) 445-6677</li>
</ul>
', NULL, 0, 17)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (25, 4, 0, N'<p><strong>Divorces</strong></p>
', NULL, 0, 19)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (26, 1, 1, N'<h3><strong>Divorce and Separation</strong></h3>

<p>Going through a divorce is never easy, but having the right support can make all the difference. Our team of experienced attorneys understands the emotional and financial complexities of divorce and is here to guide you every step of the way. Whether it&rsquo;s negotiating the division of assets, resolving spousal support, or advocating for your parental rights, we are committed to securing outcomes that align with your goals and needs.</p>

<p>With a compassionate approach and a focus on protecting your interests, we aim to provide clarity and peace of mind during this challenging time. Divorce may mark the end of one chapter, but it&rsquo;s also the beginning of a new one. Let us help you navigate this transition with confidence and build a brighter future.</p>

<p>&nbsp;</p>
', NULL, 0, 19)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (27, 4, 0, N'<p><strong>Child Custody</strong></p>

<p>Do it right</p>
', NULL, 0, 20)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (28, 1, 3, N'<h3><strong>We will take care!</strong></h3>

<p>When it comes to your children, nothing is more important than ensuring their happiness, stability, and security. Our team specializes in helping parents navigate child custody and support matters with care and professionalism. We work tirelessly to help you secure fair custody arrangements that reflect the best interests of your child, while also ensuring appropriate financial support to meet their needs. Whether through negotiation or litigation, we are committed to achieving outcomes that prioritize your family&rsquo;s well-being and create a brighter future for your children.</p>
', NULL, 0, 20)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (29, 4, 0, N'<p><strong>Prenuptial Agreement</strong></p>

<p>Take care of your money</p>
', NULL, 0, 21)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (30, 1, 1, N'<h3><strong>Prenuptial Agreements</strong></h3>

<p>Preparing a prenuptial agreement is a proactive and thoughtful way to protect your future while strengthening the trust in your relationship. Our attorneys are experts in drafting agreements that address your unique financial circumstances and future goals. We ensure that every agreement is fair, transparent, and enforceable, offering both partners clarity and security as they begin their journey together.</p>

<p>Whether you&rsquo;re looking to safeguard personal assets, protect family inheritances, or establish clear expectations for the future, we&rsquo;re here to guide you through the process with professionalism and care. A well-crafted prenuptial agreement isn&rsquo;t just about planning for the unexpected&mdash;it&rsquo;s about starting your marriage on a foundation of openness and mutual respect. Let us help you take this important step toward a secure and harmonious future.</p>

<p>&nbsp;</p>
', NULL, 0, 21)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (31, 3, 2, N'2', NULL, 0, 21)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (33, 3, 2, N'3', NULL, 0, 19)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (34, 0, 0, N'Meet our awesome lawyers', NULL, 0, 22)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (35, 3, 1, N'2', NULL, 0, 22)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (36, 3, 2, N'3', NULL, 0, 22)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (37, 3, 3, N'4', NULL, 0, 22)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (38, 3, 5, N'4', NULL, 0, 20)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (39, 0, 4, N'Lawyer:', NULL, 0, 20)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (40, 2, 2, NULL, NULL, 0, 20)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (41, 1, 1, N'<h3><strong>Child Custody and Support</strong></h3>

<p>When it comes to your children, nothing is more important than ensuring their stability, happiness, and well-being. Child custody and support cases require not only legal expertise but also a deep understanding of the unique dynamics of each family. Our attorneys specialize in crafting personalized solutions that prioritize your child&rsquo;s best interests while protecting your rights as a parent.</p>

<p>Whether you&rsquo;re seeking primary custody, negotiating a shared parenting arrangement, or ensuring appropriate financial support, we will work tirelessly to secure the best possible outcome. We understand the emotional weight of these decisions, and we are here to offer both legal guidance and compassionate support. With us by your side, you can feel confident that your family&rsquo;s future is in good hands.</p>
', NULL, 0, 20)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (42, 0, 0, N'Join our team!', NULL, 0, 25)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (43, 5, 1, N'2', NULL, 0, 25)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (44, 5, 2, N'3', NULL, 0, 25)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (45, 5, 3, N'6', NULL, 0, 25)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (46, 5, 4, N'5', NULL, 0, 25)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (47, 5, 5, N'4', NULL, 0, 25)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (48, 2, 4, NULL, NULL, 0, -1)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (49, 3, 4, N'5', NULL, 0, 22)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (50, 0, 0, N'Header', NULL, 0, 26)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (51, 1, 1, N'<p>Jakiś tekst długi</p>
', NULL, 0, 26)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (52, 2, 2, NULL, NULL, 0, 26)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (53, 1, 3, N'<p><strong>fweuihovgwierg</strong></p>
', NULL, 0, 26)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (54, 3, 5, N'6', NULL, 0, 22)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (55, 5, 6, N'7', NULL, 0, 25)
INSERT INTO [dbo].[PageElements] ([Id], [Type], [Order], [TextData], [BinaryData], [IsDeleted], [PageId]) VALUES (56, 2, 7, NULL, NULL, 0, 25)
SET IDENTITY_INSERT [dbo].[PageElements] OFF

SET IDENTITY_INSERT [dbo].[Posts] ON
INSERT INTO [dbo].[Posts] ([Id], [Content], [PublishDate], [EmployeeId], [IsDeleted], [Title]) VALUES (4, N'<p><strong>Introduction</strong><br />
Intellectual property law is a critical area of legal protection for creators, innovators, and businesses. From patents to copyrights, understanding these laws can help safeguard your work and ensure you retain control over your ideas.</p>

<p><strong>What is Intellectual Property?</strong><br />
Intellectual property (IP) refers to creations of the mind, such as inventions, literary works, designs, and symbols. Common types include:</p>

<ul>
	<li><strong>Patents</strong>: Protect inventions or processes.</li>
	<li><strong>Copyrights</strong>: Secure authorship of creative works like books, music, and films.</li>
	<li><strong>Trademarks</strong>: Identify and protect brand names, logos, and slogans.</li>
</ul>

<p><strong>Why Protect IP?</strong></p>

<ul>
	<li>Encourages innovation and creativity.</li>
	<li>Prevents unauthorized use of your work.</li>
	<li>Adds value to your business through licensing and branding.</li>
</ul>

<p><strong>Tips for Safeguarding Your IP</strong></p>

<ul>
	<li>Register your intellectual property.</li>
	<li>Use NDAs when sharing ideas with others.</li>
	<li>Monitor and enforce your rights.</li>
</ul>

<p><strong>Conclusion</strong><br />
Protecting intellectual property is essential for maintaining control over your creative and business assets. If you need help navigating IP laws, our team is here to guide you.</p>
', N'2025-01-24 19:15:03', -1, 1, N'Demystifying Intellectual Property Law: Protecting Your Ideas and Creations')
INSERT INTO [dbo].[Posts] ([Id], [Content], [PublishDate], [EmployeeId], [IsDeleted], [Title]) VALUES (5, N'<p><strong>Introduction</strong><br />
Employment law governs the relationship between employers and employees, ensuring fair treatment in the workplace. Whether you&#39;re an employer or an employee, understanding these laws is vital to protecting your interests.</p>

<p><strong>Key Areas of Employment Law</strong></p>

<ul>
	<li><strong>Wages and Hours</strong>: Compliance with minimum wage and overtime rules.</li>
	<li><strong>Discrimination</strong>: Protection against unfair treatment based on race, gender, or other factors.</li>
	<li><strong>Workplace Safety</strong>: Ensures a secure working environment.</li>
	<li><strong>Termination</strong>: Legal guidelines for ending employment contracts.</li>
</ul>

<p><strong>Common Workplace Issues</strong></p>

<ul>
	<li>Harassment and discrimination claims.</li>
	<li>Wage disputes.</li>
	<li>Unlawful termination.</li>
</ul>

<p><strong>How to Handle Employment Disputes</strong></p>

<ul>
	<li>Document incidents thoroughly.</li>
	<li>Understand your rights under labor laws.</li>
	<li>Consult an employment lawyer for guidance.</li>
</ul>

<p><strong>Conclusion</strong><br />
A strong grasp of employment law fosters better workplace relationships and prevents costly disputes. If you&rsquo;re dealing with an employment issue, reach out for legal support.</p>
', N'2025-01-24 19:15:34', -1, 0, N'Employment Law Essentials: Know Your Rights and Responsibilities')
INSERT INTO [dbo].[Posts] ([Id], [Content], [PublishDate], [EmployeeId], [IsDeleted], [Title]) VALUES (6, N'<p><strong>Introduction</strong><br />
Family law addresses legal matters involving relationships, from marriage to child custody. For those navigating these challenges, understanding the basics can ease the process and protect your rights.</p>

<p><strong>Common Family Law Issues</strong></p>

<ul>
	<li><strong>Divorce</strong>: Division of assets, alimony, and custody arrangements.</li>
	<li><strong>Child Custody</strong>: Determining parental responsibilities and visitation rights.</li>
	<li><strong>Prenuptial Agreements</strong>: Defining financial terms before marriage.</li>
</ul>

<p><strong>Tips for Navigating Family Law Matters</strong></p>

<ul>
	<li>Prioritize communication and cooperation.</li>
	<li>Understand local laws affecting your case.</li>
	<li>Seek experienced legal counsel.</li>
</ul>

<p><strong>Conclusion</strong><br />
Family law impacts deeply personal areas of life. Having the right support ensures that your interests and those of your family are protected.</p>
', N'2025-01-24 19:17:35', -1, 0, N'Navigating Family Law: Divorce, Custody, and Prenuptial Agreements')
INSERT INTO [dbo].[Posts] ([Id], [Content], [PublishDate], [EmployeeId], [IsDeleted], [Title]) VALUES (7, N'<p><strong>Introduction</strong><br />
Real estate transactions involve significant investments, making a solid understanding of real estate law essential. Whether you&#39;re buying, selling, or leasing, knowing your rights can prevent costly mistakes.</p>

<p><strong>Key Areas of Real Estate Law</strong></p>

<ul>
	<li><strong>Purchase Agreements</strong>: Terms for buying or selling property.</li>
	<li><strong>Leases</strong>: Establishing landlord-tenant relationships.</li>
	<li><strong>Disclosures</strong>: Seller obligations to inform buyers of property issues.</li>
</ul>

<p><strong>Common Real Estate Disputes</strong></p>

<ul>
	<li>Breach of contract in sales agreements.</li>
	<li>Disputes over security deposits in leases.</li>
	<li>Title or ownership issues.</li>
</ul>

<p><strong>Tips for Smooth Real Estate Transactions</strong></p>

<ul>
	<li>Hire a knowledgeable real estate attorney.</li>
	<li>Conduct thorough due diligence.</li>
	<li>Clearly define terms in all agreements.</li>
</ul>

<p><strong>Conclusion</strong><br />
Real estate law protects both buyers and sellers, ensuring fair and transparent transactions. If you&rsquo;re dealing with a real estate issue, consult a professional for guidance.</p>

<h3><strong>5. Business Law Basics: Starting and Running Your Company Legally</strong></h3>

<p><strong>Introduction</strong><br />
Starting and managing a business involves navigating a web of legal requirements. From incorporation to contracts, understanding business law can help you avoid pitfalls and focus on growth.</p>

<p><strong>Key Legal Steps to Starting a Business</strong></p>

<ul>
	<li><strong>Choosing a Structure</strong>: Sole proprietorship, partnership, LLC, or corporation.</li>
	<li><strong>Licensing and Permits</strong>: Ensuring compliance with local regulations.</li>
	<li><strong>Contracts</strong>: Drafting agreements with clients, vendors, and employees.</li>
</ul>

<p><strong>Common Legal Issues for Businesses</strong></p>

<ul>
	<li>Breach of contract disputes.</li>
	<li>Employment-related claims.</li>
	<li>Regulatory non-compliance.</li>
</ul>

<p><strong>Tips for Legal Business Operations</strong></p>

<ul>
	<li>Keep detailed records of all transactions.</li>
	<li>Stay updated on relevant laws and regulations.</li>
	<li>Work with a trusted legal advisor.</li>
</ul>

<p><strong>Conclusion</strong><br />
A strong foundation in business law is essential for long-term success. If you have questions about starting or managing your business, reach out to our team for expert advice.</p>
', N'2025-01-24 19:17:48', -1, 0, N'Real Estate Law 101: Buying, Selling, and Leasing Property')
INSERT INTO [dbo].[Posts] ([Id], [Content], [PublishDate], [EmployeeId], [IsDeleted], [Title]) VALUES (8, N'<p>jakiś post</p>
', N'2025-01-25 15:40:25', 6, 1, N'jakiś post')
SET IDENTITY_INSERT [dbo].[Posts] OFF
