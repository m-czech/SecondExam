using SecondExam.Repository.Contracts;

namespace SecondExam.Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;
    public IEducationalMaterialRepository EducationalMaterial { get; }

    public IEducationalMaterialReviewRepository Review { get; }
    public IEducationalMaterialTypeRepository EducationalMaterialType { get; }
    public IAuthorRepository Author { get; }

    public RepositoryManager(RepositoryContext context)
    {
        _context = context;
        EducationalMaterial = new EducationalMaterialRepository(_context);
        Review = new EducationalMaterialReviewRepository(_context);
        EducationalMaterialType = new EducationalMaterialTypeRepository(_context);
        Author = new AuthorRepository(_context);
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();
}
