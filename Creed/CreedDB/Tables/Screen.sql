CREATE TABLE [dbo].[Screen]
(
	ScreenKey INT NOT NULL PRIMARY KEY IDENTITY(1,1)
	,ScreenName VARCHAR(50) NOT NULL
	,ScreenDescription VARCHAR(250)
	,ScreenTypeKey INT NOT NULL
	,CreatedDate datetime
	,ModifiedDate datetime
)
