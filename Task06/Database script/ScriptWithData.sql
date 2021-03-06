USE [master]
GO
/****** Object:  Database [UsersAndAwards]    Script Date: 24.02.2020 6:33:11 ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 24.02.2020 6:33:11 ******/
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
/****** Object:  Table [dbo].[Award]    Script Date: 24.02.2020 6:33:11 ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 24.02.2020 6:33:11 ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 24.02.2020 6:33:11 ******/
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
/****** Object:  Table [dbo].[Users_Awards]    Script Date: 24.02.2020 6:33:11 ******/
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
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([id], [login], [password], [id_Role]) VALUES (2, N'lala', N'5DE85B3BFCA67759817023968C454864B1C74C27F26CA02D2E', 2)
INSERT [dbo].[Account] ([id], [login], [password], [id_Role]) VALUES (3, N'ivan', N'6F112851E6FEE2FF97DC2060238AF4CB2800E27FDE05194C5C', 2)
INSERT [dbo].[Account] ([id], [login], [password], [id_Role]) VALUES (5, N'Polina', N'3C9909AFEC25354D551DAE21590BB26E38D53F2173B8D3DC3E', 2)
INSERT [dbo].[Account] ([id], [login], [password], [id_Role]) VALUES (7, N'admin', N'C7AD44CBAD762A5DA0A452F9E854FDC1E0E7A52A38015F23F3EAB1D80B931DD472634DFAC71CD34EBC35D16AB7FB8A90C81F975113D6C7538DC69DD8DE9077EC', 1)
INSERT [dbo].[Account] ([id], [login], [password], [id_Role]) VALUES (8, N'lalala', N'5DE85B3BFCA67759817023968C454864B1C74C27F26CA02D2EF5B21D1BAE52DB42E6B5C96A42A6CD7F20C2EF0B7FE70C3EA48C8D53EDB2B7621EC031360DD389', 1)
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[Award] ON 

