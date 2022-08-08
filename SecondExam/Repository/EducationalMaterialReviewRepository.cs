using Microsoft.EntityFrameworkCore;
using SecondExam.Entities;
using SecondExam.Repository.Contracts;
using System.Linq.Expressions;

namespace SecondExam.Repository;

public class EducationalMaterialReviewRepository : RepositoryBase<EducationalMaterialReview>, IEducationalMaterialReviewRepository
{
    public EducationalMaterialReviewRepository(RepositoryContext _context) : base(_context)
    {
    }

    public void CreateEducationalMaterialReview(EducationalMaterialReview review)
    {
        Create(review);
    }

    public void DeleteEducationalMaterial(EducationalMaterialReview review)
    {
        Delete(review);
    }

    public async Task<EducationalMaterialReview> GetSingleAsync(int id)
    {
        return await GetSingleAsync(id);
    }

    public async Task<EducationalMaterialReview> GetSingleByCondition(Expression<Func<EducationalMaterialReview, bool>> expression)
    {
        return await GetByCondition(expression).SingleOrDefaultAsync();
    }
}
