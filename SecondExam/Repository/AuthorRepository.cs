using Microsoft.EntityFrameworkCore;
using SecondExam.Entities;
using SecondExam.Repository.Contracts;

namespace SecondExam.Repository;

public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
{
    public AuthorRepository(RepositoryContext context) : base(context)
    {

    }
    public async Task<Author> GetSingle(int id)
    {
        return await GetByCondition(author => author.Id == id)
            .Include(author => author.Materials)
            .SingleOrDefaultAsync();
    }
}
