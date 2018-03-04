with duble_org as(
SELECT  COUNT(*) as count_org
      ,[��������]
	  , min([ID]) as min_id_org
  FROM [������_Main].[dbo].[�����������] group by �������� 
  HAVING COUNT(*) > 1
)

	SELECT  
			org.ID
			, min_id_org
	FROM duble_org db
		join [dbo].[�����������] org on db.��������=org.��������--���� id ����������� �� �� �������� �� duble_org
	where org.ID!=min_id_org
	order by org.��������
   ;


with duble_org as(
SELECT  COUNT(*) as count_org
      ,[��������]
	  , min([ID]) as min_id_org
  FROM [dbo].[�����������] group by �������� 
  HAVING COUNT(*) > 1
)
   merge into [dbo].[�����������] org
   using (
	SELECT  
			org.ID
			, min_id_org
	FROM duble_org db
		join [dbo].[�����������] org on db.��������=org.��������--���� id ����������� �� �� �������� �� duble_org
	where org.ID!=min_id_org
		) sr
   on (org.ID=sr.ID)
   when MATCHED  
   then delete 
  ;