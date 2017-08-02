CREATE PROCEDURE [dbo].[UpdateProcess]
	@ProcessKey int
	,@ProcessName varchar(20)
	,@ProcessDescription varchar(250)
AS

-- TODO: Add error handling and check for existing name
UPDATE dbo.Process
SET ProcessName = @ProcessName
	,ProcessDescription = @ProcessDescription
WHERE ProcessKey = @ProcessKey