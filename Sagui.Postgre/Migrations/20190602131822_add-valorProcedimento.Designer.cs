﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sagui.Postgres;

namespace Sagui.Postgres.Migrations
{
    [DbContext(typeof(Sagui))]
    [Migration("20190602131822_add-valorProcedimento")]
    partial class addvalorProcedimento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Sagui.Model.Arquivos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Extensao");

                    b.Property<string>("Nome");

                    b.Property<string>("PathArquivo");

                    b.Property<int?>("PlanoOperadoraId");

                    b.Property<Guid>("PublicID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Status");

                    b.Property<byte[]>("Stream");

                    b.HasKey("Id");

                    b.HasIndex("PlanoOperadoraId");

                    b.ToTable("Arquivo");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Arquivos");
                });

            modelBuilder.Entity("Sagui.Model.GTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("LoteId");

                    b.Property<string>("Numero");

                    b.Property<int?>("PacienteId");

                    b.Property<int?>("PlanoOperadoraId");

                    b.Property<Guid>("PublicID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Solicitacao");

                    b.Property<int>("Status");

                    b.Property<double>("TotalProcedimentos");

                    b.Property<double>("ValorTotalProcedimentos");

                    b.Property<DateTime>("Vencimento");

                    b.HasKey("Id");

                    b.HasIndex("LoteId");

                    b.HasIndex("PacienteId");

                    b.HasIndex("PlanoOperadoraId");

                    b.ToTable("GTO");
                });

            modelBuilder.Entity("Sagui.Model.Lote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataEnvioCorreio");

                    b.Property<DateTime>("DataPrevistaRecebimento");

                    b.Property<int?>("FuncionarioId");

                    b.Property<int?>("PlanoOperadoraId");

                    b.Property<Guid>("PublicID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Status");

                    b.Property<int>("TotalGTOLote");

                    b.Property<decimal>("ValorTotalLote");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("PlanoOperadoraId");

                    b.ToTable("Lote");
                });

            modelBuilder.Entity("Sagui.Model.PlanoOperadora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CNPJ");

                    b.Property<DateTime>("DataEnvioLote");

                    b.Property<DateTime>("DataRecebimentoLote");

                    b.Property<string>("NomeFantasia");

                    b.Property<Guid>("PublicID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RazaoSocial");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("PlanoOperadora");
                });

            modelBuilder.Entity("Sagui.Model.Procedimento_GTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdGTO");

                    b.Property<int>("IdProcedimento");

                    b.HasKey("Id");

                    b.ToTable("Procedimento_GTO");
                });

            modelBuilder.Entity("Sagui.Model.Procedimentos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Anotacoes");

                    b.Property<string>("Codigo");

                    b.Property<string>("Exigencias");

                    b.Property<int?>("GTOId");

                    b.Property<string>("NomeProcedimento");

                    b.Property<int?>("PlanoOperadoraId");

                    b.Property<Guid>("PublicID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Status");

                    b.Property<double>("ValorProcedimento");

                    b.HasKey("Id");

                    b.HasIndex("GTOId");

                    b.HasIndex("PlanoOperadoraId");

                    b.ToTable("Procedimento");
                });

            modelBuilder.Entity("Sagui.Model.UsuarioBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Anotacoes");

                    b.Property<string>("CPF");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("Funcao");

                    b.Property<string>("Nome");

                    b.Property<Guid>("PublicID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Status");

                    b.Property<string>("Telefone");

                    b.Property<int>("TipoUsuario");

                    b.HasKey("Id");

                    b.ToTable("UsuarioBase");

                    b.HasDiscriminator<string>("Discriminator").HasValue("UsuarioBase");
                });

            modelBuilder.Entity("Sagui.Model.Arquivo_GTO", b =>
                {
                    b.HasBaseType("Sagui.Model.Arquivos");

                    b.Property<int?>("GTOId");

                    b.Property<int>("idArquivo");

                    b.Property<int>("idArquivo_GTO");

                    b.Property<int>("idGTO");

                    b.HasIndex("GTOId");

                    b.ToTable("Arquivo_GTO");

                    b.HasDiscriminator().HasValue("Arquivo_GTO");
                });

            modelBuilder.Entity("Sagui.Model.Dentinsta", b =>
                {
                    b.HasBaseType("Sagui.Model.UsuarioBase");

                    b.Property<string>("CRO");

                    b.ToTable("Dentinsta");

                    b.HasDiscriminator().HasValue("Dentinsta");
                });

            modelBuilder.Entity("Sagui.Model.Funcionario", b =>
                {
                    b.HasBaseType("Sagui.Model.UsuarioBase");


                    b.ToTable("Funcionario");

                    b.HasDiscriminator().HasValue("Funcionario");
                });

            modelBuilder.Entity("Sagui.Model.Paciente", b =>
                {
                    b.HasBaseType("Sagui.Model.UsuarioBase");

                    b.Property<string>("NumeroPlano");

                    b.Property<int>("PlanoOperadoraId");

                    b.HasIndex("PlanoOperadoraId");

                    b.ToTable("Paciente");

                    b.HasDiscriminator().HasValue("Paciente");
                });

            modelBuilder.Entity("Sagui.Model.Arquivos", b =>
                {
                    b.HasOne("Sagui.Model.PlanoOperadora")
                        .WithMany("ListaArquivos")
                        .HasForeignKey("PlanoOperadoraId");
                });

            modelBuilder.Entity("Sagui.Model.GTO", b =>
                {
                    b.HasOne("Sagui.Model.Lote")
                        .WithMany("ListaGTO")
                        .HasForeignKey("LoteId");

                    b.HasOne("Sagui.Model.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId");

                    b.HasOne("Sagui.Model.PlanoOperadora", "PlanoOperadora")
                        .WithMany()
                        .HasForeignKey("PlanoOperadoraId");
                });

            modelBuilder.Entity("Sagui.Model.Lote", b =>
                {
                    b.HasOne("Sagui.Model.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId");

                    b.HasOne("Sagui.Model.PlanoOperadora", "PlanoOperadora")
                        .WithMany()
                        .HasForeignKey("PlanoOperadoraId");
                });

            modelBuilder.Entity("Sagui.Model.Procedimentos", b =>
                {
                    b.HasOne("Sagui.Model.GTO")
                        .WithMany("Procedimentos")
                        .HasForeignKey("GTOId");

                    b.HasOne("Sagui.Model.PlanoOperadora")
                        .WithMany("ListaProcedimentos")
                        .HasForeignKey("PlanoOperadoraId");
                });

            modelBuilder.Entity("Sagui.Model.Arquivo_GTO", b =>
                {
                    b.HasOne("Sagui.Model.GTO")
                        .WithMany("Arquivos")
                        .HasForeignKey("GTOId");
                });

            modelBuilder.Entity("Sagui.Model.Paciente", b =>
                {
                    b.HasOne("Sagui.Model.PlanoOperadora", "PlanoOperadora")
                        .WithMany()
                        .HasForeignKey("PlanoOperadoraId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
