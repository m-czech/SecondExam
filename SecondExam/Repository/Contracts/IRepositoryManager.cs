namespace SecondExam.Repository.Contracts;

public interface IRepositoryManager
{
    public IEducationalMaterialRepository EducationalMaterial { get; }
    public EducationalMaterialReviewRepository Review { get; }

    public void Save();
}
