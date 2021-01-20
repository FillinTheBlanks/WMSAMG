

-- =============================================
-- Author:		kevin llupar
-- Create date: 06/06/2017
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spSelect_StocksbyFilter] 
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
		, isnull(DefaultQty,0) DefaultQty
		, isnull(StockPcsperPack,0) StockPcsperPack
		, isnull(StockPackperCase,0) StockPackperCase
		, isnull(StockWeightinKilosperPack,0) StockWeightinKilosperPack
		, isnull(StockWeightinKilosperCase,0) StockWeightinKilosperCase
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
		, PayTypeInitial
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