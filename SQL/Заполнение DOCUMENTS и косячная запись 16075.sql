--отключить айдентити на ID в Журнале
--Хотел изменить порядок, но ID уже были напечатаны на документах
update Журнал 
set ID = ID-1 where 
id between 15514 and  16075

insert into Журнал 
(ID, Date) values (16075, '10-17-2016 16:28:58')
--включить айдентити на ID в Журнале

select *
from Журнал
where id = 16075
 ---------------------------------------------------------------------------------------
--поменять пустоту на NULL
update Журнал
set NumRazresh = null
where NumRazresh =''


create table DOCUMENTS 
(
ID_DOCUMENT int IDENTITY(1,1) PRIMARY KEY,
FID_JOURNAL int FOREIGN KEY REFERENCES Журнал(ID),
FID_TYPE_DOC int FOREIGN KEY REFERENCES ТипДокумента(ID),
NUM_RAZRESH varchar (255),
DATE_RAZRESH datetime,
TICKET_NUMBER varchar (255),
TICKET_DATE datetime
)
GO

--в таблицу Документс вставляем все у которых либо NumRazresh либо [DateRazresh] не нулевой
select id,NumRazresh, [DateRazresh], TypeDoc
from Журнал 
where
not(
NumRazresh is null
and [DateRazresh]  is null
)
--and TypeDoc = 2
--and id!=4491--два тире
--AND id != 695--с вопросом внутри
--and len(NumRazresh)>50--проверка на длинные записи
order by id 

go

--ОБРАБАТЫВАЕМ ТИП НЕТ с ненулевыми данными

--непустые NumRazresh строки меняем тип на Разрешение вместо Нет--, кроме одного письма 5858
update Журнал
set TypeDoc = 1 
--select * from Журнал
where TypeDoc = 3 
and 
NumRazresh is not null
and id !=5858
go
--правим письмо 5858
update Журнал
set TypeDoc = 2 
where id =5858
go


select *
from Журнал
where memo like '%арегистрированные материалы инженерно-геодезических изыскан%'
order by id desc

--правим ненулевые [DateRazresh] с типом НЕТ на 
1 - 11, 1248, 5082
2 - 1668

update Журнал
set TypeDoc = 1  where id in(11, 1248, 5082)
update Журнал
set TypeDoc = 2  where id in(1668)

update Журнал set DateRazresh = null
--select * from Журнал
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
from Журнал
where
NumRazresh is not null
or [DateRazresh]  is not null
order by id 



select *
from [DOCUMENTS]

--не должно быть
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

--ПРОВЕРКА
--те кто не попал в ДОкументс
select *
from Журнал j 
	left join [DOCUMENTS] d on d.FID_JOURNAL = j.ID
where d.FID_JOURNAL is null

select *
from Журнал 
where  NumRazresh is null
and [DateRazresh]  is null
--and TypeDoc!=3
order by id desc

--правим обращения которые попали в разрешение
select *
from Журнал
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

--косячные
select *
from DOCUMENTS
where fid_Type_Doc=2
and( [NUM_RAZRESH] is not null
or [DATE_RAZRESH] is not null)
--косячные
select *
from DOCUMENTS
where fid_Type_Doc=1
and(  [TICKET_NUMBER] is not null
or  [TICKET_DATE] is not null)
