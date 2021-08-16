﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Pdam.Configuration.Service.DataContext;

namespace Pdam.Configuration.Service.Migrations
{
    [DbContext(typeof(ConfigContext))]
    partial class ConfigContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Pdam.Configuration.Service.DataContext.Branch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("BranchCode")
                        .HasColumnType("text");

                    b.Property<string>("BranchHeadName")
                        .HasColumnType("text");

                    b.Property<string>("BranchName")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("CompanyCode")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CompanyCode");

                    b.HasIndex("BranchCode", "CompanyCode")
                        .IsUnique();

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Pdam.Configuration.Service.DataContext.Company", b =>
                {
                    b.Property<string>("CompanyCode")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("CompanyLegalName")
                        .HasColumnType("text");

                    b.Property<string>("CompanyName")
                        .HasColumnType("text");

                    b.Property<string>("CompanyWeb")
                        .HasColumnType("text");

                    b.Property<string>("DirectorName")
                        .HasColumnType("text");

                    b.Property<string>("FinanceHead")
                        .HasColumnType("text");

                    b.Property<string>("Logo")
                        .HasColumnType("text");

                    b.Property<string>("PaymentEndPoint")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("Subscription")
                        .HasColumnType("integer");

                    b.HasKey("CompanyCode");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Pdam.Configuration.Service.DataContext.Branch", b =>
                {
                    b.HasOne("Pdam.Configuration.Service.DataContext.Company", "Company")
                        .WithMany("Branches")
                        .HasForeignKey("CompanyCode");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Pdam.Configuration.Service.DataContext.Company", b =>
                {
                    b.Navigation("Branches");
                });
#pragma warning restore 612, 618
        }
    }
}
