CREATE TABLE [dbo].Process
(
	ProcessKey INT NOT NULL PRIMARY KEY IDENTITY(1,1)
	,ProcessName VARCHAR(20)
	,ProcessDescription VARCHAR(250)
	,CreatedDate datetime
	,ModifiedDate datetime
)
