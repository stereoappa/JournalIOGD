/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [ID]
      ,[Name]
  FROM [Журнал_Main].[dbo].[ТипДокумента]


  update Журнал SET TypeDoc = 2 Where TypeDoc = 4
  select * from Журнал where typeDoc = 4
  DELETE from ТипДокумента where id = 4

  update ТипДокумента set Name = 'Обращение' where id = 2