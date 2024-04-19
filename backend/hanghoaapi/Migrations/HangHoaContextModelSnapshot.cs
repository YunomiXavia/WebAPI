﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hanghoaapi.Models;

#nullable disable

namespace hanghoaapi.Migrations
{
    [DbContext(typeof(HangHoaContext))]
    partial class HangHoaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("hanghoaapi.Models.HangHoa", b =>
                {
                    b.Property<string>("ma_hanghoa")
                        .HasMaxLength(9)
                        .HasColumnType("char(9)");

                    b.Property<string>("ghi_chu")
                        .HasColumnType("nvarchar(75)");

                    b.Property<int>("so_luong")
                        .HasColumnType("int");

                    b.Property<string>("ten_hanghoa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ma_hanghoa");

                    b.ToTable("HangHoas");
                });
#pragma warning restore 612, 618
        }
    }
}
