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
		join [dbo].[Клиенты] ct on ct.[Org_ID]=org.ID
 where org.ID!=min_id_org
 order by org.Название
   ;

--ищем организации, у которых клиент прописан несколько раз на разный id_org, чтобы исключить их в MERGE
select org.Название, cl.[ClientName], count(cl.[ClientName])
from Клиенты  cl
join Организации org on org.ID=cl.Org_ID
group by org.Название, cl.[ClientName]
having count(cl.[ClientName])>1
;


  with duble_org as(
			SELECT  COUNT(*) as count_org
				  ,[Название]
				  , min([ID]) as min_id_org
			  FROM [Журнал_Main].[dbo].[Организации] group by Название 
			  HAVING COUNT(*) > 1
			)
   merge into [dbo].[Клиенты] ct
   using 
   (					SELECT  
						ct.ID
						, db.min_id_org
			  FROM duble_org db
					join [dbo].[Организации] org on db.Название=org.Название and org.Название not in('ООО "Ареон"')--исключаем организации с дублированными клиентами
					join [dbo].[Клиенты] ct on ct.[Org_ID]=org.ID
			 where ct.[Org_ID]!=min_id_org
			   
   ) sr
   on (ct.ID=sr.ID)
   when MATCHED  
   then update 
   SET ct.[Org_ID] = sr.min_id_org
;


--ищем конкретные организации и их клиентов
select *
from Клиенты  cl
join Организации org on org.ID=cl.Org_ID
where org.Название in('ООО "Ареон"')
;
   delete from [Клиенты]
   where id in (3123,1704)
   ;
 update [Клиенты]
   set Org_ID=160
   where Org_ID=310
   ;
     select * from [Клиенты]
   where Org_ID=160 or Org_ID=310
   ;




select org.Название, cl.[ClientName], count(cl.[ClientName])
from Клиенты  cl
join Организации org on org.ID=cl.Org_ID
--where org.Название='ООО "Ареон"'
group by org.Название, cl.[ClientName]
having count(cl.[ClientName])>1
;

--итоговая проверка. должно быть пусто.
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
		join [dbo].[Организации] org on db.Название=org.Название
		join [dbo].[Клиенты] ct on ct.[Org_ID]=org.ID
where org.ID!=min_id_org
 order by org.Название
   ;

  