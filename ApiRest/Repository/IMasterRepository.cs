namespace ApiRest.Repository;

public interface IMasterRepository<TEntity> 
    where TEntity : class
{
    Task<List<TEntity>> GetAll();
    Task<TEntity?> GetById(long id);
    Task<TEntity> Add(TEntity model);
    Task<TEntity> Update(TEntity model);
    Task Delete(long id);
}