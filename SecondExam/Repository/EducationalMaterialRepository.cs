using Microsoft.EntityFrameworkCore;
using SecondExam.DTOs.EducationalMaterial;
using SecondExam.Entities;
using SecondExam.Repository.Contracts;

namespace SecondExam.Repository;

public class EducationalMaterialRepository : RepositoryBase<EducationalMaterial>, IEducationalMaterialRepository
{
    public EducationalMaterialRepository(RepositoryContext context) : base(context)
    {
    }

    public void CreateEducationalMaterial(EducationalMaterial material)
    {
        material.PublicationDate = DateTime.Now;
        Create(material);
    }
    public void DeleteEducationalMaterial(EducationalMaterial material)
    {
        Delete(material);
    }

    public async Task<IEnumerable<EducationalMaterial>> GetAllAsync()
    {
        return await GetAll()
            .Include(material => material.Reviews)
            .ToListAsync();
    }

    public async Task<EducationalMaterial> GetSingleAsync(int id)
    {
        return await GetByCondition(material => material.EducationalMaterialTypeId == id)
            .Include(material => material.Reviews)
            .SingleOrDefaultAsync();
    }

}
