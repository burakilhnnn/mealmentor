using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class MealPlanConfiguration : IEntityTypeConfiguration<MealPlan>
    {
        public void Configure(EntityTypeBuilder<MealPlan> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.ToTable("MealPlan");
        }
    }
    public class MealPlansConfiguration : IEntityTypeConfiguration<MealPlans>
    {
        public void Configure(EntityTypeBuilder<MealPlans> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.ToTable("MealPlans");
        }
    }
    public class MealRowConfiguration : IEntityTypeConfiguration<MealRow>
    {
        public void Configure(EntityTypeBuilder<MealRow> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.HasOne(x => x.MealPlans)
                .WithMany()
                .HasForeignKey(x => x.MealPlansId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("MealRows");
        }
    }
} 