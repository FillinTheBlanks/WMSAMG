USE [CSIS2017]
GO

/****** Object:  StoredProcedure [dbo].[spSelect_StorageTicket]    Script Date: 1/1/2021 12:08:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		kevin llupar
-- Create date: 06/06/2017
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spSelect_StorageTicket] 
	@CustomerID as varchar(100),
	@TransactionDate as datetime,
	@StorageID as nvarchar(MAX)
AS

SELECT
	CustomerID
	,CustomerName
	,TransactionDate
	,StorageID
	,StorageName
	,StockSKU
	,StockPcsperPack
	,SUM(Qty) Qty
	,SUM(ActualWeight) ActualWeight
	,Mode

FROM (
SELECT
	st.CustomerID
	,st.CustomerName
	,CAST(st.DateTimeFrameFrom as date) TransactionDate
	,st.StorageID
	,st.StorageName
	,st.StockSKU
	,ISNULL(st.StockPcsperPack,0) StockPcsperPack
	,st.Qty
	,st.ActualWeight
	,'IN' Mode
FROM vw_StorageTimeFrameDetail st

UNION ALL

SELECT
	sw.CustomerID
	,sw.CustomerName
	,CAST(ISNULL(sw.StartTime,sw.TransactionDate) as date) TransactionDate
	,sw.StorageID
	,sw.StorageName
	,sw.StockSKU
	,ISNULL(sw.StockPcsperPack,0) StockPcsperPack
	,sw.Qty
	,sw.ActualWeight
	,'OUT' Mode
FROM vw_StockWithdrawalDetail sw
) tb

WHERE tb.CustomerID LIKE @CustomerID + '%' AND CAST(tb.StorageID as nvarchar(MAX)) LIKE @StorageID + '%'
GROUP BY
	CustomerID
	,CustomerName
	,TransactionDate
	,StorageID
	,StorageName
	,StockSKU
	,StockPcsperPack
	,Mode



GO


