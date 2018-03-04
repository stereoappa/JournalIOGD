/****** Script for SelectTopNRows command from SSMS  ******/
--������������� duble_org, � ������� ������������� ����������� (������ ��������)
with duble_org as(
SELECT  COUNT(*) as count_org
      ,[��������]
	  , min([ID]) as min_id_org
  FROM [������_Main].[dbo].[�����������] group by �������� 
  HAVING COUNT(*) > 1
)

  SELECT  
			*
  FROM duble_org db
		join [dbo].[�����������] org on db.��������=org.��������--���� id ����������� �� �� �������� �� duble_org
		join [dbo].[������] jr on jr.[Organ_ID]=org.ID
 where org.ID!=min_id_org
 order by org.��������
   ;

--������� ������ � �������
with duble_org as(
	SELECT  COUNT(*) as count_org
			,[��������]
			, min([ID]) as min_id_org
	FROM [������_Main].[dbo].[�����������] group by �������� 
	HAVING COUNT(*) > 1
)
   merge into [dbo].[������] jr
   using (
	SELECT  
			jr.[ID]
			, db.min_id_org
	FROM duble_org db
		join [dbo].[�����������] org on db.��������=org.��������--���� id ����������� �� �� �������� �� duble_org
		join [dbo].[������] jr on jr.[Organ_ID]=org.ID
	where org.ID!=min_id_org
		) sr
   on (jr.ID=sr.ID)
   when MATCHED  
   then update 
   SET jr.[Organ_ID] = sr.min_id_org
;


