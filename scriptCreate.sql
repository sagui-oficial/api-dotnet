CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" varchar(150) NOT NULL,
    "ProductVersion" varchar(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE EXTENSION IF NOT EXISTS "uuid-ossp";


CREATE TABLE "Arquivo_GTO" (
    "idArquivo_GTO" serial NOT NULL,
    "idGTO" integer NOT NULL,
    "idArquivo" integer NOT NULL,
    CONSTRAINT "PK_Arquivo_GTO" PRIMARY KEY ("idArquivo_GTO")
);

CREATE TABLE "Procedimento_GTO" (
    "idProcedimento_GTO" serial NOT NULL,
    "idGTO" integer NOT NULL,
    "idProcedimento" integer NOT NULL,
    CONSTRAINT "PK_Procedimento_GTO" PRIMARY KEY ("idProcedimento_GTO")
);

CREATE TABLE "UsuarioBase" (
    "Id" serial NOT NULL,
    "Funcao" text NULL,
    "Nome" text NULL,
    "Anotacoes" text NULL,
    "CPF" text NULL,
    "Email" text NULL,
    "Telefone" text NULL,
    "TipoUsuario" integer NOT NULL,
    "Discriminator" text NULL,
    "PublicID" uuid NOT NULL DEFAULT (uuid_generate_v1()),
    CONSTRAINT "PK_UsuarioBase" PRIMARY KEY ("Id", "PublicID")
);

CREATE TABLE "PlanoOperadoraPaciente" (
    id serial NOT NULL,
    "NumeroPlano" text NULL,
    "PacienteId" integer NULL,
    "PublicID" uuid NOT NULL DEFAULT (uuid_generate_v1()),
    CONSTRAINT "PK_PlanoOperadoraPaciente" PRIMARY KEY (id),
    CONSTRAINT "FK_PlanoOperadoraPaciente_UsuarioBase_PacienteId_PacientePublicID" FOREIGN KEY ("PacienteId", "PublicID") REFERENCES "UsuarioBase" ("Id", "PublicID") ON DELETE RESTRICT
);

CREATE TABLE "PlanoOperadora" (
    "Id" serial NOT NULL,
    "NomeFantasia" text NULL,
    "RazaoSocial" text NULL,
    "CNPJ" text NULL,
    "DataEnvioLote" timestamp without time zone NOT NULL,
    "DataRecebimentoLote" timestamp without time zone NOT NULL,
    "PublicID" uuid NOT NULL DEFAULT (uuid_generate_v1()),
    CONSTRAINT "PK_PlanoOperadora" PRIMARY KEY ("Id", "PublicID")
);

CREATE TABLE "GTO" (
    "Id" serial NOT NULL,
    "Numero" text NULL,
    "PlanoOperadoraId" integer NULL,
    "PacienteId" integer NULL,
    "Solicitacao" timestamp without time zone NOT NULL,
    "Vencimento" timestamp without time zone NOT NULL,
    "Status" integer NOT NULL,
    "PublicID" uuid NOT NULL DEFAULT (uuid_generate_v1()),
    CONSTRAINT "PK_GTO" PRIMARY KEY ("Id", "PublicID")
);

CREATE TABLE "Arquivo" (
    "Id" serial NOT NULL,
    "Nome" text NULL,
    "Stream" bytea NULL,
    "DataCriacao" timestamp without time zone NOT NULL,
    "PathArquivo" text NULL,
    CONSTRAINT "PK_Arquivo" PRIMARY KEY ("Id")
);

CREATE TABLE "Procedimento" (
    "IdProcedimento" serial NOT NULL,
    "Codigo" integer NOT NULL,
    "NomeProcedimento" text NULL,
    "ValorProcedimento" double precision NOT NULL,
    "Exigencias" text NULL,
    "Anotacoes" text NULL,
    "PublicID" uuid NOT NULL DEFAULT (uuid_generate_v1()),
    CONSTRAINT "PK_Procedimento" PRIMARY KEY ("IdProcedimento", "PublicID")
);

CREATE UNIQUE INDEX "IX_PlanoOperadora_Id" ON "PlanoOperadora" ("Id");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20190416165508_start', '2.1.8-servicing-32085');
