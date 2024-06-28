using Domain.Entities;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mapping;

public class LevelMapping : EntityTypeConfiguration<Level>
{

    /// <summary>
    /// Configures the entity
    /// </summary>
    /// <param name="builder">The builder to be used to configure the entity</param>
    /// <param name="entity"></param>
    public override void Configure(EntityTypeBuilder<Level> entity)
    {
        #region Configures
        entity.ToTable(nameof(Level), "public");

        entity.HasKey(qt => qt.Id);

        entity.Property(qt => qt.Name).IsRequired();


        entity.HasMany(qt => qt.Questions)
            .WithOne(q => q.Level)
            .HasForeignKey(q => q.LevelId);
        
        entity.Property(_ => _.IsDeleted).IsRequired().HasDefaultValue(false);
        entity.Property(_ => _.CreatedById).IsRequired();
        entity.Property(_ => _.CreatedByName).IsRequired().HasMaxLength(256);
        entity.Property(_ => _.CreatedDateTime).IsRequired();
        entity.Property(_ => _.UpdateById).IsRequired(false);
        entity.Property(_ => _.UpdatedByName).IsRequired(false).HasMaxLength(256);
        entity.Property(_ => _.UpdatedTime).IsRequired(false);
        
        #endregion
        
        #region Seeding data
        #endregion

        base.Configure(entity);
    }
}