USE [master]
GO
/****** Object:  Database [UsersAndAwards]    Script Date: 24.02.2020 6:23:00 ******/
CREATE DATABASE [UsersAndAwards]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UsersAndAwards', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\UsersAndAwards.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UsersAndAwards_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\UsersAndAwards_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [UsersAndAwards] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UsersAndAwards].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UsersAndAwards] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UsersAndAwards] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UsersAndAwards] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UsersAndAwards] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UsersAndAwards] SET ARITHABORT OFF 
GO
ALTER DATABASE [UsersAndAwards] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UsersAndAwards] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UsersAndAwards] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UsersAndAwards] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UsersAndAwards] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UsersAndAwards] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UsersAndAwards] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UsersAndAwards] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UsersAndAwards] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UsersAndAwards] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UsersAndAwards] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UsersAndAwards] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UsersAndAwards] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UsersAndAwards] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UsersAndAwards] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UsersAndAwards] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UsersAndAwards] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UsersAndAwards] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UsersAndAwards] SET  MULTI_USER 
GO
ALTER DATABASE [UsersAndAwards] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UsersAndAwards] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UsersAndAwards] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UsersAndAwards] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UsersAndAwards] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UsersAndAwards] SET QUERY_STORE = OFF
GO
USE [UsersAndAwards]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 24.02.2020 6:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[login] [nvarchar](50) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[id_Role] [int] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Award]    Script Date: 24.02.2020 6:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Award](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Award] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 24.02.2020 6:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 24.02.2020 6:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[dateOfBirth] [date] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users_Awards]    Script Date: 24.02.2020 6:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users_Awards](
	[id_User] [int] NOT NULL,
	[id_Award] [int] NOT NULL,
 CONSTRAINT [PK_Users_Awards] PRIMARY KEY CLUSTERED 
(
	[id_User] ASC,
	[id_Award] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role] FOREIGN KEY([id_Role])
REFERENCES [dbo].[Role] ([id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Role]
GO
ALTER TABLE [dbo].[Users_Awards]  WITH CHECK ADD  CONSTRAINT [FK_Users_Awards_Award] FOREIGN KEY([id_Award])
REFERENCES [dbo].[Award] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users_Awards] CHECK CONSTRAINT [FK_Users_Awards_Award]
GO
ALTER TABLE [dbo].[Users_Awards]  WITH CHECK ADD  CONSTRAINT [FK_Users_Awards_User] FOREIGN KEY([id_User])
REFERENCES [dbo].[User] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users_Awards] CHECK CONSTRAINT [FK_Users_Awards_User]
GO
/****** Object:  StoredProcedure [dbo].[AddAccount]    Script Date: 24.02.2020 6:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddAccount]
	@login nvarchar(50),
	@password nvarchar(max),
	@roleId int  
AS
BEGIN
    SET NOCOUNT ON;
    
    IF EXISTS (SELECT 1 FROM [dbo].Account WHERE login = @login)
    BEGIN
        --PRINT 'Account with this login exists';
        RETURN (1); -- 1 <=> account with this login exists
    END;
    
    BEGIN 
       	Insert into [dbo].Account(login, password,id_Role)
	Values (@login,@password,@roleId)
        
        RETURN (0); -- 0 <=> add succeeded
END;
END;
GO
/****** Object:  StoredProcedure [dbo].[AddAward]    Script Date: 24.02.2020 6:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddAward] 
	@title nvarchar(50),
	@image nvarchar(max),
	@id int output
AS
BEGIN
	Insert into Award(title,image)
	Values (@title,@image)
	set @id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 24.02.2020 6:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUser] 
	@name nvarchar(50),
	@dateOfBirth date,
	@id int output
AS
BEGIN
	Insert into [dbo].[User](name, dateOfBirth)
	Values (@name,@dateOfBirth)
	set @id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[AddUsersAwards]    Script Date: 24.02.2020 6:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[AddUsersAwards] 
	@userId int,
	@awardId int
AS
BEGIN
	Insert into [dbo].[Users_Awards](id_User, id_Award)
	Values (@userId,@awardId)
END
GO
/****** Object:  StoredProcedure [dbo].[GetAccountByLoginAndPassword]    Script Date: 24.02.2020 6:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAccountByLoginAndPassword] 

@login nvarchar(50),
@password nvarchar(max)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT id as [countItems] FROM [dbo].[Account] WHERE login = @login and password=@password

END;
GO
/****** Object:  StoredProcedure [dbo].[GetAccounts]    Script Date: 24.02.2020 6:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAccounts] 

AS
BEGIN

	SET NOCOUNT ON;

select Account.id as accountId,[login],Role.name as roleName from [UsersAndAwards].[dbo].[Account] Inner join Role on id_Role=Role.id
END
GO
/****** Object:  StoredProcedure [dbo].[GetAwardById]    Script Date: 24.02.2020 6:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAwardById]
@id int
AS    
 
   SET NOCOUNT ON;  
   SELECT id, title, image  
   FROM Award   
   WHERE Award.id=@id   
RETURN  
GO
/****** Object:  StoredProcedure [dbo].[GetRole]    Script Date: 24.02.2020 6:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRole]
	@login nvarchar(50)
AS
BEGIN

	SET NOCOUNT ON;
	select Role.name as RoleName
	from Account inner join Role on Account.id_Role=Role.id
	where Account.login=@login
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 24.02.2020 6:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetUserById]
@id int
AS    
 
   SET NOCOUNT ON;  
   SELECT id, name, dateOfBirth  
   FROM [dbo].[User]   
   WHERE [dbo].[User].id=@id   
RETURN  
GO
/****** Object:  StoredProcedure [dbo].[RemoveAwardById]    Script Date: 24.02.2020 6:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[RemoveAwardById] 
	@id int 
AS
BEGIN
    SET NOCOUNT ON;
    
    IF NOT EXISTS (SELECT 1 FROM Award WHERE id = @id)
    BEGIN
        --PRINT 'статистики с таким ID нет в базе';
        RETURN (1); -- 1 <=> no statistic with specified id
    END;
    
    BEGIN TRANSACTION;
    BEGIN TRY
        DELETE FROM Award WITH(ROWLOCK)
        WHERE id = @id
        
        COMMIT;
        RETURN (0); -- 0 <=> deletion succeeded
    END TRY
    BEGIN CATCH
        ROLLBACK;
        RETURN (-1); -- -1 <=> deletion failed
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[RemoveUserById]    Script Date: 24.02.2020 6:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[RemoveUserById] 
	@id int 
AS
BEGIN
    SET NOCOUNT ON;
    
    IF NOT EXISTS (SELECT 1 FROM [dbo].[User] WHERE id = @id)
    BEGIN
        --PRINT 'статистики с таким ID нет в базе';
        RETURN (1); -- 1 <=> no statistic with specified id
    END;
    
    BEGIN TRANSACTION;
    BEGIN TRY
        DELETE FROM [dbo].[User] WITH(ROWLOCK)
        WHERE id = @id
        
        COMMIT;
        RETURN (0); -- 0 <=> deletion succeeded
    END TRY
    BEGIN CATCH
        ROLLBACK;
        RETURN (-1); -- -1 <=> deletion failed
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[RemoveUsersAwards]    Script Date: 24.02.2020 6:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[RemoveUsersAwards] 
	@userId int,
	@awardId int
AS
BEGIN
    SET NOCOUNT ON;
    
    
    BEGIN TRANSACTION;
    BEGIN TRY
        DELETE FROM [dbo].[Users_Awards] WITH(ROWLOCK)
        WHERE id_User = @userId and id_Award=@awardId
        
        COMMIT;
        RETURN (0); -- 0 <=> deletion succeeded
    END TRY
    BEGIN CATCH
        ROLLBACK;
        RETURN (-1); -- -1 <=> deletion failed
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateAccount]    Script Date: 24.02.2020 6:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateAccount] 
@idAccount int,
@idRole int
AS
BEGIN
 SET NOCOUNT ON;
    
    IF NOT EXISTS (SELECT 1 FROM Account WHERE id = @idAccount)
    BEGIN
        RETURN (1); -- 1 <=> no account with specified id
    END;
    
    BEGIN 
        update Account 
		set id_Role=@idRole
        WHERE id = @idAccount
        RETURN (0); -- 0 <=> update succeeded
    END 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateAward]    Script Date: 24.02.2020 6:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateAward] 
	@id int,
	@title nvarchar(50),
	@image nvarchar(max)
AS
BEGIN
    SET NOCOUNT ON;
    
    IF NOT EXISTS (SELECT 1 FROM Award WHERE id = @id)
    BEGIN
        --PRINT 'статистики с таким ID нет в базе';
        RETURN (1); -- 1 <=> no statistic with specified id
    END;
    
    BEGIN TRANSACTION;
    BEGIN TRY
        update Award 
		set title=@title,image=@image
        WHERE id = @id
        
        COMMIT;
        RETURN (0); -- 0 <=> deletion succeeded
    END TRY
    BEGIN CATCH
        ROLLBACK;
        RETURN (-1); -- -1 <=> deletion failed
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 24.02.2020 6:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[UpdateUser]
	@id int,
	@name nvarchar(50),
	@dateOfBirth date
AS
BEGIN
    SET NOCOUNT ON;
    
    IF NOT EXISTS (SELECT 1 FROM [dbo].[User] WHERE id = @id)
    BEGIN
        --PRINT 'статистики с таким ID нет в базе';
        RETURN (1); -- 1 <=> no user with specified id
    END;
    
    BEGIN TRANSACTION;
    BEGIN TRY
        update [dbo].[User] 
		set name=@name,dateOfBirth=@dateOfBirth
        WHERE id = @id
        
        COMMIT;
        RETURN (0); -- 0 <=> update succeeded
    END TRY
    BEGIN CATCH
        ROLLBACK;
        RETURN (-1); -- -1 <=> update failed
    END CATCH
END;
GO
USE [master]
GO
ALTER DATABASE [UsersAndAwards] SET  READ_WRITE 
GO
