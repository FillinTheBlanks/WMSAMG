USE [CSIS2017]
GO

/****** Object: View [dbo].[vw_StockWithdrawalDetail] Script Date: 12/25/2020 12:47:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







ALTER VIEW [dbo].[vw_StockWithdrawalDetail]

AS
SELECT	 r.ReferenceCode
		  ,r.SWCode
		  ,SUBSTRING(r.SWCode,LEN(l.LocationInitial)+LEN(r.Nature)+1,LEN(r.SWCode)) SWNumber
		  ,r.RRCode
		  ,r.CustomerID
		  ,r.PayTypeInitial
		  ,cu.CustomerName
		  ,r.StockID
		  ,s.StockDescription
		  ,r.StockSKU
		  ,r.StockGroupID
		  --,r.StockPcsperPack
		  --,r.StockPackperCase
		  ,r.Qty
		  ,r.ActualWeight
		  ,r.UOM
		  ,r.ProductionDate
		  ,r.Remarks
		  --,r.StockWeightinKilosperPack
		  --,r.StockWeightinKilosperCase
		  ,r.PalletNo
		  ,r.StorageLocationID
		  ,st.StorageLocationName 
		  ,st.StorageName
		  ,r.StorageID
		  ,r.StorageTypeID
		  ,r.TransactionDate
		  ,r.StartTime
		  ,r.EndTime
		  ,r.Nature
		  ,r.[Source]
		  ,r.EmployeeID
		  ,e2.FullName Encoder
		  ,r.EmployeeDate
		  ,r.ApprovedBy
		  ,e1.FullName ApproverName
		  ,r.Requestor
		  ,p1.FullName RequestorName
		  ,r.Approver
		  ,p2.FullName PersonnelInCharge
		  ,r.isSaved
		  ,r.CompanyID
		  ,c.CompanyInitial
		  ,r.LocationID
		  ,l.LocationInitial
		  ,r.StockPcsperPack
FROM tblStockWithdrawalDetail r
LEFT OUTER JOIN CSISControl.dbo.tblCompany c ON r.CompanyID=c.CompanyID
LEFT OUTER JOIN CSISControl.dbo.tblStock s ON r.StockID = s.StockID 
LEFT OUTER JOIN CSISControl.dbo.tblLocation l ON r.LocationID=l.LocationID 
LEFT OUTER JOIN CSISControl.dbo.tblCustomer cu ON r.CustomerID=cu.CustomerID
OUTER APPLY STORAGELOCATION_FIRSTONLY(r.StorageLocationID) st
LEFT OUTER JOIN CSISControl.dbo.vw_EmployeetoDepartmentandCompany e1
        ON r.ApprovedBy = e1.EmployeeID
    LEFT OUTER JOIN CSISControl.dbo.vw_EmployeetoDepartmentandCompany e2
        ON r.EmployeeID = e2.EmployeeID
		 LEFT OUTER JOIN CSISControl.dbo.vw_RequestorApprover p1
        ON r.Requestor = p1.IDNo
		 LEFT OUTER JOIN CSISControl.dbo.vw_RequestorApprover p2
        ON r.Approver = p2.IDNo
