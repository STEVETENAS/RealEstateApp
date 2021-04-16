CREATE TABLE [dbo].[Owner] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [CreatedDate] DATE          CONSTRAINT [DF_Owner_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [Name]        NVARCHAR (50) NOT NULL,
    [Email]       NVARCHAR (50) NOT NULL,
    [Tel]         NUMERIC (10)  NOT NULL,
    CONSTRAINT [PK_Owner] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [IX_Owner] UNIQUE NONCLUSTERED ([Email] ASC)
);

