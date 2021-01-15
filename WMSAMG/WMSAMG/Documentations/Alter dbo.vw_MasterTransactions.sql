USE [CSIS2017]
GO

/****** Object: View [dbo].[vw_MasterTransactions] Script Date: 01/09/2021 1:46:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO










ALTER VIEW [dbo].[vw_MasterTransactions]

AS
SELECT	 m.RefCode
      ,m.ReferenceNo
      ,m.CustomerID
	  ,cu.CustomerName
      ,m.PayTypeInitial
      ,m.StockID
	  ,st.StockDescription
      ,m.StockSKU
      ,m.StockGroupID
      ,m.StockPcsperPack
      --,m.StockPackperCase
      ,m.Qty
      ,m.ActualWeight
      ,m.UOM
	  ,n.Signed
      ,m.ProductionDate
      --,m.StockWeightinKilosperPack
      --,m.StockWeightinKilosperCase
      ,m.PalletNo
      ,m.CompanyID
      ,m.StorageLocationID
	  ,s.StorageLocationName
	  ,s.StorageName
      ,m.StorageID
      ,m.StorageTypeID
      ,m.TransactionDate
      ,m.LocationID
      ,m.Nature
      ,m.Source
      ,m.Remarks
      ,m.ApprovedBy
      ,m.EmployeeID
      ,m.EmployeeDate
	  ,c.CompanyInitial
	  ,l.LocationInitial
      ,m.isSaved
FROM tblMasterTransaction m
OUTER APPLY NATURE_FIRSTONLY(m.Nature) n
OUTER APPLY STORAGELOCATION_FIRSTONLY(m.StorageLocationID) s
LEFT OUTER JOIN CSISControl.dbo.tblCompany c ON m.CompanyID=c.CompanyID
LEFT OUTER JOIN CSISControl.dbo.vw_StocktoStockGrouptoCustomerandCompany st ON m.StockID = st.StockID 
LEFT OUTER JOIN CSISControl.dbo.vw_Location l ON m.LocationID=l.LocationID 
LEFT OUTER JOIN CSISControl.dbo.vw_CustomertoCompanyandLocation cu ON m.CustomerID=cu.CustomerID
