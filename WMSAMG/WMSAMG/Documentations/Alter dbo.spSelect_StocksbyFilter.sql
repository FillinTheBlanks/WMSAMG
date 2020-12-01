USE [CSISControl]
GO

/****** Object: SqlProcedure [dbo].[spSelect_StocksbyFilter] Script Date: 11/30/2020 9:32:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		kevin llupar
-- Create date: 06/06/2017
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spSelect_StocksbyFilter] 
	@TextFilter as nvarchar(200),
	@ColumnName as nvarchar(100)
AS
Declare @SQLqry4 as nvarchar(4000)

Set @SQLqry4 ='
declare @errpos4 as nvarchar(5)
BEGIN TRY
    BEGIN TRANSACTION
				
				set @errpos4 = ''kpl-pc''

	SELECT
		StockID
		, StockSKU
		, StockDescription
		, StockPcsperPack
		, StockPackperCase
		, StockWeightinKilosperPack
		, StockWeightinKilosperCase
		, ShelfLifeinDays
		, StockGroupID
		, StockGroupCategory
		, StockGroupSpecie
		, CustomerID
		, CustomerName
		, CustomerAddress
		, CompanyID
		, CompanyName
		, CompanyInitial
		, CompanyAddress
		, StockStatus
		, LocationID
		, LocationInitial
	FROM vw_StocktoStockGrouptoCustomerandCompany WHERE CAST(' + @ColumnName + ' as nvarchar(200)) LIKE ''' + @TextFilter + '%' + '''


COMMIT TRAN -- Transaction Success!
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRAN --RollBack in case of Error

    -- you can Raise ERROR with RAISEERROR() Statement including the details of the exception
    RAISERROR(''Error'', 1, 1, @errpos4)
END CATCH'

EXECUTE sp_executesql @SQLqry4
--SELECT @SQLqry4
