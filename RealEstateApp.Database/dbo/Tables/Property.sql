CREATE TABLE [dbo].[Property] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [CreatedDate] DATE           CONSTRAINT [DF_Property_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [Reference]   NVARCHAR (10)  NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Price]       FLOAT (53)     NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [OwnerId]     INT            NOT NULL,
    CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Property_Owner] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[Owner] ([Id]),
    CONSTRAINT [IX_Property] UNIQUE NONCLUSTERED ([Reference] ASC)
);

