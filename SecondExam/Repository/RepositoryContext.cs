using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecondExam.Entities;
using SecondExam.Entities.Authorization;

namespace SecondExam.Repository;

public class RepositoryContext : IdentityDbContext<User>
{
    public RepositoryContext(DbContextOptions options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "user",
                NormalizedName = "USER"
            }
        );
    }

    public DbSet<EducationalMaterial>? EducationalMaterials { get; set; }
    public DbSet<Author>? Authors { get; set; }
    public DbSet<EducationalMaterialReview>? Reviews { get; set; }
    public DbSet<EducationalMaterialType>? EducationalMaterialTypes { get; set; }
}
