CREATE TABLE [dbo].[Grades] (
    [GradeId]          INT      IDENTITY (1, 1) NOT NULL,
    [StudentSubjectId] INT      NULL,
    [CreationDate]     DATETIME NULL,
    [IsDeleted]        BIT      NULL,
    PRIMARY KEY CLUSTERED ([GradeId] ASC),
    FOREIGN KEY ([StudentSubjectId]) REFERENCES [dbo].[StudentsSubjects] ([Id])
);



