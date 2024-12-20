﻿// <auto-generated />
using System;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241215161455_init_mig_1")]
    partial class init_mig_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Library.Domain.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Library.Domain.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Library.Domain.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("AvailableCopies")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<int>("PublicationYear")
                        .HasColumnType("int");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("74e72687-c0a6-4647-b8ac-c1a47ed8edcc"),
                            Author = "Ömer Yılmaz",
                            AvailableCopies = 5,
                            Genre = "bilim kurgu",
                            ISBN = "1234",
                            Language = "ingilizce",
                            PageCount = 305,
                            PublicationYear = 2015,
                            Publisher = "Bilim Yayınları",
                            Summary = "bilim kitabı",
                            Title = "Zamanın Ötesinde"
                        },
                        new
                        {
                            Id = new Guid("eab9390a-923c-48b3-bd0c-4a5bb394dd33"),
                            Author = "Ebru Kaya",
                            AvailableCopies = 2,
                            Genre = "romantik",
                            ISBN = "9876",
                            Language = "fransızca",
                            PageCount = 192,
                            PublicationYear = 2000,
                            Publisher = "Bilim Yayınları",
                            Summary = "unutulmaz bir hikaye",
                            Title = "Bir Yaz Günü"
                        },
                        new
                        {
                            Id = new Guid("9e76346e-5f62-4235-bbf4-c5f87c7a45ac"),
                            Author = "Mehmet Takın",
                            AvailableCopies = 12,
                            Genre = "macera",
                            ISBN = "5678",
                            Language = "türkçe",
                            PageCount = 467,
                            PublicationYear = 2010,
                            Publisher = "Bilim Yayınları",
                            Summary = "Zirve Yolunda kitabı",
                            Title = "Zirve Yolunda"
                        },
                        new
                        {
                            Id = new Guid("e98bf410-0c53-46ae-90fb-eba323bad355"),
                            Author = "Elif Aksu",
                            AvailableCopies = 8,
                            Genre = "felsefe",
                            ISBN = "3456",
                            Language = "almanca",
                            PageCount = 210,
                            PublicationYear = 1998,
                            Publisher = "Bilim Yayınları",
                            Summary = "Hayatın anlamına dair derin bir sorgulama",
                            Title = "Sefiller"
                        },
                        new
                        {
                            Id = new Guid("946d30a3-9ea2-4cc7-ab49-0b9e2edab884"),
                            Author = "Berk Can",
                            AvailableCopies = 7,
                            Genre = "korku",
                            ISBN = "1111",
                            Language = "italyanca",
                            PageCount = 333,
                            PublicationYear = 2022,
                            Publisher = "Bilim Yayınları",
                            Summary = "Clean architecture kitabı",
                            Title = "Clean Architecture"
                        },
                        new
                        {
                            Id = new Guid("40de6ae3-5125-44e8-9593-4261b37d7cd0"),
                            Author = "Zeynep Yılmaz",
                            AvailableCopies = 0,
                            Genre = "biyografi",
                            ISBN = "2222",
                            Language = "ispanyolca",
                            PageCount = 654,
                            PublicationYear = 1995,
                            Publisher = "Hayat Yayınları",
                            Summary = "YAzılımcıya çok güzel şeyler katan bir kitap",
                            Title = "Pragmatic Programmer"
                        },
                        new
                        {
                            Id = new Guid("b8a1acb7-fa64-4052-b4e2-dd69bffe1841"),
                            Author = "Ali Deniz",
                            AvailableCopies = 15,
                            Genre = "fantastik",
                            ISBN = "4444",
                            Language = "japonca",
                            PageCount = 532,
                            PublicationYear = 2018,
                            Publisher = "Bilim Yayınları",
                            Summary = "DDD prensibinin genel anlatımı",
                            Title = "Learning DDD"
                        },
                        new
                        {
                            Id = new Guid("8b8b0074-5830-4735-a6a8-7088b8d51f06"),
                            Author = "Merve Koç",
                            AvailableCopies = 6,
                            Genre = "tarih",
                            ISBN = "3333",
                            Language = "arapça",
                            PageCount = 423,
                            PublicationYear = 2011,
                            Publisher = "Bilim Yayınları",
                            Summary = "Billim kurgu çok güzel bir kitap",
                            Title = "Dune"
                        },
                        new
                        {
                            Id = new Guid("4834d9cd-1443-40ac-aefc-39127340662e"),
                            Author = "Burak Efe",
                            AvailableCopies = 3,
                            Genre = "dedektif",
                            ISBN = "8888",
                            Language = "rusça",
                            PageCount = 280,
                            PublicationYear = 2020,
                            Publisher = "Bilim Yayınları",
                            Summary = "Hababam Sınıfı hikayeleri",
                            Title = "Hababam Sınıfı"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Library.Domain.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Library.Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Library.Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Library.Domain.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Library.Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
