﻿// <auto-generated />
using System;
using Data.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Core.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CompanyDeveloper", b =>
                {
                    b.Property<Guid>("CompaniesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DevelopersId")
                        .HasColumnType("uuid");

                    b.HasKey("CompaniesId", "DevelopersId");

                    b.HasIndex("DevelopersId");

                    b.ToTable("CompanyDeveloper");
                });

            modelBuilder.Entity("CompanyTag", b =>
                {
                    b.Property<Guid>("CompaniesId")
                        .HasColumnType("uuid");

                    b.Property<int>("TagsId")
                        .HasColumnType("integer");

                    b.HasKey("CompaniesId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("CompanyTag");
                });

            modelBuilder.Entity("DeveloperProject", b =>
                {
                    b.Property<Guid>("DevelopersId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProjectsId")
                        .HasColumnType("uuid");

                    b.HasKey("DevelopersId", "ProjectsId");

                    b.HasIndex("ProjectsId");

                    b.ToTable("DeveloperProject");
                });

            modelBuilder.Entity("DeveloperTag", b =>
                {
                    b.Property<Guid>("DevelopersId")
                        .HasColumnType("uuid");

                    b.Property<int>("TagsId")
                        .HasColumnType("integer");

                    b.HasKey("DevelopersId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("DeveloperTag");
                });

            modelBuilder.Entity("Domain.Content.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("DeveloperId")
                        .HasColumnType("uuid");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Domain.Content.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("DeveloperId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<int>("RequiredSubscriptionLevelId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("RequiredSubscriptionLevelId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Domain.Developers.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Domain.Developers.Entities.Developer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("Domain.Developers.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Domain.Developers.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Domain.Payments.Entities.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("integer");

                    b.Property<int>("WalletId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionId");

                    b.HasIndex("WalletId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("Domain.Payments.Entities.Replenishment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<int>("WalletId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WalletId");

                    b.ToTable("Replenishments");
                });

            modelBuilder.Entity("Domain.Payments.Entities.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<Guid>("DeveloperId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("Domain.Payments.Entities.Withdrawal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<int>("WalletId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WalletId");

                    b.ToTable("Withdrawals");
                });

            modelBuilder.Entity("Domain.Subscriptions.Entities.SubscriptionLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SubscriptionLevels");
                });

            modelBuilder.Entity("Domain.Subscriptions.Entities.Subscriptions.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsAutoRenewal")
                        .HasColumnType("boolean");

                    b.Property<Guid>("SubscriberId")
                        .HasColumnType("uuid");

                    b.Property<int>("TariffId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubscriberId");

                    b.HasIndex("TariffId");

                    b.ToTable("Subscription");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Subscription");
                });

            modelBuilder.Entity("Domain.Subscriptions.Entities.Tariff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PricePerMonth")
                        .HasColumnType("integer");

                    b.Property<int>("SubscriptionLevelId")
                        .HasColumnType("integer");

                    b.Property<int>("SubscriptionType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionLevelId");

                    b.ToTable("Tariffs");
                });

            modelBuilder.Entity("ProjectTag", b =>
                {
                    b.Property<Guid>("ProjectsId")
                        .HasColumnType("uuid");

                    b.Property<int>("TagsId")
                        .HasColumnType("integer");

                    b.HasKey("ProjectsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("ProjectTag");
                });

            modelBuilder.Entity("Domain.Subscriptions.Entities.Subscriptions.CompanySubscription", b =>
                {
                    b.HasBaseType("Domain.Subscriptions.Entities.Subscriptions.Subscription");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.HasIndex("CompanyId");

                    b.HasDiscriminator().HasValue("CompanySubscription");
                });

            modelBuilder.Entity("Domain.Subscriptions.Entities.Subscriptions.DeveloperSubscription", b =>
                {
                    b.HasBaseType("Domain.Subscriptions.Entities.Subscriptions.Subscription");

                    b.Property<Guid>("DeveloperId")
                        .HasColumnType("uuid");

                    b.HasIndex("DeveloperId");

                    b.HasDiscriminator().HasValue("DeveloperSubscription");
                });

            modelBuilder.Entity("Domain.Subscriptions.Entities.Subscriptions.ProjectSubscription", b =>
                {
                    b.HasBaseType("Domain.Subscriptions.Entities.Subscriptions.Subscription");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.HasIndex("ProjectId");

                    b.HasDiscriminator().HasValue("ProjectSubscription");
                });

            modelBuilder.Entity("CompanyDeveloper", b =>
                {
                    b.HasOne("Domain.Developers.Entities.Company", null)
                        .WithMany()
                        .HasForeignKey("CompaniesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Developers.Entities.Developer", null)
                        .WithMany()
                        .HasForeignKey("DevelopersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CompanyTag", b =>
                {
                    b.HasOne("Domain.Developers.Entities.Company", null)
                        .WithMany()
                        .HasForeignKey("CompaniesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Developers.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeveloperProject", b =>
                {
                    b.HasOne("Domain.Developers.Entities.Developer", null)
                        .WithMany()
                        .HasForeignKey("DevelopersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Developers.Entities.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeveloperTag", b =>
                {
                    b.HasOne("Domain.Developers.Entities.Developer", null)
                        .WithMany()
                        .HasForeignKey("DevelopersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Developers.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Content.Entities.Comment", b =>
                {
                    b.HasOne("Domain.Developers.Entities.Developer", "Developer")
                        .WithMany()
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Content.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Domain.Content.Entities.Post", b =>
                {
                    b.HasOne("Domain.Developers.Entities.Developer", "Developer")
                        .WithMany()
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Developers.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Subscriptions.Entities.SubscriptionLevel", "RequiredSubscriptionLevel")
                        .WithMany()
                        .HasForeignKey("RequiredSubscriptionLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");

                    b.Navigation("Project");

                    b.Navigation("RequiredSubscriptionLevel");
                });

            modelBuilder.Entity("Domain.Developers.Entities.Project", b =>
                {
                    b.HasOne("Domain.Developers.Entities.Company", "Company")
                        .WithMany("Projects")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Domain.Payments.Entities.Bill", b =>
                {
                    b.HasOne("Domain.Subscriptions.Entities.Subscriptions.Subscription", "Subscription")
                        .WithMany()
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Payments.Entities.Wallet", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("Domain.Payments.Entities.Replenishment", b =>
                {
                    b.HasOne("Domain.Payments.Entities.Wallet", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("Domain.Payments.Entities.Wallet", b =>
                {
                    b.HasOne("Domain.Developers.Entities.Developer", "Developer")
                        .WithMany()
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");
                });

            modelBuilder.Entity("Domain.Payments.Entities.Withdrawal", b =>
                {
                    b.HasOne("Domain.Payments.Entities.Wallet", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("Domain.Subscriptions.Entities.Subscriptions.Subscription", b =>
                {
                    b.HasOne("Domain.Developers.Entities.Developer", "Subscriber")
                        .WithMany()
                        .HasForeignKey("SubscriberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Subscriptions.Entities.Tariff", "Tariff")
                        .WithMany()
                        .HasForeignKey("TariffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscriber");

                    b.Navigation("Tariff");
                });

            modelBuilder.Entity("Domain.Subscriptions.Entities.Tariff", b =>
                {
                    b.HasOne("Domain.Subscriptions.Entities.SubscriptionLevel", "SubscriptionLevel")
                        .WithMany()
                        .HasForeignKey("SubscriptionLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubscriptionLevel");
                });

            modelBuilder.Entity("ProjectTag", b =>
                {
                    b.HasOne("Domain.Developers.Entities.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Developers.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Subscriptions.Entities.Subscriptions.CompanySubscription", b =>
                {
                    b.HasOne("Domain.Developers.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Domain.Subscriptions.Entities.Subscriptions.DeveloperSubscription", b =>
                {
                    b.HasOne("Domain.Developers.Entities.Developer", "Developer")
                        .WithMany()
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");
                });

            modelBuilder.Entity("Domain.Subscriptions.Entities.Subscriptions.ProjectSubscription", b =>
                {
                    b.HasOne("Domain.Developers.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Domain.Content.Entities.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Domain.Developers.Entities.Company", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
