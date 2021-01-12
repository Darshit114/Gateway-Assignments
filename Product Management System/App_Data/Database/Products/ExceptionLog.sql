USE [Product Management System]
GO

/****** Object:  Table [Inventory].[exceptionlog]    Script Date: 12-01-2021 17:44:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Inventory].[exceptionlog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[timestamp] [datetime] NOT NULL,
	[level] [varchar](100) NOT NULL,
	[logger] [varchar](1000) NOT NULL,
	[message] [varchar](3600) NOT NULL,
	[userid] [int] NULL,
	[exception] [varchar](3600) NULL,
	[stacktrace] [varchar](3600) NULL,
 CONSTRAINT [PK_ExceptionLog] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


