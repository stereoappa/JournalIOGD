select id,NumRazresh, [dbo].[GetNumRazresh](NumRazresh)
--COUNT(*)
--

from ������ 

where
id!=4491
--and id between 600 and 694
AND id != 695
 and
(NumRazresh  like '%-%' )
and NumRazresh not like '%/%'
--
--and TypeDoc = 1
--and  NumRazresh  like '%[0-9]%'
and  NumRazresh not like '%[�-�]%'
and NumRazresh is not null
and NumRazresh !=''
go

select STRING_SPLIT ('aaf,sdfsdf,sdf',',')
go
ALTER DATABASE [������_Main] SET COMPATIBILITY_LEVEL = 120

select id,NumRazresh, [dbo].STRING_SPLIT ([dbo].[GetNumRazresh](NumRazresh) , ',' ) 
--COUNT(*)
--

from ������ 

where
id!=4491
--and id between 600 and 694
AND id != 695
 and
(NumRazresh  like '%-%' )
and NumRazresh not like '%/%'
--
--and TypeDoc = 1
--and  NumRazresh  like '%[0-9]%'
and  NumRazresh not like '%[�-�]%'
and NumRazresh is not null
and NumRazresh !=''
go
with array as (
select
123 as NumRazresh
union 
select
345 as NumRazresh
)
select *
from array, ������
where id=58

go
--select 
----COUNT(*)
----
--*
--from ������ 

--where
--(NumRazresh  like '%-%' or NumRazresh   like '%,%')
--and NumRazresh not like '%/%'
----
--and TypeDoc = 1
----and  NumRazresh  like '%[0-9]%'
--and  NumRazresh not like '%[�-�]%'
--and NumRazresh is not null
--and NumRazresh !=''
--go