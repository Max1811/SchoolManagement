-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GenerateRandomClasses]
	@UpperParalelAmount int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Declare @ClassesLoop int
	Declare @FirstClassBoundary int
	Declare @LastClassBoundary int = 11
	Declare @ClassNumber int
	Declare @CurrentSchoolId int
	Declare @CurrentClassNumber int
	Declare @CurrentCreationDate datetime = Getdate()
	Declare @IsDeleted bit = 0
	Declare @SchoolsCount int = (select count(id) from schools)
	Declare @MinSchoolsId int = (select min(id) from schools)
	Declare @RandomSchoolParalelClasses int
	Declare @LowerParalelAmount int = 1

	set @ClassesLoop = 1
	while @ClassesLoop <= @SchoolsCount -- going through all schools
	begin

	set @FirstClassBoundary = 1
	set @CurrentSchoolId = @MinSchoolsId --current school id
	set @RandomSchoolParalelClasses = Rand()*(@UpperParalelAmount + 1 -@LowerParalelAmount)+@LowerParalelAmount

	while @FirstClassBoundary <= @LastClassBoundary -- going through all class numbers
	begin

	set @CurrentClassNumber = @FirstClassBoundary --current class number

	Declare @ParalelClassesLoop int = @LowerParalelAmount
	
	while @ParalelClassesLoop <= @RandomSchoolParalelClasses -- going through all paralel classes
	begin

	insert into classes(SchoolId, ClassNumber, ClassParalel, CreationDate, IsDeleted)
	values(@CurrentSchoolId, @FirstClassBoundary, @ParalelClassesLoop, @CurrentCreationDate, @IsDeleted)

	set @ParalelClassesLoop += 1
	end

	set @FirstClassBoundary += 1
	end

	set @MinSchoolsId += 1
	set @ClassesLoop += 1
	end

END
