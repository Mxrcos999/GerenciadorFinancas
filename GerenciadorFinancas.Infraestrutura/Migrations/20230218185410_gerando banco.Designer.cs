// <auto-generated />
using System;
using GerenciadorFinancas.Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GerenciadorFinancas.Infraestrutura.Migrations
{
    [DbContext(typeof(GerenciadorContext))]
    [Migration("20230218185410_gerando banco")]
    partial class gerandobanco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GerenciadorFinancas.Dominio.Entidades.ContaFinanceira", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("RendaBruta")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ValorExtra")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("ContaFinanceiras");
                });

            modelBuilder.Entity("GerenciadorFinancas.Dominio.Entidades.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("EmpresaAtual")
                        .HasColumnType("boolean");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("integer");

                    b.Property<decimal>("ValorPago")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("GerenciadorFinancas.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ContaFinanceiraId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ContaFinanceiraId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("GerenciadorFinancas.Dominio.Entidades.Empresa", b =>
                {
                    b.HasOne("GerenciadorFinancas.Dominio.Entidades.Usuario", null)
                        .WithMany("Empresas")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("GerenciadorFinancas.Dominio.Entidades.Usuario", b =>
                {
                    b.HasOne("GerenciadorFinancas.Dominio.Entidades.ContaFinanceira", "ContaFinanceira")
                        .WithMany()
                        .HasForeignKey("ContaFinanceiraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContaFinanceira");
                });

            modelBuilder.Entity("GerenciadorFinancas.Dominio.Entidades.Usuario", b =>
                {
                    b.Navigation("Empresas");
                });
#pragma warning restore 612, 618
        }
    }
}
