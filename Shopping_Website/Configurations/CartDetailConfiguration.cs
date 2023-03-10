﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping_Website.Models;
namespace Shopping_Website.Configurations
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(p=>p.Cart).WithMany(p=>p.Details).
                HasForeignKey(p=>p.UserId);
            builder.HasOne(p => p.Product).WithMany(p => p.CartDetails).
                HasForeignKey(p => p.IdSp);
        }
    }
}
