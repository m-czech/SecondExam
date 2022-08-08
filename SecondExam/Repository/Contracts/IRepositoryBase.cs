namespace SecondExam.Repository.Contracts;

public interface IRepositoryBase<T>
{
    public IQueryable<T> GetAll();
    IQueryable<T> GetByCondition(Func<T, bool> condition);
    public void Create(T entity);
    public void Update(T entity);
    public void Delete(T entity);
}
