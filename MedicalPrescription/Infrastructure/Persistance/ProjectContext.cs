using Domain.Entities.Patients;
using Domain.Entities.PatientValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistance;

public class ProjectContext : DbContext
{
    public ProjectContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Patient> Patients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>(builder =>
        {
            builder.Property(p => p.PatientId)
                .HasConversion(
                    id => id.Value,
                    value => new PatientId(value)
                )
                .IsRequired();
            
            builder.OwnsOne(e => e.FirstName, firstName =>
            {
                firstName.Property(e => e.FirstName)
                    .HasColumnName("FirstName")
                    .HasMaxLength(200)
                    .IsRequired();
            });

            builder.OwnsOne(e => e.LastName, lastName =>
            {
                lastName.Property(e => e.LastName)
                    .HasColumnName("LastName")
                    .HasMaxLength(200)
                    .IsRequired();
            });

            builder.OwnsOne(e => e.Pesel, pesel =>
            {
                pesel.Property(e => e.Pesel)
                    .HasColumnName("Pesel")
                    .HasMaxLength(11)
                    .IsRequired();
            });

            builder.OwnsOne(e => e.PhoneNumber, phoneNumber =>
            {
                phoneNumber.Property(e => e.PhoneNumber)
                    .HasColumnName("PhoneNumber")
                    .HasMaxLength(20)
                    .IsRequired();
            });
            
            builder.OwnsOne(p => p.EmailAddress, email =>
            {
                email.Property(e => e.EmailAddress)
                    .HasColumnName("EmailAddress")
                    .HasMaxLength(200)
                    .IsRequired();
            });
            
            
        });

    }
}