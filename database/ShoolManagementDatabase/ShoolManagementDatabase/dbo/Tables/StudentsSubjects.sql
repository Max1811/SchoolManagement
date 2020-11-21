CREATE TABLE [dbo].[StudentsSubjects] (
    [Id]           INT      IDENTITY (1, 1) NOT NULL,
    [StudentId]    INT      NULL,
    [SubjectId]    INT      NULL,
    [CreationDate] DATETIME NULL,
    [IsChanged]    BIT      NULL,
    [IsDeleted]    BIT      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students] ([Id]),
    FOREIGN KEY ([SubjectId]) REFERENCES [dbo].[Subjects] ([Id])
);

