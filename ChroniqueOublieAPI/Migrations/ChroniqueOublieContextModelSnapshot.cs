﻿// <auto-generated />
using ChroniqueOublieAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Storage.Internal;
using System;

namespace ChroniqueOublieAPI.Migrations
{
    [DbContext(typeof(ChroniqueOublieContext))]
    partial class ChroniqueOublieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("ChroniqueOublieAPI.Models.Maitrise.MaitriseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnName("libelle")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Niveau")
                        .IsRequired()
                        .HasColumnName("niveau")
                        .HasColumnType("varchar(10)");

                    b.Property<int?>("voieId");

                    b.HasKey("Id");

                    b.HasIndex("voieId");

                    b.ToTable("maitrise");
                });

            modelBuilder.Entity("ChroniqueOublieAPI.Models.Maitrise.MaitriseMaitriseType.MaitriseMaitriseTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer");

                    b.Property<int?>("maitriseId");

                    b.Property<int?>("maitriseTypeId");

                    b.HasKey("Id");

                    b.HasIndex("maitriseId");

                    b.HasIndex("maitriseTypeId");

                    b.ToTable("maitrise_maitrise_type");
                });

            modelBuilder.Entity("ChroniqueOublieAPI.Models.Maitrise.Type.MaitriseTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnName("libelle")
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("maitrise_type");
                });

            modelBuilder.Entity("ChroniqueOublieAPI.Models.Voie.Profil.ProfilEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("DescriptionCourte")
                        .IsRequired()
                        .HasColumnName("description_courte")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnName("libelle")
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("profil");
                });

            modelBuilder.Entity("ChroniqueOublieAPI.Models.Voie.Type.VoieTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnName("libelle")
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("voie_type");
                });

            modelBuilder.Entity("ChroniqueOublieAPI.Models.Voie.VoieEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnName("libelle")
                        .HasColumnType("varchar(10)");

                    b.Property<int?>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("voie");
                });

            modelBuilder.Entity("ChroniqueOublieAPI.Models.Voie.VoieProfil.VoieProfilEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("voieId")
                        .HasColumnName("id_voie");

                    b.HasKey("Id");

                    b.HasIndex("voieId");

                    b.ToTable("voie_profil");
                });

            modelBuilder.Entity("ChroniqueOublieAPI.Models.Maitrise.MaitriseEntity", b =>
                {
                    b.HasOne("ChroniqueOublieAPI.Models.Voie.VoieEntity", "voie")
                        .WithMany()
                        .HasForeignKey("voieId");
                });

            modelBuilder.Entity("ChroniqueOublieAPI.Models.Maitrise.MaitriseMaitriseType.MaitriseMaitriseTypeEntity", b =>
                {
                    b.HasOne("ChroniqueOublieAPI.Models.Maitrise.MaitriseEntity", "maitrise")
                        .WithMany()
                        .HasForeignKey("maitriseId");

                    b.HasOne("ChroniqueOublieAPI.Models.Maitrise.Type.MaitriseTypeEntity", "maitriseType")
                        .WithMany()
                        .HasForeignKey("maitriseTypeId");
                });

            modelBuilder.Entity("ChroniqueOublieAPI.Models.Voie.VoieEntity", b =>
                {
                    b.HasOne("ChroniqueOublieAPI.Models.Voie.Type.VoieTypeEntity", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("ChroniqueOublieAPI.Models.Voie.VoieProfil.VoieProfilEntity", b =>
                {
                    b.HasOne("ChroniqueOublieAPI.Models.Voie.VoieEntity", "voie")
                        .WithMany()
                        .HasForeignKey("voieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
