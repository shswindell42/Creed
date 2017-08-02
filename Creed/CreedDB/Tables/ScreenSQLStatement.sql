CREATE TABLE [dbo].[ScreenSQLStatement]
(
	ScreenSQLStatementKey INT NOT NULL PRIMARY KEY IDENTITY(1,1)
	,ScreenKey INT NOT NULL REFERENCES dbo.Screen (ScreenKey)
	,SQLStatement VARCHAR(MAX) 
	,CreatedDate datetime
	,ModifiedDate datetime
)
