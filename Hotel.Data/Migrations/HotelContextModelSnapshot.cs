﻿// <auto-generated />
using System;
using Hotel.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotel.Data.Migrations
{
    [DbContext(typeof(HotelContext))]
    partial class HotelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hotel.Data.Data.Atractions.Atraction", b =>
                {
                    b.Property<int>("IdAtrakcji")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAtrakcji"));

                    b.Property<decimal>("Cena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("HomePageId")
                        .HasColumnType("int");

                    b.Property<int?>("MediaId")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdAtrakcji");

                    b.HasIndex("HomePageId");

                    b.HasIndex("MediaId");

                    b.ToTable("Atraction");
                });

            modelBuilder.Entity("Hotel.Data.Data.CMS.HomePage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BannerId")
                        .HasColumnType("int");

                    b.Property<int?>("GrafikaId")
                        .HasColumnType("int");

                    b.Property<string>("Naglowek")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tagi")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("BannerId");

                    b.HasIndex("GrafikaId");

                    b.ToTable("HomePage");
                });

            modelBuilder.Entity("Hotel.Data.Data.CMS.Media", b =>
                {
                    b.Property<int>("IdMedia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedia"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("PageIdStrony")
                        .HasColumnType("int");

                    b.Property<string>("RelatedObjectType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMedia");

                    b.HasIndex("PageIdStrony");

                    b.ToTable("Media");
                });

            modelBuilder.Entity("Hotel.Data.Data.CMS.Page", b =>
                {
                    b.Property<int>("IdStrony")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStrony"));

                    b.Property<string>("LinkTytul")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Pozycja")
                        .HasColumnType("int");

                    b.Property<string>("Tresc")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdStrony");

                    b.ToTable("Page");
                });

            modelBuilder.Entity("Hotel.Data.Data.Messages.Message", b =>
                {
                    b.Property<int>("IdWiadomosci")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdWiadomosci"));

                    b.Property<DateTime>("DataWyslania")
                        .HasColumnType("datetime2");

                    b.Property<string>("Temat")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Tresc")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdWiadomosci");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("Hotel.Data.Data.Reservations.Reservation", b =>
                {
                    b.Property<int>("IdRezerwacji")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRezerwacji"));

                    b.Property<DateTime>("DataRozpoczecia")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataZakonczenia")
                        .HasColumnType("datetime2");

                    b.Property<string>("TypRezerwacji")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UserIdUzytkownika")
                        .HasColumnType("int");

                    b.Property<int>("UzytkownikId")
                        .HasColumnType("int");

                    b.HasKey("IdRezerwacji");

                    b.HasIndex("UserIdUzytkownika");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("Hotel.Data.Data.Rooms.Room", b =>
                {
                    b.Property<int>("IdPokoju")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPokoju"));

                    b.Property<decimal>("Cena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("HomePageId")
                        .HasColumnType("int");

                    b.Property<int>("LiczbaOsob")
                        .HasColumnType("int");

                    b.Property<int?>("MediaId")
                        .HasColumnType("int");

                    b.Property<int>("Numer")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Typ")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdPokoju");

                    b.HasIndex("HomePageId");

                    b.HasIndex("MediaId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("Hotel.Data.Data.Users.User", b =>
                {
                    b.Property<int>("IdUzytkownika")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUzytkownika"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Haslo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Rola")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUzytkownika");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Hotel.Data.Data.Users.UserMessages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.Property<int>("RecipientId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("UserMessages");
                });

            modelBuilder.Entity("Hotel.Data.Data.Atractions.Atraction", b =>
                {
                    b.HasOne("Hotel.Data.Data.CMS.HomePage", "HomePage")
                        .WithMany("Atrakcje")
                        .HasForeignKey("HomePageId");

                    b.HasOne("Hotel.Data.Data.CMS.Media", "Media")
                        .WithMany("Atractions")
                        .HasForeignKey("MediaId");

                    b.Navigation("HomePage");

                    b.Navigation("Media");
                });

            modelBuilder.Entity("Hotel.Data.Data.CMS.HomePage", b =>
                {
                    b.HasOne("Hotel.Data.Data.CMS.Media", "Banner")
                        .WithMany()
                        .HasForeignKey("BannerId");

                    b.HasOne("Hotel.Data.Data.CMS.Media", "Grafika")
                        .WithMany()
                        .HasForeignKey("GrafikaId");

                    b.Navigation("Banner");

                    b.Navigation("Grafika");
                });

            modelBuilder.Entity("Hotel.Data.Data.CMS.Media", b =>
                {
                    b.HasOne("Hotel.Data.Data.CMS.Page", null)
                        .WithMany("MediaFiles")
                        .HasForeignKey("PageIdStrony");
                });

            modelBuilder.Entity("Hotel.Data.Data.Reservations.Reservation", b =>
                {
                    b.HasOne("Hotel.Data.Data.Users.User", null)
                        .WithMany("Rezerwacje")
                        .HasForeignKey("UserIdUzytkownika");
                });

            modelBuilder.Entity("Hotel.Data.Data.Rooms.Room", b =>
                {
                    b.HasOne("Hotel.Data.Data.CMS.HomePage", "HomePage")
                        .WithMany("Pokoje")
                        .HasForeignKey("HomePageId");

                    b.HasOne("Hotel.Data.Data.CMS.Media", "Media")
                        .WithMany("Rooms")
                        .HasForeignKey("MediaId");

                    b.Navigation("HomePage");

                    b.Navigation("Media");
                });

            modelBuilder.Entity("Hotel.Data.Data.Users.UserMessages", b =>
                {
                    b.HasOne("Hotel.Data.Data.Messages.Message", "Message")
                        .WithMany("UserMessages")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Hotel.Data.Data.Users.User", "Recipient")
                        .WithMany("ReceivedMessages")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Hotel.Data.Data.Users.User", "Sender")
                        .WithMany("SentMessages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Message");

                    b.Navigation("Recipient");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Hotel.Data.Data.CMS.HomePage", b =>
                {
                    b.Navigation("Atrakcje");

                    b.Navigation("Pokoje");
                });

            modelBuilder.Entity("Hotel.Data.Data.CMS.Media", b =>
                {
                    b.Navigation("Atractions");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Hotel.Data.Data.CMS.Page", b =>
                {
                    b.Navigation("MediaFiles");
                });

            modelBuilder.Entity("Hotel.Data.Data.Messages.Message", b =>
                {
                    b.Navigation("UserMessages");
                });

            modelBuilder.Entity("Hotel.Data.Data.Users.User", b =>
                {
                    b.Navigation("ReceivedMessages");

                    b.Navigation("Rezerwacje");

                    b.Navigation("SentMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
