declare @id int=15372
		,@seed int = 34--������ ����� � ��������� �����
		,@in_date date='2017-03-14 22:06:48.000'
		;

SELECT  
  j.ID
, Date
, org.��������
, TICKET_NUMBER
, TICKET_DATE
, j.Cost 
, ROW_NUMBER() over (order by d.ID_DOCUMENT)--����������� ��������� �����, ���� ����������� �� d.ID_DOCUMENT
, ROW_NUMBER() over (order by d.ID_DOCUMENT) + @seed-1--��������� ����� �� � 1, � � ���������� � ���������� �����
from ������ j 
	join DOCUMENTS d on j.ID = d.FID_JOURNAL 
	join ����������� org on org.ID=j.Organ_ID
WHERE
 j.ID >  @id	and @id is not null
or j.Date > @in_date and @in_date is not null
order by d.ID_DOCUMENT--�� ���� ���������� ��������� ����� �� �������

