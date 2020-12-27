USE [CSIS2017]
GO

/****** Object: SqlProcedure [dbo].[spSelect_StockWithdrawalDetailbyFilter] Script Date: 12/25/2020 12:46:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		kevin llupar
-- Create date: 06/06/2017
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spSelect_StockWithdrawalDetailbyFilter] 
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
		  ,SWCode
		  ,RRCode
		  ,CustomerID
		  ,CustomerName
		  ,PayTypeInitial
		  ,StockID
		  ,StockDescription
		  ,StockSKU
		  ,StockGroupID
		  ,Qty
		  ,ActualWeight
		  ,UOM
		  ,ProductionDate
		  ,PalletNo
		  ,StorageLocationID
		  ,StorageLocationName
		  ,StorageName
		  ,StorageID
		  ,StorageTypeID
		  ,TransactionDate
		  ,StartTime
		  ,EndTime
		  ,Nature
		  ,[Source]
		  ,Remarks
		  ,EmployeeID
		  ,EmployeeDate
		  ,ApprovedBy
		  ,Requestor
		  ,RequestorName
		  ,Approver
		  ,ApproverName
		  ,PersonnelInCharge
		  ,isSaved
		  ,CompanyID
		  ,CompanyInitial
		  ,LocationID
		  ,LocationInitial
		  ,SWNumber
		  ,StockPcsperPack
	FROM vw_StockWithdrawalDetail r WHERE CAST(' + @ColumnName + ' as nvarchar(200)) LIKE ''' + @TextFilter + '%' + '''
	ORDER BY SWCode DESC

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
