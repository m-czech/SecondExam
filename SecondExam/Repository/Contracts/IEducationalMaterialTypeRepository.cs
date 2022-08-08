using SecondExam.Entities;

namespace SecondExam.Repository.Contracts;

public interface IEducationalMaterialTypeRepository
{
    public Task<EducationalMaterialType> GetSingleAsync(int id);
}
