﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using appcrud.Data;

#nullable disable

namespace appcrud.Migrations
{
    [DbContext(typeof(appcrudContext))]
    partial class appcrudContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("appcrud.Model.HangHoa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("ghi_chu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ma_hanghoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("so_luong")
                        .HasColumnType("int");

                    b.Property<string>("ten_hanghoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("HangHoa", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
