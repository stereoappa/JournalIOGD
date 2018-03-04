  use ������_Main --���������� ����


ALTER TABLE ������ --�������� �������: ��������� ������� ������� ���� (������ �� ������� ������� �����������)
  ADD CONSTRAINT FK_OrgID 
  FOREIGN KEY (Organ_ID) REFERENCES �����������(ID)
  ON UPDATE CASCADE -- ��� ���������� ������������ ������� (�����������) �������� �������� �������� (������)

  ALTER TABLE ������ --�������� �������: ��������� ������� ������� ���� (������ �� ������� ������� ������������)
  ADD CONSTRAINT FK_TypeDocId
  FOREIGN KEY (TypeDoc) REFERENCES ������������(ID)
  ON UPDATE CASCADE -- ��� ���������� ������������ ������� (��� ���) �������� �������� �������� (������)

  SELECT ������.ID FROM ������ WHERE ������.Organ_ID NOT IN (SELECT ID FROM ����������� ) -- ������� ID ������ �������, 
										--� ������� ����� ����������� �� ������ � ������ ����������� (�� ���� �������)		
 
  
  SELECT * FROM ������ WHERE ������.Empl_ID NOT IN (SELECT ID FROM ����������) -- ������� ID ������ �������, 
										--� ������� ����� ����������� �� ������ � ������ ����������� (�� ���� �������)		

 SELECT * FROM ������ WHERE ������.ID='2415' -- ������ � ������� ������������

 UPDATE ������ -- ������� ������� ����� ������ � ������� ������������
 SET Organ_ID='33'
 WHERE ������.ID='2415' 


 -- ������� �������
 CREATE TABLE �������  -- ������� ������� 
 (
 ID int identity(1,1) not null,
 ClientName varchar(100) not null,
 Org_ID int not null
 )

ALTER TABLE  �������		-- ��������� ��������� ����
ADD CONSTRAINT PK_ClientOrg PRIMARY KEY (ClientName, Org_ID)

 ALTER TABLE ������� -- ������� ���� �� �����������
 ADD CONSTRAINT FK_Custom FOREIGN KEY (Org_ID) REFERENCES �����������(ID)
 ON DELETE CASCADE 

 ALTER TABLE ������� -- �������� ������� ���� �� �����������
DROP CONSTRAINT FK_Custom 

 INSERT INTO ������� (ClientName, Org_ID) -- ����������� �� ������� ��� ������ - ����������
 (SELECT DISTINCT ClientName, Organ_ID FROM ������ 
 WHERE (Organ_ID IS NOT NULL AND Organ_ID NOT IN (33, '') AND ClientName IS NOT NULL AND ClientName NOT IN ('')))

 DBCC CHECKIDENT (�������, reseed, 1) -- ����� ������� ��������� �� 1

  TRUNCATE TABLE ������� -- �������� �������
  DROP TABLE  �������  -- ������� �������


  --������������� �����������
  select ��������  from ����������� group by �������� having count(��������)>1
  select *  from ����������� where �������� = '��� "�����"'

select *  from ������� where ClientName = '����'

delete  from ������� where ClientName = '����'

--����� ���� �������� ������� ��� � �������
TRUNCATE TABLE �������

INSERT INTO ������� (ClientName, Org_ID) -- ����������� �� ������� ��� ������ - ����������
 (SELECT DISTINCT ClientName, Organ_ID FROM ������ 
 WHERE (Organ_ID IS NOT NULL AND ClientName IS NOT NULL AND ClientName NOT IN ('')))

 Update ����������� SET �������������� = NULL
