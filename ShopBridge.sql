USE [ShopBridge]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 03/21/2021 17:26:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Item](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Price] [decimal](8, 2) NULL,
	[Description] [varchar](255) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
