using SecondExam.Entities;

namespace SecondExam.Repository.Contracts;

public interface IEducationalMaterialRepository
{
    public void CreateEducationalMaterial(EducationalMaterial material);
    public void DeleteEducationalMaterial(EducationalMaterial material);
    public Task<EducationalMaterial> GetSingleAsync(int id);
}
