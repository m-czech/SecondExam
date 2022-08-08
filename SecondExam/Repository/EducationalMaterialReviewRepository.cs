using SecondExam.Entities;
using SecondExam.Repository.Contracts;

namespace SecondExam.Repository;

public class EducationalMaterialReviewRepository : RepositoryBase<EducationalMaterialReview>, IEducationalMaterialReviewRepository
{
    public EducationalMaterialReviewRepository(RepositoryContext _context) : base(_context)
    {
    }
   
}
