using Domain.Entities.Addresses;
using Domain.Entities.Addresses.AddressValueObjects;
using Domain.Entities.Patients;
using Domain.Entities.Patients.PatientValueObjects;
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
    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Patient>()
            .Property(p => p.PatientId)
            .HasConversion(id => id.PatientIdValue, v => new PatientId(v));

        modelBuilder.Entity<Address>()
            .Property(a => a.AddressId)
            .HasConversion(id => id.AddressIdValue, v => new AddressId(v));

        modelBuilder.Entity<Address>()
            .Property(a => a.PatientId)
            .HasConversion(e=> e.PatientIdValue ,  e=> new PatientId(e));

        
        modelBuilder.Entity<Address>()
            .HasOne(a => a.Patient)
            .WithOne(p => p.Address)
            .HasForeignKey<Address>(a => a.PatientId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Address>()
            .HasIndex(a => a.PatientId).IsUnique();

        
        
        modelBuilder.Entity<Patient>(builder =>
        {
            
            builder.Property(p => p.PatientId)
                .HasConversion(
                    id => id.PatientIdValue,
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


        modelBuilder.Entity<Address>(builder =>
        {
            builder.HasKey(e => e.AddressId);
            
            
            builder.Property(a => a.AddressId)
                .HasConversion(id => id.AddressIdValue, value => new AddressId(value))
                .IsRequired();


            builder.OwnsOne(e => e.Street, street =>
            {
                street.Property(e => e.StreetName)
                    .HasColumnName("StreetName")
                    .HasMaxLength(50)
                    .IsRequired();
            });

            builder.OwnsOne(e => e.City, city =>
            {
                city.Property(e => e.CityName)
                    .HasColumnName("CityName")
                    .HasMaxLength(50)
                    .IsRequired();
            });


            builder.OwnsOne(p => p.PostalCode, postalCode =>
            {
                postalCode.Property(e => e.PostalCodeName)
                    .HasColumnName("PostalCode")
                    .HasMaxLength(6)
                    .IsRequired();
            });
            
            
        });


    }
}