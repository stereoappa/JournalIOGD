with fill as (select errorRows = CAST(j.ID as varchar) + 
CASE 
WHEN j.TypeDoc = 1 and (d.FID_JOURNAL is null) THEN ' - ��� �� ������ �������������� ����������' 
WHEN j.TypeDoc = 2 and (d.FID_JOURNAL is null) THEN ' - ��� �� ������ �������������� ���������' 
WHEN j.TypeDoc = 1 and (d.TICKET_NUMBER is null OR d.TICKET_DATE is null) THEN ' - �� ������� ��������� ���������' 
END 
from ������ j left join DOCUMENTS d 
ON 
j.ID = d.FID_JOURNAL 
WHERE 
j.ID > 16786) select distinct *  from fill where errorRows is not null

--AND is not null
--j.TypeDoc = 2 and (d.TICKET_NUMBER is null and d.TICKET_DATE is null)	--��������� ��� ������������� ����������


