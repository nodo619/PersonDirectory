﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonDirectoryApi.Persistence;

#nullable disable

namespace PersonDirectoryApi.Migrations
{
    [DbContext(typeof(PersonsDbContext))]
    [Migration("20221102215934_PhoneNumberRelation")]
    partial class PhoneNumberRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PersonDirectoryApi.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PersonalIdNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("PhotoFilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("PersonDirectoryApi.Models.PersonToPerson", b =>
                {
                    b.Property<int>("SourcePersonId")
                        .HasColumnType("int");

                    b.Property<int?>("RelatedPersonId")
                        .HasColumnType("int");

                    b.Property<int>("ConnectionType")
                        .HasColumnType("int");

                    b.HasKey("SourcePersonId", "RelatedPersonId");

                    b.HasIndex("RelatedPersonId");

                    b.ToTable("PersonToPerson");
                });

            modelBuilder.Entity("PersonDirectoryApi.Models.PhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumberValue")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PhoneType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("PhoneNumber");
                });

            modelBuilder.Entity("PersonDirectoryApi.Models.PersonToPerson", b =>
                {
                    b.HasOne("PersonDirectoryApi.Models.Person", "RelatedPerson")
                        .WithMany("ConnectionOfPersons")
                        .HasForeignKey("RelatedPersonId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("PersonDirectoryApi.Models.Person", "SourcePerson")
                        .WithMany("ConnectedPersons")
                        .HasForeignKey("SourcePersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RelatedPerson");

                    b.Navigation("SourcePerson");
                });

            modelBuilder.Entity("PersonDirectoryApi.Models.PhoneNumber", b =>
                {
                    b.HasOne("PersonDirectoryApi.Models.Person", "Person")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("PersonDirectoryApi.Models.Person", b =>
                {
                    b.Navigation("ConnectedPersons");

                    b.Navigation("ConnectionOfPersons");

                    b.Navigation("PhoneNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
