﻿// <auto-generated />
using System;
using FullStackAuth_WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FullStackAuth_WebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231023033841_blogUpdate")]
    partial class blogUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.BlogPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<int?>("UserHomepageId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserHomepageId");

                    b.HasIndex("UserId");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OwnerId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.Friend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<string>("User1Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("User2Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("UserContentId")
                        .HasColumnType("int");

                    b.Property<int?>("UserContentId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("User2Id");

                    b.HasIndex("UserContentId");

                    b.HasIndex("UserContentId1");

                    b.HasIndex("User1Id", "User2Id")
                        .IsUnique();

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.ImageUpload", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<int?>("UserContentId")
                        .HasColumnType("int");

                    b.Property<int?>("UserHomepageId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserContentId");

                    b.HasIndex("UserHomepageId");

                    b.HasIndex("UserId");

                    b.ToTable("ImageUpload");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.ImageUrl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<int?>("BlogPostId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("BlogPostId");

                    b.ToTable("ImageUrl");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsRead")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AnimeId")
                        .HasColumnType("int");

                    b.Property<double>("Rating")
                        .HasColumnType("double");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Text")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<int?>("UserContentId")
                        .HasColumnType("int");

                    b.Property<int?>("UserHomepageId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserContentId");

                    b.HasIndex("UserHomepageId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("FriendId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("FriendId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.UserContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ContentText")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserContents");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.UserHomepage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("UserContentId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserContentId");

                    b.HasIndex("UserId");

                    b.ToTable("UserHomepages");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.ViewedList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AnimeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<int?>("UserContentId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("WasViewed")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("UserContentId");

                    b.HasIndex("UserId");

                    b.ToTable("ViewedLists");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.BlogPost", b =>
                {
                    b.HasOne("FullStackAuth_WebAPI.Models.UserHomepage", null)
                        .WithMany("BlogPosts")
                        .HasForeignKey("UserHomepageId");

                    b.HasOne("FullStackAuth_WebAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.Car", b =>
                {
                    b.HasOne("FullStackAuth_WebAPI.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.Friend", b =>
                {
                    b.HasOne("FullStackAuth_WebAPI.Models.User", "User1")
                        .WithMany()
                        .HasForeignKey("User1Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FullStackAuth_WebAPI.Models.User", "User2")
                        .WithMany()
                        .HasForeignKey("User2Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FullStackAuth_WebAPI.Models.UserContent", null)
                        .WithMany("FriendsAsUser1")
                        .HasForeignKey("UserContentId");

                    b.HasOne("FullStackAuth_WebAPI.Models.UserContent", null)
                        .WithMany("FriendsAsUser2")
                        .HasForeignKey("UserContentId1");

                    b.Navigation("User1");

                    b.Navigation("User2");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.ImageUpload", b =>
                {
                    b.HasOne("FullStackAuth_WebAPI.Models.UserContent", null)
                        .WithMany("Gallery")
                        .HasForeignKey("UserContentId");

                    b.HasOne("FullStackAuth_WebAPI.Models.UserHomepage", null)
                        .WithMany("Gallery")
                        .HasForeignKey("UserHomepageId");

                    b.HasOne("FullStackAuth_WebAPI.Models.User", "User")
                        .WithMany("Gallery")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.ImageUrl", b =>
                {
                    b.HasOne("FullStackAuth_WebAPI.Models.BlogPost", null)
                        .WithMany("ImageUrls")
                        .HasForeignKey("BlogPostId");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.Notification", b =>
                {
                    b.HasOne("FullStackAuth_WebAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.Review", b =>
                {
                    b.HasOne("FullStackAuth_WebAPI.Models.UserContent", null)
                        .WithMany("Reviews")
                        .HasForeignKey("UserContentId");

                    b.HasOne("FullStackAuth_WebAPI.Models.UserHomepage", null)
                        .WithMany("Reviews")
                        .HasForeignKey("UserHomepageId");

                    b.HasOne("FullStackAuth_WebAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.User", b =>
                {
                    b.HasOne("FullStackAuth_WebAPI.Models.User", "Friend")
                        .WithMany()
                        .HasForeignKey("FriendId");

                    b.Navigation("Friend");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.UserContent", b =>
                {
                    b.HasOne("FullStackAuth_WebAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.UserHomepage", b =>
                {
                    b.HasOne("FullStackAuth_WebAPI.Models.UserContent", "UserContent")
                        .WithMany()
                        .HasForeignKey("UserContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullStackAuth_WebAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");

                    b.Navigation("UserContent");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.ViewedList", b =>
                {
                    b.HasOne("FullStackAuth_WebAPI.Models.UserContent", null)
                        .WithMany("ViewedLists")
                        .HasForeignKey("UserContentId");

                    b.HasOne("FullStackAuth_WebAPI.Models.User", "User")
                        .WithMany("ViewedAnimeList")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FullStackAuth_WebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FullStackAuth_WebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullStackAuth_WebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FullStackAuth_WebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.BlogPost", b =>
                {
                    b.Navigation("ImageUrls");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.User", b =>
                {
                    b.Navigation("Gallery");

                    b.Navigation("ViewedAnimeList");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.UserContent", b =>
                {
                    b.Navigation("FriendsAsUser1");

                    b.Navigation("FriendsAsUser2");

                    b.Navigation("Gallery");

                    b.Navigation("Reviews");

                    b.Navigation("ViewedLists");
                });

            modelBuilder.Entity("FullStackAuth_WebAPI.Models.UserHomepage", b =>
                {
                    b.Navigation("BlogPosts");

                    b.Navigation("Gallery");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
