-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GenerateRandomStudentsSubjects] 
	@SubjectsPerStudent int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Declare @SchoolId int
	Declare @StudentId int
	Declare @SchoolsCount int = (select count(id) from schools)
	Declare @StudentsInSchool Table(id int)
	Declare @SchoolLoop int = 1
	Declare @StudentsLoop int

	Declare @ExistingSubjectsIdCount int = (select count(id) from subjects)
	Declare @subjects table(id int)
	Declare @randomsubject int
	Declare @SubjectId int
	Declare @SubjectsForStudentsLoop int = 1
	Declare @SubjectsCondition int = 1

	while @SchoolLoop <= @SchoolsCount
		begin

		delete from @subjects where id > 0
		set @SchoolId = (Select id From(
			Select Row_Number() Over (Order By id) As RowNum, * From schools) t2 
			Where RowNum = @SchoolLoop)

		insert into @StudentsInSchool
		select st.id from students as st
		left join classes as cl
		on st.ClassId = cl.Id
		where cl.SchoolId = @SchoolId
		--generation of subjects

		while @SubjectsForStudentsLoop <= @SubjectsPerStudent
			begin 

				set @SubjectsCondition = 1
				while @SubjectsCondition > 0
					begin

					set @randomsubject = Rand()*(@ExistingSubjectsIdCount-1)+1

					set @SubjectId = (Select id From(
						Select Row_Number() Over (Order By id) As RowNum, * From subjects) t2 
						Where RowNum = @randomsubject)

					if @randomsubject not in (select * from @subjects)
						insert @subjects(id) values(@subjectId);
						set @SubjectsCondition = -2;

					set @SubjectsCondition += 1;
				end

			set @SubjectsForStudentsLoop += 1
		end

		--todo generate here random subjects for current school = @SubjectsPerStudents

		set @StudentsLoop = 1
		while @StudentsLoop <= (select count(*) from @StudentsInSchool)
			begin

			set @StudentId = (Select id From(
			Select Row_Number() Over (Order By id) As RowNum, * From students) t2 
			Where RowNum = @StudentsLoop)

			--make loop for subjects and insert values
			Declare @subjectsSetLoop int = 1
			while @subjectsSetLoop <= (select count(*) from @subjects)
				begin

				set @SubjectId = (Select id From(
						Select Row_Number() Over (Order By id) As RowNum, * From @subjects) t2 
						Where RowNum = @subjectsSetLoop)
				insert into StudentsSubjects(StudentId, SubjectId, CreationDate, IsChanged, IsDeleted)
				values(@StudentId, @SubjectId, getdate(), 0, 0)

				set @subjectsSetLoop += 1
			end

			set @StudentsLoop += 1
		end

		set @SchoolLoop += 1
	end
END