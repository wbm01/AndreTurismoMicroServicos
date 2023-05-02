﻿// <auto-generated />
using System;
using AndreTurismoMicroServico.ClientService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AndreTurismoMicroServico.ClientService.Migrations
{
    [DbContext(typeof(AndreTurismoMicroServicoClientServiceContext))]
    partial class AndreTurismoMicroServicoClientServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Models.Address", b =>
                {
                    b.Property<int>("Id_Address")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Address"), 1L, 1);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtRegister_Address")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_City_AddressId_City")
                        .HasColumnType("int");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Address");

                    b.HasIndex("Id_City_AddressId_City");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Models.City", b =>
                {
                    b.Property<int>("Id_City")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_City"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtRegister_City")
                        .HasColumnType("datetime2");

                    b.HasKey("Id_City");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressClientId_Address")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtRegisterClient")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameClient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressClientId_Address");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Models.Address", b =>
                {
                    b.HasOne("Models.City", "Id_City_Address")
                        .WithMany()
                        .HasForeignKey("Id_City_AddressId_City")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Id_City_Address");
                });

            modelBuilder.Entity("Models.Client", b =>
                {
                    b.HasOne("Models.Address", "AddressClient")
                        .WithMany()
                        .HasForeignKey("AddressClientId_Address")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddressClient");
                });
#pragma warning restore 612, 618
        }
    }
}