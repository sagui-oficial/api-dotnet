﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sagui.Postgres;

namespace Sagui.Postgres.Migrations
{
    [DbContext(typeof(Sagui))]
    partial class SaguiModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Sagui.Model.Arquivos", b =>
                {
                    b.Property<int>("Id");

                    b.Property<Guid>("PublicID")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("uuid_generate_v1()");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Nome");

                    b.Property<string>("PathArquivo");

                    b.Property<int?>("PlanoOperadoraId");

                    b.Property<Guid?>("PlanoOperadoraPublicID");

                    b.Property<int>("Status");

                    b.Property<byte[]>("Stream");

                    b.HasKey("Id", "PublicID");

                    b.HasAlternateKey("Id");

                    b.HasIndex("PlanoOperadoraId", "PlanoOperadoraPublicID");

                    b.ToTable("Arquivo");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Arquivos");
                });

            modelBuilder.Entity("Sagui.Model.GTO", b =>
                {
                    b.Property<int>("Id");

                    b.Property<Guid>("PublicID")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("uuid_generate_v1()");

                    b.Property<int?>("LoteId");

                    b.Property<string>("Numero");

                    b.Property<int?>("PacienteId");

                    b.Property<Guid?>("PacientePublicID");

                    b.Property<int?>("PlanoOperadoraId");

                    b.Property<Guid?>("PlanoOperadoraPublicID");

                    b.Property<DateTime>("Solicitacao");

                    b.Property<int>("Status");

                    b.Property<DateTime>("Vencimento");

                    b.HasKey("Id", "PublicID");

                    b.HasAlternateKey("Id");

                    b.HasIndex("LoteId");

                    b.HasIndex("PacienteId", "PacientePublicID");

                    b.HasIndex("PlanoOperadoraId", "PlanoOperadoraPublicID");

                    b.ToTable("GTO");
                });

            modelBuilder.Entity("Sagui.Model.Lote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataEnvioCorreio");

                    b.Property<DateTime>("DataPrevistaRecebimento");

                    b.Property<int?>("FuncionarioId");

                    b.Property<Guid?>("FuncionarioPublicID");

                    b.Property<int?>("PlanoOperadoraId");

                    b.Property<Guid?>("PlanoOperadoraPublicID");

                    b.Property<Guid>("PublicID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Status");

                    b.Property<int>("TotalGTOLote");

                    b.Property<decimal>("ValorTotalLote");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId", "FuncionarioPublicID");

                    b.HasIndex("PlanoOperadoraId", "PlanoOperadoraPublicID");

                    b.ToTable("Lote");
                });

            modelBuilder.Entity("Sagui.Model.PlanoOperadora", b =>
                {
                    b.Property<int>("Id");

                    b.Property<Guid>("PublicID")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("uuid_generate_v1()");

                    b.Property<string>("CNPJ");

                    b.Property<DateTime>("DataEnvioLote");

                    b.Property<DateTime>("DataRecebimentoLote");

                    b.Property<string>("NomeFantasia");

                    b.Property<string>("RazaoSocial");

                    b.Property<int>("Status");

                    b.HasKey("Id", "PublicID");

                    b.HasAlternateKey("Id");

                    b.ToTable("PlanoOperadora");
                });

            modelBuilder.Entity("Sagui.Model.PlanoOperadoraPaciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NumeroPlano");

                    b.Property<int?>("PacienteId");

                    b.Property<Guid?>("PacientePublicID");

                    b.Property<int>("PlanoOperadoraId");

                    b.Property<int?>("PlanoOperadoraId1");

                    b.Property<Guid?>("PlanoOperadoraPublicID");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId", "PacientePublicID");

                    b.HasIndex("PlanoOperadoraId1", "PlanoOperadoraPublicID");

                    b.ToTable("PlanoOperadoraPaciente");
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
                    b.Property<int>("Id");

                    b.Property<Guid>("PublicID")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("uuid_generate_v1()");

                    b.Property<string>("Anotacoes");

                    b.Property<string>("Codigo");

                    b.Property<string>("Exigencias");

                    b.Property<int?>("GTOId");

                    b.Property<Guid?>("GTOPublicID");

                    b.Property<string>("NomeProcedimento");

                    b.Property<int?>("PlanoOperadoraId");

                    b.Property<Guid?>("PlanoOperadoraPublicID");

                    b.Property<int>("Status");

                    b.Property<double>("ValorProcedimento");

                    b.HasKey("Id", "PublicID");

                    b.HasAlternateKey("Id");

                    b.HasIndex("GTOId", "GTOPublicID");

                    b.HasIndex("PlanoOperadoraId", "PlanoOperadoraPublicID");

                    b.ToTable("Procedimento");
                });

            modelBuilder.Entity("Sagui.Model.UsuarioBase", b =>
                {
                    b.Property<int>("Id");

                    b.Property<Guid>("PublicID")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("uuid_generate_v1()");

                    b.Property<string>("Anotacoes");

                    b.Property<string>("CPF");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("Funcao");

                    b.Property<string>("Nome");

                    b.Property<int>("Status");

                    b.Property<string>("Telefone");

                    b.Property<int>("TipoUsuario");

                    b.HasKey("Id", "PublicID");

                    b.HasAlternateKey("Id");

                    b.ToTable("UsuarioBase");

                    b.HasDiscriminator<string>("Discriminator").HasValue("UsuarioBase");
                });

            modelBuilder.Entity("Sagui.Model.Arquivo_GTO", b =>
                {
                    b.HasBaseType("Sagui.Model.Arquivos");

                    b.Property<int?>("GTOId");

                    b.Property<Guid?>("GTOPublicID");

                    b.Property<int>("idArquivo");

                    b.Property<int>("idArquivo_GTO");

                    b.Property<int>("idGTO");

                    b.HasIndex("GTOId", "GTOPublicID");

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


                    b.ToTable("Paciente");

                    b.HasDiscriminator().HasValue("Paciente");
                });

            modelBuilder.Entity("Sagui.Model.Arquivos", b =>
                {
                    b.HasOne("Sagui.Model.PlanoOperadora")
                        .WithMany("ListaArquivos")
                        .HasForeignKey("PlanoOperadoraId", "PlanoOperadoraPublicID");
                });

            modelBuilder.Entity("Sagui.Model.GTO", b =>
                {
                    b.HasOne("Sagui.Model.Lote")
                        .WithMany("ListaGTO")
                        .HasForeignKey("LoteId");

                    b.HasOne("Sagui.Model.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId", "PacientePublicID");

                    b.HasOne("Sagui.Model.PlanoOperadora", "PlanoOperadora")
                        .WithMany()
                        .HasForeignKey("PlanoOperadoraId", "PlanoOperadoraPublicID");
                });

            modelBuilder.Entity("Sagui.Model.Lote", b =>
                {
                    b.HasOne("Sagui.Model.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId", "FuncionarioPublicID");

                    b.HasOne("Sagui.Model.PlanoOperadora", "PlanoOperadora")
                        .WithMany()
                        .HasForeignKey("PlanoOperadoraId", "PlanoOperadoraPublicID");
                });

            modelBuilder.Entity("Sagui.Model.PlanoOperadoraPaciente", b =>
                {
                    b.HasOne("Sagui.Model.Paciente")
                        .WithMany("ListaPlanoOperadoraPaciente")
                        .HasForeignKey("PacienteId", "PacientePublicID");

                    b.HasOne("Sagui.Model.PlanoOperadora", "PlanoOperadora")
                        .WithMany()
                        .HasForeignKey("PlanoOperadoraId1", "PlanoOperadoraPublicID");
                });

            modelBuilder.Entity("Sagui.Model.Procedimentos", b =>
                {
                    b.HasOne("Sagui.Model.GTO")
                        .WithMany("Procedimentos")
                        .HasForeignKey("GTOId", "GTOPublicID");

                    b.HasOne("Sagui.Model.PlanoOperadora")
                        .WithMany("ListaProcedimentos")
                        .HasForeignKey("PlanoOperadoraId", "PlanoOperadoraPublicID");
                });

            modelBuilder.Entity("Sagui.Model.Arquivo_GTO", b =>
                {
                    b.HasOne("Sagui.Model.GTO")
                        .WithMany("Arquivos")
                        .HasForeignKey("GTOId", "GTOPublicID");
                });
#pragma warning restore 612, 618
        }
    }
}
