using Assignment_02_EFC_.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_02_EFC_.Configurations
{
    public class OrganizerProfileConfiguration : IEntityTypeConfiguration<OrganizerProfile>
    {
        public void Configure(EntityTypeBuilder<OrganizerProfile> builder)
        {
            builder.ToTable("OrganizerProfiles");

            builder.Property(p => p.Biography).HasMaxLength(1000);

            builder.Property(p => p.WebsiteUrl).HasMaxLength(300);

            builder.Property(p => p.LogoUrl).HasMaxLength(500);


            builder.HasOne(p => p.Organizer)
                   .WithOne(o => o.Profile)
                   .HasForeignKey<OrganizerProfile>(p => p.OrganizerId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.HasIndex(p => p.OrganizerId).IsUnique();
        }
    }
}
