using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Net.Clinic.Domain.AggregateRoots.AppointmentAggregate;

namespace Net.Clinic.Infrastructure.Persistence.Configurations
{
    public class AppointmentEntityConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("appointments");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnOrder(0)
                .HasColumnName("id")
                .HasColumnType("integer")
                .UseIdentityAlwaysColumn()
                .IsRequired(true);

            builder.Property(e => e.DidAssist)
                .HasColumnOrder(1)
                .HasColumnName("did_assist")
                .HasColumnType("boolean")
                .HasDefaultValue(false)
                .IsRequired(true);

            builder.Property(e => e.DateSelected)
                .HasColumnOrder(2)
                .HasColumnName("date_selected")
                .HasColumnType("timestamp with time zone")
                .IsRequired(true);

            builder.OwnsOne(e => e.PatientName, patientName =>
            {
                patientName.Property(p => p.Value)
                .HasColumnOrder(3)
                .HasColumnName("patient_name")
                .HasColumnType("varchar(255)")
                .IsRequired(true);
            });

            builder.OwnsOne(e => e.Identification, identification =>
            {
                identification.Property(p => p.Value)
                .HasColumnOrder(4)
                .HasColumnName("identification")
                .HasColumnType("integer")
                .IsRequired(true);
            });
        }
    }
}