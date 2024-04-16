﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hanghoaapi.Models;

#nullable disable

namespace hanghoaapi.Migrations
{
    [DbContext(typeof(HangHoaContext))]
    [Migration("20240416105504_Edid-Constrain#2")]
    partial class EdidConstrain2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("hanghoaapi.Models.HangHoa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("ghi_chu")
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("ma_hanghoa")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("char(9)");

                    b.Property<int>("so_luong")
                        .HasColumnType("int");

                    b.Property<string>("ten_hanghoa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("HangHoas");
                });
#pragma warning restore 612, 618
        }
    }
}
