with duble_org as(
SELECT  COUNT(*) as count_org
      ,[Название]
	  , min([ID]) as min_id_org
  FROM [Журнал_Main].[dbo].[Организации] group by Название 
  HAVING COUNT(*) > 1
)

	SELECT  
			org.ID
			, min_id_org
	FROM duble_org db
		join [dbo].[Организации] org on db.Название=org.Название--ищем id организаций по их названию из duble_org
	where org.ID!=min_id_org
	order by org.Название
   ;


with duble_org as(
SELECT  COUNT(*) as count_org
      ,[Название]
	  , min([ID]) as min_id_org
  FROM [dbo].[Организации] group by Название 
  HAVING COUNT(*) > 1
)
   merge into [dbo].[Организации] org
   using (
	SELECT  
			org.ID
			, min_id_org
	FROM duble_org db
		join [dbo].[Организации] org on db.Название=org.Название--ищем id организаций по их названию из duble_org
	where org.ID!=min_id_org
		) sr
   on (org.ID=sr.ID)
   when MATCHED  
   then delete 
  ;