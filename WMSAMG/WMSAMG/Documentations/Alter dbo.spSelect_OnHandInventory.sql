USE [CSIS2017]
GO

/****** Object: SqlProcedure [dbo].[spSelect_OnHandInventory] Script Date: 12/18/2020 3:29:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		kevin llupar
-- Create date: 06/06/2017
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spSelect_OnHandInventory] 
	@CompanyID as uniqueidentifier,
	@LocationID as uniqueidentifier,
	@CustomerID as varchar(100)
AS

	SELECT i.StorageLocationName
	,s.RackName
	,s.LevelNo
	,i.StorageName
	,i.PalletNo
	,i.StockSKU
	,i.StockDescription
	,SUM(i.Qty) TotalQty
	,SUM(i.ActualWeight) TotalActualWeight
	,i.UOM
	,i.CustomerName
	FROM vw_ActualInventory i
	LEFT OUTER JOIN CSISControl.dbo.vw_StoragetoLocation s
	ON i.StorageLocationID = s.StorageLocationID
	WHERE i.CompanyID=@CompanyID
		AND i.LocationID=@LocationID
		AND i.CustomerID LIKE '%'+ @CustomerID +'%'
	GROUP BY
	i.StorageLocationName
	,s.RackName
	,s.LevelNo
	,i.StorageName
	,i.PalletNo
	,i.StockSKU
	,i.StockDescription
	,i.UOM
	,i.CustomerName
	ORDER BY StorageName,StorageLocationName
