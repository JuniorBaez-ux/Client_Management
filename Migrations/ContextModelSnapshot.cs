﻿// <auto-generated />
using System;
using Client_Management.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClientManagement.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Client_Management.Models.CustomerTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustomerTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Normal"
                        },
                        new
                        {
                            Id = 2,
                            Description = "VIP"
                        });
                });

            modelBuilder.Entity("Client_Management.Models.Customers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerTypesId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CustomerTypesId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adress = "773 S. Queen St.Nutley, NJ 07110",
                            CustName = "Bill gates 2th",
                            CustomerTypeId = 1,
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            Adress = "64 Blue Spring Street Bonita Springs, FL 34135",
                            CustName = "Juan Perez 2th",
                            CustomerTypeId = 2,
                            Status = true
                        });
                });

            modelBuilder.Entity("Client_Management.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomersId")
                        .HasColumnType("int");

                    b.Property<double>("SubTotal")
                        .HasColumnType("float");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<double>("Totalitbis")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CustomersId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Client_Management.Models.InvoiceDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CustomerIdId")
                        .HasColumnType("int");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<double>("SubTotal")
                        .HasColumnType("float");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<double>("Totalitbis")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CustomerIdId");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceDetails");
                });

            modelBuilder.Entity("Client_Management.Models.Customers", b =>
                {
                    b.HasOne("Client_Management.Models.CustomerTypes", "CustomerTypes")
                        .WithMany()
                        .HasForeignKey("CustomerTypesId");

                    b.Navigation("CustomerTypes");
                });

            modelBuilder.Entity("Client_Management.Models.Invoice", b =>
                {
                    b.HasOne("Client_Management.Models.Customers", "Customers")
                        .WithMany()
                        .HasForeignKey("CustomersId");

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("Client_Management.Models.InvoiceDetail", b =>
                {
                    b.HasOne("Client_Management.Models.Invoice", "CustomerId")
                        .WithMany()
                        .HasForeignKey("CustomerIdId");

                    b.HasOne("Client_Management.Models.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId");

                    b.Navigation("CustomerId");

                    b.Navigation("Invoice");
                });
#pragma warning restore 612, 618
        }
    }
}
