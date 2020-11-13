﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimulaParcela.Repositorio;

namespace SimulaParcela.Repositorio.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimulaParcela.Domain.Entidade.Parcela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataDoVencimento");

                    b.Property<int>("SimulacaoId");

                    b.Property<decimal>("ValorDaParcela");

                    b.Property<decimal>("ValorDoJurosAplicado");

                    b.HasKey("Id");

                    b.HasIndex("SimulacaoId");

                    b.ToTable("Parcela");
                });

            modelBuilder.Entity("SimulaParcela.Domain.Entidade.Simulacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataDaCompra");

                    b.Property<int>("QuantidadeDeParcela");

                    b.Property<int>("ValorJuros");

                    b.Property<decimal>("ValorTotalCompra");

                    b.HasKey("Id");

                    b.ToTable("Simulacao");
                });

            modelBuilder.Entity("SimulaParcela.Domain.Entidade.Parcela", b =>
                {
                    b.HasOne("SimulaParcela.Domain.Entidade.Simulacao", "Simulacao")
                        .WithMany("Parcelas")
                        .HasForeignKey("SimulacaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
