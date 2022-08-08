namespace SecondExam.Repository.Contracts;

public interface IRepositoryManager
{
    public IEducationalMaterialRepository EducationalMaterial { get; }
    public IEducationalMaterialReviewRepository Review { get; }

    public void Save();
}
