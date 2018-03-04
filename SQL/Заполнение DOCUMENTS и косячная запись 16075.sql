--��������� ��������� �� ID � �������
--����� �������� �������, �� ID ��� ���� ���������� �� ����������
update ������ 
set ID = ID-1 where 
id between 15514 and  16075

insert into ������ 
(ID, Date) values (16075, '10-17-2016 16:28:58')
--�������� ��������� �� ID � �������

select *
from ������
where id = 16075
 ---------------------------------------------------------------------------------------
--�������� ������� �� NULL
update ������
set NumRazresh = null
where NumRazresh =''


create table DOCUMENTS 
(
ID_DOCUMENT int IDENTITY(1,1) PRIMARY KEY,
FID_JOURNAL int FOREIGN KEY REFERENCES ������(ID),
FID_TYPE_DOC int FOREIGN KEY REFERENCES ������������(ID),
NUM_RAZRESH varchar (255),
DATE_RAZRESH datetime,
TICKET_NUMBER varchar (255),
TICKET_DATE datetime
)
GO

--� ������� ��������� ��������� ��� � ������� ���� NumRazresh ���� [DateRazresh] �� �������
select id,NumRazresh, [DateRazresh], TypeDoc
from ������ 
where
not(
NumRazresh is null
and [DateRazresh]  is null
)
--and TypeDoc = 2
--and id!=4491--��� ����
--AND id != 695--� �������� ������
--and len(NumRazresh)>50--�������� �� ������� ������
order by id 

go

--������������ ��� ��� � ���������� �������

--�������� NumRazresh ������ ������ ��� �� ���������� ������ ���--, ����� ������ ������ 5858
update ������
set TypeDoc = 1 
--select * from ������
where TypeDoc = 3 
and 
NumRazresh is not null
and id !=5858
go
--������ ������ 5858
update ������
set TypeDoc = 2 
where id =5858
go


select *
from ������
where memo like '%����������������� ��������� ���������-������������� �������%'
order by id desc

--������ ��������� [DateRazresh] � ����� ��� �� 
1 - 11, 1248, 5082
2 - 1668

update ������
set TypeDoc = 1  where id in(11, 1248, 5082)
update ������
set TypeDoc = 2  where id in(1668)

update ������ set DateRazresh = null
--select * from ������
where TypeDoc = 3 
and 
[DateRazresh] is not null
go

insert into [dbo].[DOCUMENTS]
(
[FID_JOURNAL]
, [FID_TYPE_DOC]
, [NUM_RAZRESH]
, [DATE_RAZRESH]
, [TICKET_NUMBER]
, [TICKET_DATE]
)
select 
id
, TypeDoc
, NumRazresh
, [DateRazresh]
, NumRazresh
, [DateRazresh]
from ������
where
NumRazresh is not null
or [DateRazresh]  is not null
order by id 



select *
from [DOCUMENTS]

--�� ������ ����
select *
from [DOCUMENTS]
where FID_TYPE_DOC =3


--update [DOCUMENTS]
--set  FID_TYPE_DOC = 1
--where FID_TYPE_DOC = 3

update [DOCUMENTS]
set  [NUM_RAZRESH] = null
, [DATE_RAZRESH] = null
where FID_TYPE_DOC = 2


update [DOCUMENTS]
set  
 [TICKET_NUMBER] = null
, [TICKET_DATE] = null
where FID_TYPE_DOC = 1

--��������
--�� ��� �� ����� � ���������
select *
from ������ j 
	left join [DOCUMENTS] d on d.FID_JOURNAL = j.ID
where d.FID_JOURNAL is null

select *
from ������ 
where  NumRazresh is null
and [DateRazresh]  is null
--and TypeDoc!=3
order by id desc

--������ ��������� ������� ������ � ����������
select *
from ������
where NumRazresh like '%12/%'
and TypeDoc=1

update  [DOCUMENTS]
set  
 [TICKET_NUMBER] = Num_Razresh
, [TICKET_DATE] = [DATE_RAZRESH]
,  [NUM_RAZRESH] = null
, [DATE_RAZRESH] = null
, fid_Type_Doc = 2
--select * from [DOCUMENTS]
where Num_Razresh like '%12/%'
and fid_Type_Doc=1
and FID_JOURNAL !=8678

--��������
select *
from DOCUMENTS
where fid_Type_Doc=2
and( [NUM_RAZRESH] is not null
or [DATE_RAZRESH] is not null)
--��������
select *
from DOCUMENTS
where fid_Type_Doc=1
and(  [TICKET_NUMBER] is not null
or  [TICKET_DATE] is not null)