INSERT [dbo].[Award] ([id], [title], [image]) VALUES (5, N'First', NULL)
INSERT [dbo].[Award] ([id], [title], [image]) VALUES (6, N'Second', N'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')
INSERT [dbo].[Award] ([id], [title], [image]) VALUES (8, N'За победу в конкурсе', N'/9j/4AAQSkZJRgABAQEASABIAAD/2wBDAAgGBgcGBQgHBwcJCQgKDBQNDAsLDBkSEw8UHRofHh0aHBwgJC4nICIsIxwcKDcpLDAxNDQ0Hyc5PTgyPC4zNDL/2wBDAQkJCQwLDBgNDRgyIRwhMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjL/wAARCABQAGQDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwDzm62x+H7WeOJG3plwijO4cY/TP41UtYpNQtEjW2zLIR5alRkHOMZ96sWTl7e5sg5VxAtxbkjI3gYZSPQgfmors/BvhPWBqOk6vcy2U1rcK7wi1bPlOoz84x97JX16V6XtUops0wmGi4Rk1o/6ZyXifwpHokcYhG/7Mvlzv2eTGWx7BuPwrnNLglv7po1j3W4B3Db14/n3r2nWdDn8WzDStFi3WUIKT3n8LOeu098evr60zVfB2neHtHGlWziMuP8AS7ofe2/884/9pj1Pp1pJwulf1PSxVCFWtGNNWVlf+vQ8hjgt2kmupgFt1cgHH3vYflVhNQ0wOEmtp0QdwqgL/wABrW8WacNOm062swFeGL7S6A5CZbCD34X9a2fhxo9pq+oX+p6lbQuLNVSCJlyvmMSSxB64AOM+vtXLLGRVF118P/BsvvMPdhVdGFm+vn/wER6Vo9pqDQmPymtz8zyqg4UDP58YHvTPEbLNtgsrKCG2jIRI4grMP97HOT71t3EIF7cC1xCt2zxgp8vJX7wx7qT/APrrnNCtrW31XTTFAytGWaSQnibajOeP95RiuShWlib4iW0Ft+vr0OHG4OOHqKmm7z+dvL0/roU10eG2u2t5IonaJczucAKf7o4P8jVZNNuJ5nRdO+1RRsBK0KDhSMhlYAc+xrYuU8zRbqZHCyzvtV2bAXaOWJ7Abuv9a0Ct/HoOntawP9hbCwySfJ9pfu4X7xBPc46UV8XKEE95N9fx/HZf5Hp4HC+0quktI9NNW/636HPWOgaXG8z6tdJEFOIoz8pf3PpS3XhnT7gR/YyMyKWwpyF5xjPc1FqX7+6k8879vzFhxnHXH1zVCG9NvL+52qP4kUnkfif6Vw3xFSTqKbv+B606NOEVDlRUl8PXaSFY4xKvZl5FFdJEolhRrcRBCo9R/KimswqrR2OJ4OhfVMTTLVJdSgDfx2u5fqDz+hFejeGdPmtbSO1XzZIbkbJEjJBOcFsehKjGfQ15lbSE2dtcI7I0KrIHU4IHCvj9D+Few+CtSlnv5Ld0ja3tuBOflY7yVCkY6j16Hj1r1MVWnCmoxW/4HNl9e+HnTXR/nqjY1TxSdKsVsrK2gtFjG3EabxGPYcD+dcjaT6brfnXV9f3rXCNjyUiAOPXJOMH2FdPq8Fm8jwzK6uDydhOPwrMsdM0KGSQWepRfbXPDX9uxXPbC7gv5k1pS9n7Plin5vv8AOxpGKjSbb97pZfmee674btbu6lvLOLWHkY5knkZZQfyUAVd8NoukWklsI7ovO+9mkUJu4wAOa0vGdxrumWxa9ujc28YLNLAgVIgPSMcBieBkEDua85OqT7o7m4kkVpl3xwQqrPszwXdwSSf84rHHUVVpezjojhw+NUK140bS6N7v5f8AB+7Q7xy82pEBSsiI2FPAX5eFH6ZPfA7CsDS2hXX7MLG/libYZGkyZFOVPyY+UEE459M9aTR9cja9hQvIyN8uJUCujf8AAflKn2A57esejotl42t0u/8AUwyZfPTaB1/LmsqUIxw84U1ZKL07v+vzM4rEvFXrO7cl0+z2S6EGr2M8oXSUYiG1JVyP+Wj55P4Z/U12N3dy3HhbTE27JobQx57IEG0sPc44+p9KyNauRb21woXF5YalK5z/ABxs2CPpXQxwpe6eQnG6Dy19s7if51yUbY6VKnNWcXdvvpr+Nj06rqYKrKon7rX3PS3yabOIvbB4/Dy3zpg3LKkf+6FP+fwrnZ7mWKEQwsFjUDKjjcSOWPqc5+mK77Vrn+2fC2mW8KKptYPmAHdVC/0NcFZj7XMseD/tc8GurLlKEL1I6ttfc7EVabx3K4y6/wDA/CxqWDMsDKWK4bgfgKKvWNurWaOVyXJbp6k0VvLK4SdzklxRSpycOS9m1+JW0+3L+GbeQDLFHXHqCSK6+x1aTR9SvVTMsMqxRTIpweR95f8AaBXI/GsazjNv4fiQDmCGN8ewwzH9R+db+neGZ746k/mFQH+Ru5JXg/gv6mupWdm9jkhhKt4V4OyTV39z/wA162PSjd2+seHhM14kzyfPHMqD92e4wffsa8yn1WCW/l0y+sIo7tSV8yCRkWQYzkA5HI5x7H0qvDJqOj3l1pcDltqKXTsDxz7cE/pXPajczJcS6hKd0kEaohXndIN5LZ/ugyYz3xRTpOnpFno1I1PYudCTjUTtptbXXt0v3LM3jm3tbeGFo7x4ssF8woxC9Mdsj2NZWoQ2t5LDqmkp51mEWOWFVOYiOxXrtIrF1C0aTToJ4wWERZXx254P8vzFJod++m3XmKx8txtkUHqPX6j/AD1rR0fbxeplUx1XnTqWvF6O3+XR9fvNa7nilmW4jUx+WCSXAUk/wqAAMkcDpnAya7SGwg1eG0v1AF0iFW9JEZSGU/gTiq0DWmoW6x3SpMrDKMRnAPcE1oaTa/2Q7Rhy1i53I3UxH0P+yf0ooYB0E9bxZx4vHTlUjzQ5ZR26pp+ffb/MoLpJvInEzFpdpwx/iIGCD+ArodEkitdJkmmx5a3Cx7j/AAhsAH8yKvWttCLl2yhjxvzngDvn6f4UNoyPaatpKSKy3a7olByVYj7v4FQamlh6VKrKa62+Xc7cRi6mKgqc1ovy0/I5u3sv7P8AEGrWcg/dGJpY8+jf/Xri9N05rW6QuMeY+8fTPH6fzrsPtst1ptndzEm8EcllN6sVwVJ98N+lZNzJHDdSSscrEDj/AICAP6V6MaMb83b+mbYCP1epTjLd3X/pT/8AbR1hGxsISPQ/zNFadrbNBZW8b8MIlyPfGTRXGq2h+a16jlVlKK0bf5mtZaZBceGblhjzpbFFRf8AZO0k/wAq6XStW060svJklU3TRqywgHLMIgSPx4rhPCniiOXwtZRXDbLqykUoT0nhHDLn+8PT0Aq9rVneW/iyS/0/lA0ZRl6bdoGR26Z/OuWUG218z9QhGFZTpS0Ts0devhpLeOa5vcSXEpM0/wDd3f1x0HYYrmdb0GSfw66vDDboyb3mkPI75NddHrPn7Le9YeTJkmc98DODj1APNefa/f6jq2nfZbeC4lW/uWnEeCSIlAAz6AnnFceAxbxD/M5pVJwouo9Uun4WX9eZyFrayWfCTpNFJyrBGX27jkEAdM9Ae1XEuRgxXMUJjPTzIxz+I4NRpYzhBG0l4oX5djbWC47Z/wAasQwzxcMDOnfK4b8+hr6WnhJR1T3/AK2PIoZvOm2lZ+Wv6/56mlp2nxRD/R12xE58sHIB9V9Pp0PtXVQQNDYGVDGwJwvmNtBPoT2P1rntIa0jnAScQ5PMcowD/n2rtJILJtOY3ETNBL8jlMso44J284Hr1FZ4mTpx0OyniYYqai4/Jqz/AOD8jjrjXoLLVxcW6ARjCNAXyJV6NnsB2rX0qWObUPtdrcN5alTC0uN6AY2hsddpAGe4rK1rShaRR/ZJj5YTOCQyj8Rxj0I/HHSszS7+S3u9rjbJhh9cgjj9K8OWGr4uCqUanXVdj6bnw1Jey5dUtPNf1/VhTqEflXsigbkvnk29gTwP8+1UdDs31vUBFy1vEQ87dsA52/Unj6ZrDe4L3psRL5QnmG+UjIjHQsfXAzXrqaVp/hTR/s8bBIYxueZzy7Y6n1z6V1ZtmP1b9zTV5T0X6nzdeU504+z31/G6X3Jv7zjfEOq/ZdWaGNgAqjPPfrRWNNbRapcS31zdC385y0SMCSU6A/oaK0p0rRSZ6+EyyjSoQp+yTst+5m+G7yTS4ybtrYWVxgiOZjuyP4lwDj8a9GW6vLjSLU6JdomA/O1ZA6ZB4PquTx6Y4rzYbECSNBFKSigecpKqoTPQfjWno2pDSbwT2bvb2c7qs8IbcLeQ/clQ916j6ZB7VnUco2lufP4fFOUHFbnZx+HdZu4Dvv5yrbndQcZb19up6VZ8OaPF4f1o3+o3cszQxlYLXfuLSEYzycDAJ/OsOTV9S0Z5oLXWLhIopGjfzYXMIbPzAN1Az64FQvc6jd2ZLf2bMjnl4SA5+jscA+/WsYTg7qKST+R6SxN4fvHZdkv6X4/M2PEup3uoXpmOjwWcK8NeEkOR6dg34g1h/a5MAEpMhGQwBQ//AFqhnvpY5B5+mXCsv3WuN8uPpkkVUmvpbnh5nPovl4A/ACvSwzqRtyySj2b/AOH/ADPMrRpV5RnGla276v8A8B/+SZfluJAP9WGXuJQD/wCPD+tQrqt1atutyYv9xv5YqpGLoEFbcyr6FHFRXsgf5DYW0bH+EMWY/wDAeTXXKrSW8l9/+R2RxChHli2vz/G5HdapPJI26V8kk8Mc+5qhJqEjJtWV27DP9K07Kz2TK13ZJKByIbi6S1jP1BO5h+VNvtNSMNPLZT2Mbt8txbzpdQg+hK8r+f4V51TF03Lkgvn/AFr+BtTxrvecrpbX/pmbFEkn7nf/AKRK/wDpDH/llH3+ldhresDXpo/OeSWPZuhtIg52x9nIVSefU4z2GMGuEvraa1BifHlkbh5f3XHqPX8a3ykl0mpxQKZZGuo7h4VODPb7flA9QMjiuKu4ylGe1uva9rirVJQ9/wDImFtZTZZZrmPHy7VBcDH1GR9CBRVSOxvJ1LppdxKuSASpXaP7ozzgUUe1a09ovwNIV58q/e28j//Z')
SET IDENTITY_INSERT [dbo].[Award] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([id], [name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([id], [name]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [name], [dateOfBirth]) VALUES (4, N'Ivan Ivaniv', CAST(N'1990-10-01' AS Date))
INSERT [dbo].[User] ([id], [name], [dateOfBirth]) VALUES (5, N'Polina', CAST(N'1997-11-11' AS Date))
SET IDENTITY_INSERT [dbo].[User] OFF
INSERT [dbo].[Users_Awards] ([id_User], [id_Award]) VALUES (4, 5)
INSERT [dbo].[Users_Awards] ([id_User], [id_Award]) VALUES (4, 6)
INSERT [dbo].[Users_Awards] ([id_User], [id_Award]) VALUES (5, 6)
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
/****** Object:  StoredProcedure [dbo].[AddAccount]    Script Date: 24.02.2020 6:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[AddAward]    Script Date: 24.02.2020 6:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 24.02.2020 6:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[AddUsersAwards]    Script Date: 24.02.2020 6:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[GetAccountByLoginAndPassword]    Script Date: 24.02.2020 6:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[GetAccounts]    Script Date: 24.02.2020 6:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[GetAwardById]    Script Date: 24.02.2020 6:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[GetRole]    Script Date: 24.02.2020 6:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 24.02.2020 6:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[RemoveAwardById]    Script Date: 24.02.2020 6:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[RemoveUserById]    Script Date: 24.02.2020 6:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[RemoveUsersAwards]    Script Date: 24.02.2020 6:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateAccount]    Script Date: 24.02.2020 6:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateAward]    Script Date: 24.02.2020 6:33:12 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 24.02.2020 6:33:12 ******/
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
