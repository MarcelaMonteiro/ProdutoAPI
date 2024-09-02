﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProdutoApp.Data.Contexts;

#nullable disable

namespace ProdutoApp.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240901062608_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProdutoApp.Data.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("NAME");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("TYPE");

                    b.Property<int>("UnitaryPrice")
                        .HasColumnType("int")
                        .HasColumnName("UNITARYPRICE");

                    b.HasKey("Id");

                    b.ToTable("PRODUCT", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
