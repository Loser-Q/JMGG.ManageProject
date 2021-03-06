USE [JMGGProject]
GO
/****** Object:  Table [dbo].[tblUserInfo]    Script Date: 2021/1/1 1:41:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BussinessID] [varchar](50) NOT NULL,
	[CompanyName] [varchar](200) NOT NULL,
	[Mobile] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Contacts] [varchar](50) NOT NULL,
	[CreateUser] [varchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_tblUserInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblUserInfo] ADD  CONSTRAINT [DF_tblUserInfo_BussinessID]  DEFAULT ('') FOR [BussinessID]
GO
ALTER TABLE [dbo].[tblUserInfo] ADD  CONSTRAINT [DF_Table_1_BussinessName]  DEFAULT ('') FOR [CompanyName]
GO
ALTER TABLE [dbo].[tblUserInfo] ADD  CONSTRAINT [DF_tblUserInfo_Mobile]  DEFAULT ('') FOR [Mobile]
GO
ALTER TABLE [dbo].[tblUserInfo] ADD  CONSTRAINT [DF_tblUserInfo_Password]  DEFAULT ('') FOR [Password]
GO
ALTER TABLE [dbo].[tblUserInfo] ADD  CONSTRAINT [DF_tblUserInfo_Address]  DEFAULT ('') FOR [Address]
GO
ALTER TABLE [dbo].[tblUserInfo] ADD  CONSTRAINT [DF_tblUserInfo_Contacts]  DEFAULT ('') FOR [Contacts]
GO
ALTER TABLE [dbo].[tblUserInfo] ADD  CONSTRAINT [DF_tblUserInfo_CreateUser]  DEFAULT ('') FOR [CreateUser]
GO
ALTER TABLE [dbo].[tblUserInfo] ADD  CONSTRAINT [DF_tblUserInfo_CreateTime]  DEFAULT ('') FOR [CreateTime]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商家ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblUserInfo', @level2type=N'COLUMN',@level2name=N'BussinessID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblUserInfo', @level2type=N'COLUMN',@level2name=N'CompanyName'
GO
