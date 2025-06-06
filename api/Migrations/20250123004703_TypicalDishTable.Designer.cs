﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using api;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20250123004703_TypicalDishTable")]
    partial class TypicalDishTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("api.Models.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<int>("DeparmentId")
                        .HasColumnType("integer");

                    b.Property<string>("IataCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("OaciCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("DeparmentId");

                    b.ToTable("Airport", (string)null);
                });

            modelBuilder.Entity("api.Models.CategoryNaturalArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("Id");

                    b.ToTable("CategoryNaturalArea", (string)null);
                });

            modelBuilder.Entity("api.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<float?>("Population")
                        .HasColumnType("real");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<float?>("Surface")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("City", (string)null);
                });

            modelBuilder.Entity("api.Models.ConstitutionArticle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticleNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Chapter")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("ChapterNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("TitleNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ConstitutionArticle", (string)null);
                });

            modelBuilder.Entity("api.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AircraftPrefix")
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.Property<string[]>("Borders")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Currency")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<string>("CurrencyCode")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("CurrencySymbol")
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string[]>("Flags")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("ISOCode")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("InternetDomain")
                        .HasColumnType("text");

                    b.Property<string[]>("Languages")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("PhonePrefix")
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.Property<float>("Population")
                        .HasColumnType("real");

                    b.Property<string>("RadioPrefix")
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.Property<string>("Region")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("StateCapital")
                        .HasColumnType("text");

                    b.Property<string>("SubRegion")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<float>("Surface")
                        .HasColumnType("real");

                    b.Property<string>("TimeZone")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("Id");

                    b.ToTable("Country", (string)null);
                });

            modelBuilder.Entity("api.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CityCapitalId")
                        .HasColumnType("integer");

                    b.Property<int>("CityCapitalId1")
                        .HasColumnType("integer");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("Municipalities")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("PhonePrefix")
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.Property<float?>("Population")
                        .HasColumnType("real");

                    b.Property<int?>("RegionId")
                        .HasColumnType("integer");

                    b.Property<float>("Surface")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CityCapitalId1");

                    b.HasIndex("CountryId");

                    b.HasIndex("RegionId");

                    b.ToTable("Department", (string)null);
                });

            modelBuilder.Entity("api.Models.Holiday", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("Date");

                    b.ToTable("Holidays", (string)null);
                });

            modelBuilder.Entity("api.Models.IndigenousReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("AdministrativeActDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("AdministrativeActNumber")
                        .HasColumnType("integer");

                    b.Property<string>("AdministrativeActType")
                        .HasColumnType("text");

                    b.Property<int?>("CityId")
                        .HasColumnType("integer");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<int?>("DeparmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int?>("NativeCommunityId")
                        .HasColumnType("integer");

                    b.Property<string>("ProcedureType")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("DeparmentId");

                    b.HasIndex("NativeCommunityId");

                    b.ToTable("IndigenousReservation", (string)null);
                });

            modelBuilder.Entity("api.Models.InvasiveSpecie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CommonNames")
                        .HasColumnType("text");

                    b.Property<string>("Impact")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Manage")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<int>("RiskLevel")
                        .HasColumnType("integer");

                    b.Property<string>("ScientificName")
                        .HasColumnType("text");

                    b.Property<string>("UrlImage")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("InvasiveSpecie", (string)null);
                });

            modelBuilder.Entity("api.Models.Map", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string[]>("UrlImages")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("UrlSource")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Map", (string)null);
                });

            modelBuilder.Entity("api.Models.NativeCommunity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string[]>("Images")
                        .HasColumnType("text[]");

                    b.Property<string>("Languages")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.HasKey("Id");

                    b.ToTable("NativeCommunity", (string)null);
                });

            modelBuilder.Entity("api.Models.NaturalArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AreaGroupId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryNaturalAreaId")
                        .HasColumnType("integer");

                    b.Property<int?>("DaneCode")
                        .HasColumnType("integer");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<double?>("LandArea")
                        .HasColumnType("double precision");

                    b.Property<double?>("MaritimeArea")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryNaturalAreaId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("NaturalArea", (string)null);
                });

            modelBuilder.Entity("api.Models.President", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<int?>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateOnly?>("EndPeriodDate")
                        .HasColumnType("date");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("PoliticalParty")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("StartPeriodDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("President", (string)null);
                });

            modelBuilder.Entity("api.Models.Radio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Band")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<double>("Frequency")
                        .HasMaxLength(10000)
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string[]>("Streamers")
                        .HasColumnType("text[]");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Radio", (string)null);
                });

            modelBuilder.Entity("api.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("Id");

                    b.ToTable("Region", (string)null);
                });

            modelBuilder.Entity("api.Models.TouristAttraction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string[]>("Images")
                        .HasColumnType("text[]");

                    b.Property<string>("Latitude")
                        .HasColumnType("text");

                    b.Property<string>("Longitude")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("TouristAttraction", (string)null);
                });

            modelBuilder.Entity("api.Models.TypicalDish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("DepartmentId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("TypicalDish", (string)null);
                });

            modelBuilder.Entity("api.Models.Airport", b =>
                {
                    b.HasOne("api.Models.City", "City")
                        .WithMany("Airports")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Department", "Department")
                        .WithMany("Airports")
                        .HasForeignKey("DeparmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("api.Models.City", b =>
                {
                    b.HasOne("api.Models.Department", "Department")
                        .WithMany("Cities")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("api.Models.Department", b =>
                {
                    b.HasOne("api.Models.City", "CityCapital")
                        .WithMany()
                        .HasForeignKey("CityCapitalId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Country", "Country")
                        .WithMany("Departments")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Region", "Region")
                        .WithMany("Departments")
                        .HasForeignKey("RegionId");

                    b.Navigation("CityCapital");

                    b.Navigation("Country");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("api.Models.IndigenousReservation", b =>
                {
                    b.HasOne("api.Models.City", "City")
                        .WithMany("IndigenousReservations")
                        .HasForeignKey("CityId");

                    b.HasOne("api.Models.Department", "Department")
                        .WithMany("IndigenousReservations")
                        .HasForeignKey("DeparmentId");

                    b.HasOne("api.Models.NativeCommunity", "NativeCommunity")
                        .WithMany("IndigenousReservations")
                        .HasForeignKey("NativeCommunityId");

                    b.Navigation("City");

                    b.Navigation("Department");

                    b.Navigation("NativeCommunity");
                });

            modelBuilder.Entity("api.Models.Map", b =>
                {
                    b.HasOne("api.Models.Department", "Department")
                        .WithMany("Maps")
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("api.Models.NaturalArea", b =>
                {
                    b.HasOne("api.Models.CategoryNaturalArea", "CategoryNaturalArea")
                        .WithMany("NaturalAreas")
                        .HasForeignKey("CategoryNaturalAreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Department", "Department")
                        .WithMany("NaturalAreas")
                        .HasForeignKey("DepartmentId");

                    b.Navigation("CategoryNaturalArea");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("api.Models.President", b =>
                {
                    b.HasOne("api.Models.City", "City")
                        .WithMany("Presidents")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Country", null)
                        .WithMany("Presidents")
                        .HasForeignKey("CountryId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("api.Models.Radio", b =>
                {
                    b.HasOne("api.Models.City", "City")
                        .WithMany("Radios")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("api.Models.TouristAttraction", b =>
                {
                    b.HasOne("api.Models.City", "City")
                        .WithMany("TouristAttractions")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("api.Models.TypicalDish", b =>
                {
                    b.HasOne("api.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("api.Models.CategoryNaturalArea", b =>
                {
                    b.Navigation("NaturalAreas");
                });

            modelBuilder.Entity("api.Models.City", b =>
                {
                    b.Navigation("Airports");

                    b.Navigation("IndigenousReservations");

                    b.Navigation("Presidents");

                    b.Navigation("Radios");

                    b.Navigation("TouristAttractions");
                });

            modelBuilder.Entity("api.Models.Country", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Presidents");
                });

            modelBuilder.Entity("api.Models.Department", b =>
                {
                    b.Navigation("Airports");

                    b.Navigation("Cities");

                    b.Navigation("IndigenousReservations");

                    b.Navigation("Maps");

                    b.Navigation("NaturalAreas");
                });

            modelBuilder.Entity("api.Models.NativeCommunity", b =>
                {
                    b.Navigation("IndigenousReservations");
                });

            modelBuilder.Entity("api.Models.Region", b =>
                {
                    b.Navigation("Departments");
                });
#pragma warning restore 612, 618
        }
    }
}
