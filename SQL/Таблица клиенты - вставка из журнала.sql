/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 4000 [ID]
      ,[ClientName]
      ,[Org_ID]
  FROM [JournalDBSQL].[dbo].[Клиенты]

  ORDER BY ID

  DELETE FROM Клиенты WHERE Org_ID=33

  TRUNCATE TABLE Клиенты -- Очистить таблицу
  DBCC CHECKIDENT (Клиенты, reseed, 1) -- Сбить счетчик айдентити на 1

  ALTER TABLE Клиенты ADD CONSTRAINT FK_Custom FOREIGN KEY (Org_ID) REFERENCES Организации(ID)

  INSERT INTO Клиенты (ClientName, Org_ID) (SELECT DISTINCT ClientName, Organ_ID FROM Журнал WHERE (Organ_ID IS NOT NULL AND Organ_ID NOT IN (33, '') AND ClientName IS NOT NULL AND ClientName NOT IN ('')))
  INSERT INTO Клиенты (ClientName, Org_ID) VALUES ('Антон' ,'24')
    INSERT INTO Клиенты (ClientName, Org_ID) VALUES ('Антон' ,'25')

  SELECT DISTINCT( ClientName) , Organ_ID FROM Журнал ORDER BY ClientName
  SELECT DISTINCT( ClientName) , Organ_ID FROM Журнал WHERE ((Organ_ID=23) AND (ClientName IS NOT NULL)  )