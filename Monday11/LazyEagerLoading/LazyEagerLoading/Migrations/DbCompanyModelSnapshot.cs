﻿// <auto-generated />
using LazyEagerLoading.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LazyEagerLoading.Migrations
{
    [DbContext(typeof(DbCompany))]
    partial class DbCompanyModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LazyEagerLoading.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("company");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyName = "TCS"
                        },
                        new
                        {
                            Id = 2,
                            CompanyName = "Nimap"
                        },
                        new
                        {
                            Id = 3,
                            CompanyName = "Fyntune"
                        },
                        new
                        {
                            Id = 4,
                            CompanyName = "IDZ Digital"
                        });
                });

            modelBuilder.Entity("LazyEagerLoading.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("EmpName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("employee");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 1,
                            EmpName = "Swapnil"
                        },
                        new
                        {
                            Id = 2,
                            CompanyId = 1,
                            EmpName = "Mayur"
                        },
                        new
                        {
                            Id = 3,
                            CompanyId = 1,
                            EmpName = "Omkar"
                        },
                        new
                        {
                            Id = 4,
                            CompanyId = 2,
                            EmpName = "Omkar"
                        },
                        new
                        {
                            Id = 5,
                            CompanyId = 2,
                            EmpName = "Bhavesh"
                        },
                        new
                        {
                            Id = 6,
                            CompanyId = 2,
                            EmpName = "Jitesh Sir"
                        },
                        new
                        {
                            Id = 7,
                            CompanyId = 3,
                            EmpName = "Deepak"
                        },
                        new
                        {
                            Id = 8,
                            CompanyId = 3,
                            EmpName = "Vinay"
                        },
                        new
                        {
                            Id = 9,
                            CompanyId = 3,
                            EmpName = "Rahul"
                        },
                        new
                        {
                            Id = 10,
                            CompanyId = 4,
                            EmpName = "Yash"
                        },
                        new
                        {
                            Id = 11,
                            CompanyId = 4,
                            EmpName = "Rohit"
                        },
                        new
                        {
                            Id = 12,
                            CompanyId = 4,
                            EmpName = "Virat"
                        });
                });

            modelBuilder.Entity("LazyEagerLoading.Models.Employee", b =>
                {
                    b.HasOne("LazyEagerLoading.Models.Company", "company")
                        .WithMany("Emp")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("company");
                });

            modelBuilder.Entity("LazyEagerLoading.Models.Company", b =>
                {
                    b.Navigation("Emp");
                });
#pragma warning restore 612, 618
        }
    }
}
