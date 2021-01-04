USE [CSISControl]
GO

/****** Object: SqlProcedure [dbo].[spSelect_StorageLocationbyLocation] Script Date: 1/4/2021 5:48:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		kevin llupar
-- Create date: 06/06/2017
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spSelect_StorageLocationbyLocation] 
	@LocationID as uniqueidentifier
AS

	SELECT
		StorageLocationID
		, (StorageLocationName + ' - ' + StorageName) StorageLocationName
		, StorageID
		, StorageName
		, StorageTypeID
		, RackCapacity
		, RackNo
		, LevelNo
		, AreaNo
		
	FROM vw_StoragetoLocation WHERE StorageLocationStatus = 1
	AND (LocationID=@LocationID OR LocationID IS NULL)
	order by StorageName,RackNo,LevelNo,AreaNo
