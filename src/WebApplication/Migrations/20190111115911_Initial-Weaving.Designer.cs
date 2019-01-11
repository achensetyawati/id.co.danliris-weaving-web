﻿// <auto-generated />
using System;
using DanLiris.Admin.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DanLiris.Admin.Web.Migrations
{
    [DbContext(typeof(AppStorageContext))]
    [Migration("20190111115911_Initial-Weaving")]
    partial class InitialWeaving
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Manufactures.Domain.Orders.ReadModels.WeavingOrderDocumentReadModel", b =>
                {
                    b.Property<Guid>("Identity")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Composition")
                        .HasMaxLength(255);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<DateTimeOffset>("DateOrdered");

                    b.Property<bool?>("Deleted");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(32);

                    b.Property<DateTimeOffset?>("DeletedDate");

                    b.Property<string>("FabricConstructionDocument")
                        .HasMaxLength(255);

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(32);

                    b.Property<DateTimeOffset?>("ModifiedDate");

                    b.Property<string>("OrderNumber");

                    b.Property<string>("Period")
                        .HasMaxLength(255);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("WarpOrigin");

                    b.Property<string>("WeavingUnit")
                        .HasMaxLength(255);

                    b.Property<string>("WeftOrigin");

                    b.Property<int>("WholeGrade");

                    b.Property<string>("YarnType");

                    b.HasKey("Identity");

                    b.ToTable("WeavingOrderDocuments");
                });
#pragma warning restore 612, 618
        }
    }
}
