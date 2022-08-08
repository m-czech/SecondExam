using SecondExam.Entities;

namespace SecondExam.Repository.Contracts;

public interface IEducationalMaterialRepository
{
    public void CreateEducationalMaterial(EducationalMaterial material);
}
