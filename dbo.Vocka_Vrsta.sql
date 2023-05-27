CREATE TABLE [dbo].[Vocka_Vrsta] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Naziv]       NVARCHAR (40)  NOT NULL,
    [Broj_godina] INT            NULL,
    [Kolicina]    INT            NOT NULL,
    [Cena]        DECIMAL (8, 2) NOT NULL,
    [Id_vocke]    INT            NOT NULL,
    [Id_kupca]    INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Vocka_Vrsta_Kupac] FOREIGN KEY ([Id_kupca]) REFERENCES [dbo].[Kupac] ([Id]),
    CONSTRAINT [FK_Vocka_Vrsta_Vocka] FOREIGN KEY ([Id_vocke]) REFERENCES [dbo].[Vocka] ([Id])
);

