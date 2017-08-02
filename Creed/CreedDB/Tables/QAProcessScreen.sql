CREATE TABLE [dbo].ProcessScreen
(
	ProcessKey INT REFERENCES dbo.Process (ProcessKey)
	,ScreenKey INT REFERENCES dbo.Screen (ScreenKey)
	,CreatedDate datetime
	,CONSTRAINT PK_QAProcessScreen PRIMARY KEY (ProcessKey, ScreenKey)
)
