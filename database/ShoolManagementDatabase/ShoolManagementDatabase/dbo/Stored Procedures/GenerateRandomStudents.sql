-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GenerateRandomStudents]
	@LowerBound int,
	@UpperBound int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Declare @Name varchar(20)
	Declare @NameLength int
	Declare @LastName varchar(20)
	Declare @LastNameLength int
	Declare @Patronymic varchar(20)
	Declare @PatronymicLength int
	Declare @Age int
	Declare @FirstClassAge int = 7
	Declare @ClassId int
	Declare @ClassCount int = (select count(*) from Classes)
	Declare @ClassesLoop int = 1
	Declare @StudentsInClass int
	Declare @StudentsInClassLoop int
	Declare @ClassNumber int

	--generate students for each class
	while @ClassesLoop <= @ClassCount
	begin

		set @ClassId = (Select id From(
			Select Row_Number() Over (Order By id) As RowNum, * From classes) t2 
			Where RowNum = @ClassesLoop)

		set @StudentsInClass = Rand()*(@UpperBound-@LowerBound)+@LowerBound
	
		--generate students in certaint class
		set @StudentsInClassLoop = 0
		while @StudentsInClassLoop < @StudentsInClass
		begin

			--generate name
			SET @Name =''
			SET @NameLength = CAST(RAND() * 20 AS INT) + 2

			WHILE @NameLength <> 0
			BEGIN

				SET @Name = @Name + CHAR(CAST(RAND() * 96 + 32 AS INT))
				SET @NameLength = @NameLength - 1

			END

			--generate last name
			SET @LastName =''
			SET @LastNameLength = CAST(RAND() * 20 AS INT) + 2

			WHILE @LastNameLength <> 0
			BEGIN

				SET @LastName = @LastName + CHAR(CAST(RAND() * 96 + 32 AS INT))
				SET @LastNameLength = @LastNameLength - 1

			END

			--generate patronymic
			SET @Patronymic =''
			SET @PatronymicLength = CAST(RAND() * 20 AS INT) + 2

			WHILE @PatronymicLength <> 0
			BEGIN

				SET @Patronymic = @Patronymic + CHAR(CAST(RAND() * 96 + 32 AS INT))
				SET @PatronymicLength = @PatronymicLength - 1

			END

			--all string data was successfully generated

			set @ClassNumber = (select ClassNumber from classes where id = @ClassId)
			set @Age = @FirstClassAge + @ClassNumber - 1

			Insert into students(FirstName, LastName, Patronymic, Age, ClassId, CreationDate, IsDeleted)
			values(@Name, @LastName, @Patronymic, @Age, @ClassId, getdate(), 0)

			set @StudentsInClassLoop += 1
		end

		set @ClassesLoop += 1
	end
END