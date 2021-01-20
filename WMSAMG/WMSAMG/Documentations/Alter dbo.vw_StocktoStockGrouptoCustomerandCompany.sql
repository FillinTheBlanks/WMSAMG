USE [CSISControl]
GO

/****** Object: View [dbo].[vw_StocktoStockGrouptoCustomerandCompany] Script Date: 11/30/2020 9:51:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









ALTER VIEW [dbo].[vw_StocktoStockGrouptoCustomerandCompany]
AS
SELECT st.StockID,
       st.StockSKU,
       st.StockDescription,
       st.DefaultQty,
       st.StockPackperCase,
       st.StockPcsperPack,
       st.StockWeightinKilosperCase,
       st.StockWeightinKilosperPack,
       st.ShelfLifeinDays,
       st.StockStatus,
       st.StockGroupID,
       sg.StockGroupCategory,
       sg.StockGroupSpecie,
       st.CustomerID,
       cs.CustomerName,
       cs.CustomerAddress,
	   cs.PayTypeInitial,
       st.CompanyID,
       cs.CompanyName,
       cs.CompanyInitial,
       cs.CompanyAddress,
	   cs.LocationID,
	   cs.LocationDescription,
	   cs.LocationInitial
FROM tblStock st
    LEFT JOIN tblStockGroup sg
        ON st.StockGroupID = sg.StockGroupID
    LEFT JOIN vw_CustomertoCompanyandLocation cs
        ON st.CustomerID = cs.CustomerID AND st.CompanyID = cs.CompanyID
