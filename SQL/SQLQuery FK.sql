

  use JournalDBSQL --подключаем базу


  DELETE  FROM Журнал WHERE Журнал.Organ_ID NOT IN (SELECT ID FROM Организации ) 

  ALTER TABLE Журнал --изменяем таблицу: добавляем ограние ВНЕШНИЙ КЛЮЧ (ссылка на внешнюю таблицу организаций)
  ADD CONSTRAINT FK_OrgID 
  FOREIGN KEY (Organ_ID) REFERENCES Организации(ID)
  ON UPDATE CASCADE -- при обновлении родительской таблицы (организации) каскадно обновить дочернюю (журнал)

  ALTER TABLE  Журнал 
DROP CONSTRAINT FK_OrgID ; 


 SELECT Журнал.ID FROM Журнал WHERE Журнал.Organ_ID NOT IN (SELECT ID FROM Организации ) -- вывести ID записи журнала, 
										--у которой номер организации не входит в список организаций (их надо удалить)		


