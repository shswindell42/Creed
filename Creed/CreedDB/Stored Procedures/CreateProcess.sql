CREATE PROCEDURE [dbo].[CreateProcess]
	@ProcessName varchar(20)
	,@ProcessDescription varchar(250)
AS

-- TODO: Add error handling and check for existing name
INSERT INTO dbo.Process
(ProcessName, ProcessDescription)
VALUES
(@ProcessName, @ProcessDescription)