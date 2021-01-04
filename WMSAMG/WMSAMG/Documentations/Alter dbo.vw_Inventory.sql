USE [CSIS2017]
GO

/****** Object: View [dbo].[vw_Inventory] Script Date: 12/24/2020 10:46:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



--select * from vw_Inventory


ALTER VIEW [dbo].[vw_Inventory]

AS
SELECT	r.ReferenceCode
      ,r.RRCode
	  ,r.RRNumber
	  ,r.CustomerID
	  ,r.CustomerName
      ,r.PayTypeInitial
      ,r.StockID
	  ,r.StockDescription
      ,r.StockSKU
      ,r.StockGroupID
      ,ib.Qty
      ,ib.ActualWeight
      ,r.UOM
	  --,MAX(m.Signed) Signed
      ,m.ProductionDate TransactionDate
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
FROM vw_ReceivingDetail r
INNER JOIN vw_MasterTransactions m ON r.CustomerID=m.CustomerID And r.StockID=m.StockID AND r.PalletNo=m.PalletNo
OUTER APPLY DBO.INVENTORYBALANCE(r.CustomerID,r.StockID,r.PalletNo,m.ProductionDate) ib

GROUP BY
	r.ReferenceCode
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
	  ,ib.Qty
      ,ib.ActualWeight
	  --,m.Signed
      ,m.ProductionDate
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