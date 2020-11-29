CREATE TABLE [dbo].[Regions] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [Country]      VARCHAR (20) NULL,
    [City]         VARCHAR (20) NULL,
    [Street]       VARCHAR (20) NULL,
    [CreationDate] DATETIME     NULL,
    [IsDeleted]    BIT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

