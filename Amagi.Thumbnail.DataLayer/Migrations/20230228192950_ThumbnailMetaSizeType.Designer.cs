﻿// <auto-generated />
using Amagi.Thumbnail.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Amagi.Thumbnail.DataLayer.Migrations
{
    [DbContext(typeof(AmagiContext))]
    [Migration("20230228192950_ThumbnailMetaSizeType")]
    partial class ThumbnailMetaSizeType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Amagi.Thumbnail.DataLayer.Models.Thumbnail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("ThumbnailImage")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("ThumbnailMetaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ThumbnailMetaId")
                        .IsUnique();

                    b.ToTable("Thumbnail");
                });

            modelBuilder.Entity("Amagi.Thumbnail.DataLayer.Models.ThumbnailMeta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<bool>("IsProcessed")
                        .HasColumnType("bit");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ThumbnailMeta");
                });

            modelBuilder.Entity("Amagi.Thumbnail.DataLayer.Models.Thumbnail", b =>
                {
                    b.HasOne("Amagi.Thumbnail.DataLayer.Models.ThumbnailMeta", "ThumbnailMeta")
                        .WithOne("Thumbnail")
                        .HasForeignKey("Amagi.Thumbnail.DataLayer.Models.Thumbnail", "ThumbnailMetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ThumbnailMeta");
                });

            modelBuilder.Entity("Amagi.Thumbnail.DataLayer.Models.ThumbnailMeta", b =>
                {
                    b.Navigation("Thumbnail");
                });
#pragma warning restore 612, 618
        }
    }
}
