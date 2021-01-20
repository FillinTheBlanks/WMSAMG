USE [CSIS2017]
GO

/****** Object: View [dbo].[vw_ReceivingDetail] Script Date: 01/20/2021 9:42:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO













CREATE VIEW [dbo].[vw_BlastingIn]

AS
SELECT	 r.ReferenceCode
		  ,r.RRCode
		  ,SUBSTRING(r.RRCode,LEN(l.LocationInitial)+LEN(r.Nature)+1,LEN(r.RRCode)) RRNumber
		  ,r.CarrierReferenceCode
		  ,r.CustomerID
		  ,cu.CustomerName
		  ,r.PayTypeInitial
		  ,r.StockID
		  ,s.StockDescription
		  ,r.StockSKU
		  ,r.Size
		  ,r.StockGroupID
		  ,s.StockGroupCategory
		  ,r.StockPcsperPack
		  ,r.StockPackperCase
		  ,r.Qty
		  ,r.ActualWeight
		  ,r.UOM
		  ,r.ReceivingTime
		  ,r.EndTime
		  ,r.Remarks
		  ,r.StockWeightinKilosperPack
		  ,r.StockWeightinKilosperCase
		  ,r.PalletNo
		  ,st.StorageLocationID
		  ,st.StorageLocationName
		  ,st.StorageName
		  ,st.StorageID
		  ,st.StorageTypeID
		  ,r.TransactionDate
		  ,r.Nature
		  ,r.[Source]
		  ,r.EmployeeID
		  ,e2.FullName Encoder
		  ,r.EmployeeDate
		  ,r.ApprovedBy
		  ,e1.FullName Approver
		  ,r.isSaved
		  ,r.CompanyID
		  ,c.CompanyInitial
		  ,c.CompanyName
		  ,r.LocationID
		  ,l.LocationInitial
		  ,l.LocationDescription
		  ,MAX(st.DateTimeFrameFrom) DateTimeFrameFrom
		  ,sc.DateSchedule
		  ,sc.TimeSchedule
FROM tblReceivingDetail r
LEFT OUTER JOIN CSISControl.dbo.tblCompany c ON r.CompanyID=c.CompanyID
LEFT OUTER JOIN CSISControl.dbo.vw_StocktoStockGrouptoCustomerandCompany s ON r.StockID = s.StockID 
LEFT OUTER JOIN CSISControl.dbo.vw_Location l ON r.LocationID=l.LocationID 
LEFT OUTER JOIN CSISControl.dbo.vw_CustomertoCompanyandLocation cu ON r.CustomerID=cu.CustomerID
   LEFT OUTER JOIN CSISControl.dbo.vw_EmployeetoDepartmentandCompany e1
        ON r.ApprovedBy = e1.EmployeeID
    LEFT OUTER JOIN CSISControl.dbo.vw_EmployeetoDepartmentandCompany e2
        ON r.EmployeeID = e2.EmployeeID
OUTER APPLY LATESTSTORAGEOFITEM_FIRSTONLY(r.ReferenceCode,r.RRCode) st
--LEFT OUTER JOIN vw_StorageTimeFrameDetail st ON r.ReferenceCode = st.RefCode AND r.RRCode=st.ReferenceNo AND r.CustomerID=st.CustomerID
LEFT OUTER JOIN tblScheduleCarrier sc ON r.CarrierReferenceCode = sc.ReferenceCode
WHERE st.DateTimeFrameTo IS NULL OR st.DateTimeFrameFrom <= GETDATE() AND r.isSaved=0
GROUP BY r.ReferenceCode
		  ,r.RRCode
		  ,l.LocationInitial
		  ,r.CarrierReferenceCode
		  ,r.CustomerID
		  ,cu.CustomerName
		  ,r.PayTypeInitial
		  ,r.StockID
		  ,s.StockDescription
		  ,r.StockSKU
		  ,r.Size
		  ,r.StockGroupID
		  ,s.StockGroupCategory
		  ,r.StockPcsperPack
		  ,r.StockPackperCase
		  ,r.Qty
		  ,r.ActualWeight
		  ,r.UOM
		  ,r.ReceivingTime
		  ,r.EndTime
		  ,r.Remarks
		  ,r.StockWeightinKilosperPack
		  ,r.StockWeightinKilosperCase
		  ,r.PalletNo
		  ,st.StorageLocationID
		  ,st.StorageLocationName
		  ,st.StorageName
		  ,st.StorageID
		  ,st.StorageTypeID
		  ,r.TransactionDate
		  ,r.Nature
		  ,r.[Source]
		  ,r.EmployeeID
		  ,e2.FullName
		  ,r.EmployeeDate
		  ,r.ApprovedBy
		  ,e1.FullName
		  ,r.isSaved
		  ,r.CompanyID
		  ,c.CompanyInitial
		  ,c.CompanyName
		  ,r.LocationID
		  ,l.LocationDescription
		  ,sc.DateSchedule
		  ,sc.TimeSchedule
