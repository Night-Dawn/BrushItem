﻿// <auto-generated />
using System;
using BrushItem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BrushItem.Migrations
{
    [DbContext(typeof(BrushDbContext))]
    [Migration("20210805100421_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("BrushItem.Shared.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("category");
                });

            modelBuilder.Entity("BrushItem.Shared.Entities.Choice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasComment("题目编号");

                    b.Property<string>("Analysis")
                        .HasColumnType("longtext")
                        .HasComment("题目分析");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime(6)")
                        .HasComment("创建时间");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasComment("题目描述");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime(6)")
                        .HasComment("更新时间");

                    b.Property<string>("optionA")
                        .HasColumnType("longtext")
                        .HasComment("选项A");

                    b.Property<string>("optionB")
                        .HasColumnType("longtext")
                        .HasComment("选项B");

                    b.Property<string>("optionC")
                        .HasColumnType("longtext")
                        .HasComment("选项C");

                    b.Property<string>("optionD")
                        .HasColumnType("longtext")
                        .HasComment("选项D");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("choice");
                });

            modelBuilder.Entity("BrushItem.Shared.Entities.User", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.Property<string>("username")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("BrushItem.Shared.Entities.Choice", b =>
                {
                    b.HasOne("BrushItem.Shared.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
