CREATE TABLE [dbo].[GTO] (
    [Id]          NUMERIC (18)  NOT NULL,
    [Numero]      NVARCHAR (50) NULL,
    [Status]      NUMERIC (18)  NULL,
    [Operadora]   NUMERIC (18)  NULL,
    [Paciente]    NUMERIC (18)  NULL,
    [Solicitacao] DATETIME      NULL,
    [Vencimento]  DATETIME      NULL,
    CONSTRAINT [PK_GTO] PRIMARY KEY CLUSTERED ([Id] ASC)
);

