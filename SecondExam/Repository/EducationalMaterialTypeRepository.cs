using Microsoft.EntityFrameworkCore;
using SecondExam.Entities;
using SecondExam.Repository.Contracts;

namespace SecondExam.Repository;

public class EducationalMaterialTypeRepository : RepositoryBase<EducationalMaterialType>, IEducationalMaterialTypeRepository
{
    public EducationalMaterialTypeRepository(RepositoryContext context) : base(context)
    {
    }

    public async Task<EducationalMaterialType> GetSingleAsync(int id)
    {
        return await GetByCondition(type => type.Id == id).SingleOrDefaultAsync();
    }
}
