using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mapping;

public class QuestionMapping : EntityTypeConfiguration<Question>
{

    /// <summary>
    /// Configures the entity
    /// </summary>
    /// <param name="builder">The builder to be used to configure the entity</param>
    /// <param name="entity"></param>
    public override void Configure(EntityTypeBuilder<Question> entity)
    {
        #region Configures
        entity.ToTable(nameof(Question), "public");

        entity.HasKey(q => q.Id);

        entity.Property(q => q.Title).IsRequired();

        entity.Property(q => q.RightAnswer);

        entity.Property(q => q.AnswerChoice);

        entity.HasOne(q => q.QuestionType)
            .WithMany(qt => qt.Questions)
            .HasForeignKey(q => q.QuestionTypeId);
        
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