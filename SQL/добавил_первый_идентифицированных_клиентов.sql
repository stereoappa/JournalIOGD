/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [ID]
      ,[ClientName]
      ,[Org_ID]
      ,[FID_DOCTYPE]
      ,[REQUISITES]
      ,[SCAN_LINK]
  FROM [Журнал_Main].[dbo].[Клиенты]

  update Клиенты SET FID_DOCTYPE = 1, 
  REQUISITES = '1805 810013', 
  SCAN_LINK = '\\UNIT-G\Docs\UaigUpdateApss\Scans\SCAN_20170331_115016277.jpg'
  WHERE ID = 3946

  update Клиенты SET FID_DOCTYPE = 1, 
  REQUISITES = '1809 398670', 
  SCAN_LINK = '\\UNIT-G\Docs\UaigUpdateApss\Scans\SCAN_20170331_110227328.jpg'
  WHERE ID = 2962

  update Клиенты SET FID_DOCTYPE = 1, 
  REQUISITES = '1816 234959', 
  SCAN_LINK = '\\UNIT-G\Docs\UaigUpdateApss\Scans\SCAN_20170330_164537420.jpg'
  WHERE ID = 3945

  update Клиенты SET FID_DOCTYPE = 1, 
  REQUISITES = '1812 781543', 
  SCAN_LINK = '\\UNIT-G\Docs\UaigUpdateApss\Scans\SCAN_20170330_163522638.jpg'
  WHERE ID = 3944

  update Клиенты SET FID_DOCTYPE = 1, 
  REQUISITES = '1803 183954', 
  SCAN_LINK = '\\UNIT-G\Docs\UaigUpdateApss\Scans\SCAN_20170330_153220833.jpg'
  WHERE ID = 3943

  update Клиенты SET FID_DOCTYPE = 1, 
  REQUISITES = '1808 236696', 
  SCAN_LINK = '\\UNIT-G\Docs\UaigUpdateApss\Scans\SCAN_20170330_152605150.jpg'
  WHERE ID = 3848

   update Клиенты SET FID_DOCTYPE = 1, 
  REQUISITES = '1808 236696', 
  SCAN_LINK = '\\UNIT-G\Docs\UaigUpdateApss\Scans\SCAN_20170330_152605150.jpg'
  WHERE ID = 3848

  update Клиенты SET FID_DOCTYPE = 1, 
  REQUISITES = '1803 824872', 
  SCAN_LINK = '\\UNIT-G\Docs\UaigUpdateApss\Scans\SCAN_20170330_151732532.jpg'
  WHERE ID = 1012

  update Клиенты SET FID_DOCTYPE = 1, 
  REQUISITES = '1803 146441', 
  SCAN_LINK = '\\UNIT-G\Docs\UaigUpdateApss\Scans\SCAN_20170330_150558959.jpg'
  WHERE ID = 3942

  update Клиенты SET FID_DOCTYPE = 1, 
  REQUISITES = '1803 186339', 
  SCAN_LINK = '\\UNIT-G\Docs\UaigUpdateApss\Scans\SCAN_20170328_12420201.jpg'
  WHERE ID = 3938

  update Клиенты SET FID_DOCTYPE = 1, 
  REQUISITES = '1806 953138', 
  SCAN_LINK = '\\UNIT-G\Docs\UaigUpdateApss\Scans\SCAN_20170327_154559788.jpg'
  WHERE ID = 3937

  update Клиенты SET FID_DOCTYPE = 1, 
  REQUISITES = '1805 811407', 
  SCAN_LINK = '\\UNIT-G\Docs\UaigUpdateApss\Scans\SCAN_20170327_141201846.jpg'
  WHERE ID = 3936

 select * from клиенты where REQUISITES is not null