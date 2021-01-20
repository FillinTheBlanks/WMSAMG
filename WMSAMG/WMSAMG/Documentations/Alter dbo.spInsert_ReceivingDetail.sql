USE [CSIS2017]
GO

/****** Object: SqlProcedure [dbo].[spInsert_ReceivingDetail] Script Date: 01/20/2021 10:42:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		kevin llupar
-- Create date: 06/06/2017
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spInsert_ReceivingDetail] 
	@ReferenceCode as nvarchar(100),
	@RRCode as nvarchar(50),
	@CarrierReferenceCode as nvarchar(100),
	@CustomerID as nvarchar(50),
	@PayTypeInitial as nvarchar(10),
	@StockID as nvarchar(100),
	@StockSKU as nvarchar(100),
	@Size as nvarchar(100),
	@StockGroupID as nvarchar(100),
	@StockPcsperPack as money,
	@StockPackperCase as money,
	@Qty as money,
	@ActualWeight as decimal(18,4),
	@UOM as nvarchar(3),
	@ReceivingTime as datetime,
	@EndTime as datetime,
	@StockWeightinKilosperPack as money,
	@StockWeightinKilosperCase as money,
	@PalletNo as nvarchar(10),
	@CompanyID as nvarchar(100),
	--@StorageLocationID as uniqueidentifier,
	--@StorageID as uniqueidentifier,
	--@StorageTypeID as nvarchar(50),
	@TransactionDate as datetime,
	@LocationID as nvarchar(100),
	@Nature as nvarchar(10) ,
	@Source as nvarchar(10),
	@Remarks as nvarchar(500),
	@ApprovedBy as nvarchar(100),
	@EmployeeID as nvarchar(100),
	@isSaved as bit
AS

IF NOT EXISTS(SELECT ReferenceCode FROM tblReceivingDetail WHERE ReferenceCode=@ReferenceCode AND RRCode = @RRCode)

BEGIN
	--Insert Receiving Details
	INSERT INTO tblReceivingDetail
	(
		 RRCode
		  ,CarrierReferenceCode
		  ,CustomerID
		  ,PayTypeInitial
		  ,StockID
		  ,StockSKU
		  ,Size
		  ,StockGroupID
		  ,StockPcsperPack
		  ,StockPackperCase
		  ,Qty
		  ,ActualWeight
		  ,UOM
		  ,ReceivingTime
		  ,EndTime
		  ,StockWeightinKilosperPack
		  ,StockWeightinKilosperCase
		  ,PalletNo
		  --,StorageLocationID
		  --,StorageID
		  --,StorageTypeID
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
	@RRCode,
	@CarrierReferenceCode,
	@CustomerID,
	@PayTypeInitial,
	@StockID,
	@StockSKU,
	@Size,
	@StockGroupID,
	@StockPcsperPack,
	@StockPackperCase,
	@Qty,
	@ActualWeight,
	@UOM,
	@ReceivingTime,
	@EndTime,
	@StockWeightinKilosperPack,
	@StockWeightinKilosperCase,
	@PalletNo,
	--@StorageLocationID,
	--@StorageID,
	--@StorageTypeID,
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
	--Insert Master Transaction
	INSERT INTO tblMasterTransaction
	(
		 ReferenceNo
		  ,CustomerID
		  ,PayTypeInitial
		  ,StockID
		  ,StockSKU
		  ,Size
		  ,StockGroupID
		  ,StockPcsperPack
		  ,StockPackperCase
		  ,Qty
		  ,ActualWeight
		  ,UOM
		  ,ProductionDate
		  ,StockWeightinKilosperPack
		  ,StockWeightinKilosperCase
		  ,PalletNo
		  --,StorageLocationID
		  --,StorageID
		  --,StorageTypeID
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
	@RRCode,
	@CustomerID,
	@PayTypeInitial,
	@StockID,
	@StockSKU,
	@Size,
	@StockGroupID,
	@StockPcsperPack,
	@StockPackperCase,
	@Qty,
	@ActualWeight,
	@UOM,
	@ReceivingTime,
	@StockWeightinKilosperPack,
	@StockWeightinKilosperCase,
	@PalletNo,
	--@StorageLocationID,
	--@StorageID,
	--@StorageTypeID,
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
	UPDATE tblReceivingDetail
	SET
		RRCode=@RRCode
		  --,CarrierReferenceCode=@CarrierReferenceCode
		  --,CustomerID=@CustomerID
		  ,PayTypeInitial=@PayTypeInitial
		  ,StockID=@StockID
		  ,StockSKU=@StockSKU
		  ,StockGroupID=@StockGroupID
		  ,StockPcsperPack=@StockPcsperPack
		  ,StockPackperCase=@StockPackperCase
		  ,Qty=@Qty
		  ,ActualWeight=@ActualWeight
		  ,UOM=@UOM
		  ,ReceivingTime=@ReceivingTime
		  ,EndTime=@EndTime
		  ,StockWeightinKilosperPack=@StockWeightinKilosperPack
		  ,StockWeightinKilosperCase=@StockWeightinKilosperCase
		  ,PalletNo=@PalletNo
		  --,StorageLocationID=@StorageLocationID
		  --,StorageID=@StorageID
		  --,StorageTypeID=@StorageTypeID
		  ,TransactionDate=@TransactionDate
		  --,Nature=@Nature
		  --,[Source]=@Source
		  ,Remarks=@Remarks
		  ,ApprovedBy=@ApprovedBy
		  ,isSaved=@isSaved
		  --,CompanyID=@CompanyID
		  --,LocationID=@LocationID
	WHERE ReferenceCode=@ReferenceCode
	
	--update master transaction
	UPDATE tblMasterTransaction
	SET
		ReferenceNo=@RRCode
		  --,CustomerID=@CustomerID
		  ,PayTypeInitial=@PayTypeInitial
		  ,StockID=@StockID
		  ,StockSKU=@StockSKU
		  ,StockGroupID=@StockGroupID
		  ,StockPcsperPack=@StockPcsperPack
		  ,StockPackperCase=@StockPackperCase
		  ,Qty=@Qty
		  ,ActualWeight=@ActualWeight
		  ,UOM=@UOM
		  ,ProductionDate=@ReceivingTime
		  ,StockWeightinKilosperPack=@StockWeightinKilosperPack
		  ,StockWeightinKilosperCase=@StockWeightinKilosperCase
		  ,PalletNo=@PalletNo
		  --,StorageLocationID=@StorageLocationID
		  --,StorageID=@StorageID
		  --,StorageTypeID=@StorageTypeID
		  ,TransactionDate=@TransactionDate
		  --,Nature=@Nature
		  --,[Source]=@Source
		  ,Remarks=@Remarks
		  ,ApprovedBy=@ApprovedBy
		  ,isSaved=@isSaved
		  --,CompanyID=@CompanyID
		  --,LocationID=@LocationID
	WHERE ReferenceNo=@RRCode  AND StockID=@StockID
END

SELECT EquipmentID,EquipmentRate,OvertimeRate INTO #Temp FROM CSISControl.dbo.vw_EquipmenttoCategory
WHERE AutoAdd=1

DECLARE @EquipmentID as uniqueidentifier,
		@EquipmentRate as money,
		@OvertimeRate as money

WHILE EXISTS (SELECT * FROM #Temp)
BEGIN 
SELECT TOP 1
           @EquipmentID = EquipmentID,
           @EquipmentRate = EquipmentRate,
		   @OvertimeRate = OvertimeRate
    FROM #Temp;

	IF NOT EXISTS(SELECT * FROM tblEquipmentCharges WHERE ReferenceNo=@ReferenceCode AND EquipmentID=@EquipmentID)
		BEGIN
			exec spInsert_EquipmentCharges NULL,@RRCode,@RRCode,@EquipmentID,1,@EquipmentRate,@OvertimeRate,@TransactionDate,@EmployeeID,@LocationID
		END

	DELETE FROM #Temp
    WHERE EquipmentID = @EquipmentID;
END
