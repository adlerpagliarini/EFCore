﻿// <auto-generated />
using System;
using EFCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCore.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-rc.1.20451.13");

            modelBuilder.Entity("EFCore.Domain.Developers.Developer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DevType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Developer");
                });

            modelBuilder.Entity("EFCore.Domain.Motivations.Motivation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("DeveloperId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Factor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId")
                        .IsUnique()
                        .HasFilter("[DeveloperId] IS NOT NULL");

                    b.ToTable("Motivation");
                });

            modelBuilder.Entity("EFCore.Domain.Tasks.Skill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("EFCore.Domain.Tasks.SkillTaskToDo", b =>
                {
                    b.Property<long>("SkillsId")
                        .HasColumnType("bigint");

                    b.Property<long>("TasksToDoId")
                        .HasColumnType("bigint");

                    b.HasKey("SkillsId", "TasksToDoId");

                    b.HasIndex("TasksToDoId");

                    b.ToTable("SkillTaskToDo");
                });

            modelBuilder.Entity("EFCore.Domain.Tasks.TaskToDo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DeadLine")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeveloperId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.ToTable("TaskToDo");
                });

            modelBuilder.Entity("EFCore.Domain.Developers.BackEndDeveloper", b =>
                {
                    b.HasBaseType("EFCore.Domain.Developers.Developer");

                    b.Property<string>("DatabasePreference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DatabaseStack")
                        .HasColumnType("bit");

                    b.ToTable("BackEndDeveloper");
                });

            modelBuilder.Entity("EFCore.Domain.Developers.FrontEndDeveloper", b =>
                {
                    b.HasBaseType("EFCore.Domain.Developers.Developer");

                    b.Property<string>("FrameworkPreference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MobileStack")
                        .HasColumnType("bit");

                    b.ToTable("FrontEndDeveloper");
                });

            modelBuilder.Entity("EFCore.Domain.Developers.FullStackDeveloper", b =>
                {
                    b.HasBaseType("EFCore.Domain.Developers.Developer");

                    b.Property<string>("CloudPreference")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("FullStackDeveloper");
                });

            modelBuilder.Entity("EFCore.Domain.Motivations.Motivation", b =>
                {
                    b.HasOne("EFCore.Domain.Developers.Developer", null)
                        .WithOne("Motivation")
                        .HasForeignKey("EFCore.Domain.Motivations.Motivation", "DeveloperId");
                });

            modelBuilder.Entity("EFCore.Domain.Tasks.SkillTaskToDo", b =>
                {
                    b.HasOne("EFCore.Domain.Tasks.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCore.Domain.Tasks.TaskToDo", "TaskToDo")
                        .WithMany()
                        .HasForeignKey("TasksToDoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");

                    b.Navigation("TaskToDo");
                });

            modelBuilder.Entity("EFCore.Domain.Tasks.TaskToDo", b =>
                {
                    b.HasOne("EFCore.Domain.Developers.Developer", null)
                        .WithMany("TasksToDo")
                        .HasForeignKey("DeveloperId");
                });

            modelBuilder.Entity("EFCore.Domain.Developers.BackEndDeveloper", b =>
                {
                    b.HasOne("EFCore.Domain.Developers.Developer", null)
                        .WithOne()
                        .HasForeignKey("EFCore.Domain.Developers.BackEndDeveloper", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCore.Domain.Developers.FrontEndDeveloper", b =>
                {
                    b.HasOne("EFCore.Domain.Developers.Developer", null)
                        .WithOne()
                        .HasForeignKey("EFCore.Domain.Developers.FrontEndDeveloper", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCore.Domain.Developers.FullStackDeveloper", b =>
                {
                    b.HasOne("EFCore.Domain.Developers.Developer", null)
                        .WithOne()
                        .HasForeignKey("EFCore.Domain.Developers.FullStackDeveloper", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.OwnsOne("EFCore.Domain.Motivations.ExtraMotivation", "ExtraMotivation", b1 =>
                        {
                            b1.Property<string>("FullStackDeveloperId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Factor")
                                .HasColumnType("varchar(50)");

                            b1.HasKey("FullStackDeveloperId");

                            b1.ToTable("FullStackDeveloper");

                            b1.WithOwner()
                                .HasForeignKey("FullStackDeveloperId");
                        });

                    b.Navigation("ExtraMotivation");
                });

            modelBuilder.Entity("EFCore.Domain.Developers.Developer", b =>
                {
                    b.Navigation("Motivation");

                    b.Navigation("TasksToDo");
                });
#pragma warning restore 612, 618
        }
    }
}
