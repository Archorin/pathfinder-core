﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Storage.Internal;
using PathfinderCore.Contexts;
using System;

namespace PathfinderCore.Migrations
{
    [DbContext(typeof(PathfinderContext))]
    [Migration("20180203231224_utilisateur")]
    partial class utilisateur
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("PathfinderCore.Models.Alignement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Nom")
                        .HasColumnName("nom")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("alignement");
                });

            modelBuilder.Entity("PathfinderCore.Models.Caracteristique", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("nom_court")
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnName("nom")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("caracteristique");
                });

            modelBuilder.Entity("PathfinderCore.Models.Classe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BBAId")
                        .HasColumnName("bba");

                    b.Property<int>("DVId")
                        .HasColumnName("dv");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnName("nom")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("OuvrageId")
                        .HasColumnName("ouvrage");

                    b.Property<int>("ReflexeId")
                        .HasColumnName("reflexe");

                    b.Property<int>("VigueurId")
                        .HasColumnName("vigueur");

                    b.Property<int>("VolonteId")
                        .HasColumnName("volonte");

                    b.HasKey("Id");

                    b.HasIndex("BBAId");

                    b.HasIndex("DVId");

                    b.HasIndex("OuvrageId");

                    b.HasIndex("ReflexeId");

                    b.HasIndex("VigueurId");

                    b.HasIndex("VolonteId");

                    b.ToTable("classe");
                });

            modelBuilder.Entity("PathfinderCore.Models.ClasseAlignement", b =>
                {
                    b.Property<int>("ClasseId")
                        .HasColumnName("classe_id");

                    b.Property<int>("AlignementId")
                        .HasColumnName("alignement_id");

                    b.HasKey("ClasseId", "AlignementId");

                    b.HasIndex("AlignementId");

                    b.ToTable("classe_alignement");
                });

            modelBuilder.Entity("PathfinderCore.Models.Competence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("CaracteristiqueId")
                        .HasColumnName("caracteristique");

                    b.Property<string>("CaracteristiqueId1");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnName("nom")
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("PenaliteArmure")
                        .HasColumnName("penalite_armure")
                        .HasColumnType("bit");

                    b.Property<bool>("SansFormation")
                        .HasColumnName("sans_formation")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CaracteristiqueId1");

                    b.ToTable("competence");
                });

            modelBuilder.Entity("PathfinderCore.Models.Courbe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nom")
                        .HasColumnName("nom")
                        .HasColumnType("varchar(16)");

                    b.HasKey("Id");

                    b.ToTable("courbe");
                });

            modelBuilder.Entity("PathfinderCore.Models.Don", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.HasKey("Id");

                    b.ToTable("don");
                });

            modelBuilder.Entity("PathfinderCore.Models.DV", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer");

                    b.Property<string>("Nom")
                        .HasColumnName("nom")
                        .HasColumnType("varchar(3)");

                    b.HasKey("Id");

                    b.ToTable("dv");
                });

            modelBuilder.Entity("PathfinderCore.Models.Ouvrage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnName("nom")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NomSlug")
                        .HasColumnName("nom_slug")
                        .HasColumnType("varchar(5)");

                    b.HasKey("Id");

                    b.ToTable("ouvrage");
                });

            modelBuilder.Entity("PathfinderCore.Models.Personnage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnName("nom")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("personnage");
                });

            modelBuilder.Entity("PathfinderCore.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer");

                    b.Property<string>("AlignementReligion")
                        .HasColumnName("alignement_religion")
                        .HasColumnType("text");

                    b.Property<string>("Aventurier")
                        .HasColumnName("aventurier")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<string>("DescriptionPhysique")
                        .HasColumnName("description_physique")
                        .HasColumnType("text");

                    b.Property<string>("DescriptionPlus")
                        .HasColumnName("description_plus")
                        .HasColumnType("text");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnName("nom")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NomSlug")
                        .HasColumnName("nom_slug")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("OuvrageId")
                        .HasColumnName("ouvrage");

                    b.Property<string>("Relation")
                        .HasColumnName("relation")
                        .HasColumnType("text");

                    b.Property<string>("Societe")
                        .HasColumnName("societe")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OuvrageId");

                    b.ToTable("race");
                });

            modelBuilder.Entity("PathfinderCore.Models.Special", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.HasKey("Id");

                    b.ToTable("special");
                });

            modelBuilder.Entity("PathfinderCore.Models.Statistique", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("CourbeId")
                        .HasColumnName("courbe");

                    b.Property<int>("Niveau")
                        .HasColumnName("niveau")
                        .HasColumnType("tinyint");

                    b.Property<int>("Valeur")
                        .HasColumnName("valeur")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("CourbeId");

                    b.ToTable("statistique");
                });

            modelBuilder.Entity("PathfinderCore.Models.Utilisateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnName("login")
                        .HasColumnType("varchar(50)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnName("password_hash")
                        .HasColumnType("Binary")
                        .HasMaxLength(256);

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnName("password_salt")
                        .HasColumnType("Binary")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("utilisateur");
                });

            modelBuilder.Entity("PathfinderCore.Models.Classe", b =>
                {
                    b.HasOne("PathfinderCore.Models.Courbe", "BBA")
                        .WithMany()
                        .HasForeignKey("BBAId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PathfinderCore.Models.DV", "DV")
                        .WithMany("Classes")
                        .HasForeignKey("DVId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PathfinderCore.Models.Ouvrage", "Ouvrage")
                        .WithMany()
                        .HasForeignKey("OuvrageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PathfinderCore.Models.Courbe", "Reflexe")
                        .WithMany()
                        .HasForeignKey("ReflexeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PathfinderCore.Models.Courbe", "Vigueur")
                        .WithMany()
                        .HasForeignKey("VigueurId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PathfinderCore.Models.Courbe", "Volonte")
                        .WithMany()
                        .HasForeignKey("VolonteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PathfinderCore.Models.ClasseAlignement", b =>
                {
                    b.HasOne("PathfinderCore.Models.Alignement", "Alignement")
                        .WithMany("ClasseAlignements")
                        .HasForeignKey("AlignementId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PathfinderCore.Models.Classe", "Classe")
                        .WithMany("ClasseAlignements")
                        .HasForeignKey("ClasseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PathfinderCore.Models.Competence", b =>
                {
                    b.HasOne("PathfinderCore.Models.Caracteristique", "Caracteristique")
                        .WithMany("Competences")
                        .HasForeignKey("CaracteristiqueId1");
                });

            modelBuilder.Entity("PathfinderCore.Models.Race", b =>
                {
                    b.HasOne("PathfinderCore.Models.Ouvrage", "Ouvrage")
                        .WithMany("Races")
                        .HasForeignKey("OuvrageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PathfinderCore.Models.Statistique", b =>
                {
                    b.HasOne("PathfinderCore.Models.Courbe", "Courbe")
                        .WithMany("Statistiques")
                        .HasForeignKey("CourbeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
