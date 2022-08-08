using SecondExam.Entities;

namespace SecondExam.Repository.Contracts;

public interface IAuthorRepository
{
    public Task<Author> GetSingle(int id);
}
