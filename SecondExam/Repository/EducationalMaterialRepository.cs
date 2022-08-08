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
        Create(material);
    }
}
