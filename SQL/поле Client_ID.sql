/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [ID]
      ,[TypeDoc]
      ,[Date]
      ,[Memo]
      ,[Organ_ID]
      ,[Client_ID]
      ,[Empl_ID]
      ,[Desc]
      ,[ClientName]
      ,[in_id]
      ,[Print]
      ,[Cost]
      ,[MapCasesCount]
      ,[RequireConfirmAct]
  FROM [Журнал_Main].[dbo].[Журнал]
  go

MERGE INTO Журнал j --Куда будут записаны новые данные
USING (select ID, ClientName, Org_ID from Клиенты) res --откуда берем данные
on (j.Organ_ID = res.Org_ID and j.ClientName = res.ClientName) -- условие совпадения 
WHEN MATCHED THEN 
UPDATE set j.Client_ID = res.ID; 

select j.ID, j.Client_ID, res.ID, j.ClientName, res.ClientName from Журнал j
join Клиенты res on j.Organ_ID = res.Org_ID and j.ClientName = res.ClientName


SELECT Журнал.ID AS Номер, 
ТипДокумента.Name AS Документ, 
Журнал.Date AS Дата,
 Организации.Название As Организация, 
 Сотрудники.Фамилия AS Выдал, 
 Клиенты.ClientName,
  Memo, 
  Info_type.in_type,
   Cost, 
   MapCasesCount, 
   RequireConfirmAct 
   FROM Журнал LEFT JOIN Организации ON Журнал.Organ_ID = Организации.ID
			LEFT JOIN ТипДокумента ON Журнал.TypeDoc = ТипДокумента.ID
				LEFT JOIN Сотрудники ON Журнал.Empl_ID = Сотрудники.ID
				LEFT JOIN Клиенты ON Журнал.Client_ID = Клиенты.ID
					LEFT JOIN Info_type ON Журнал.in_id = Info_type.ID
					ORDER BY Журнал.ID

Select * from Журнал where id = 12223