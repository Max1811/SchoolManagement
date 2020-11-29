CREATE TABLE [dbo].[Schools] (
    [Id]           INT      IDENTITY (1, 1) NOT NULL,
    [RegionId]     INT      NULL,
    [SchoolNumber] INT      NULL,
    [CreationDate] DATETIME NULL,
    [IsDeleted]    BIT      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([RegionId]) REFERENCES [dbo].[Regions] ([Id])
);

