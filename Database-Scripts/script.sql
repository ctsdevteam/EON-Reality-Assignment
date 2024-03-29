USE [master]
GO
CREATE DATABASE [EON_Reality_Assignment_DB]
GO
USE [EON_Reality_Assignment_DB]
GO
/****** Object:  Table [dbo].[tblRegisteredUsers]    Script Date: 22-Oct-19 5:13:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRegisteredUsers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](30) NULL,
	[EmailAddress] [nvarchar](50) NULL,
	[Gender] [bit] NULL,
	[RegisterDate] [smalldatetime] NULL,
	[AdditionalRequest] [nvarchar](100) NULL,
	[SelectedDays] [nchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUserSelectedDays]    Script Date: 22-Oct-19 5:13:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserSelectedDays](
	[UserID] [int] NOT NULL,
	[SelectedDay] [int] NOT NULL,
 CONSTRAINT [PK_tbl_UserSelectedDays] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[SelectedDay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblUserSelectedDays]  WITH NOCHECK ADD  CONSTRAINT [FK_tbl_UserSelectedDays_tblRegisteredUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[tblRegisteredUsers] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[tblUserSelectedDays] CHECK CONSTRAINT [FK_tbl_UserSelectedDays_tblRegisteredUsers]
GO
USE [master]
GO
ALTER DATABASE [EON_Reality_Assignment_DB] SET  READ_WRITE 
GO
