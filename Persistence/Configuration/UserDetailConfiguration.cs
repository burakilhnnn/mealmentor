using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class UserDetailConfiguration : IEntityTypeConfiguration<UserDetail>
    {
        public void Configure(EntityTypeBuilder<UserDetail>builder){

            builder.HasKey(x=> x.UserId);

            builder.Property(x=>x.UserId)
            .IsRequired();

            builder.ToTable("UserDetails");
        }
    }
}