CREATE TABLE [dbo].[Employees] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [Name]                 NVARCHAR (MAX) NOT NULL,
    [Surname]              NVARCHAR (MAX) NOT NULL,
    [IdentificationNumber] INT            NOT NULL,
    [BirthDate]            DATETIME       NOT NULL,
    [Gender]               INT            NOT NULL,
    [ContactNumber]        NVARCHAR (MAX) NOT NULL,
    [Email]                NVARCHAR (MAX) NOT NULL,
    [IsDeleted]            BIT            NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([Id] ASC)
);

