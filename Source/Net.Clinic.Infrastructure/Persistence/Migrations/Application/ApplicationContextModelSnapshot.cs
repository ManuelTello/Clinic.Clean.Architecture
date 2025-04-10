﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Net.Clinic.Infrastructure.Persistence.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Net.Clinic.Infrastructure.Persistence.Migrations.Application
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Net.Clinic.Domain.AggregateRoots.AppointmentAggregate.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateSelected")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_selected")
                        .HasColumnOrder(2);

                    b.Property<bool>("DidAssist")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("did_assist")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.ToTable("appointments", (string)null);
                });

            modelBuilder.Entity("Net.Clinic.Domain.AggregateRoots.AppointmentAggregate.Appointment", b =>
                {
                    b.OwnsOne("Net.Clinic.Domain.ObjectValues.Identification", "Identification", b1 =>
                        {
                            b1.Property<int>("AppointmentId")
                                .HasColumnType("integer");

                            b1.Property<int>("Value")
                                .HasColumnType("integer")
                                .HasColumnName("identification")
                                .HasColumnOrder(4);

                            b1.HasKey("AppointmentId");

                            b1.ToTable("appointments");

                            b1.WithOwner()
                                .HasForeignKey("AppointmentId");
                        });

                    b.OwnsOne("Net.Clinic.Domain.ObjectValues.PatientName", "PatientName", b1 =>
                        {
                            b1.Property<int>("AppointmentId")
                                .HasColumnType("integer");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("varchar(255)")
                                .HasColumnName("patient_name")
                                .HasColumnOrder(3);

                            b1.HasKey("AppointmentId");

                            b1.ToTable("appointments");

                            b1.WithOwner()
                                .HasForeignKey("AppointmentId");
                        });

                    b.Navigation("Identification")
                        .IsRequired();

                    b.Navigation("PatientName")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
