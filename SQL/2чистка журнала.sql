/****** Script for SelectTopNRows command from SSMS  ******/
--представление duble_org, в котором дублированные организации (только названия)
with duble_org as(
SELECT  COUNT(*) as count_org
      ,[Название]
	  , min([ID]) as min_id_org
  FROM [Журнал_Main].[dbo].[Организации] group by Название 
  HAVING COUNT(*) > 1
)

  SELECT  
			*
  FROM duble_org db
		join [dbo].[Организации] org on db.Название=org.Название--ищем id организаций по их названию из duble_org
		join [dbo].[Журнал] jr on jr.[Organ_ID]=org.ID
 where org.ID!=min_id_org
 order by org.Название
   ;

--убираем ссылки в журнале
with duble_org as(
	SELECT  COUNT(*) as count_org
			,[Название]
			, min([ID]) as min_id_org
	FROM [Журнал_Main].[dbo].[Организации] group by Название 
	HAVING COUNT(*) > 1
)
   merge into [dbo].[Журнал] jr
   using (
	SELECT  
			jr.[ID]
			, db.min_id_org
	FROM duble_org db
		join [dbo].[Организации] org on db.Название=org.Название--ищем id организаций по их названию из duble_org
		join [dbo].[Журнал] jr on jr.[Organ_ID]=org.ID
	where org.ID!=min_id_org
		) sr
   on (jr.ID=sr.ID)
   when MATCHED  
   then update 
   SET jr.[Organ_ID] = sr.min_id_org
;


