CREATE TABLE [dbo].[Audit]
(
	AuditKey INT NOT NULL PRIMARY KEY IDENTITY(1,1)
	,AuditName VARCHAR(50)
	,AuditDescription VARCHAR(250)
	,ScreenKey INT REFERENCES dbo.Screen (ScreenKey)
	,CreatedDate datetime
)
