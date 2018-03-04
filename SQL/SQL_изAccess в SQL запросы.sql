  use Журнал_Main --подключаем базу


ALTER TABLE Журнал --изменяем таблицу: добавляем ограние ВНЕШНИЙ КЛЮЧ (ссылка на внешнюю таблицу организаций)
  ADD CONSTRAINT FK_OrgID 
  FOREIGN KEY (Organ_ID) REFERENCES Организации(ID)
  ON UPDATE CASCADE -- при обновлении родительской таблицы (организации) каскадно обновить дочернюю (журнал)

  ALTER TABLE Журнал --изменяем таблицу: добавляем ограние ВНЕШНИЙ КЛЮЧ (ссылка на внешнюю таблицу типдокумента)
  ADD CONSTRAINT FK_TypeDocId
  FOREIGN KEY (TypeDoc) REFERENCES ТипДокумента(ID)
  ON UPDATE CASCADE -- при обновлении родительской таблицы (тип док) каскадно обновить дочернюю (журнал)

  SELECT Журнал.ID FROM Журнал WHERE Журнал.Organ_ID NOT IN (SELECT ID FROM Организации ) -- вывести ID записи журнала, 
										--у которой номер организации не входит в список организаций (их надо удалить)		
 
  
  SELECT * FROM Журнал WHERE Журнал.Empl_ID NOT IN (SELECT ID FROM Сотрудники) -- вывести ID записи журнала, 
										--у которой номер организации не входит в список сотрудников (их надо удалить)		

 SELECT * FROM Журнал WHERE Журнал.ID='2415' -- запись с нулевой организацией

 UPDATE Журнал -- сделали частным лицом запись с нулевой организацией
 SET Organ_ID='33'
 WHERE Журнал.ID='2415' 


 -- Таблица клиенты
 CREATE TABLE Клиенты  -- создали таблицу 
 (
 ID int identity(1,1) not null,
 ClientName varchar(100) not null,
 Org_ID int not null
 )

ALTER TABLE  Клиенты		-- составной первичный ключ
ADD CONSTRAINT PK_ClientOrg PRIMARY KEY (ClientName, Org_ID)

 ALTER TABLE Клиенты -- внешний ключ на организацию
 ADD CONSTRAINT FK_Custom FOREIGN KEY (Org_ID) REFERENCES Организации(ID)
 ON DELETE CASCADE 

 ALTER TABLE Клиенты -- удаление внешний ключ на организацию
DROP CONSTRAINT FK_Custom 

 INSERT INTO Клиенты (ClientName, Org_ID) -- копирование из журнала пар клиент - организция
 (SELECT DISTINCT ClientName, Organ_ID FROM Журнал 
 WHERE (Organ_ID IS NOT NULL AND Organ_ID NOT IN (33, '') AND ClientName IS NOT NULL AND ClientName NOT IN ('')))

 DBCC CHECKIDENT (Клиенты, reseed, 1) -- Сбить счетчик айдентити на 1

  TRUNCATE TABLE Клиенты -- Очистить таблицу
  DROP TABLE  Клиенты  -- Удалить таблицу


  --повторяющиеся организации
  select Название  from Организации group by Название having count(Название)>1
  select *  from Организации where Название = 'ООО "Город"'

select *  from Клиенты where ClientName = 'ТЕСТ'

delete  from Клиенты where ClientName = 'ТЕСТ'

--Нужно было добавить частных лиц в Клиенты
TRUNCATE TABLE Клиенты

INSERT INTO Клиенты (ClientName, Org_ID) -- копирование из журнала пар клиент - организция
 (SELECT DISTINCT ClientName, Organ_ID FROM Журнал 
 WHERE (Organ_ID IS NOT NULL AND ClientName IS NOT NULL AND ClientName NOT IN ('')))

 Update Организации SET ОсновнойКлиент = NULL
