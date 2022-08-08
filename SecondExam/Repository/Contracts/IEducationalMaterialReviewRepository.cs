using SecondExam.Entities;
using System.Linq.Expressions;

namespace SecondExam.Repository.Contracts;

public interface IEducationalMaterialReviewRepository
{
    public void CreateEducationalMaterialReview(EducationalMaterialReview review);
    public void DeleteEducationalMaterialReview(EducationalMaterialReview review);
    public Task<EducationalMaterialReview> GetSingleAsync(int id);
    public Task<EducationalMaterialReview> GetSingleByConditionAsync(Expression<Func<EducationalMaterialReview, bool>> expression);
}
