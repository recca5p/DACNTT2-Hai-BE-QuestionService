using System.Reflection;
using Contract.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class QuestionDbContext : DbContext, IQuestionDbContext
{
    public QuestionDbContext()
    {

    }
    
    public QuestionDbContext(DbContextOptions<QuestionDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
        if(!string.IsNullOrEmpty(connectionString))
        {
            optionsBuilder.UseNpgsql(connectionString);
        }
        optionsBuilder.UseNpgsql("");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //dynamically load all entity and query type configurations
        var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
            (type.BaseType?.IsGenericType ?? false)
            && (type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)));

        foreach (var typeConfiguration in typeConfigurations)
        {
            var configuration = (IMappingConfiguration)Activator.CreateInstance(typeConfiguration)!;
            configuration.ApplyConfiguration(modelBuilder);
        }

        base.OnModelCreating(modelBuilder);
    }
}