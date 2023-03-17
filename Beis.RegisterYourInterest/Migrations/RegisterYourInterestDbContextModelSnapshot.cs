﻿// <auto-generated />
using System;
using Beis.RegisterYourInterest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Beis.RegisterYourInterest.Migrations
{
    [DbContext(typeof(RegisterYourInterestDbContext))]
    partial class RegisterYourInterestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Beis.Common.Entities.Models.BaseUserEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("email_address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("email_verified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("full_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("verification_code")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("verification_expiry_date")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id");

                    b.HasIndex("email_address")
                        .IsUnique();

                    b.ToTable("users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseUserEntity");
                });

            modelBuilder.Entity("Beis.RegisterYourInterest.Data.Entities.Address", b =>
                {
                    b.Property<int>("address_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("address_id"));

                    b.Property<string>("address_line_1")
                        .HasColumnType("text");

                    b.Property<string>("address_line_2")
                        .HasColumnType("text");

                    b.Property<string>("county")
                        .HasColumnType("text");

                    b.Property<int?>("custodian_code")
                        .HasColumnType("integer");

                    b.Property<string>("postcode")
                        .HasColumnType("text");

                    b.Property<string>("town")
                        .HasColumnType("text");

                    b.Property<string>("uprn")
                        .HasColumnType("text");

                    b.HasKey("address_id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Beis.RegisterYourInterest.Data.Applicant", b =>
                {
                    b.HasBaseType("Beis.Common.Entities.Models.BaseUserEntity");

                    b.Property<int>("address_id")
                        .HasColumnType("integer");

                    b.Property<int>("address_id1")
                        .HasColumnType("integer");

                    b.Property<string>("applicant_phone_number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasIndex("address_id1");

                    b.HasDiscriminator().HasValue("Applicant");
                });

            modelBuilder.Entity("Beis.RegisterYourInterest.Data.Applicant", b =>
                {
                    b.HasOne("Beis.RegisterYourInterest.Data.Entities.Address", "address")
                        .WithMany()
                        .HasForeignKey("address_id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("address");
                });
#pragma warning restore 612, 618
        }
    }
}
