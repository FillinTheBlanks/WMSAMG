USE [CSIS2017]
GO

/****** Object: View [dbo].[vw_ActualInventory] Script Date: 12/24/2020 10:45:50 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






--select * from vw_Inventory


ALTER VIEW [dbo].[vw_ActualInventory]

AS
SELECT	distinct r.ReferenceCode
      ,r.RRCode
	  ,r.RRNumber
	  ,r.CustomerID
	  ,r.CustomerName
      ,r.PayTypeInitial
      ,r.StockID
	  ,r.StockDescription
      ,r.StockSKU
      ,r.StockGroupID
      ,MIN(r.Qty) Qty
      ,MIN(r.ActualWeight) ActualWeight
      ,r.UOM
	  --,MAX(m.Signed) Signed
      ,MAX(r.TransactionDate) TransactionDate
      ,r.PalletNo
      ,r.CompanyID
	  ,r.CompanyInitial
      ,r.StorageLocationID
      ,r.StorageLocationName
	  ,r.StorageName
	  ,r.StorageID
      ,r.StorageTypeID
      ,r.LocationID
	  ,r.LocationInitial
      ,r.Nature
      ,r.[Source]
      ,r.Remarks
	  ,r.StockPcsperPack
FROM vw_Inventory r 
where r.ActualWeight > 0
group by r.ReferenceCode
      ,r.RRCode
	  ,r.RRNumber
	  ,r.CustomerID
	  ,r.CustomerName
      ,r.PayTypeInitial
      ,r.StockID
	  ,r.StockDescription
      ,r.StockSKU
      ,r.StockGroupID
      ,r.UOM
	  ,r.PalletNo
      ,r.CompanyID
	  ,r.CompanyInitial
      ,r.StorageLocationID
      ,r.StorageLocationName
	  ,r.StorageName
	  ,r.StorageID
      ,r.StorageTypeID
      ,r.LocationID
	  ,r.LocationInitial
      ,r.Nature
      ,r.[Source]
      ,r.Remarks
	  ,r.StockPcsperPack