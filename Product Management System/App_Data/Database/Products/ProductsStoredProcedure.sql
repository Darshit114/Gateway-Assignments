USE [Product Management System]
GO

/****** Object:  StoredProcedure [Inventory].[usp_ProductsCRUD]    Script Date: 12-01-2021 17:49:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Inventory].[usp_ProductsCRUD]
      @ActionName nvarchar(10),
	  @ProductId int = NULL,
	  @ProductName nvarchar(50) = NULL,
	  @CategoryName nvarchar(50) = NULL,
	  @Price money = NULL,
	  @Quantity bigint = NULL,
	  @Short_Description nvarchar(255) = NULL,
	  @Long_Description nvarchar(1000) = NULL,
	  @Small_Img nvarchar(100) = NULL,
	  @Large_Img nvarchar(100) = NULL,
	  @CreatedAt datetime = NULL,
	  @UpdatedAt datetime = NULL
AS
BEGIN
      SET NOCOUNT ON;
 
      --SELECT
      IF @ActionName = 'SELECT'
      BEGIN
            SELECT Id,[Name], Category, Price, Quantity, Short_Description, Long_Description,
				   Small_Image, Large_Image
            FROM [Inventory].[Products]
      END

      --INSERT
      IF @ActionName = 'INSERT'
      BEGIN
            INSERT INTO [Inventory].[Products]( [Name], Category, Price, Quantity, Short_Description, Long_Description,
				   Small_Image, Large_Image, CreatedAt)
				   VALUES (@ProductName, @CategoryName, @Price, @Quantity, @Short_Description, @Long_Description,
				           @Small_Img, @Large_Img, @CreatedAt)

			SET @ProductId = SCOPE_IDENTITY()
			SELECT
				[Name] = @ProductName,
				Category = @CategoryName,
				Price = @Price,
				Quantity = @Quantity,
				Short_Description = @Short_Description,
				Long_Description = @Long_Description,
				Small_Image = @Small_Img,
				Large_Image = @Large_Img
			FROM [Inventory].[Products]
			WHERE [Id] = @ProductId	
      END
 
      --UPDATE
      IF @ActionName = 'UPDATE'
      BEGIN
			UPDATE [Inventory].[Products]
			SET [Name] = @ProductName,
				Category = @CategoryName,
				Price = @Price,
				Quantity = @Quantity,
				Short_Description = @Short_Description,
				Long_Description = @Long_Description,
				Small_Image = @Small_Img,
				Large_Image = @Large_Img,
				UpdatedAt = @UpdatedAt
			WHERE [Id] = @ProductId

			SET @ProductId = SCOPE_IDENTITY()
			SELECT
				[Name] = @ProductName,
				Category = @CategoryName,
				Price = @Price,
				Quantity = @Quantity,
				Short_Description = @Short_Description,
				Long_Description = @Long_Description,
				Small_Image = @Small_Img,
				Large_Image = @Large_Img
			FROM [Inventory].[Products]
			WHERE [Id] = @ProductId	
      END
 
      --DELETE
      IF @ActionName = 'DELETE'
      BEGIN
			DELETE FROM [Inventory].[Products]
			WHERE [Id] = @ProductId
			SELECT [Id],[Name], Category,
				   Price, Quantity,
				   Short_Description,
				   Long_Description,
				   Small_Image,
				   Large_Image
				   FROM  [Inventory].[Products]
      END
END
GO


