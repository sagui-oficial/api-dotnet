﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sagui.DB;

namespace Sagui.DB.Migrations
{
    [DbContext(typeof(Sagui))]
    partial class SaguiModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sagui.Model.Arquivo_GTO", b =>
                {
                    b.Property<int>("idArquivo_GTO")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idArquivo");

                    b.Property<int>("idGTO");

                    b.HasKey("idArquivo_GTO");

                    b.ToTable("Arquivo_GTO");
                });

            modelBuilder.Entity("Sagui.Model.Arquivos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacao");

                    b.Property<int?>("GTOId");

                    b.Property<Guid?>("GTOPublicID");

                    b.Property<string>("Nome");

                    b.Property<string>("PathArquivo");

                    b.Property<int?>("PlanoOperadoraId");

                    b.Property<Guid?>("PlanoOperadoraPublicID");

                    b.Property<byte[]>("Stream");

                    b.HasKey("Id");

                    b.HasIndex("GTOId", "GTOPublicID");

                    b.HasIndex("PlanoOperadoraId", "PlanoOperadoraPublicID");

                    b.ToTable("Arquivo");
                });

            modelBuilder.Entity("Sagui.Model.GTO", b =>
                {
                    b.Property<int>("Id");

                    b.Property<Guid>("PublicID")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Numero");

                    b.Property<int?>("PacienteId");

                    b.Property<Guid?>("PacientePublicID");

                    b.Property<int?>("PlanoOperadoraId");

                    b.Property<Guid?>("PlanoOperadoraPublicID");

                    b.Property<DateTime>("Solicitacao");

                    b.Property<int>("Status");

                    b.Property<DateTime>("Vencimento");

                    b.HasKey("Id", "PublicID");

                    b.HasIndex("PacienteId", "PacientePublicID");

                    b.HasIndex("PlanoOperadoraId", "PlanoOperadoraPublicID");

                    b.ToTable("GTO");
                });

            modelBuilder.Entity("Sagui.Model.PlanoOperadora", b =>
                {
                    b.Property<int>("Id");

                    b.Property<Guid>("PublicID")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("CNPJ");

                    b.Property<DateTime>("DataEnvioLote");

                    b.Property<DateTime>("DataRecebimentoLote");

                    b.Property<string>("NomeFantasia");

                    b.Property<string>("RazaoSocial");

                    b.HasKey("Id", "PublicID");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("PlanoOperadora");
                });

            modelBuilder.Entity("Sagui.Model.PlanoOperadoraPaciente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NumeroPlano");

                    b.Property<int?>("PacienteId");

                    b.Property<Guid?>("PacientePublicID");

                    b.HasKey("id");

                    b.HasIndex("PacienteId", "PacientePublicID");

                    b.ToTable("PlanoOperadoraPaciente");
                });

            modelBuilder.Entity("Sagui.Model.Procedimento_GTO", b =>
                {
                    b.Property<int>("idProcedimento_GTO")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idGTO");

                    b.Property<int>("idProcedimento");

                    b.HasKey("idProcedimento_GTO");

                    b.ToTable("Procedimento_GTO");
                });

            modelBuilder.Entity("Sagui.Model.Procedimentos", b =>
                {
                    b.Property<int>("IdProcedimento")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("PublicID")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Anotacoes");

                    b.Property<int>("Codigo");

                    b.Property<string>("Exigencias");

                    b.Property<int?>("GTOId");

                    b.Property<Guid?>("GTOPublicID");

                    b.Property<string>("NomeProcedimento");

                    b.Property<int?>("PlanoOperadoraId");

                    b.Property<Guid?>("PlanoOperadoraPublicID");

                    b.Property<double>("ValorProcedimento");

                    b.HasKey("IdProcedimento", "PublicID");

                    b.HasIndex("GTOId", "GTOPublicID");

                    b.HasIndex("PlanoOperadoraId", "PlanoOperadoraPublicID");

                    b.ToTable("Procedimento");
                });

            modelBuilder.Entity("Sagui.Model.UsuarioBase", b =>
                {
                    b.Property<int>("Id");

                    b.Property<Guid>("PublicID")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Anotacoes");

                    b.Property<string>("CPF");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("Funcao");

                    b.Property<string>("Nome");

                    b.Property<string>("Telefone");

                    b.Property<int>("TipoUsuario");

                    b.HasKey("Id", "PublicID");

                    b.ToTable("UsuarioBase");

                    b.HasDiscriminator<string>("Discriminator").HasValue("UsuarioBase");
                });

            modelBuilder.Entity("Sagui.Model.Paciente", b =>
                {
                    b.HasBaseType("Sagui.Model.UsuarioBase");


                    b.ToTable("Paciente");

                    b.HasDiscriminator().HasValue("Paciente");
                });

            modelBuilder.Entity("Sagui.Model.Arquivos", b =>
                {
                    b.HasOne("Sagui.Model.GTO")
                        .WithMany("Arquivos")
                        .HasForeignKey("GTOId", "GTOPublicID");

                    b.HasOne("Sagui.Model.PlanoOperadora")
                        .WithMany("ListaArquivos")
                        .HasForeignKey("PlanoOperadoraId", "PlanoOperadoraPublicID");
                });

            modelBuilder.Entity("Sagui.Model.GTO", b =>
                {
                    b.HasOne("Sagui.Model.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId", "PacientePublicID");

                    b.HasOne("Sagui.Model.PlanoOperadora", "PlanoOperadora")
                        .WithMany()
                        .HasForeignKey("PlanoOperadoraId", "PlanoOperadoraPublicID");
                });

            modelBuilder.Entity("Sagui.Model.PlanoOperadora", b =>
                {
                    b.HasOne("Sagui.Model.PlanoOperadoraPaciente")
                        .WithOne("PlanoOperadora")
                        .HasForeignKey("Sagui.Model.PlanoOperadora", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sagui.Model.PlanoOperadoraPaciente", b =>
                {
                    b.HasOne("Sagui.Model.Paciente")
                        .WithMany("ListaPlanoOperadoraPaciente")
                        .HasForeignKey("PacienteId", "PacientePublicID");
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
#pragma warning restore 612, 618
        }
    }
}
