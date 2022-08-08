using SecondExam.Repository.Contracts;

namespace SecondExam.Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;
    public IEducationalMaterialRepository EducationalMaterial { get; }

    public EducationalMaterialReviewRepository Review { get; }

    public RepositoryManager(RepositoryContext context)
    {
        _context = context;
        EducationalMaterial = new EducationalMaterialRepository(_context);
        Review = new EducationalMaterialReviewRepository(_context);
    }

    public void Save() => _context.SaveChanges();
}
