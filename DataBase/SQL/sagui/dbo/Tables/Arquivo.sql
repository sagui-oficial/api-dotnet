CREATE TABLE [dbo].[Arquivo] (
    [Id]          NUMERIC (18)  NOT NULL,
    [Nome]        NVARCHAR (50) NULL,
    [DataArquivo] DATETIME      NULL,
    CONSTRAINT [PK_Arquivo] PRIMARY KEY CLUSTERED ([Id] ASC)
);

