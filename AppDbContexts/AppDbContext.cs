using Assignment_02_EFC_.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_02_EFC_.AppDbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Organizer> Organizers => Set<Organizer>();
        public DbSet<OrganizerProfile> OrganizerProfiles => Set<OrganizerProfile>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<Attendee> Attendees => Set<Attendee>();
        public DbSet<Badge> Badges => Set<Badge>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=.; Database = EventHubDb; Trusted_Connection = True; TrustServerCertificate = True; MultipleActiveResultSets = true"
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Events");

                entity.Property(e => e.Title)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(e => e.Description)
                      .IsRequired()
                      .HasMaxLength(2000);

                entity.Property(e => e.StartDate)
                      .IsRequired();

                entity.Property(e => e.MaxAttendees)
                      .IsRequired();

                entity.HasOne(e => e.Organizer)
                      .WithMany(o => o.Events)
                      .HasForeignKey(e => e.OrganizerId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Badge>(entity =>
            {
                entity.ToTable("Badges");

                entity.Property(b => b.BadgeNumber)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.HasIndex(b => b.BadgeNumber)
                      .IsUnique();

                entity.Property(b => b.IssueDate)
                      .IsRequired();

                entity.Property(b => b.Tier)
                      .HasConversion<string>()
                      .IsRequired()
                      .HasMaxLength(20);

                entity.HasOne(b => b.Attendee)
                      .WithOne(a => a.Badge)
                      .HasForeignKey<Badge>(b => b.AttendeeId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(b => b.AttendeeId)
                      .IsUnique();
            });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        }
    }
}
