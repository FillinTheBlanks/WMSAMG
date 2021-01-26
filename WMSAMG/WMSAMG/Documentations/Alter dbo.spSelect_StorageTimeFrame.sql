USE [CSIS2017]
GO

/****** Object: SqlProcedure [dbo].[spSelect_StorageTimeFrame] Script Date: 01/21/2021 1:41:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		kevin llupar
-- Create date: 06/06/2017
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spSelect_StorageTimeFrame] 
	@RefCode as uniqueidentifier
AS

	SELECT 
		a.StorageTimeFrameID
		,b.ReferenceCode
		,b.RRCode
		,b.CustomerID
		,b.CustomerName
		,b.PayTypeInitial
		,b.Nature
		,a.StorageLocationID
		,a.StorageTypeID
		,a.StorageID
		,b.StorageName
		,b.StorageLocationName
		,a.DateTimeFrameFrom
		,a.DateTimeFrameTo
		,a.FixedRate
		,a.HourlyRate
		,b.Remarks
	FROM vw_ActualInventory b
	LEFT OUTER JOIN tblStorageTimeFrame a ON a.ReferenceNo = b.RRCode AND a.CustomerID = b.CustomerID AND a.StorageID = b.StorageID
	WHERE b.ReferenceCode = @RefCode
