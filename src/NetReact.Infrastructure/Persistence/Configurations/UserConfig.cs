﻿using NetReact.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetReact.Infrastructure.Persistence.Configurations
{
     public class UserConfig : IEntityTypeConfiguration<User>
     {
          public void Configure(EntityTypeBuilder<User> builder)
          {
               builder.HasIndex(x => x.Username)
                    .IsUnique();

               builder.Property(x => x.FirstName)
                    .HasMaxLength(100);

               builder.Property(x => x.LastName)
                    .HasMaxLength(100);
               
               builder.Property(x => x.Username)
                    .IsRequired()
                    .HasMaxLength(100);

               builder.HasMany(x => x.WishedBooks)
                    .WithMany(x => x.WishedBy)
                    .UsingEntity<Wishlist>(
                         x => x.HasOne(x => x.Book).WithMany().HasForeignKey(x => x.BookId),
                         x => x.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId)
                    );

               builder.HasMany(x => x.Posts)
                    .WithOne(x => x.PostedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull);

               builder.HasOne(x => x.UserContact)
                    .WithOne(x => x.User)
                    .OnDelete(DeleteBehavior.Cascade);

               builder.Property(x => x.RowVersion)
                    .IsRowVersion();
          }
     }
}
