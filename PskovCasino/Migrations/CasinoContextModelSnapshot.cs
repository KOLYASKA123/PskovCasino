﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PskovCasino.MVVM.Model;

#nullable disable

namespace PskovCasino.Migrations
{
    [DbContext(typeof(CasinoContext))]
    partial class CasinoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PskovCasino.MVVM.Model.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ClientStatusID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ClientStatusID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("PskovCasino.MVVM.Model.ClientStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ClientStatuses");
                });

            modelBuilder.Entity("PskovCasino.MVVM.Model.ClientStatusService", b =>
                {
                    b.Property<int>("ClientStatusID")
                        .HasColumnType("int");

                    b.Property<int>("ServiceID")
                        .HasColumnType("int");

                    b.ToTable("ClientStatusServices");
                });

            modelBuilder.Entity("PskovCasino.MVVM.Model.GameParticipant", b =>
                {
                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<int>("GameSessionID")
                        .HasColumnType("int");

                    b.Property<decimal>("InitialPayment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WinPayment")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("GameParticipants");
                });

            modelBuilder.Entity("PskovCasino.MVVM.Model.GameSession", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("GameTypeID")
                        .HasColumnType("int");

                    b.Property<int>("MimimalParticipantsCountToStart")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("GameSessions");
                });

            modelBuilder.Entity("PskovCasino.MVVM.Model.GameType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("GameTypes");
                });

            modelBuilder.Entity("PskovCasino.MVVM.Model.Service", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("PskovCasino.MVVM.Model.Tournament", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("GameSessionID")
                        .HasColumnType("int");

                    b.Property<decimal>("MainPrize")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("PskovCasino.MVVM.Model.Client", b =>
                {
                    b.HasOne("PskovCasino.MVVM.Model.ClientStatus", "ClientStatus")
                        .WithMany("Clients")
                        .HasForeignKey("ClientStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientStatus");
                });

            modelBuilder.Entity("PskovCasino.MVVM.Model.ClientStatus", b =>
                {
                    b.Navigation("Clients");
                });
#pragma warning restore 612, 618
        }
    }
}