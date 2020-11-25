USE [CSIS2017]
GO

/****** Object: SqlProcedure [dbo].[spSelect_ReceivingDetailbyFilter] Script Date: 11/25/2020 1:37:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		kevin llupar
-- Create date: 06/06/2017
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spSelect_ReceivingDetailbyFilter] 
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
		 ReferenceCode
		  ,RRCode
		  ,CarrierReferenceCode
		  ,CustomerID
		  ,CustomerName
		  ,PayTypeInitial
		  ,StockID
		  ,StockDescription
		  ,StockSKU
		  ,StockGroupID
		  ,StockGroupCategory
		  ,StockPcsperPack
		  ,StockPackperCase
		  ,Qty
		  ,ActualWeight
		  ,UOM
		  ,ReceivingTime
		  ,EndTime
		  ,StockWeightinKilosperPack
		  ,StockWeightinKilosperCase
		  ,PalletNo
		  ,StorageLocationID
		  ,StorageID
		  ,StorageTypeID
		  ,TransactionDate
		  ,Nature
		  ,[Source]
		  ,Remarks
		  ,EmployeeID
		  ,Encoder
		  ,EmployeeDate
		  ,ApprovedBy
		  ,Approver
		  ,isSaved
		  ,CompanyID
		  ,CompanyName
		  ,LocationID
		  ,LocationInitial
		  ,LocationDescription
		  ,RRNumber
		  ,DateSchedule
		  ,TimeSchedule
	FROM vw_ReceivingDetail WHERE CAST(' + @ColumnName + ' as nvarchar(200)) LIKE ''' + @TextFilter + '%' + '''
	ORDER BY RRNumber DESC

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
