-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GenerateRandomSubjects]
	@SubjectsCount int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Declare @ClassesLoop int
	DECLARE @SubjectName VARCHAR(20)
	DECLARE @SubjectNameLength int

	set @ClassesLoop = 1
	WHILE @ClassesLoop <= @SubjectsCount -- going through all schools
	BEGIN

	SET @SubjectName =''
	SET @SubjectNameLength = CAST(RAND() * 20 AS INT) + 2

	WHILE @SubjectNameLength <> 0
	BEGIN

	SET @SubjectName = @SubjectName + CHAR(CAST(RAND() * 96 + 32 AS INT))
	SET @SubjectNameLength = @SubjectNameLength - 1

	END

	INSERT INTO [Subjects](SubjectName, CreationDate, IsDeleted)
	VALUES (@SubjectName, getdate(), 0)

	set @ClassesLoop += 1

	END
END