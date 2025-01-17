﻿using NetReact.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetReact.Infrastructure.Persistence.Configurations
{
     public class CategoryConfig : IEntityTypeConfiguration<Category>
     {
          public void Configure(EntityTypeBuilder<Category> builder)
          {
               builder.Property(x => x.Name)
                    .IsRequired();
          }
     }
}
