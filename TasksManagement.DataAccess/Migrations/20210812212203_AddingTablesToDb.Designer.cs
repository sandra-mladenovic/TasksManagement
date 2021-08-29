﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TasksManagement.DataAccess;

namespace TasksManagement.DataAccess.Migrations
{
    [DbContext(typeof(TasksManagementContext))]
    [Migration("20210812212203_AddingTablesToDb")]
    partial class AddingTablesToDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TasksManagement.Domain.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Progress")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("StatusTypeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StatusTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("TasksManagement.Domain.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "OBS",
                            CreatedAt = new DateTime(2021, 8, 12, 23, 22, 2, 903, DateTimeKind.Local).AddTicks(5960),
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Online Book Store"
                        },
                        new
                        {
                            Id = 2,
                            Code = "OLP",
                            CreatedAt = new DateTime(2021, 8, 12, 23, 22, 2, 903, DateTimeKind.Local).AddTicks(6137),
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Online Language Platform"
                        },
                        new
                        {
                            Id = 3,
                            Code = "SWS",
                            CreatedAt = new DateTime(2021, 8, 12, 23, 22, 2, 903, DateTimeKind.Local).AddTicks(6152),
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Shoes web shop"
                        });
                });

            modelBuilder.Entity("TasksManagement.Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 8, 12, 23, 22, 2, 900, DateTimeKind.Local).AddTicks(8851),
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Developer"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 8, 12, 23, 22, 2, 903, DateTimeKind.Local).AddTicks(2583),
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Project Manager"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2021, 8, 12, 23, 22, 2, 903, DateTimeKind.Local).AddTicks(2622),
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Administrator"
                        });
                });

            modelBuilder.Entity("TasksManagement.Domain.StatusType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("StatusTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 8, 12, 23, 22, 2, 903, DateTimeKind.Local).AddTicks(5424),
                            IsActive = false,
                            IsDeleted = false,
                            Name = "new"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 8, 12, 23, 22, 2, 903, DateTimeKind.Local).AddTicks(5480),
                            IsActive = false,
                            IsDeleted = false,
                            Name = "in progress"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2021, 8, 12, 23, 22, 2, 903, DateTimeKind.Local).AddTicks(5485),
                            IsActive = false,
                            IsDeleted = false,
                            Name = "finished"
                        });
                });

            modelBuilder.Entity("TasksManagement.Domain.UseCaseLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Actor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("UseCaseName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UseCaseLogs");
                });

            modelBuilder.Entity("TasksManagement.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 8, 12, 23, 22, 2, 903, DateTimeKind.Local).AddTicks(3048),
                            Email = "pera@gmail.com",
                            FirstName = "Pera",
                            IsActive = false,
                            IsDeleted = false,
                            LastName = "Peric",
                            Password = "sifra1",
                            RoleId = 1,
                            Username = "perica"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 8, 12, 23, 22, 2, 903, DateTimeKind.Local).AddTicks(4050),
                            Email = "marcosswill@gmail.com",
                            FirstName = "Marcos",
                            IsActive = false,
                            IsDeleted = false,
                            LastName = "Swill",
                            Password = "sifra1",
                            RoleId = 2,
                            Username = "marcosswill"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2021, 8, 12, 23, 22, 2, 903, DateTimeKind.Local).AddTicks(4104),
                            Email = "linabrown@gmail.com",
                            FirstName = "Lina",
                            IsActive = false,
                            IsDeleted = false,
                            LastName = "Brown",
                            Password = "sifra1",
                            RoleId = 3,
                            Username = "linabrown"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2021, 8, 12, 23, 22, 2, 903, DateTimeKind.Local).AddTicks(4108),
                            Email = "sandra@gmail.com",
                            FirstName = "Sandra",
                            IsActive = false,
                            IsDeleted = false,
                            LastName = "Mladenovic",
                            Password = "sifra1",
                            RoleId = 2,
                            Username = "sandra"
                        });
                });

            modelBuilder.Entity("TasksManagement.Domain.UserUseCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UseCaseId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserUseCases");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UseCaseId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            UseCaseId = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            UseCaseId = 3,
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            UseCaseId = 4,
                            UserId = 1
                        },
                        new
                        {
                            Id = 5,
                            UseCaseId = 5,
                            UserId = 1
                        },
                        new
                        {
                            Id = 6,
                            UseCaseId = 6,
                            UserId = 1
                        },
                        new
                        {
                            Id = 7,
                            UseCaseId = 7,
                            UserId = 1
                        },
                        new
                        {
                            Id = 8,
                            UseCaseId = 8,
                            UserId = 1
                        },
                        new
                        {
                            Id = 9,
                            UseCaseId = 9,
                            UserId = 1
                        },
                        new
                        {
                            Id = 10,
                            UseCaseId = 10,
                            UserId = 1
                        },
                        new
                        {
                            Id = 11,
                            UseCaseId = 11,
                            UserId = 1
                        },
                        new
                        {
                            Id = 12,
                            UseCaseId = 12,
                            UserId = 1
                        },
                        new
                        {
                            Id = 13,
                            UseCaseId = 13,
                            UserId = 1
                        },
                        new
                        {
                            Id = 14,
                            UseCaseId = 14,
                            UserId = 1
                        },
                        new
                        {
                            Id = 15,
                            UseCaseId = 15,
                            UserId = 1
                        },
                        new
                        {
                            Id = 16,
                            UseCaseId = 16,
                            UserId = 1
                        },
                        new
                        {
                            Id = 17,
                            UseCaseId = 17,
                            UserId = 1
                        },
                        new
                        {
                            Id = 18,
                            UseCaseId = 18,
                            UserId = 1
                        },
                        new
                        {
                            Id = 19,
                            UseCaseId = 19,
                            UserId = 1
                        },
                        new
                        {
                            Id = 20,
                            UseCaseId = 20,
                            UserId = 1
                        },
                        new
                        {
                            Id = 21,
                            UseCaseId = 21,
                            UserId = 1
                        },
                        new
                        {
                            Id = 22,
                            UseCaseId = 22,
                            UserId = 1
                        },
                        new
                        {
                            Id = 23,
                            UseCaseId = 23,
                            UserId = 1
                        },
                        new
                        {
                            Id = 24,
                            UseCaseId = 24,
                            UserId = 1
                        },
                        new
                        {
                            Id = 25,
                            UseCaseId = 25,
                            UserId = 1
                        },
                        new
                        {
                            Id = 26,
                            UseCaseId = 26,
                            UserId = 1
                        },
                        new
                        {
                            Id = 27,
                            UseCaseId = 27,
                            UserId = 1
                        },
                        new
                        {
                            Id = 28,
                            UseCaseId = 28,
                            UserId = 1
                        },
                        new
                        {
                            Id = 29,
                            UseCaseId = 29,
                            UserId = 1
                        },
                        new
                        {
                            Id = 30,
                            UseCaseId = 30,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("TasksManagement.Domain.Assignment", b =>
                {
                    b.HasOne("TasksManagement.Domain.Project", "Project")
                        .WithMany("Assignments")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TasksManagement.Domain.StatusType", "StatusType")
                        .WithMany("Assignments")
                        .HasForeignKey("StatusTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TasksManagement.Domain.User", "User")
                        .WithMany("Assignments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("StatusType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TasksManagement.Domain.User", b =>
                {
                    b.HasOne("TasksManagement.Domain.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TasksManagement.Domain.UserUseCase", b =>
                {
                    b.HasOne("TasksManagement.Domain.User", "User")
                        .WithMany("UserUserCases")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TasksManagement.Domain.Project", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("TasksManagement.Domain.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("TasksManagement.Domain.StatusType", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("TasksManagement.Domain.User", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("UserUserCases");
                });
#pragma warning restore 612, 618
        }
    }
}
