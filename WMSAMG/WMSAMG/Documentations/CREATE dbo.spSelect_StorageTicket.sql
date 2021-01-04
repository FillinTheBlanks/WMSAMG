USE [CSIS2017]
GO

/****** Object:  StoredProcedure [dbo].[spSelect_OnHandInventory]    Script Date: 1/1/2021 12:08:59 PM ******/
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
	,StockPcsperPack
	,Qty
	,ActualWeight
	,Mode

FROM (
SELECT
	st.CustomerID
	,st.CustomerName
	,st.DateTimeFrameFrom TransactionDate
	,st.StorageID
	,st.StorageName
	,ISNULL(st.StockPcsperPack,0) StockPcsperPack
	,st.Qty
	,st.ActualWeight
	,'IN' Mode
FROM vw_StorageTimeFrameDetail st

UNION ALL

SELECT
	sw.CustomerID
	,sw.CustomerName
	,ISNULL(sw.StartTime,sw.TransactionDate) TransactionDate
	,sw.StorageID
	,sw.StorageName
	,ISNULL(sw.StockPcsperPack,0) StockPcsperPack
	,sw.Qty
	,sw.ActualWeight
	,'OUT' Mode
FROM vw_StockWithdrawalDetail sw
) tb

WHERE tb.CustomerID LIKE @CustomerID + '%' AND CAST(tb.TransactionDate as date) = CAST(@TransactionDate as date) AND CAST(tb.StorageID as nvarchar(MAX)) LIKE @StorageID + '%'

GO


