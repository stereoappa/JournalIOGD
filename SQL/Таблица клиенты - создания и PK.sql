/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [ID]
      ,[ClientName]
      ,[Org_ID]
  FROM [JournalDBSQL].[dbo].[Клиенты]

  INSERT INTO Клиенты  (ClientName, Org_ID) Values ('Валюныч',    (SELECT Организации.ID FROM Организации WHERE Организации.Название='Частное лицо' )  )

  SELECT Организации.ID FROM Организации WHERE Организации.Название='ООО "Межа"'

  INSERT INTO Клиенты  ( ClientName, Org_ID) Values ( 'Валюныч', '3')

  TRUNCATE TABLE Клиенты -- Очистить таблицу
  DBCC CHECKIDENT (Клиенты, reseed, 1) -- Сбить счетчик айдентити на 1

  DELETE FROM Клиенты WHERE ID = 9;

ALTER TABLE  Клиенты
ADD CONSTRAINT PK_ClientOrg PRIMARY KEY (ClientName, Org_ID)