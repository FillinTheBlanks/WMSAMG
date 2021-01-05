USE [CSIS2017]
GO

/****** Object: View [dbo].[vw_StorageTimeFrameDetail] Script Date: 1/1/2021 11:46:31 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO










ALTER VIEW [dbo].[vw_StorageTimeFrameDetail]

AS

SELECT	 
		f.StorageTimeFrameID
		,f.RefCode
	  ,f.ReferenceNo
      ,f.CustomerID
	  ,rr.CustomerName
      ,f.PayTypeInitial
	  ,rr.StockSKU
	  ,rr.StockPcsperPack
	  ,rr.Qty
	  ,rr.ActualWeight
      ,f.Nature
      ,f.StorageLocationID
	  ,slf.StorageLocationName
      ,f.StorageID
	  ,slf.StorageName
      ,f.StorageTypeID
      ,f.DateTimeFrameFrom
      ,ISNULL(stf.DateTimeFrameFrom,GETDATE()) AS DateTimeFrameTo
      ,f.FixedRate
      ,f.HourlyRate
	  ,ROUND(DATEDIFF("MINUTE",f.DateTimeFrameFrom,ISNULL(stf.DateTimeFrameFrom,GETDATE()))/60,2) TotalHours
	  ,(ROUND(DATEDIFF("MINUTE",f.DateTimeFrameFrom,ISNULL(stf.DateTimeFrameFrom,GETDATE()))/60,2))/24 TotalDays
	  ,(f.FixedRate / 30) FixedRateperDay
	  ,ROUND((ROUND(DATEDIFF("MINUTE",f.DateTimeFrameFrom,ISNULL(stf.DateTimeFrameFrom,GETDATE()))/60,2))/24,1)*(f.FixedRate / 30) FixedRateAmount
	  ,(ROUND(DATEDIFF("MINUTE",f.DateTimeFrameFrom,ISNULL(stf.DateTimeFrameFrom,GETDATE()))/60,2))* (f.HourlyRate * rr.ActualWeight) HourlyRateAmount
FROM tblStorageTimeFrame f
OUTER APPLY STORAGETIMEFRAME_FIRSTONLY(f.RefCode,f.DateTimeFrameFrom) stf
OUTER APPLY dbo.STORAGELOCATION_FIRSTONLY(f.StorageLocationID) slf
LEFT OUTER JOIN vw_ReceivingDetail rr ON rr.ReferenceCode=f.RefCode
