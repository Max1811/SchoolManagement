-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[GenerateRandomGrades] 
	@LowerGradeBound int = 1,
	@UpperGradeBound int = 12,
	@GradesForStudent int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Declare @StudentsSubjectId int
    Declare @StudentsSubjectsLoop int = 1
	Declare @GradesLoop int = 1
	Declare @RandomGrade int

	while @StudentsSubjectsLoop <= (select count(*) from StudentsSubjects)
		begin

		set @StudentsSubjectId = (Select id From(
			Select Row_Number() Over (Order By id) As RowNum, * From StudentsSubjects) t2 
			Where RowNum = @StudentsSubjectsLoop)
		
		set @GradesLoop = 1
		
		while @GradesLoop <= @GradesForStudent
			begin

			--set @RandomGrade = Rand()*(@UpperGradeBound-@LowerGradeBound)+@LowerGradeBound
			--insert into grades(studentSubjectId, Grade, CreationDate, IsDeleted)
			--values(@StudentsSubjectId, @RandomGrade, getdate(), 0)

			set @GradesLoop += 1
		end

		set @StudentsSubjectsLoop += 1
	end
END