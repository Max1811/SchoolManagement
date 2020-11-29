CREATE TABLE [dbo].[Subjects] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [SubjectName]  VARCHAR (30) NULL,
    [CreationDate] DATETIME     NULL,
    [IsDeleted]    BIT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

