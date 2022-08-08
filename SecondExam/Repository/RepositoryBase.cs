using SecondExam.Repository.Contracts;
using System.Linq.Expressions;

namespace SecondExam.Repository;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected RepositoryContext _context;
    public RepositoryBase(RepositoryContext context)
    {
        _context = context;
    }
    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
    }
    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>();
    }

    public IQueryable<T> GetByCondition(Expression<Func<T, bool>> condition)
    {
        return _context.Set<T>().Where(condition);
    }

}
