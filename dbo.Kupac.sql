CREATE TABLE [dbo].[Kupac] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [Korisnicko_ime] NVARCHAR (20)   NOT NULL,
    [Lozinka]        NVARCHAR (200)  NOT NULL,
    [Racun]          INT             NOT NULL,
    [Stanje]         DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Racun] ASC)
);

