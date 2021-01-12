USE [Product Management System]
GO

/****** Object:  StoredProcedure [Inventory].[AuthenticateUser]    Script Date: 12-01-2021 17:48:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Inventory].[AuthenticateUser]
		@email nvarchar(50),
		@password nvarchar(50)
AS
BEGIN
	SELECT Id, Email, Password
	FROM Users
	WHERE Email = @email 
	AND Password = @password
END
GO


