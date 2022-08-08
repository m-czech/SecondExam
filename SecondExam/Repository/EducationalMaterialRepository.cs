using SecondExam.Repository.Contracts;

namespace SecondExam.Repository;

public class EducationalMaterialRepository : RepositoryBase<EducationalMaterialRepository>, IEducationalMaterialRepository
{
    public EducationalMaterialRepository(RepositoryContext context) : base(context)
    {
    }
}
