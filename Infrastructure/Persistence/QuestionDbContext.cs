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
        optionsBuilder.UseNpgsql("User ID=koffee;Password=koffee;Host=103.166.182.81;Port=5432;Database=question_service;Pooling=true;Minimum Pool Size=0;Maximum Pool Size=200;Timeout=60;Application Name=ExamBank");
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