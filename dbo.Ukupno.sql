CREATE TABLE [dbo].[Ukupno] (
    [Id]       INT             IDENTITY (1, 1) NOT NULL,
    [Kolicina] INT             NULL,
    [Cena]     DECIMAL (18, 2) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

