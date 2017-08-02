CREATE TABLE [dbo].[QualityFact]
(
	ScreenKey INT NOT NULL REFERENCES dbo.Screen (ScreenKey)
	,AuditKey INT NOT NULL REFERENCES dbo.Audit (AuditKey)
	,ScreeningStartTime datetime
	,ScreeningEndTime datetime
	,TotalRecordsFlagged int
)
