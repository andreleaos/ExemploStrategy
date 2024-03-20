namespace ExemploStrategy.Domain.Interfaces;
public interface IBaseRepoService<T, Y> where T : class
{
    void Create(T entity);
    void Update(T entity);
    void Delete(Y id);
    List<T> GetAll();
    T GetById(Y id);
}
