USE [CSIS2017]
GO

/****** Object: SqlProcedure [dbo].[spInsert_StockWithdrawalDetail] Script Date: 12/25/2020 12:50:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		kevin llupar
-- Create date: 06/06/2017
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spInsert_StockWithdrawalDetail] 
	@ReferenceCode as uniqueidentifier,
	@SWCode as nvarchar(50),
	@RRCode as nvarchar(50),
	@CustomerID as nvarchar(50),
	@PayTypeInitial as nvarchar(5),
	@StockID as uniqueidentifier,
	@StockSKU as nvarchar(100),
	@StockGroupID as uniqueidentifier,
	@StockPcsperPack as money,
	--@StockPackperCase as money,
	@Qty as money,
	@ActualWeight as decimal(18,4),
	@UOM as nvarchar(3),
	@ProductionDate as datetime,
	--@StockWeightinKilosperPack as money,
	--@StockWeightinKilosperCase as money,
	@PalletNo as nvarchar(10),
	@CompanyID as uniqueidentifier,
	@StorageLocationID as uniqueidentifier,
	@StorageID as uniqueidentifier,
	@StorageTypeID as nvarchar(50),
	@TransactionDate as datetime,
	@StartTime as datetime,
	@EndTime as datetime,
	@LocationID as uniqueidentifier,
	@Nature as nvarchar(10) ,
	@Source as nvarchar(10),
	@Remarks as nvarchar(500),
	@ApprovedBy as uniqueidentifier,
	@Requestor as uniqueidentifier,
	@Approver as uniqueidentifier,
	@EmployeeID as uniqueidentifier,
	@isSaved as bit
AS

SET @Qty = CASE WHEN (SELECT Qty FROM vw_ActualInventory WHERE ReferenceCode=@ReferenceCode AND RRCode=@RRCode AND StockID=@StockID AND StorageLocationID=@StorageLocationID)<@Qty
			THEN (SELECT Qty FROM vw_ActualInventory WHERE ReferenceCode=@ReferenceCode AND RRCode=@RRCode AND StockID=@StockID AND StorageLocationID=@StorageLocationID)
			ELSE @Qty END

SET @ActualWeight = CASE WHEN (SELECT ActualWeight FROM vw_ActualInventory WHERE ReferenceCode=@ReferenceCode AND RRCode=@RRCode AND StockID=@StockID AND StorageLocationID=@StorageLocationID)<@ActualWeight
			THEN (SELECT ActualWeight FROM vw_ActualInventory WHERE ReferenceCode=@ReferenceCode AND RRCode=@RRCode AND StockID=@StockID AND StorageLocationID=@StorageLocationID)
			ELSE @ActualWeight END

IF NOT EXISTS(SELECT ReferenceCode FROM tblStockWithdrawalDetail WHERE ReferenceCode=@ReferenceCode AND SWCode = @SWCode)

BEGIN
	--Insert Receiving Details
	INSERT INTO tblStockWithdrawalDetail
	(
		 SWCode
		  ,RRCode
		  ,CustomerID
		  ,PayTypeInitial
		  ,StockID
		  ,StockSKU
		  ,StockGroupID
		  ,StockPcsperPack
		  --,StockPackperCase
		  ,Qty
		  ,ActualWeight
		  ,UOM
		  ,ProductionDate
		  --,StockWeightinKilosperPack
		  --,StockWeightinKilosperCase
		  ,PalletNo
		  ,StorageLocationID
		  ,StorageID
		  ,StorageTypeID
		  ,TransactionDate
		  ,StartTime
		  ,EndTime
		  ,Nature
		  ,[Source]
		  ,Remarks
		  ,EmployeeID
		  ,EmployeeDate
		  ,ApprovedBy
		  ,Requestor
		  ,Approver
		  ,isSaved
		  ,CompanyID
		  ,LocationID
	)
	VALUES
	(
	@SWCode,
	@RRCode,
	@CustomerID,
	@PayTypeInitial,
	@StockID,
	@StockSKU,
	@StockGroupID,
	@StockPcsperPack,
	--@StockPackperCase,
	@Qty,
	@ActualWeight,
	@UOM,
	@ProductionDate,
	--@StockWeightinKilosperPack,
	--@StockWeightinKilosperCase,
	@PalletNo,
	@StorageLocationID,
	@StorageID,
	@StorageTypeID,
	GETDATE(),
	@StartTime,
	@EndTime,
	@Nature,
	@Source,
	@Remarks,
	@EmployeeID,
	GETDATE(),
	@ApprovedBy,
	@Requestor,
	@Approver,
	@isSaved,
	@CompanyID,
	@LocationID
	)
	--Insert Master Transaction
	INSERT INTO tblMasterTransaction
	(
		 ReferenceNo
		  ,CustomerID
		  ,PayTypeInitial
		  ,StockID
		  ,StockSKU
		  ,StockGroupID
		  ,StockPcsperPack
		  --,StockPackperCase
		  ,Qty
		  ,ActualWeight
		  ,UOM
		  ,ProductionDate
		  --,StockWeightinKilosperPack
		  --,StockWeightinKilosperCase
		  ,PalletNo
		  ,StorageLocationID
		  ,StorageID
		  ,StorageTypeID
		  ,TransactionDate
		  ,Nature
		  ,[Source]
		  ,Remarks
		  ,EmployeeID
		  ,EmployeeDate
		  ,ApprovedBy
		  ,isSaved
		  ,CompanyID
		  ,LocationID
	)
	VALUES
	(
	@SWCode,
	@CustomerID,
	@PayTypeInitial,
	@StockID,
	@StockSKU,
	@StockGroupID,
	@StockPcsperPack,
	--@StockPackperCase,
	@Qty,
	@ActualWeight,
	@UOM,
	@ProductionDate,
	--@StockWeightinKilosperPack,
	--@StockWeightinKilosperCase,
	@PalletNo,
	@StorageLocationID,
	@StorageID,
	@StorageTypeID,
	GETDATE(),
	@Nature,
	@Source,
	@Remarks,
	@EmployeeID,
	GETDATE(),
	@ApprovedBy,
	@isSaved,
	@CompanyID,
	@LocationID
	)
END
ELSE
BEGIN
	--update receiving details
	UPDATE tblStockWithdrawalDetail
	SET
		  SWCode=@SWCode
		  ,RRCode=@RRCode
		  ,StockID=@StockID
		  ,StockSKU=@StockSKU
		  ,StockGroupID=@StockGroupID
		  --,StockPcsperPack=@StockPcsperPack
		  --,StockPackperCase=@StockPackperCase
		  ,Qty=@Qty
		  ,ActualWeight=@ActualWeight
		  ,UOM=@UOM
		  ,ProductionDate=@ProductionDate
		  --,StockWeightinKilosperPack=@StockWeightinKilosperPack
		  --,StockWeightinKilosperCase=@StockWeightinKilosperCase
		  ,PalletNo=@PalletNo
		  ,StorageLocationID=@StorageLocationID
		  ,StorageID=@StorageID
		  ,StorageTypeID=@StorageTypeID
		  ,TransactionDate=@TransactionDate
		  ,StartTime=@StartTime
		  ,EndTime=@EndTime
		  ,Remarks=@Remarks
		  ,ApprovedBy=@ApprovedBy
		  ,Requestor=@Requestor
		  ,Approver=@Approver
		  ,isSaved=@isSaved
	WHERE ReferenceCode=@ReferenceCode AND StockID=@StockID
	
	--update master transaction
	UPDATE tblMasterTransaction
	SET
		ReferenceNo=@SWCode
		  ,StockID=@StockID
		  ,StockSKU=@StockSKU
		  ,StockGroupID=@StockGroupID
		  --,StockPcsperPack=@StockPcsperPack
		  --,StockPackperCase=@StockPackperCase
		  ,Qty=@Qty
		  ,ActualWeight=@ActualWeight
		  ,UOM=@UOM
		  ,ProductionDate=@ProductionDate
		  --,StockWeightinKilosperPack=@StockWeightinKilosperPack
		  --,StockWeightinKilosperCase=@StockWeightinKilosperCase
		  ,PalletNo=@PalletNo
		  ,StorageLocationID=@StorageLocationID
		  ,StorageID=@StorageID
		  ,StorageTypeID=@StorageTypeID
		  ,TransactionDate=@TransactionDate
		  ,Remarks=@Remarks
		  ,ApprovedBy=@ApprovedBy
		  ,isSaved=@isSaved
	WHERE ReferenceNo=@SWCode AND StockID=@StockID
END

--exec spDelete_ReceivingDetail @RRCode,@CustomerID,@PayTypeInitial,@StockID,@Qty,@ActualWeight,@PalletNo,@LocationID
