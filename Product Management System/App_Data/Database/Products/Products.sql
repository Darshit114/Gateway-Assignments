USE [Product Management System]
GO

/****** Object:  Table [Inventory].[Products]    Script Date: 12-01-2021 17:45:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Inventory].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
	[Price] [money] NOT NULL,
	[Quantity] [bigint] NOT NULL,
	[Short_Description] [nvarchar](255) NOT NULL,
	[Long_Description] [nvarchar](1000) NULL,
	[Small_Image] [nvarchar](100) NOT NULL,
	[Large_Image] [nvarchar](100) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


