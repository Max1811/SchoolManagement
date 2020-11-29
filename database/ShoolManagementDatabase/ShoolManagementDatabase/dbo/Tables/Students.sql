CREATE TABLE [dbo].[Students] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (20) NOT NULL,
    [LastName]     VARCHAR (20) NOT NULL,
    [Patronymic]   VARCHAR (20) NULL,
    [Age]          INT          NULL,
    [ClassId]      INT          NULL,
    [CreationDate] DATETIME     NULL,
    [IsDeleted]    BIT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ClassId]) REFERENCES [dbo].[Classes] ([Id])
);



