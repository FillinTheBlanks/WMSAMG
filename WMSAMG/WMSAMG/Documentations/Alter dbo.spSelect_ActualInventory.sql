USE [CSIS2017]
GO

/****** Object: SqlProcedure [dbo].[spSelect_ActualInventory] Script Date: 12/18/2020 11:59:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		kevin llupar
-- Create date: 06/06/2017
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spSelect_ActualInventory] 
	@CompanyID as uniqueidentifier,
	@LocationID as uniqueidentifier,
	@CustomerID as varchar(100)
AS

	SELECT 
	i.ReferenceCode
	,i.RRCode
	,i.CustomerID
	,i.CustomerName
	,s.RackName
	,s.LevelNo
	,i.StorageTypeID
	,i.StorageName
	,i.StorageLocationName
	,i.PalletNo
	,i.StockID
	,i.StockSKU
	,i.StockDescription
	,i.Qty
	,i.ActualWeight
	,i.UOM
	,i.TransactionDate
	,i.PayTypeInitial
	,i.StockGroupID
	,i.UOM
	,i.CompanyID
	,i.Nature
	,i.StorageID
	,i.StorageLocationID
	FROM vw_ActualInventory i
	LEFT OUTER JOIN CSISControl.dbo.vw_StoragetoLocation s
	ON i.StorageLocationID = s.StorageLocationID
	WHERE i.CompanyID=@CompanyID
		AND i.LocationID=@LocationID
		AND i.CustomerID LIKE '%'+ @CustomerID +'%'
	--GROUP BY
	--i.StorageLocationName
	--,s.RackName
	--,s.LevelNo
	--,i.StorageName
	--,i.PalletNo
	--,i.StockSKU
	--,i.StockDescription
	--,i.UOM
	ORDER BY StorageName,StorageLocationName
