CREATE TABLE [dbo].[HrData] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [SecurityNumber] INT            NOT NULL,
    [Salary]         int            NOT NULL,
    [IsDeleted]      BIT            NOT NULL,
    [EmployeeId]     INT            NOT NULL,
    CONSTRAINT [PK_HrData] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_HrData_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employees] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_HrData_EmployeeId]
    ON [dbo].[HrData]([EmployeeId] ASC);

