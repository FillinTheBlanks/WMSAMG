USE [CSISControl]
GO
/****** Object:  StoredProcedure [dbo].[spInsert_Stocks]    Script Date: 11/18/2020 9:00:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		kevin llupar
-- Create date: 06/06/2017
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spInsert_Stocks] 
		@StockID as uniqueidentifier
		, @StockSKU as nvarchar(100)
		, @StockDescription as nvarchar(200)
		, @StockPackperCase as money
		, @StockPcsperPack as money
		, @StockWeightinKilosperCase as money
		, @StockWeightinKilosperPack as money
		, @ShelfLifeinDays as int
		, @StockStatus as bit
		, @StockGroupID as uniqueidentifier
		--, @StockGroupCategory as nvarchar(50)
		, @CustomerID as nvarchar(50)
		, @CompanyID as uniqueidentifier
AS


--SET @StockGroupID = (SELECT TOP 1 StockGroupID FROM tblStockGroup WHERE StockGroupCategory=@StockGroupCategory)



IF NOT EXISTS(SELECT StockID FROM tblStock WHERE StockID=@StockID OR StockSKU=@StockSKU)

BEGIN
	INSERT INTO tblStock
	(
		StockSKU
		, StockDescription
		, StockPackperCase
		, StockPcsperPack
		, StockWeightinKilosperCase
		, StockWeightinKilosperPack
		, ShelfLifeinDays
		, StockStatus
		, StockGroupID
		, CustomerID
		, CompanyID
	)
	VALUES
	(
		@StockSKU
		, @StockDescription
		, @StockPackperCase
		, @StockPcsperPack
		, @StockWeightinKilosperCase
		, @StockWeightinKilosperPack
		, @ShelfLifeinDays
		, 1
		, @StockGroupID
		, @CustomerID
		, @CompanyID
	)
END
IF EXISTS(SELECT StockID FROM tblStock WHERE StockID =@StockID )
BEGIN
	UPDATE tblStock
	SET
	StockSKU = @StockSKU
		, StockDescription = @StockDescription
		, StockPackperCase = @StockPackperCase
		, StockPcsperPack = @StockPcsperPack
		, StockWeightinKilosperCase = @StockWeightinKilosperCase
		, StockWeightinKilosperPack = @StockWeightinKilosperPack
		, ShelfLifeinDays = @ShelfLifeinDays
		, StockStatus = @StockStatus
		, StockGroupID = @StockGroupID
		, CustomerID = @CustomerID
		, CompanyID = @CompanyID
	WHERE StockID = @StockID
END
