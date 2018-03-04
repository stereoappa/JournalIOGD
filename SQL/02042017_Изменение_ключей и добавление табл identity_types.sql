ALTER TABLE  [dbo].[Клиенты]
DROP CONSTRAINT [PK_ClientOrg];

ALTER TABLE  [dbo].[Клиенты]
add CONSTRAINT PK_ID primary key CLUSTERED (ID)
;

alter table [dbo].[Клиенты]
add [FID_DOCTYPE] [int] NULL,
	[REQUISITES] [varchar](75) NULL,
	[SCAN_LINK] [varchar](max) NULL;

alter table  [dbo].[Журнал]
alter column [Memo] [varchar](max) NULL
;

alter table  [dbo].[Журнал]
alter column [Desc] [varchar](max) NULL
;



USE [Журнал_Main]
GO

/****** Object:  Table [dbo].[IDENTITY_TYPES]    Script Date: 02.04.2017 14:34:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IDENTITY_TYPES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDENTITY_TYPE] [varchar](150) NULL,
	[SHORT_IDENTITY_TYPE] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

INSERT INTO [IDENTITY_TYPES]
([IDENTITY_TYPE],[SHORT_IDENTITY_TYPE])
values ('Паспорт гражданина РФ','паспорт РФ')
, ('Водительское удостоверение','водительское')
, ('Паспорт иностранного гражданина','паспорт иного гос-ва')
;


ALTER TABLE  [dbo].[Журнал]
add CONSTRAINT FK_ClientID foreign key (Client_ID) REFERENCES Клиенты(ID) 
;

ALTER TABLE  [dbo].[Клиенты]
add CONSTRAINT FK_Doctype foreign key (FID_DOCTYPE) REFERENCES [dbo].[IDENTITY_TYPES](ID) 
;