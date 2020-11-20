USE [CSISControl]
GO

/****** Object: View [dbo].[vw_StocktoStockGrouptoCustomerandCompany] Script Date: 11/20/2020 10:45:53 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







ALTER VIEW [dbo].[vw_StocktoStockGrouptoCustomerandCompany]
AS
SELECT st.StockID,
       st.StockSKU,
       st.StockDescription,
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
       st.CompanyID,
       co.CompanyName,
       co.CompanyInitial,
       co.CompanyAddress
FROM tblStock st
    LEFT JOIN tblStockGroup sg
        ON st.StockGroupID = sg.StockGroupID
    LEFT JOIN tblCustomer cs
        ON st.CustomerID = cs.CustomerID
    LEFT JOIN tblCompany co
        ON st.CompanyID = co.CompanyID;
