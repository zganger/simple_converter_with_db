CREATE TABLE [dbo].[Conversions] (
    [Id]     INT            NOT NULL IDENTITY,
    [Unit]   NVARCHAR (MAX) NOT NULL,
    [Factor] FLOAT (53)     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

