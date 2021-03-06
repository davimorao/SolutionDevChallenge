﻿// <auto-generated />
using System;
using DevChallenge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DevChallenge.Infra.Data.Migrations
{
    [DbContext(typeof(CadastroContext))]
    [Migration("20190419015434_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DevChallenge.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CascadeMode");

                    b.Property<string>("Cpf");

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime?>("DataExclusao");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Facebook");

                    b.Property<int?>("IdUsuarioAlteracao");

                    b.Property<int?>("IdUsuarioCadastro");

                    b.Property<string>("Instagram");

                    b.Property<string>("Linkedin");

                    b.Property<string>("Nome");

                    b.Property<string>("Rg");

                    b.Property<bool>("Status");

                    b.Property<string>("Twitter");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("DevChallenge.Domain.Entities.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro");

                    b.Property<int>("CascadeMode");

                    b.Property<int>("Cep");

                    b.Property<string>("Cidade");

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime?>("DataExclusao");

                    b.Property<string>("Estado");

                    b.Property<int>("IdCliente");

                    b.Property<int?>("IdUsuarioAlteracao");

                    b.Property<int?>("IdUsuarioCadastro");

                    b.Property<string>("Logradouro");

                    b.Property<string>("Numero");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente")
                        .IsUnique();

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("DevChallenge.Domain.Entities.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CascadeMode");

                    b.Property<string>("Celular");

                    b.Property<DateTime?>("DataAlteracao");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime?>("DataExclusao");

                    b.Property<int>("IdCliente");

                    b.Property<int?>("IdUsuarioAlteracao");

                    b.Property<int?>("IdUsuarioCadastro");

                    b.Property<string>("Residencial");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente")
                        .IsUnique();

                    b.ToTable("Telefone");
                });

            modelBuilder.Entity("DevChallenge.Domain.Entities.Endereco", b =>
                {
                    b.HasOne("DevChallenge.Domain.Entities.Cliente", "Cliente")
                        .WithOne("Endereco")
                        .HasForeignKey("DevChallenge.Domain.Entities.Endereco", "IdCliente")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DevChallenge.Domain.Entities.Telefone", b =>
                {
                    b.HasOne("DevChallenge.Domain.Entities.Cliente", "Cliente")
                        .WithOne("Telefone")
                        .HasForeignKey("DevChallenge.Domain.Entities.Telefone", "IdCliente")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
