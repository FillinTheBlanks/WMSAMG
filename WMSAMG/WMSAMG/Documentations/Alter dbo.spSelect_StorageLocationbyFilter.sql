USE [CSISControl]
GO

/****** Object: SqlProcedure [dbo].[spSelect_StorageLocationbyFilter] Script Date: 12/11/2020 3:00:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		kevin llupar
-- Create date: 06/06/2017
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spSelect_StorageLocationbyFilter] 
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
		StorageLocationID
		, StorageLocationName
		, CompanyID
		, CompanyInitial
		, StorageID
		, StorageName
		, SerialNo
		, RackID
		, RackName
		, RackCapacity
		, RackNo
		, LevelNo
		, AreaNo
		, LocationID
		, LocationDescription
		, ApprovedBy
		, Approver
		, EncodedBy
		, Encoder
		, DateEncoded
		, StorageLocationStatus
		,StorageTypeID
		,FixedRate
		,HourlyRate
	FROM vw_StoragetoLocation WHERE CAST(' + @ColumnName + ' as nvarchar(200)) LIKE ''' + @TextFilter + '%' + '''


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
