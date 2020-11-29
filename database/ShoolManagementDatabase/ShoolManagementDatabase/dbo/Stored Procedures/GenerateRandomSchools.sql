-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GenerateRandomSchools]
	--@SchoolsAmount int
	@LowerBoundSchoolsPerRegion int,
	@UpperBoundSchoolsPerRegion int
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Loop INT, @Length INT

	Declare @RegionsCount int
	Declare @RegionId int
	Declare @SchoolNumber int
	Declare @SchoolsPerRegionNumber int
	Declare @CreationDate date = getdate()
	Declare @IsDeleted bit = 0

	set @RegionsCount = (select count(Id) from Regions)
	set @Loop = 1

	WHILE @Loop <= @RegionsCount  
	BEGIN

	set @RegionId = (Select id From(
			Select Row_Number() Over (Order By id) As RowNum, * From classes) t2 
			Where RowNum = @Loop)

	set @SchoolsPerRegionNumber = Rand()
		*(@UpperBoundSchoolsPerRegion-@LowerBoundSchoolsPerRegion)+@LowerBoundSchoolsPerRegion
	
	Declare @SchoolIndex int = 1
	while @SchoolIndex <= @SchoolsPerRegionNumber
	begin

	set @SchoolNumber = Rand()*(500-1)+1
	INSERT INTO [Schools](RegionId,SchoolNumber, CreationDate, IsDeleted)
		VALUES (@RegionId,@SchoolNumber,@CreationDate,@IsDeleted)

	set @SchoolIndex += 1
	end	

	set @Loop = @Loop + 1
	END
END
