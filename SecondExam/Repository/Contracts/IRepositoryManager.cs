namespace SecondExam.Repository.Contracts;

public interface IRepositoryManager
{
    public IEducationalMaterialRepository EducationalMaterial { get; }
    public IEducationalMaterialReviewRepository Review { get; }
    public IEducationalMaterialTypeRepository EducationalMaterialType { get; }
    public IAuthorRepository Author { get; }

    public Task SaveAsync();
}
