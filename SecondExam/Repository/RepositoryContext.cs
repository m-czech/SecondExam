using Microsoft.EntityFrameworkCore;
using SecondExam.Entities;

namespace SecondExam.Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    { }

    public DbSet<EducationalMaterial>? EducationalMaterials { get; set; }
    public DbSet<Author>? Authors { get; set; }
    public DbSet<EducationalMaterialReview>? Reviews { get; set; }
    public DbSet<EducationalMaterialType>? EducationalMaterialTypes { get; set; }
}
