﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Website.Models;
namespace Shopping_Website.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Description).HasColumnType("nvarchar(100)");
            builder.Property(p => p.RoleName).HasColumnType("nvarchar(100)");

        }
    }
}
