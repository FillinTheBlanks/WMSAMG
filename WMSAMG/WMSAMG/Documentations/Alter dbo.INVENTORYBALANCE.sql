USE [CSIS2017]
GO

/****** Object: Table Valued Function [dbo].[INVENTORYBALANCE] Script Date: 01/09/2021 1:45:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER FUNCTION [dbo].[INVENTORYBALANCE]
(	
	@CustomerID	as varchar(100),
	@StockID as uniqueidentifier,
	@PalletNo as varchar(100),
	@ProductionDate as date
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT TOP 1 SUM(m1.Qty * m1.Signed) Qty,
	SUM(m1.ActualWeight * m1.Signed) ActualWeight,
	MAX(m1.ProductionDate) ProductionDate
	  FROM vw_MasterTransactions m1 
	  WHERE m1.CustomerID=@CustomerID 
	  AND m1.StockID=@StockID
	  AND m1.PalletNo=@PalletNo
	  AND m1.ProductionDate<=@ProductionDate AND m1.isSaved=1
	GROUP BY ReferenceNo,StockID,StockPcsperPack
)
