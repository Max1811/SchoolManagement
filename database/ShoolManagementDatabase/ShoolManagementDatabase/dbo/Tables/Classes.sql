CREATE TABLE [dbo].[Classes] (
    [Id]           INT      IDENTITY (1, 1) NOT NULL,
    [SchoolId]     INT      NULL,
    [ClassNumber]  INT      NULL,
    [CreationDate] DATETIME NULL,
    [IsDeleted]    BIT      NULL,
    [ClassParalel] INT      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([SchoolId]) REFERENCES [dbo].[Schools] ([Id])
);

