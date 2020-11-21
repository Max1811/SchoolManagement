-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GenerateRandomRegions]
	@RegionsCount int
AS
BEGIN
	SET NOCOUNT ON;
		
	DECLARE @Loop INT, @Length INT
	DECLARE @Country VARCHAR(20)
	DECLARE @City VARCHAR(20)
	DECLARE @Street VARCHAR(20)
	DECLARE @IsDeleted BIT = 0
	DECLARE @CreationDate DATE = GETDATE()

	SET @Loop = 0
	WHILE @Loop < @RegionsCount  
	BEGIN

	--country init
	SET @Country =''
	SET @Length = CAST(RAND() * 20 AS INT) + 2

	WHILE @Length <> 0
	BEGIN

	SET @Country = @Country + CHAR(CAST(RAND() * 96 + 32 AS INT))
	SET @Length = @Length - 1

	END

	--city init
	SET @City =''
	SET @Length = CAST(RAND() * 20 AS INT) + 2

	WHILE @Length <> 0
	BEGIN

	SET @City = @City + CHAR(CAST(RAND() * 96 + 32 AS INT))
	SET @Length = @Length - 1

	END

	--street init
	SET @Street =''
	SET @Length = CAST(RAND() * 20 AS INT) + 2

	WHILE @Length <> 0
	BEGIN

	SET @Street = @Street + CHAR(CAST(RAND() * 96 + 32 AS INT))
	SET @Length = @Length - 1

	END

	INSERT INTO [Regions] VALUES (@Country,@City,@Street,@CreationDate,@IsDeleted)

	SET @Loop = @Loop + 1
	end
END
