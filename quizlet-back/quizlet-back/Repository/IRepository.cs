using System.Collections;

namespace quizlet_back.Repository
{
    public interface IRepository<T>
    {
        // CRUD operations
        Task<bool> Create(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
        Task<int> DeleteById(int entityId);
        // queries
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(int id);
    }
}
