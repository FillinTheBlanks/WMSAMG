

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
	,Size
	,SUM(Qty) Qty
	,SUM(ActualWeight) ActualWeight
	,Mode
	,Reference
	,Num
FROM (
SELECT
	bi.ReferenceCode
	,bi.CustomerID
	,bi.CustomerName
	,CAST(bi.ReceivingTime as date) TransactionDate
	,bi.StorageID
	,bi.StorageName
	,bi.StockSKU
	,bi.Size
	,bi.Qty
	,bi.ActualWeight
	,'IN' Mode
	,bi.Remarks as Reference
	,DENSE_RANK() OVER (PARTITION BY bi.Remarks ORDER BY bi.ReferenceCode) AS Num
FROM vw_BlastingIn bi

UNION ALL

SELECT
	st.ReferenceCode
	,st.CustomerID
	,st.CustomerName
	,CAST(st.ReceivingTime as date) TransactionDate
	,st.StorageID
	,st.StorageName
	,st.StockSKU
	,st.Size
	,st.Qty
	,st.ActualWeight
	,'OUT' Mode
	,st.Remarks as Reference
	,DENSE_RANK() OVER (PARTITION BY st.Remarks ORDER BY st.ReferenceCode) AS Num
	FROM vw_ReceivingDetail st
--FROM vw_StorageTimeFrameDetail st
) tb

--WHERE tb.CustomerID LIKE @CustomerID + '%' AND CAST(tb.StorageID as nvarchar(MAX)) LIKE @StorageID + '%'
GROUP BY
	CustomerID
	,CustomerName
	,TransactionDate
	,StorageID
	,StorageName
	,StockSKU
	,Size
	,Mode
	,Reference
	,Num

	ORDER BY ActualWeight