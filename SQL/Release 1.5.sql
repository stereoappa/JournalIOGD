USE [Журнал_Main]
GO

--==================================================
--1) TEMPLATE_TYPES--
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TEMPLATE_TYPES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [nvarchar](100) NOT NULL,
	[TEMPLATE_TYPE_ID] [int] NOT NULL,
 CONSTRAINT [PK_TEMPLATE_TYPES] PRIMARY KEY CLUSTERED 
(
	[TEMPLATE_TYPE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--====================================
--2) LOADED_TEMPLATES--
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LOADED_TEMPLATES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FILE_DATA] [varbinary](max) NOT NULL,
	[MD5] [nvarchar](32) NOT NULL,
	[TYPE_FID] [int] NOT NULL,
	[LOAD_DATE] [datetime] NOT NULL,
	[EMPLOYEE_FID] [int] NOT NULL,
 CONSTRAINT [PK_LOADED_TEMPLATES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[LOADED_TEMPLATES]  WITH CHECK ADD  CONSTRAINT [FK_LOADED_TEMPLATES_TEMPLATE_TYPES] FOREIGN KEY([EMPLOYEE_FID])
REFERENCES [dbo].[Сотрудники] ([ID])
GO

ALTER TABLE [dbo].[LOADED_TEMPLATES] CHECK CONSTRAINT [FK_LOADED_TEMPLATES_TEMPLATE_TYPES]
GO

ALTER TABLE [dbo].[LOADED_TEMPLATES]  WITH CHECK ADD  CONSTRAINT [FK_LOADED_TEMPLATES_TEMPLATE_TYPES1] FOREIGN KEY([TYPE_FID])
REFERENCES [dbo].[TEMPLATE_TYPES] ([TEMPLATE_TYPE_ID])
GO

ALTER TABLE [dbo].[LOADED_TEMPLATES] CHECK CONSTRAINT [FK_LOADED_TEMPLATES_TEMPLATE_TYPES1]
GO



--==================================================
--3) INSERT ISSUE TEMPLATE TYPE

INSERT INTO [dbo].[TEMPLATE_TYPES] VALUES ('Шаблон формы выдачи информации', 1)
GO

--=========================================
--4) SP: ADD TEMPLATE 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddTemplate]
	@FileData varbinary(MAX),
	@HashMd5 nvarchar(32),
	@TemplateTypeId int,
	@EmployeeFID int

AS
BEGIN SET NOCOUNT ON;
	INSERT INTO LOADED_TEMPLATES 
	VALUES (@FileData, @HashMd5, @TemplateTypeId, GETDATE(), @EmployeeFID)

	SELECT
		T.FILE_DATA as FileData,
		T.MD5		as HashMd5,
		T.LOAD_DATE as LoadedDate,
		TYP.ID		as TypeId,
		TYP.NAME	as [Name],
		E.ID		as IdEmployee,
		E.Имя		as FirstName,
		E.Фамилия	as SecondName,
		E.Отчество	as ThirdName,
		E.PostName	as Post,
		E.ShortName as ShortName
	FROM dbo.LOADED_TEMPLATES T
	LEFT JOIN dbo.TEMPLATE_TYPES TYP ON (TYP.TEMPLATE_TYPE_ID = T.TYPE_FID)
	LEFT JOIN dbo.Сотрудники E ON (E.ID = T.EMPLOYEE_FID)
	WHERE T.ID = @@IDENTITY;
END
GO

--=========================================
--4) SP: GET ACTUAL TEMPLATE
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetActualTemplate]
	@TemplateTypeId int,
	@WithData bit
AS
BEGIN SET NOCOUNT ON;
	
	SELECT 
		CASE WHEN @WithData = 1 THEN RES.FILE_DATA END as FileData,
		RES.MD5			as HashMd5,
		RES.LOAD_DATE	as LoadedDate,
		RES.ID			as TypeId,
		RES.NAME		as [Name],
		RES.ID			as IdEmployee,
		RES.Имя			as FirstName,
		RES.Фамилия		as SecondName,
		RES.Отчество	as ThirdName,
		RES.PostName	as Post,
		RES.ShortName	as ShortName
	 FROM 
		(SELECT 
			 ROW_NUMBER() OVER (PARTITION BY T.TYPE_FID ORDER BY T.LOAD_DATE DESC) AS RN,
			 T.FILE_DATA, T.MD5, T.LOAD_DATE, TYP.[NAME]
			,E.ID		
			,E.Имя		
			,E.Фамилия	
			,E.Отчество
			,E.PostName
			,E.ShortName
		FROM dbo.LOADED_TEMPLATES T
		LEFT JOIN dbo.TEMPLATE_TYPES TYP ON (TYP.TEMPLATE_TYPE_ID = T.TYPE_FID)
		LEFT JOIN dbo.Сотрудники E ON (E.ID = T.EMPLOYEE_FID)
		WHERE T.TYPE_FID = @TemplateTypeId
			) AS RES 
	WHERE RES.RN = 1

END
GO

--=========================================
--5) SP: GET TEMPLATE TYPES
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTemplateTypes]
AS
BEGIN
	SET NOCOUNT ON;

    SELECT 
		TT.TEMPLATE_TYPE_ID as TypeId
		,TT.[NAME]			as [Name]
	FROM TEMPLATE_TYPES TT
END
GO




